using desafio_picpay_simplificado.domain.Interfaces.repositories;
using desafio_picpay_simplificado.domain.Interfaces.services;
using desafio_picpay_simplificado.domain.model.DTO.Transaction;
using desafio_picpay_simplificado.domain.model.DTO.Transaction.request;
using desafio_picpay_simplificado.domain.model.DTO.Transaction.response;
using desafio_picpay_simplificado.domain.model.Entity;
using desafio_picpay_simplificado.domain.model.Enum;
using desafio_picpay_simplificado.domain.ResultPattern;
using desafio_picpay_simplificado.Mapper;
using Microsoft.EntityFrameworkCore.Storage;

namespace desafio_picpay_simplificado.application.Services.Transactions;

public class TransactionsService(
    IWalletRepository wallet,
    ITransactionsRepository transactions,
    IAuthorizeTransactionService authorize,
    IInvoiceRepository invoice
) : ITransactionsService
{
    public async Task<Result<TransactionResponseDTO>> ExecuteAsync(TransactionRequestDTO request)
    {
        if (!await authorize.AuthorizeAsync())
            return Result<TransactionResponseDTO>.Failed("Not authorized");

        var payer = await wallet.GetById(request.sender_id);
        var receive = await wallet.GetById(request.receive_id);
        if (payer is null || receive is null)
            return Result<TransactionResponseDTO>.Failed("Payer and Receive cannot be null");
        if (payer.wallet_amount < request.amount || payer.wallet_amount == 0)
            return Result<TransactionResponseDTO>.Failed("Balance insufficient");
        if (payer is { types: TypeOfUsers.Logists })
            return Result<TransactionResponseDTO>.Failed("Payer cannot be logists");
        payer.Payment(request.amount);
        receive.Receive(request.amount);
        var entity = new TransactionEntity(payer.id, receive.id, request.amount);
        await using (var scope = await transactions.BeginTransactionAsync())
        {
            try
            {
                await ExecuteInParallelAsync(payer, receive, entity);
                await CommitTransactionAsync(scope);
            }
            catch (Exception e)
            {
                await RollbackTransactionAsync(scope);
                return Result<TransactionResponseDTO>.Failed("Rollback on payment" + e.Message);
            }
        }

        await invoice.GenerateAsync(entity);
        await invoice.CommitAsync();
        return Result<TransactionResponseDTO>.Success(entity.ToTransactionDTO());
    }

    private async Task RollbackTransactionAsync(IDbContextTransaction scope)
        => await scope.RollbackAsync();

    private async Task CommitTransactionAsync(IDbContextTransaction scope)
    {
        await transactions.CommitAsync();
        await scope.CommitAsync();
    }

    private async Task ExecuteInParallelAsync(WalletEntity payer, WalletEntity receive, TransactionEntity entity)
    {
        var tasks = new List<Task>()
        {
            wallet.UpdateAsync(payer),
            wallet.UpdateAsync(receive),
            transactions.AddTransactionAsync(entity)
        };
        await Task.WhenAll(tasks);
    }
}
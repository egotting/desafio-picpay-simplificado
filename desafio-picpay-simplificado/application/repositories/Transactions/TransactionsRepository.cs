using desafio_picpay_simplificado.domain.data.Context;
using desafio_picpay_simplificado.domain.Interfaces.repositories;
using desafio_picpay_simplificado.domain.model.Entity;
using Microsoft.EntityFrameworkCore.Storage;

namespace desafio_picpay_simplificado.application.repositories.Transactions;

public class TransactionsRepository(DataContext context) : ITransactionsRepository
{
    public async Task AddTransactionAsync(TransactionEntity entity)
        => await context.Transaction.AddAsync(entity);

    public async Task CommitAsync()
        => await context.SaveChangesAsync();

    public async Task<IDbContextTransaction> BeginTransactionAsync()
        => await context.Database.BeginTransactionAsync();
}
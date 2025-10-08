using desafio_picpay_simplificado.domain.Interfaces.repositories;
using desafio_picpay_simplificado.domain.Interfaces.services;
using desafio_picpay_simplificado.domain.model.DTO.Wallet.Request;
using desafio_picpay_simplificado.domain.ResultPattern;
using desafio_picpay_simplificado.Mapper;

namespace desafio_picpay_simplificado.Application.Services.Wallet;

public class WalletService(IWalletRepository repository) : IWalletService
{
    public async Task<Result<bool>> ExecuteAsync(WalletRequestDTO request)
    {
        var response = await repository.GetByEmailOrCpfCnpj(request.email, request.cpf_cnpj);

        if (response is not null)
            return Result<bool>.Failed("Wallet exists");

        var convert = request.ToWalletEntity();
        await repository.PostAsync(convert);
        await repository.CommitAsync();
        return Result<bool>.Success(true);
    }
}
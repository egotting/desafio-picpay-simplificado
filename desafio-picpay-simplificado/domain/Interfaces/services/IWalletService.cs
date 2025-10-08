using desafio_picpay_simplificado.domain.model.DTO.Wallet.Request;
using desafio_picpay_simplificado.domain.ResultPattern;

namespace desafio_picpay_simplificado.domain.Interfaces.services;

public interface IWalletService
{
    Task<Result<bool>> ExecuteAsync(WalletRequestDTO request);
}
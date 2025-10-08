using desafio_picpay_simplificado.domain.model.Entity;

namespace desafio_picpay_simplificado.domain.Interfaces.repositories;

public interface IWalletRepository
{
    Task PostAsync(WalletEntity entity);
    Task UpdateAsync(WalletEntity entity);
    Task<WalletEntity?> GetByEmailOrCpfCnpj(string email, string cpf_cnpj);
    Task<WalletEntity?> GetById(long id);
    Task CommitAsync();
}
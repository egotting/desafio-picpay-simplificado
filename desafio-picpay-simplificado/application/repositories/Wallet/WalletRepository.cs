using desafio_picpay_simplificado.domain.data.Context;
using desafio_picpay_simplificado.domain.Interfaces.repositories;
using desafio_picpay_simplificado.domain.model.Entity;
using desafio_picpay_simplificado.domain.model.Type;
using desafio_picpay_simplificado.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace desafio_picpay_simplificado.Application.repositories;

public class WalletRepository(DataContext context) : IWalletRepository
{
    public async Task PostAsync(WalletEntity entity)
        => await context.Wallet.AddAsync(entity);

    public async Task UpdateAsync(WalletEntity entity)
        => context.Update(entity);

    public async Task CommitAsync()
        => await context.SaveChangesAsync();

    public async Task<WalletEntity?> GetById(long id)
        => await context.Wallet.FindAsync(id);

    public async Task<WalletEntity?> GetByEmailOrCpfCnpj(string email, string cpf_cnpj)
        => await context.Wallet
            .FirstOrDefaultAsync(w => w.email.Equals(email) || w.cpf_cnpj.Equals(cpf_cnpj));
}
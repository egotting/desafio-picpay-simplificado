using desafio_picpay_simplificado.domain.model.Entity;
using Microsoft.EntityFrameworkCore.Storage;

namespace desafio_picpay_simplificado.domain.Interfaces.repositories;

public interface ITransactionsRepository
{
    Task AddTransactionAsync(TransactionEntity entity);
    Task CommitAsync();
    Task<IDbContextTransaction> BeginTransactionAsync();
}
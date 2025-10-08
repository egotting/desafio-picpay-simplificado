using desafio_picpay_simplificado.domain.model.DTO.Invoice.Response;
using desafio_picpay_simplificado.domain.model.Entity;

namespace desafio_picpay_simplificado.domain.Interfaces.repositories;

public interface IInvoiceRepository
{
    Task GenerateAsync(TransactionEntity entity);

    Task CommitAsync();
}
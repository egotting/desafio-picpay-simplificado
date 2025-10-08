using System.Text;
using desafio_picpay_simplificado.domain.data.Context;
using desafio_picpay_simplificado.domain.Interfaces.repositories;
using desafio_picpay_simplificado.domain.model.DTO.Invoice.Response;
using desafio_picpay_simplificado.domain.model.Entity;

namespace desafio_picpay_simplificado.application.repositories.Invoice;

public class InvoiceRepository(DataContext context) : IInvoiceRepository
{
    public async Task GenerateAsync(TransactionEntity entity)
    {
        var folder_path = Path.Combine(Directory.GetCurrentDirectory(), "invoices");
        Directory.CreateDirectory(folder_path);
        var file_name = $"invoice_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        var file_path = Path.Combine(folder_path, file_name);
        var invoice = new InvoiceEntity(
            entity.id,
            entity.payer.fullname,
            entity.payee.fullname,
            entity.amount,
            DateTime.UtcNow);
        var content = $"""
                       Date: {invoice.date_immitted}
                       Transaction: {invoice.transaction_id}
                       Sender: {invoice.sender_fullname}
                       Receiver: {invoice.receive_fullname}
                       Value: R$ {invoice.amount}
                       """;
        await File.WriteAllTextAsync(file_path, content, Encoding.UTF8);
    }

    public Task CommitAsync()
        => context.SaveChangesAsync();
}
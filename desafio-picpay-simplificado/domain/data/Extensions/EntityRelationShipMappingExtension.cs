using desafio_picpay_simplificado.domain.model.Entity;
using Microsoft.EntityFrameworkCore;

namespace desafio_picpay_simplificado.domain.data.Extensions;

public static class EntityRelationShipMappingExtension
{
    public static ModelBuilder ConfigureRelationShipTransaction(this ModelBuilder builder)
    {
        builder.Entity<TransactionEntity>()
            .HasOne(t => t.payer)
            .WithMany()
            .HasForeignKey(t => t.payerId)
            .OnDelete(DeleteBehavior.Cascade);
        return builder;
    }

    public static ModelBuilder ConfigureRelationShipNF(this ModelBuilder builder)
    {
        builder.Entity<InvoiceEntity>()
            .HasOne(t => t.transaction)
            .WithMany()
            .HasForeignKey(t => t.transaction_id)
            .OnDelete(DeleteBehavior.Cascade);
        return builder;
    }
}
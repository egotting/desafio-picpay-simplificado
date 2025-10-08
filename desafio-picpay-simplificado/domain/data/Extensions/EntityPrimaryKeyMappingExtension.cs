using desafio_picpay_simplificado.domain.model.Entity;
using Microsoft.EntityFrameworkCore;

namespace desafio_picpay_simplificado.domain.data.Extensions;

public static class EntityPrimaryKeyMappingExtension
{
    public static ModelBuilder ConfigurePrimaryKeyWallet(this ModelBuilder builder)
    {
        builder.Entity<WalletEntity>()
            .HasKey(w => w.id);
        return builder;
    }

    public static ModelBuilder ConfigurePrimaryKeyTransaction(this ModelBuilder builder)
    {
        builder.Entity<TransactionEntity>()
            .HasKey(w => w.id);
        return builder;
    }

    public static ModelBuilder ConfigurePrimaryKeyNF(this ModelBuilder builder)
    {
        builder.Entity<InvoiceEntity>()
            .HasKey(w => w.id);
        return builder;
    }
}
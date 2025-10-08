using desafio_picpay_simplificado.domain.model.Entity;
using desafio_picpay_simplificado.domain.model.Type;
using Microsoft.EntityFrameworkCore;

namespace desafio_picpay_simplificado.domain.data.Extensions;

public static class EntityConvertMappingExtension
{
    public static ModelBuilder ConfigureEntityConvertWallet(this ModelBuilder builder)
    {
        builder.Entity<WalletEntity>(entity =>
        {
            entity.Property(e => e.cpf_cnpj)
                .HasConversion(
                    v => v.ToString(),
                    v => new CpfCnpj(v));
            entity.Property(t => t.types)
                .HasConversion<string>();

            entity.Property(w => w.wallet_amount)
                .HasColumnType("decimal(18, 2)");
        });

        return builder;
    }

    public static ModelBuilder ConfigureEntityConvertTransaction(this ModelBuilder builder)
    {
        builder.Entity<TransactionEntity>(entity =>
        {
            entity.Property(w => w.amount)
                .HasColumnType("decimal(18, 2)");
        });
        return builder;
    }

    public static ModelBuilder ConfigureEntityConvertNF(this ModelBuilder builder)
    {
        builder.Entity<InvoiceEntity>(entity =>
        {
            entity.Property(w => w.amount)
                .HasColumnType("decimal(18, 2)");
        });
        return builder;
    }
}
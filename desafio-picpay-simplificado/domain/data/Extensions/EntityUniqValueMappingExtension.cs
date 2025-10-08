using desafio_picpay_simplificado.domain.model.Entity;
using Microsoft.EntityFrameworkCore;

namespace desafio_picpay_simplificado.domain.data.Extensions;

public static class EntityUniqValueMappingExtension
{
    public static ModelBuilder ConfigureUniqValueWallet(this ModelBuilder builder)
    {
        builder.Entity<WalletEntity>()
            .HasIndex(w => new { w.cpf_cnpj, w.email })
            .IsUnique();
        return builder;
    }
}
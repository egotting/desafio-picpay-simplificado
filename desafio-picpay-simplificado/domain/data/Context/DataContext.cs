using desafio_picpay_simplificado.domain.data.Extensions;
using desafio_picpay_simplificado.domain.model.Entity;
using Microsoft.EntityFrameworkCore;

namespace desafio_picpay_simplificado.domain.data.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<WalletEntity> Wallet { get; set; }
    public DbSet<TransactionEntity> Transaction { get; set; }
    public DbSet<InvoiceEntity> Invoice { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // wallet
        builder.ConfigurePrimaryKeyWallet();
        builder.ConfigureUniqValueWallet();
        builder.ConfigureEntityConvertWallet();

        // transaction
        builder.ConfigurePrimaryKeyTransaction();
        builder.ConfigureRelationShipTransaction();
        builder.ConfigureEntityConvertTransaction();

        // Invoice
        builder.ConfigurePrimaryKeyNF();
        builder.ConfigureRelationShipNF();
        builder.ConfigureEntityConvertNF();
    }
}
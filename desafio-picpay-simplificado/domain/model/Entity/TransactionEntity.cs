namespace desafio_picpay_simplificado.domain.model.Entity;

public class TransactionEntity
{
    private TransactionEntity()
    {
    }

    public TransactionEntity(long payerId, long payeeId, decimal amount)
    {
        this.payerId = payerId;
        this.payeeId = payeeId;
        this.amount = amount;
    }

    public Guid id { get; set; } = Guid.NewGuid();
    public long payerId { get; set; }
    public WalletEntity payer { get; set; }
    public long payeeId { get; set; }
    public WalletEntity payee { get; set; }
    public decimal amount { get; set; }
}
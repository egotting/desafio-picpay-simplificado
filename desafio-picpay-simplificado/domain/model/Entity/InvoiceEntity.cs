namespace desafio_picpay_simplificado.domain.model.Entity;

public class InvoiceEntity
{
    public InvoiceEntity()
    {
    }

    public InvoiceEntity(
        Guid transactionId,
        string senderFullname,
        string receiveFullname,
        decimal amount,
        DateTime date_immitted)
    {
        transaction_id = transactionId;
        sender_fullname = senderFullname;
        receive_fullname = receiveFullname;
        this.amount = amount;
        this.date_immitted = date_immitted;
    }

    public long id { get; private set; }
    public Guid transaction_id { get; private set; }
    public DateTime date_immitted { get; private set; }
    public TransactionEntity transaction { get; private set; }
    public string sender_fullname { get; private set; }
    public string receive_fullname { get; private set; }
    public decimal amount { get; private set; }
}
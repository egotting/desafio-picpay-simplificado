using desafio_picpay_simplificado.domain.model.Enum;
using desafio_picpay_simplificado.domain.model.Type;

namespace desafio_picpay_simplificado.domain.model.Entity;

public class WalletEntity
{
    private WalletEntity()
    {
    }

    public WalletEntity(
        string fullname,
        CpfCnpj cpf_cnpj,
        string email,
        string password,
        decimal wallet_amount,
        TypeOfUsers types)
    {
        this.fullname = fullname;
        this.cpf_cnpj = cpf_cnpj;
        this.email = email;
        this.password = password;
        this.wallet_amount = wallet_amount;
        this.types = types;
    }

    public long id { get; set; }
    public string fullname { get; set; }
    public CpfCnpj cpf_cnpj { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public decimal wallet_amount { get; set; }

    public TypeOfUsers types { get; set; }

    public void Payment(decimal value)
    {
        wallet_amount -= value;
    }

    public void Receive(decimal amount)
    {
        wallet_amount += amount;
    }
}
namespace desafio_picpay_simplificado.domain.Interfaces.services;

public interface IAuthorizeTransactionService
{
    Task<bool> AuthorizeAsync();
}
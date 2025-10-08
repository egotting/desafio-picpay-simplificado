using desafio_picpay_simplificado.domain.model.DTO.Transaction;
using desafio_picpay_simplificado.domain.model.DTO.Transaction.request;
using desafio_picpay_simplificado.domain.model.DTO.Transaction.response;
using desafio_picpay_simplificado.domain.ResultPattern;

namespace desafio_picpay_simplificado.domain.Interfaces.services;

public interface ITransactionsService
{
    Task<Result<TransactionResponseDTO>> ExecuteAsync(TransactionRequestDTO request);
}
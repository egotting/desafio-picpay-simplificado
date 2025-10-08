using desafio_picpay_simplificado.domain.model.DTO.Transaction.response;
using desafio_picpay_simplificado.domain.model.Entity;

namespace desafio_picpay_simplificado.Mapper;

public static class TransactionsDTOMapper
{
    public static TransactionResponseDTO ToTransactionDTO(this TransactionEntity entity)
    {
        return new TransactionResponseDTO(
            entity.payer.fullname,
            entity.payee.fullname,
            entity.amount,
            DateTime.UtcNow
        );
    }
}
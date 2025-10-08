namespace desafio_picpay_simplificado.domain.model.DTO.Transaction.request;

public record TransactionRequestDTO(long sender_id, long receive_id, decimal amount);
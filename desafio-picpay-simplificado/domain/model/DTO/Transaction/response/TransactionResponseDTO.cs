namespace desafio_picpay_simplificado.domain.model.DTO.Transaction.response;

public record TransactionResponseDTO(
    string fullname_sender,
    string fullname_receive,
    decimal amount,
    DateTime date_transaction);
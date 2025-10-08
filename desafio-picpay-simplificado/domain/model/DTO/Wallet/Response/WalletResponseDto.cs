namespace desafio_picpay_simplificado.domain.model.DTO.Wallet.Response;

public record WalletResponseDto(
    string sender_fullname,
    string receive_fullname,
    string cpf_cnpj,
    decimal amount);
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using desafio_picpay_simplificado.domain.model.Enum;
using desafio_picpay_simplificado.domain.model.Type;

namespace desafio_picpay_simplificado.domain.model.DTO.Wallet.Request;

public record WalletRequestDTO(
    [MaxLength(40)] string fullname,
    string cpf_cnpj,
    [EmailAddress] string email,
    [MaxLength(12), MinLength(4)] string password,
    decimal balance,
    TypeOfUsers type
);
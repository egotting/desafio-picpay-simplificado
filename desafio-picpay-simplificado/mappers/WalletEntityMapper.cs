using desafio_picpay_simplificado.domain.model.DTO.Wallet.Request;
using desafio_picpay_simplificado.domain.model.Entity;

namespace desafio_picpay_simplificado.Mapper;

public static class WalletEntityMapper
{
    public static WalletEntity ToWalletEntity(this WalletRequestDTO entity)
    {
        return new WalletEntity(
            entity.fullname,
            entity.cpf_cnpj,
            entity.email,
            entity.password,
            entity.balance,
            entity.type
        );
    }
}
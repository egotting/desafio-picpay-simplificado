using desafio_picpay_simplificado.Application.repositories;
using desafio_picpay_simplificado.application.repositories.Invoice;
using desafio_picpay_simplificado.application.repositories.Transactions;
using desafio_picpay_simplificado.application.Services.Authorize;
using desafio_picpay_simplificado.application.Services.Transactions;
using desafio_picpay_simplificado.Application.Services.Wallet;
using desafio_picpay_simplificado.domain.Interfaces.repositories;
using desafio_picpay_simplificado.domain.Interfaces.services;

namespace desafio_picpay_simplificado.IoC;

public static class DependencyInjectionRegister
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped<IWalletRepository, WalletRepository>();
        services.AddScoped<ITransactionsRepository, TransactionsRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        return services;
    }

    public static IServiceCollection InjectServices(this IServiceCollection services)
    {
        services.AddScoped<IWalletService, WalletService>();
        services.AddScoped<ITransactionsService, TransactionsService>();
        return services;
    }

    public static IServiceCollection InjectHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient<IAuthorizeTransactionService, AuthorizeTransactionService>();
        return services;
    }
}
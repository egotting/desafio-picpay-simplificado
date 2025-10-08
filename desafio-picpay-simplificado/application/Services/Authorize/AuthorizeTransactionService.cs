using System.Text.Json;
using desafio_picpay_simplificado.domain.Interfaces.services;
using desafio_picpay_simplificado.domain.ResultPattern;

namespace desafio_picpay_simplificado.application.Services.Authorize;

public class AuthorizeTransactionService(HttpClient client) : IAuthorizeTransactionService
{
    private const string uri = "https://util.devi.tools/api/v2/authorize";

    public async Task<bool> AuthorizeAsync()
    {
        var body = string.Empty;
        var response = await client.GetAsync(uri);
        if (!response.IsSuccessStatusCode)
            return false;
        response.EnsureSuccessStatusCode();
        body = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ApiResponse>(body);

        return result?.status == "success";
    }


    private class ApiResponse()
    {
        public string status { get; set; }
        public DataResponse data { get; set; }
    }

    private record DataResponse()
    {
        public bool authorize { get; set; }
    }
}
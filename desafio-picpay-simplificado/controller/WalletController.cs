using desafio_picpay_simplificado.domain.Interfaces.services;
using desafio_picpay_simplificado.domain.model.DTO.Wallet.Request;
using Microsoft.AspNetCore.Mvc;

namespace desafio_picpay_simplificado.controller;

[ApiController]
[Route("wallet")]
public class WalletController(IWalletService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] WalletRequestDTO request)
    {
        var result = await service.ExecuteAsync(request);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Created();
    }
}
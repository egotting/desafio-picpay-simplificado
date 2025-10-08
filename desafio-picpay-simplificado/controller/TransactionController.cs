using System.Net.Mime;
using desafio_picpay_simplificado.domain.Interfaces.services;
using desafio_picpay_simplificado.domain.model.DTO.Transaction;
using desafio_picpay_simplificado.domain.model.DTO.Transaction.request;
using desafio_picpay_simplificado.domain.model.DTO.Transaction.response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace desafio_picpay_simplificado.controller;

[ApiController]
[Route("transactions")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class TransactionController(ITransactionsService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] TransactionRequestDTO request)
    {
        var response = await service.ExecuteAsync(request);
        if (!response.IsSuccess)
            return BadRequest();
        return Ok(response);
    }
}
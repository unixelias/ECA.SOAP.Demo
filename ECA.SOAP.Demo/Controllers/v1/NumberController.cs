using ECA.SOAP.Demo.Models;
using ECA.SOAP.Demo.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ECA.SOAP.Demo.Controllers.v1;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class NumberController : Controller
{
    private ILogger<NumberController> _logger { get; set; }
    private readonly IDataAccessRepository _dataAccessRepository;
    public NumberController(
        IDataAccessRepository dataAccessRepository,
        ILogger<NumberController> logger
        )
    {
        _dataAccessRepository = dataAccessRepository;
        _logger = logger;
    }
    [HttpGet]
    [Route("full-name/{number}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(NumberFullNameModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetNumberInFullName([FromRoute] double number)
    {
        try
        {
            var retorno = await _dataAccessRepository.GetFulNameByNumber(number);
            _logger.LogInformation("Entrada: {entrada}; Saída: {saida}", number, retorno.Body.NumberToWordsResponse.NumberToWordsResult);
            return Ok(retorno.GetModel(number));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao executar: {ex.Message}; {ex.StackTrace}");
            return StatusCode((int)HttpStatusCode.InternalServerError, ex);
        }

    }

    [HttpGet]
    [Route("dollars/{number}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(NumberToDollarsModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetNumberToDollars([FromRoute] double number)
    {
        try
        {
            var retorno = await _dataAccessRepository.GetDollarsFromNumber(number);
            _logger.LogInformation("Entrada: {entrada}; Saída: {saida}", number, retorno.Body.NumberToDollarsResponse.NumberToDollarsResult);
            return Ok(retorno.GetModel(number));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao executar: {ex.Message}; {ex.StackTrace}");
            return StatusCode((int)HttpStatusCode.InternalServerError, ex);
        }

    }
}
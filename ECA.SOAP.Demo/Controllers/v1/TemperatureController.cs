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
public class TemperatureController : Controller
{
    private readonly ILogger<TemperatureController> _logger;
    private readonly IW3cTemperatureRepository _w3cTemperatureRepository;
    public TemperatureController(
        IW3cTemperatureRepository w3cTemperatureRepository,
        ILogger<TemperatureController> logger
        )
    {
        _w3cTemperatureRepository = w3cTemperatureRepository;
        _logger = logger;
    }
    [HttpGet]
    [Route("celsius-fahrenheit/{number}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CelsiusToFahrenheitModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetNumberInFullName([FromRoute] int number)
    {
        try
        {
            var retorno = await _w3cTemperatureRepository.ConvertGetFulNameByNumber(number);
            _logger.LogInformation($"Entrada: {number}; Saída: {retorno.Body.CelsiusToFahrenheitResponse.CelsiusToFahrenheitResult}");
            return Ok(retorno.GetModel(number));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao executar: {ex.Message}; {ex.StackTrace}");
            return StatusCode((int)HttpStatusCode.InternalServerError, ex);
        }

    }
}
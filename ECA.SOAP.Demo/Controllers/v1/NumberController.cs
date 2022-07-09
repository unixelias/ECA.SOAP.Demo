using ECA.SOAP.Demo.Models;
using ECA.SOAP.Demo.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static ECA.SOAP.Demo.Entities.NumberToWordsResponseEntity;

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
    [Route("FullName/{number}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(NumberFullNameModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetNumberInFullName([FromRoute] int number)
    {
        var retorno = await _dataAccessRepository.GetFulNameByNumber(number);
        _logger.LogInformation($"Entrada: {number}; Saída: {retorno}");
        return Ok(retorno.GetModel(number));
    }
}
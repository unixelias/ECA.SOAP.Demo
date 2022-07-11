using ECA.SOAP.Demo.Entities;
using ECA.SOAP.Demo.Repository.Interface;
using ECA.SOAP.Demo.Util;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using static ECA.SOAP.Demo.Entities.CelsiusToFahrenheitEntity;
using static ECA.SOAP.Demo.Entities.CelsiusToFahrenheitResponseEntity;

namespace ECA.SOAP.Demo.Repository
{
    public class W3cTemperatureRepository : BaseRepository, IW3cTemperatureRepository
    {
        protected override sealed string ApiUrl => ConfigParams.Get().W3SchoolsApi.BaseUrl;
        protected override sealed string ApiName => ConfigParams.Get().W3SchoolsApi.Name;

        private const string TEMPERATURE_CONVERSION_ROUTE = "/tempconvert.asmx";
        private const string CONTENT_TYPE = "application/soap+xml; charset=utf-8";

        public W3cTemperatureRepository(
            IHttpClientFactory clientFactory,
            ILogger<W3cTemperatureRepository> logger) : base(clientFactory, logger)
        {
        }

        public async Task<CelsiusToFahrenheitResponseXmlEntity> ConvertGetFulNameByNumber(int number)
        {
            CelsiusToFahrenheitXmlEntity degreesXml = new()
            {
                Body = new CelsiusToFahrenheitEntity.Body()
                {
                    CelsiusToFahrenheit = new CelsiusToFahrenheit()
                    {
                        Celsius = number
                    }
                }
            };

            string bodyString = ObjectXmlToString(degreesXml, CelsiusToFahrenheitXmlEntity.Xmlns);
            var body = new StringContent(bodyString);
            string retorno = await CallApiSoapAsync(body, TEMPERATURE_CONVERSION_ROUTE, CONTENT_TYPE);
            CelsiusToFahrenheitResponseXmlEntity resposta = retorno.DeserializarXml<CelsiusToFahrenheitResponseXmlEntity>();

            return resposta;
        }
    }
}
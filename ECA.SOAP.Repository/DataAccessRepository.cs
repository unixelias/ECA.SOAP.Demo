using ECA.SOAP.Demo.Entities;
using ECA.SOAP.Demo.Repository.Interface;
using ECA.SOAP.Demo.Util;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using static ECA.SOAP.Demo.Entities.NumberToDollarsEntity;
using static ECA.SOAP.Demo.Entities.NumberToDollarsResponseEntity;
using static ECA.SOAP.Demo.Entities.NumberToWordsEntity;
using static ECA.SOAP.Demo.Entities.NumberToWordsResponseEntity;

namespace ECA.SOAP.Demo.Repository
{
    public class DataAccessRepository : BaseRepository, IDataAccessRepository
    {
        protected override sealed string ApiUrl => ConfigParams.Get().DataAccessApi.BaseUrl;
        protected override sealed string ApiName => ConfigParams.Get().DataAccessApi.Name;

        private const string NUMBER_CONVERSION_ROUTE = "/NumberConversion.wso";
        private const string CONTENT_TYPE = "text/xml; charset=utf-8";

        public DataAccessRepository(
            IHttpClientFactory clientFactory,
            ILogger<DataAccessRepository> logger) : base(clientFactory, logger)
        {
        }

        public async Task<NumberToWordsResponseXmlEntity> GetFulNameByNumber(double number)
        {
            NumberToWordsXmlEntity numberXml = new()
            {
                Body = new NumberToWordsEntity.Body()
                {
                    NumberToWords = new NumberToWords()
                    {
                        UbiNum = number
                    }
                }
            };

            string bodyString = ObjectXmlToString(numberXml, NumberToWordsXmlEntity.Xmlns);
            Logger.LogInformation("Conteudo enviado via SOAP:\n {bodyString}", bodyString);
            var body = new StringContent(bodyString);
            string retorno = await CallApiSoapAsync(body, NUMBER_CONVERSION_ROUTE, CONTENT_TYPE);
            Logger.LogInformation("Resposta recebida via SOAP:\n {retorno}", retorno);
            NumberToWordsResponseXmlEntity resposta = retorno.DeserializarXml<NumberToWordsResponseXmlEntity>();

            return resposta;
        }

        public async Task<NumberToDollarsResponseXmlEntity> GetDollarsFromNumber(double number)
        {
            NumberToDollarsXmlEntity numberXml = new()
            {
                Body = new NumberToDollarsEntity.Body()
                {
                    NumberToDollars = new NumberToDollars()
                    {
                        DNum = number
                    }
                }
            };

            string bodyString = ObjectXmlToString(numberXml, NumberToDollarsXmlEntity.Xmlns);
            Logger.LogInformation("Conteudo enviado via SOAP:\n {bodyString}", bodyString);
            var body = new StringContent(bodyString);
            string retorno = await CallApiSoapAsync(body, NUMBER_CONVERSION_ROUTE, CONTENT_TYPE);
            Logger.LogInformation("Resposta recebida via SOAP:\n {retorno}", retorno);
            NumberToDollarsResponseXmlEntity resposta = retorno.DeserializarXml<NumberToDollarsResponseXmlEntity>();

            return resposta;
        }
    }
}
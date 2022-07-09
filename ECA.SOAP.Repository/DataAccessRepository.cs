using ECA.SOAP.Demo.Entities;
using ECA.SOAP.Demo.Repository.Interface;
using ECA.SOAP.Demo.Util;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using static ECA.SOAP.Demo.Entities.NumberToWordsEntity;
using static ECA.SOAP.Demo.Entities.NumberToWordsResponseEntity;

namespace ECA.SOAP.Demo.Repository
{
    public class DataAccessRepository : BaseRepository, IDataAccessRepository
    {
        protected override sealed string ApiUrl => ConfigParams.Get().DataAccessApi.BaseUrl;
        protected override sealed string ApiName => ConfigParams.Get().DataAccessApi.Name;
        public DataAccessRepository(
            IHttpClientFactory clientFactory,
            ILogger<DataAccessRepository> logger) : base(clientFactory, logger)
        {
        }

        public async Task<NumberToWordsResponseXmlEntity> GetFulNameByNumber(int number)
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
            var body = new StringContent(bodyString);
            string retorno = await CallApiSoapAsync(body, "/NumberConversion.wso", "text/xml; charset=utf-8");
            NumberToWordsResponseXmlEntity resposta = retorno.DeserializarXml<NumberToWordsResponseXmlEntity>();

            return resposta;
        }
    }
}
using System.Threading.Tasks;
using static ECA.SOAP.Demo.Entities.CelsiusToFahrenheitResponseEntity;

namespace ECA.SOAP.Demo.Repository.Interface
{
    public interface IW3cTemperatureRepository
    {
        Task<CelsiusToFahrenheitResponseXmlEntity> ConvertGetFulNameByNumber(int number);
    }
}
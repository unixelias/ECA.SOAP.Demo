using System.Threading.Tasks;
using static ECA.SOAP.Demo.Entities.CelsiusToFahrenheitResponseEntity;
using static ECA.SOAP.Demo.Entities.FahrenheitToCelsiusResponseEntity;

namespace ECA.SOAP.Demo.Repository.Interface
{
    public interface IW3cTemperatureRepository
    {
        Task<CelsiusToFahrenheitResponseXmlEntity> ConvertCelsiusToFahrenheit(double number);

        Task<FahrenheitToCelsiusResponseXmlEntity> ConvertFahrenheitToCelsius(double number);
    }
}
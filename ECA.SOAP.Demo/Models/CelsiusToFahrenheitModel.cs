using System.Text.Json.Serialization;
using static ECA.SOAP.Demo.Entities.CelsiusToFahrenheitResponseEntity;

namespace ECA.SOAP.Demo.Models;

public class CelsiusToFahrenheitModel
{
    [JsonPropertyName("fahrenheit-degree")]
    public int FahrenheitDegree { get; set; }
    [JsonPropertyName("celsius-input")]
    public int CelsiusInput { get; set; }
}


public static class CelsiusToFahrenheitModelExtension
{
    public static CelsiusToFahrenheitModel GetModel(this CelsiusToFahrenheitResponseXmlEntity entity, int numberInput)
    {
        if (entity == null)
        {
            return null;
        }

        return new CelsiusToFahrenheitModel()
        {
            FahrenheitDegree = entity.Body.CelsiusToFahrenheitResponse.CelsiusToFahrenheitResult,
            CelsiusInput = numberInput
        };
    }
}
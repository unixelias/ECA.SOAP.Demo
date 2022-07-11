using System.Text.Json.Serialization;
using static ECA.SOAP.Demo.Entities.FahrenheitToCelsiusResponseEntity;

namespace ECA.SOAP.Demo.Models;

public class FahrenheitToCelsiusModel
{
    [JsonPropertyName("celsius-degree")]
    public double CelsiusDegree { get; set; }
    [JsonPropertyName("fahrenheit-input")]
    public double FahrenheitInput { get; set; }
}


public static class FahrenheitToCelsiusModelExtension
{
    public static FahrenheitToCelsiusModel GetModel(this FahrenheitToCelsiusResponseXmlEntity entity, double numberInput)
    {
        if (entity == null)
        {
            return null;
        }

        return new FahrenheitToCelsiusModel()
        {
            CelsiusDegree = entity.Body.FahrenheitToCelsiusResponse.FahrenheitToCelsiusResult,
            FahrenheitInput = numberInput
        };
    }
}
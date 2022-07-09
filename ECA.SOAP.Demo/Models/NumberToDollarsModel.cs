using System.Text.Json.Serialization;
using static ECA.SOAP.Demo.Entities.NumberToDollarsResponseEntity;

namespace ECA.SOAP.Demo.Models;

public class NumberToDollarsModel
{
    [JsonPropertyName("full-value")]
    public string FullValue { get; set; }

    [JsonPropertyName("number")]
    public double Number { get; set; }
}

public static class NumberToDollarsModelExtension
{
    public static NumberToDollarsModel GetModel(this NumberToDollarsResponseXmlEntity entity, double numberInput)
    {
        if (entity == null)
        {
            return null;
        }

        return new NumberToDollarsModel()
        {
            FullValue = entity.Body.NumberToDollarsResponse.NumberToDollarsResult,
            Number = numberInput
        };
    }
}
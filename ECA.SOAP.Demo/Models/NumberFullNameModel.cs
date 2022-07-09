using System.Text.Json.Serialization;
using static ECA.SOAP.Demo.Entities.NumberToWordsResponseEntity;

namespace ECA.SOAP.Demo.Models;

public class NumberFullNameModel
{
    [JsonPropertyName("full-name")]
    public string FullName { get; set; }
    [JsonPropertyName("number")]
    public int Number { get; set; }
}


public static class NumberFullNameModelExtension
{
    public static NumberFullNameModel GetModel(this NumberToWordsResponseXmlEntity entity, int numberInput)
    {
        if (entity == null)
        {
            return null;
        }

        return new NumberFullNameModel()
        {
            FullName = entity.Body.NumberToWordsResponse.NumberToWordsResult,
            Number = numberInput
        };
    }
}
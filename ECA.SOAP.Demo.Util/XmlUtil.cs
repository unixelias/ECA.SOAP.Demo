using System.IO;
using System.Xml.Serialization;

namespace ECA.SOAP.Demo.Util;

public static class XmlUtil
{
    public static T DeserializarXml<T>(this string xml)
    {
        XmlSerializer serializador = new(typeof(T));
        using StringReader leitor = new(xml);
        return (T)serializador.Deserialize(leitor);
    }

    public static string SerializeObject<T>(this T toSerialize)
    {
        if (toSerialize is null)
        {
            return default;
        }
        XmlSerializer xmlSerializer = new(toSerialize.GetType());

        using StringWriter textWriter = new Utf8StringWriter();
        xmlSerializer.Serialize(textWriter, toSerialize);
        return textWriter.ToString();
    }
}
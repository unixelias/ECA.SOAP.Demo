using System.Xml.Serialization;

namespace ECA.SOAP.Demo.Entities;

public class NumberToWordsResponseEntity
{
    private const string Soap = "http://schemas.xmlsoap.org/soap/envelope/";
    private const string DataAccess = "http://www.dataaccess.com/webservicesserver/";

    [XmlType(IncludeInSchema = true)]
    [XmlRoot("Envelope", Namespace = Soap)]
    public class NumberToWordsResponseXmlEntity
    {
        public Body Body { get; set; }

        public NumberToWordsResponseXmlEntity()
        {
            Xmlns.Add("soap", Soap);
            Xmlns.Add("m", DataAccess);
        }

        [XmlNamespaceDeclarations]
        public static XmlSerializerNamespaces Xmlns { get; } = new XmlSerializerNamespaces();
    }

    [XmlType(Namespace = "")]
    public class Body
    {
        [XmlElement(ElementName = "NumberToWordsResponse", Namespace = DataAccess)]
        public NumberToWordsResponse NumberToWordsResponse { get; set; }
    }

    [XmlType(Namespace = "")]
    public class NumberToWordsResponse
    {
        [XmlElement(ElementName = "NumberToWordsResult", Namespace = DataAccess)]
        public string NumberToWordsResult { get; set; }
    }
}
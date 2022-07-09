using System.Xml.Serialization;

namespace ECA.SOAP.Demo.Entities;

public class NumberToDollarsResponseEntity
{
    private const string Soap = "http://schemas.xmlsoap.org/soap/envelope/";
    private const string DataAccess = "http://www.dataaccess.com/webservicesserver/";

    [XmlType(IncludeInSchema = true)]
    [XmlRoot("Envelope", Namespace = Soap)]
    public class NumberToDollarsResponseXmlEntity
    {
        public Body Body { get; set; }

        public NumberToDollarsResponseXmlEntity()
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
        [XmlElement(ElementName = "NumberToDollarsResponse", Namespace = DataAccess)]
        public NumberToDollarsResponse NumberToDollarsResponse { get; set; }
    }

    [XmlType(Namespace = "")]
    public class NumberToDollarsResponse
    {
        [XmlElement(ElementName = "NumberToDollarsResult", Namespace = DataAccess)]
        public string NumberToDollarsResult { get; set; }
    }
}
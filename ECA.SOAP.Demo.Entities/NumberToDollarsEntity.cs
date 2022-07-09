using System.Xml.Serialization;

namespace ECA.SOAP.Demo.Entities;

public class NumberToDollarsEntity
{
    private const string Soap = "http://schemas.xmlsoap.org/soap/envelope/";
    private const string DataAccess = "http://www.dataaccess.com/webservicesserver/";

    [XmlType(IncludeInSchema = true)]
    [XmlRoot("Envelope", Namespace = Soap)]
    public class NumberToDollarsXmlEntity
    {
        public Body Body { get; set; }

        public NumberToDollarsXmlEntity()
        {
            Xmlns.Add("soap", Soap);
            Xmlns.Add("dataAccess", DataAccess);
        }

        [XmlNamespaceDeclarations]
        public static XmlSerializerNamespaces Xmlns { get; } = new XmlSerializerNamespaces();
    }

    [XmlType(Namespace = "")]
    public class Body
    {
        [XmlElement(ElementName = "NumberToDollars", Namespace = DataAccess)]
        public NumberToDollars NumberToDollars { get; set; }
    }

    [XmlType(Namespace = "")]
    public class NumberToDollars
    {
        [XmlElement(ElementName = "dNum", Namespace = "")]
        public double DNum { get; set; }
    }
}
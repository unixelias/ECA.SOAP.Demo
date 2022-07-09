using System.Xml.Serialization;

namespace ECA.SOAP.Demo.Entities;

public class NumberToWordsEntity
{
    private const string Soap = "http://schemas.xmlsoap.org/soap/envelope/";
    private const string DataAccess = "http://www.dataaccess.com/webservicesserver/";

    [XmlType(IncludeInSchema = true)]
    [XmlRoot("Envelope", Namespace = Soap)]
    public class NumberToWordsXmlEntity
    {
        public Body Body { get; set; }

        public NumberToWordsXmlEntity()
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
        [XmlElement(ElementName = "NumberToWords", Namespace = "http://www.dataaccess.com/webservicesserver/")]
        public NumberToWords NumberToWords { get; set; }
    }

    [XmlType(Namespace = "")]
    public class NumberToWords
    {
        [XmlElement(ElementName = "ubiNum", Namespace = "")]
        public int UbiNum { get; set; }
    }
}
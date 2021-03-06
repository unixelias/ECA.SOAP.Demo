using System.Xml.Serialization;

namespace ECA.SOAP.Demo.Entities;

public class FahrenheitToCelsiusResponseEntity
{
    private const string Soap12 = "http://www.w3.org/2003/05/soap-envelope";
    private const string Xsd = "http://www.w3.org/2001/XMLSchema";
    private const string XSI= "http://www.w3.org/2001/XMLSchema-instance";
    private const string W3sns = "https://www.w3schools.com/xml/";

    [XmlType(IncludeInSchema = true)]
    [XmlRoot("Envelope", Namespace = Soap12)]
    public class FahrenheitToCelsiusResponseXmlEntity
    {
        public Body Body { get; set; }

        public FahrenheitToCelsiusResponseXmlEntity()
        {
            Xmlns.Add("soap12", Soap12);
            Xmlns.Add("xsd", Xsd);
            Xmlns.Add("xsi", XSI);
        }

        [XmlNamespaceDeclarations]
        public static XmlSerializerNamespaces Xmlns { get; } = new XmlSerializerNamespaces();
    }

    [XmlType(Namespace = Soap12)]
    public class Body
    {
        [XmlElement(ElementName = "FahrenheitToCelsiusResponse", Namespace = W3sns)]
        public FahrenheitToCelsiusResponse FahrenheitToCelsiusResponse { get; set; }
    }

    [XmlType(Namespace = "")]
    public class FahrenheitToCelsiusResponse
    {
        [XmlElement(ElementName = "FahrenheitToCelsiusResult", Namespace = W3sns)]
        public double FahrenheitToCelsiusResult { get; set; }
    }
}
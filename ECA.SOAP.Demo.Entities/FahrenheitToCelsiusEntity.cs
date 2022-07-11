using System.Xml.Serialization;

namespace ECA.SOAP.Demo.Entities;

public class FahrenheitToCelsiusEntity
{
    private const string Soap12 = "http://www.w3.org/2003/05/soap-envelope";
    private const string Xsd = "http://www.w3.org/2001/XMLSchema";
    private const string XSI= "http://www.w3.org/2001/XMLSchema-instance";
    private const string W3sns = "https://www.w3schools.com/xml/";

    [XmlType(IncludeInSchema = true)]
    [XmlRoot("Envelope", Namespace = Soap12)]
    public class FahrenheitToCelsiusXmlEntity
    {
        public Body Body { get; set; }

        public FahrenheitToCelsiusXmlEntity()
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
        [XmlElement(ElementName = "FahrenheitToCelsius", Namespace = W3sns)]
        public FahrenheitToCelsius FahrenheitToCelsius { get; set; }
    }

    [XmlType(Namespace = "")]
    public class FahrenheitToCelsius
    {
        [XmlElement(ElementName = "Fahrenheit", Namespace = W3sns)]
        public double Fahrenheit { get; set; }
    }
}
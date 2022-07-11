using System.Xml.Serialization;

namespace ECA.SOAP.Demo.Entities;

public class CelsiusToFahrenheitResponseEntity
{
    private const string Soap12 = "http://www.w3.org/2003/05/soap-envelope";
    private const string Xsd = "http://www.w3.org/2001/XMLSchema";
    private const string XSI= "http://www.w3.org/2001/XMLSchema-instance";
    private const string W3sns = "https://www.w3schools.com/xml/";

    [XmlType(IncludeInSchema = true)]
    [XmlRoot("Envelope", Namespace = Soap12)]
    public class CelsiusToFahrenheitResponseXmlEntity
    {
        public Body Body { get; set; }

        public CelsiusToFahrenheitResponseXmlEntity()
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
        [XmlElement(ElementName = "CelsiusToFahrenheitResponse", Namespace = W3sns)]
        public CelsiusToFahrenheitResponse CelsiusToFahrenheitResponse { get; set; }
    }

    [XmlType(Namespace = "")]
    public class CelsiusToFahrenheitResponse
    {
        [XmlElement(ElementName = "CelsiusToFahrenheitResult", Namespace = W3sns)]
        public double CelsiusToFahrenheitResult { get; set; }
    }
}
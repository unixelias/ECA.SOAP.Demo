using System.IO;
using System.Text;

namespace ECA.SOAP.Demo.Util;

public class Utf8StringWriter : StringWriter
{
    public override Encoding Encoding => Encoding.UTF8;
}
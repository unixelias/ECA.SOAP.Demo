using ECA.SOAP.Demo.Entities.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ECA.SOAP.Demo.Repository;

public abstract class BaseRepository
{
    #region Properties

    protected abstract string ApiUrl { get; }
    protected abstract string ApiName { get; }

    private readonly IHttpClientFactory _clientFactory;
    protected readonly ILogger<BaseRepository> Logger;

    #endregion Properties

    #region Constructor

    protected BaseRepository(
        IHttpClientFactory clientFactory,
        ILogger<BaseRepository> logger
        )
    {
        _clientFactory = clientFactory;
        Logger = logger;
    }

    #endregion Constructor

    #region Methods

    protected async Task<string> CallApiSoapAsync(StringContent body, string rota = null, string contentType = null)
    {
        using HttpRequestMessage requisicao = new (HttpMethod.Post, ApiUrl + rota)
        {
            Content = body
        };
        requisicao.Content.Headers.TryAddWithoutValidation("Content-Type", contentType);
        return await ExecuteApiCallAsync(requisicao);
    }

    protected async Task<string> ExecuteApiCallAsync(HttpRequestMessage requestMessage)
    {
        using HttpClient client = _clientFactory.CreateClient(ApiName);
        try
        {
            HttpResponseMessage resposta = await client.SendAsync(requestMessage);

            if (resposta.IsSuccessStatusCode)
            {
                return await resposta.Content.ReadAsStringAsync();
            }
            throw new SoapException($"Resposta da api sem sucesso!: {await resposta.Content.ReadAsStringAsync()}");
        }
        catch (SoapException ex)
        {
            throw new SoapException(ex.Message);
        }
        catch (Exception e)
        {
            throw new SoapException($"Falha ao se comunicar com a API:  {e.Message}");
        }
    }

    protected static XmlDocument ToXmlDocument(XDocument xDocument)
    {
        var xmlDocument = new XmlDocument();
        using (XmlReader xmlReader = xDocument.CreateReader())
        {
            xmlDocument.Load(xmlReader);
        }
        return xmlDocument;
    }
    protected static string ObjectXmlToString<T>(T entity, XmlSerializerNamespaces nameSpaces)
    {
        var serializer = new XmlSerializer(typeof(T));
        var settings = new XmlWriterSettings
        {
            Encoding = Encoding.UTF8,
            Indent = true,
            OmitXmlDeclaration = true,
            NamespaceHandling = NamespaceHandling.OmitDuplicates
        };
        var builder = new StringBuilder();
        using (var writer = XmlWriter.Create(builder, settings))
        {
            serializer.Serialize(writer, entity, nameSpaces);
        }
        return builder.ToString();
    }
    #endregion Methods
}
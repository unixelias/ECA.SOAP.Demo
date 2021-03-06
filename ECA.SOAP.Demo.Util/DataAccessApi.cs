using Microsoft.Extensions.Configuration;

namespace ECA.SOAP.Demo.Util;

public class DataAccessApi
{
    #region Constants

    private const string API_BASE_URL = "BaseUrl";
    private const string API_SECION_NAME = "DataAccessApi";

    #endregion Constants

    #region Properties

    public string BaseUrl { get; private set; }
    public string Name { get; private set; }

    #endregion Properties

    #region Methods

    public DataAccessApi(IConfiguration config)
    {
        IConfigurationSection configApi = config.GetSection(API_SECION_NAME);
        this.Name = API_SECION_NAME;
        this.BaseUrl = configApi[API_BASE_URL];
    }

    #endregion Methods
}
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ECA.SOAP.Demo.Util;

public class ConfigParams
{
    #region Properties

    private static ConfigParams configuration;

    public W3SchoolsApi W3SchoolsApi { get; private set; }
    public DataAccessApi DataAccessApi { get; private set; }

    #endregion Properties

    #region Constructors

    private ConfigParams(IConfiguration configuracao)
    {
        W3SchoolsApi = new W3SchoolsApi(configuracao);
        DataAccessApi = new DataAccessApi(configuracao);
    }

    #endregion Constructors

    #region Methods

    public static ConfigParams Get()
    {
        if (configuration is null)
        {
            configuration = GetConfigParams();
        }
        return configuration;
    }

    #endregion Methods

    private static ConfigParams GetConfigParams()
    {
        string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? String.Empty;
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        return new ConfigParams(builder.Build());
    }
}
using ECA.SOAP.Demo;
using ECA.SOAP.Demo.Repository;
using ECA.SOAP.Demo.Repository.Interface;
using ECA.SOAP.Demo.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(config =>
{
    config.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
}).AddXmlSerializerFormatters();
builder.Services.AddApiVersioning(option =>
{
    option.DefaultApiVersion = new ApiVersion(1, 0);
    option.AssumeDefaultVersionWhenUnspecified = true;
    option.ReportApiVersions = true;
});
builder.Services.AddHttpClient(ConfigParams.Get().DataAccessApi.Name, client =>
{
    client.BaseAddress = new Uri(ConfigParams.Get().DataAccessApi.BaseUrl);
    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "text/xml; charset=utf-8");
});
builder.Services.AddHttpClient(ConfigParams.Get().W3SchoolsApi.Name, client =>
{
    client.BaseAddress = new Uri(ConfigParams.Get().W3SchoolsApi.BaseUrl);
    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "text/xml; charset=utf-8");
});

#region Dependencies Injection

builder.Services.AddScoped<IDataAccessRepository, DataAccessRepository>();

#endregion Dependencies Injection

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
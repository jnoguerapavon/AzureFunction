using FunctionAppGenerarPDF.Generar;
using FunctionAppGenerarPDF.Interfaces;
using FunctionAppGenerarPDF.ManejoErrores;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = FunctionsApplication.CreateBuilder(args);

new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

builder.ConfigureFunctionsWebApplication();




builder.Services.AddSingleton(new OpenApiConfigurationOptions()
{
    Info = new OpenApiInfo
    {
        Title = "Azure Function API",
        Version = "v1",
        Description = "Documentación de Swagger para Azure Function"
    }
});

var connectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];

builder.Services.AddSingleton(new TelemetryClient(new Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration
{
    ConnectionString = connectionString
}));


builder.Services.AddSingleton<LoggerService>();

builder.Services.AddScoped<IGenerar, Generar>();


builder.Services.AddLogging();

await builder.Build().RunAsync();

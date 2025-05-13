using FunctionAppGenerarPDF.Generar;
using FunctionAppGenerarPDF.Interfaces;
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

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();


builder.Services.AddSingleton(new OpenApiConfigurationOptions()
{
    Info = new OpenApiInfo
    {
        Title = "Azure Function API",
        Version = "v1",
        Description = "Documentación de Swagger para Azure Function"
    }
});

builder.Services.AddScoped<IGenerar, Generar>();


builder.Services.AddLogging();

await builder.Build().RunAsync();

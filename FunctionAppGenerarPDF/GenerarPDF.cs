using AzureFunction;
using FunctionAppGenerarPDF.Clases;
using FunctionAppGenerarPDF.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionAppGenerarPDF
{
    public class GenerarPDF
    {
        private readonly ILogger<GenerarPDF> _logger;
        private readonly IGenerar _generarService;

        public GenerarPDF(ILogger<GenerarPDF> logger, IGenerar generarService)
        {
            _logger = logger;
            _generarService = generarService;
        }

        [Function("GenerarPDF")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
      
            var Respuesta = new Response
            {
                Archivo = "",
                CodeError = 0,
                MensajeError = ""
            };


            try
            {

                // Obtener el cuerpo de la solicitud
                var requestBody = await req.ReadFromJsonAsync<Request>();

                if(requestBody != null)
                {
                    var datos =await _generarService.ObtenerDatosPorReporte(requestBody);

                    var bytes = await _generarService.GenerarPDFPorReporte(requestBody.IdReporte, Constantes.Ruta, requestBody.Cliente, requestBody.Cedula, datos);

                    string base64String = Convert.ToBase64String(bytes);

                    Respuesta = new Response
                    {
                        Archivo = base64String,
                        CodeError = 0,
                        MensajeError = "Archivo Generado correctamente"
                    };
                }
                else
                {
                    Respuesta = new Response
                    {
                        Archivo = "",
                        CodeError = 99,
                        MensajeError = "Data Invalida"
                    };
                }


            }
            catch (Exception ex)
            {

                Respuesta = new Response
                {
                    Archivo = "",
                    CodeError = 99,
                    MensajeError = ex.Message
                };
            }
            return new OkObjectResult(Respuesta);
        }
    }
    }


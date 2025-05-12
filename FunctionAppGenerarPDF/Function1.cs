using AzureFunction;
using AzureFunction.ProcesarReportes;
using FunctionAppGenerarPDF.Clases;
using FunctionAppGenerarPDF.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using static Microsoft.ClearScript.V8.V8ScriptEngine;

namespace FunctionAppGenerarPDF
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
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

                string ruta = @"C:\";

             
                // Obtener el cuerpo de la solicitud
                var requestBody = await req.ReadFromJsonAsync<Request>();

                if(requestBody != null)
                {
                    var datos = Utils.ObtenerDatosPorReporte(requestBody);

                    var bytes = Utils.GenerarPDFPorReporte(requestBody.IdReporte, ruta, requestBody.Cliente, requestBody.Cedula, datos);

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


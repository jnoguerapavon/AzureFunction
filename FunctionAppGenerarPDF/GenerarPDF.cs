using AzureFunction;
using FunctionAppGenerarPDF.Clases;
using FunctionAppGenerarPDF.Interfaces;
using FunctionAppGenerarPDF.ManejoErrores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionAppGenerarPDF
{
    public class GenerarPDF
    {
        private readonly LoggerService _logger;
        private readonly IGenerar _generarService;

        public GenerarPDF(LoggerService logger, IGenerar generarService)
        {
            _logger = logger;
            _generarService = generarService;
        }

        /// <summary>
        /// La funci�n GenerarPDF es una Azure Function HTTP tipo POST que recibe datos de entrada en formato JSON, 
        /// genera un archivo PDF seg�n un tipo de documento y usuario, 
        /// y devuelve el resultado en formato Base64 junto con un c�digo de respuesta.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [Function("GenerarPDF")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {

            Response Respuesta;


            try
            {
                _logger.LogInfo("Inicio de funci�n GenerarPDF");

                // Obtener el cuerpo de la solicitud
                var requestBody = await req.ReadFromJsonAsync<Request>();

                if(requestBody != null)
                {
                    var datos =await _generarService.ObtenerDatosPorReporte(requestBody);

                    if (requestBody.Usuario == null)
                    {
                        throw new InvalidOperationException("No hay Datos de usuario");
                    }


                    var bytes = await _generarService.GenerarPDFPorReporte(requestBody.TipoDocumento, requestBody.Usuario, datos);

                    string base64String = Convert.ToBase64String(bytes);

                    Respuesta = new Response
                    {
                        Archivo = base64String,
                        CodeError = 0,
                        MensajeError = "Archivo Generado correctamente"
                    };

                    _logger.LogEvento("PDF_Generado");
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
                _logger.LogError("Error en GenerarPDF", ex);

                Respuesta = new Response
                {
                    Archivo = "",
                    CodeError = 99,
                    MensajeError = ex.Message + "--" + ex.StackTrace + "--" + ex.InnerException
                };
            }
            return new OkObjectResult(Respuesta);
        }
    }
    }


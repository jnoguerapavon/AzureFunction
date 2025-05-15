using AzureFunction;
using AzureFunction.ProcesarReportes;
using FunctionAppGenerarPDF.Clases;
using FunctionAppGenerarPDF.Interfaces;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using Microsoft.ClearScript.JavaScript;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static FunctionAppGenerarPDF.Clases.Constantes;
using JsonException = Newtonsoft.Json.JsonException;

namespace FunctionAppGenerarPDF.Generar
{
    public class Generar : IGenerar
    {
        /// <summary>
        /// Este método convierte un objeto JsonArray (de System.Text.Json.Nodes) 
        /// en una lista fuertemente tipada de objetos T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonArray"></param>
        /// <returns></returns>
        public Task<List<T>> ConvertJsonArrayToList<T>(JsonArray? jsonArray)
        {
            var result = jsonArray?.Deserialize<List<T>>() ?? new List<T>();
            return Task.FromResult(result);
        }

        /// <summary>
        /// Este método se encarga de generar un archivo PDF en formato binario (byte[]) según el tipo 
        /// de documento solicitado, los datos del usuario y los datos asociados al reporte. 
        /// El PDF generado depende del tipo de documento especificado.Actualmente, 
        /// solo se implementa la generación para el tipo IRCTradicional.
        /// </summary>
        /// <param name="Tipo"></param>
        /// <param name="Usuario"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>

        public Task<byte[]> GenerarPDFPorReporte(Constantes.Documentos? Tipo, User Usuario, object datos)
        {
            if (Tipo == null)
            {
                throw new NotSupportedException($"Sin datos");
            }


            return Tipo switch
            {
                Documentos.IRCTradicional =>
                Procesar.GenerarBytesIRCTradicional(string.Empty, Usuario.Cliente, Usuario.Identificacion, (List<DatosIRC>)datos),
                _ => throw new NotSupportedException($"Generador para reporte '{Tipo}' no implementado."),
            };
        }



        /// <summary>
        /// Esta función recibe un request con datos en formato JSON, detecta qué tipo de reporte es, averigua qué clase le corresponde y luego convierte (deserializa) ese JSON
        /// a una lista de objetos de esa clase usando reflexión.
        /// </summary>
        /// <param name="datosJson"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<object> ObtenerDatosPorReporte(Request? datosJson)
        {
            if (datosJson == null)
                throw new NotSupportedException("Sin datos");

            if (datosJson.Datos == null)
                throw new NotSupportedException("Sin datos");

            if (string.IsNullOrWhiteSpace((datosJson.Datos.ToJsonString())))
                throw new ArgumentException("El campo 'Datos' está vacío.");

            var tipo = ObtenerTipoDesdeEnum(datosJson.TipoDocumento);
            if (tipo == null)
                throw new NotSupportedException($"No se encontró tipo asociado para el reporte '{datosJson.TipoDocumento}'.");

            var listType = typeof(List<>).MakeGenericType(tipo);

            try
            {
                var resultado = JsonConvert.DeserializeObject(datosJson.Datos.ToJsonString(), listType);

                if (resultado == null)
                    throw new InvalidOperationException("La deserialización devolvió null. Verifica el JSON de entrada y el tipo de destino.");

                return await Task.FromResult(resultado);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Error al deserializar los datos. Verifica el formato JSON.", ex);
            }
        }

        /// <summary>
        /// La función busca un atributo personalizado que está asociado a un valor específico del enum Reportes y devuelve el Type (tipo de clase) que está guardado en ese atributo.
        /// </summary>
        /// <param name="reporte"></param>
        /// <returns></returns>
        public static Type? ObtenerTipoDesdeEnum(Documentos Tipo)
        {
            var member = typeof(Documentos).GetMember(Tipo.ToString()).FirstOrDefault();
            var attr = member?.GetCustomAttributes(typeof(TipoFormularioAttribute), false).FirstOrDefault() as TipoFormularioAttribute;
            return attr?.Tipo;
        }


    }
}

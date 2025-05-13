using AzureFunction;
using AzureFunction.ProcesarReportes;
using FunctionAppGenerarPDF.Clases;
using FunctionAppGenerarPDF.Interfaces;
using Microsoft.ClearScript.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static FunctionAppGenerarPDF.Clases.Constantes;

namespace FunctionAppGenerarPDF.Generar
{
    public class Generar : IGenerar
    {

        public Task<List<T>> ConvertJsonArrayToList<T>(JsonArray? jsonArray)
        {
            var result = jsonArray?.Deserialize<List<T>>() ?? new List<T>();
            return Task.FromResult(result);
        }

        public Task<byte[]> GenerarPDFPorReporte(Constantes.Reportes? nombreReporte, string ruta, string? cliente, string? cedula, object datos)
        {
            if (nombreReporte == null)
            {
                throw new NotSupportedException($"Sin datos");
            }

            return nombreReporte switch
            {
                Reportes.IRCTradicional =>  
                Procesar.GenerarBytesPDF_GIE(ruta, cliente, cedula, (List<DatosFormularioGie>)datos),
                _ => throw new NotSupportedException($"Generador para reporte '{nombreReporte}' no implementado."),
            };
        }

        public async Task<object> ObtenerDatosPorReporte(Request? datosJson)
        {
            if (datosJson == null)
            {
                throw new NotSupportedException($"Sin datos");
            }

            return datosJson.IdReporte switch
            {
                Reportes.IRCTradicional =>await  ConvertJsonArrayToList<DatosFormularioGie>(datosJson.Datos),
                _ => throw new NotSupportedException($"Reporte '{datosJson.IdReporte}' no está soportado."),
            };
        }
    }
}

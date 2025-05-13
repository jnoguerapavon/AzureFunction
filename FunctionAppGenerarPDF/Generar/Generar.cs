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
        public async Task<List<T>> ConvertJsonArrayToList<T>(JsonArray? jsonArray)
        {
            if (jsonArray == null)
                return new List<T>();

            return  jsonArray.Deserialize<List<T>>() ?? new List<T>();
        }

        public Task<byte[]> GenerarPDFPorReporte(Constantes.Reportes? nombreReporte, string ruta, string? cliente, string? cedula, object datos)
        {
            if (nombreReporte == null)
            {
                throw new NotSupportedException($"Sin datos");
            }

            var lista = datos as List<DatosFormularioGie>;


            return nombreReporte switch
            {
                Reportes.IRCTradicional =>  
                Procesar.GenerarBytesPDF_GIE(ruta, cliente, cedula, lista),
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
                Reportes.IRCTradicional =>ConvertJsonArrayToList<DatosFormularioGie>(datosJson.Datos),
                _ => throw new NotSupportedException($"Reporte '{datosJson.IdReporte}' no está soportado."),
            };
        }
    }
}

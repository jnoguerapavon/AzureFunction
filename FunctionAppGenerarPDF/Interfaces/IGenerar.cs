using FunctionAppGenerarPDF.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static FunctionAppGenerarPDF.Clases.Constantes;

namespace FunctionAppGenerarPDF.Interfaces
{
   public  interface IGenerar
    {

        Task<List<T>> ConvertJsonArrayToList<T>(JsonArray? jsonArray);
        Task<object> ObtenerDatosPorReporte(Request? datosJson);
        Task<byte[]> GenerarPDFPorReporte(Documentos? Tipo, User Usuario, object datos);

    }
}

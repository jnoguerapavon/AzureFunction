using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static FunctionAppGenerarPDF.Clases.Constantes;

namespace FunctionAppGenerarPDF.Clases
{
    public  class Request
    {
        public Reportes  IdReporte { get; set; }

        public string? Cliente {  get; set; }    

        public string? Cedula {  get; set; } 

        public int? TipoId {  get; set; } 

        public JsonArray? Datos { get; set; }

    }
}

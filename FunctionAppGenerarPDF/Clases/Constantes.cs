using AzureFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppGenerarPDF.Clases
{
    public class Constantes
    {


        public enum Reportes
        {
            [TipoFormularioAttribute(typeof(DatosFormularioGie))]
            IRCTradicional = 1,

            // Puedes agregar otros reportes así:
            //[TipoFormulario(typeof(OtraClase))]
            // OtroReporte,
        }


        public const string Ruta = "";


    }





}

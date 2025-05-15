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


        public enum Documentos
        {
            [TipoFormularioAttribute(typeof(DatosIRC))]
            IRCTradicional = 1,

            // Puedes agregar otros reportes así:
            //[TipoFormulario(typeof(OtraClase))]
            // OtroReporte,
        }










        public const string Ruta = "";


    }





}

using FunctionAppGenerarPDF.Clases.IRC;
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
            [TipoFormularioAttribute(typeof(DatosIrc))]
            IRCTradicional = 1
        }






    }





}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppGenerarPDF.Clases
{
    [AttributeUsage(AttributeTargets.Field)]
    public class TipoFormularioAttribute : Attribute
    {
        public Type Tipo { get; }

        public TipoFormularioAttribute(Type tipo)
        {
            Tipo = tipo;
        }
    }
}

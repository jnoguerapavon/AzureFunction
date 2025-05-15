using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction
{
    public class DatosIRC
    {
        /// <summary>
        /// Id GUID inico 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id Solicitud de tramite
        /// </summary>
        public int IdSolicitud { get; set; }

        /// <summary>
        /// Identificacion o cedula
        /// </summary>
        public string IdentificacionIntegrante { get; set; }

        /// <summary>
        /// Nombre completo del cliente fisico
        /// </summary>
        public string NombreCliente { get; set; }

        /// <summary>
        /// Descripcion del tipo de relacion usado para el GRID
        /// </summary>
        public string TipoRelacion { get; set; }

        /// <summary>
        /// IdTipo relacion usado para enviarse a almacenar
        /// </summary>

        public string IdTipoRelacion { get; set; }

        /// <summary>
        /// Descripcion del puesto
        /// </summary>

        public string Puesto { get; set; }

        /// <summary>
        /// IdPuesto utilizado para enviarse a almacenar
        /// </summary>
        public string IdPuesto { get; set; }

        /// <summary>
        ///Id  Articulo de formulario de GIE
        /// </summary>

        public int ArticuloVinculacion { get; set; }

        /// <summary>
        /// Id Inciso del articulo del formulario de GIE.
        /// </summary>
        public string IncisoVinculacion { get; set; }

    }
}

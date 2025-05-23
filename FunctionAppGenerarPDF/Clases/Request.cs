using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static FunctionAppGenerarPDF.Clases.Constantes;

namespace FunctionAppGenerarPDF.Clases
{
    public  class Request
    {
        [JsonProperty("TipoDocumento")]
        public Documentos TipoDocumento { get; set; }

        [JsonProperty("Usuario")]
        public User? Usuario { get; set; }

        [JsonProperty("Datos")]
        public JsonArray? Datos { get; set; }

    }
}

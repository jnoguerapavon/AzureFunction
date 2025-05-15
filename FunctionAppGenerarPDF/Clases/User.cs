using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FunctionAppGenerarPDF.Clases
{
    public  class User
    {

        [JsonPropertyName("Cliente")]
        public string? Cliente { get; set; }

  
        [JsonPropertyName("Identificacion")]
        public string? Identificacion { get; set; }


        [JsonPropertyName("TipoId")]
        public int? TipoId { get; set; }
    }
}

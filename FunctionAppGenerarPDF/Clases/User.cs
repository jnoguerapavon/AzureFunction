using Newtonsoft.Json;
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

        [JsonProperty("Cliente")]
        public string? Cliente { get; set; }

  
        [JsonProperty("Identificacion")]
        public string? Identificacion { get; set; }


        [JsonProperty("TipoId")]
        public int? TipoId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FunctionAppGenerarPDF.Clases
{
    public  class Response : ResponseError
    {
        [JsonPropertyName("Archivo")]
        public string? Archivo {  get; set; }    
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FunctionAppGenerarPDF.Clases
{
    public  class ResponseError
    {
        [JsonPropertyName("MensajeError")]
        public string? MensajeError { get; set; } = "";

        [JsonPropertyName("CodeError")]
        public int CodeError { get; set; } = 0;
    }
}

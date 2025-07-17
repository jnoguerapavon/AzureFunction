using AzureFunction.Clases.IRC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppGenerarPDF.Clases.IRC
{
    public class DatosIrc
    {

        public List<InfoSolicitante> infoSolicitante { get; set; }
        public List<DetalleGie> detalleGie { get; set; }
        public List<Comentarios> comentarios { get; set; }
        public List<CondPrest> condPrest { get; set; }
        public List<FormaEntrega> formaEntrega { get; set; }
        public List<PlanInversion> planInversion { get; set; }
        public List<TasaInteres> tasaInteres { get; set; }
        public List<Comisiones> comisiones { get; set; }
        public List<ClasifCrediticia> clasifCrediticia { get; set; }
        public List<Garantias> garantias { get; set; }
        public List<Seguros> seguros { get; set; }
        public List<CapacidadPago> capacidadPago { get; set; }
        public List<Aprobacion> aprobacion { get; set; }
        public List<Tarjetas> tarjetas { get; set; }


    }


}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction
{
    public class DatosIrc
    {

        [JsonProperty("capacidadPago")]
        public List<CapacidadPago> CapacidadPago { get; set; }

        [JsonProperty("infoSolicitante")]
        public List<InfoSolicitante> InfoSolicitante { get; set; }

        [JsonProperty("garantias")]
        public List<Garantia> Garantias { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }

        [JsonProperty("condPrest")]
        public List<CondPrest> CondPrest { get; set; }

        [JsonProperty("detalleGie")]
        public List<DetalleGie> DetalleGie { get; set; }

        [JsonProperty("formaEntrega")]
        public List<FormaEntrega> FormaEntrega { get; set; }

        [JsonProperty("aprobacion")]
        public List<Aprobacion> Aprobacion { get; set; }

        [JsonProperty("clasifCrediticia")]
        public List<ClasifCrediticium> ClasifCrediticia { get; set; }

        [JsonProperty("comisiones")]
        public List<Comisione> Comisiones { get; set; }

        [JsonProperty("tarjetas")]
        public List<Tarjeta> Tarjetas { get; set; }

        [JsonProperty("comentarios")]
        public List<Comentario> Comentarios { get; set; }

        [JsonProperty("tasaInteres")]
        public List<TasaIntere> TasaInteres { get; set; }

        [JsonProperty("planInversion")]
        public List<PlanInversion> PlanInversion { get; set; }

        [JsonProperty("seguros")]
        public List<Seguro> Seguros { get; set; }


    }

    // Clases Hijas



    public class Aprobacion
    {
        [JsonProperty("nombreAprobador1")]
        public string NombreAprobador1 { get; set; }

        [JsonProperty("nombreAprobador2")]
        public string NombreAprobador2 { get; set; }

        [JsonProperty("nombreEjecutivoEnlace")]
        public string NombreEjecutivoEnlace { get; set; }

        [JsonProperty("resolucionSolicitud")]
        public string ResolucionSolicitud { get; set; }

        [JsonProperty("tipoAprobacion")]
        public string TipoAprobacion { get; set; }
    }

    public class CapacidadPago
    {
        [JsonProperty("nroCapPago")]
        public int NroCapPago { get; set; }

        [JsonProperty("descExpRiesgoCamb")]
        public string DescExpRiesgoCamb { get; set; }

        [JsonProperty("indEliminar")]
        public string IndEliminar { get; set; }

        [JsonProperty("usuarioResponsable")]
        public string UsuarioResponsable { get; set; }

        [JsonProperty("grupoCliente")]
        public string GrupoCliente { get; set; }

        [JsonProperty("riesgoCambiario")]
        public string RiesgoCambiario { get; set; }

        [JsonProperty("nivelCapPago")]
        public int NivelCapPago { get; set; }
    }

    public class ClasifCrediticium
    {
        [JsonProperty("modalidadDeCredito")]
        public string ModalidadDeCredito { get; set; }

        [JsonProperty("periodoGracia")]
        public int PeriodoGracia { get; set; }

        [JsonProperty("tope")]
        public string Tope { get; set; }

        [JsonProperty("plazo")]
        public int Plazo { get; set; }

        [JsonProperty("moneda")]
        public string Moneda { get; set; }

        [JsonProperty("subclase")]
        public string Subclase { get; set; }

        [JsonProperty("usoDeRecursos")]
        public string UsoDeRecursos { get; set; }

        [JsonProperty("actividad")]
        public string Actividad { get; set; }

        [JsonProperty("clase")]
        public string Clase { get; set; }
    }

    public class Comentario
    {
        [JsonProperty("descTipoAmortizacion")]
        public string DescTipoAmortizacion { get; set; }

        [JsonProperty("desgloseFondos")]
        public string DesgloseFondos { get; set; }

        [JsonProperty("descripcionComentarioGarant")]
        public string DescripcionComentarioGarant { get; set; }

        [JsonProperty("beneficioPlanilla")]
        public string BeneficioPlanilla { get; set; }

        [JsonProperty("codigoTipoIrc")]
        public int CodigoTipoIrc { get; set; }

        [JsonProperty("sarasObservacionesComent")]
        public string SarasObservacionesComent { get; set; }

        [JsonProperty("sarasRequisitosPendientes")]
        public string SarasRequisitosPendientes { get; set; }

        [JsonProperty("otrasReferenciasDeudores")]
        public string OtrasReferenciasDeudores { get; set; }

        [JsonProperty("formaEntrega")]
        public string FormaEntrega { get; set; }

        [JsonProperty("descripcionTasaInteres")]
        public string DescripcionTasaInteres { get; set; }

        [JsonProperty("detalleSeguros")]
        public string DetalleSeguros { get; set; }

        [JsonProperty("indicadorIrcGenerado")]
        public string IndicadorIrcGenerado { get; set; }

        [JsonProperty("comentariosRecomendaciones")]
        public string ComentariosRecomendaciones { get; set; }

        [JsonProperty("condicionesComentariosAprob")]
        public string CondicionesComentariosAprob { get; set; }

        [JsonProperty("consideracionesParaNotario")]
        public string ConsideracionesParaNotario { get; set; }

        [JsonProperty("justificacionPlanInversion")]
        public string JustificacionPlanInversion { get; set; }

        [JsonProperty("formaPago")]
        public string FormaPago { get; set; }

        [JsonProperty("aplicaSaras")]
        public string AplicaSaras { get; set; }

        [JsonProperty("previoFormalizacion")]
        public string PrevioFormalizacion { get; set; }
    }

    public class Comisione
    {
        [JsonProperty("monto")]
        public int Monto { get; set; }

        [JsonProperty("codigoComision")]
        public int CodigoComision { get; set; }

        [JsonProperty("descComision")]
        public string DescComision { get; set; }

        [JsonProperty("porcentaje")]
        public double Porcentaje { get; set; }

        [JsonProperty("detalleComision")]
        public string DetalleComision { get; set; }
    }

    public class CondPrest
    {
        [JsonProperty("tipoNotario")]
        public string TipoNotario { get; set; }

        [JsonProperty("nroCuentaDebitoAut")]
        public string NroCuentaDebitoAut { get; set; }

        [JsonProperty("diaPago")]
        public int DiaPago { get; set; }

        [JsonProperty("indReqVerifPlanInv")]
        public string IndReqVerifPlanInv { get; set; }
    }

    public class DetalleGie
    {
        [JsonProperty("codigoTipoIdentificacion")]
        public int CodigoTipoIdentificacion { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("endeudamientoTarjeta")]
        public string EndeudamientoTarjeta { get; set; }

        [JsonProperty("numeroIdentificacion")]
        public string NumeroIdentificacion { get; set; }

        [JsonProperty("endeudamientoBn")]
        public int EndeudamientoBn { get; set; }

        [JsonProperty("nombreORazonSocial")]
        public string NombreORazonSocial { get; set; }

        [JsonProperty("indEliminar")]
        public string IndEliminar { get; set; }
    }

    public class FormaEntrega
    {
        [JsonProperty("informacionDestino")]
        public string InformacionDestino { get; set; }

        [JsonProperty("codigoTipoPago")]
        public int CodigoTipoPago { get; set; }

        [JsonProperty("descripcionTipoDestino")]
        public string DescripcionTipoDestino { get; set; }

        [JsonProperty("indEliminar")]
        public string IndEliminar { get; set; }

        [JsonProperty("prioridad")]
        public int Prioridad { get; set; }
    }

    public class Garantia
    {
        [JsonProperty("grado")]
        public int Grado { get; set; }

        [JsonProperty("conseGar")]
        public int ConseGar { get; set; }

        [JsonProperty("valorResponsabilidad")]
        public double ValorResponsabilidad { get; set; }

        [JsonProperty("gravamenGarantia")]
        public int GravamenGarantia { get; set; }

        [JsonProperty("indEliminar")]
        public string IndEliminar { get; set; }

        [JsonProperty("valor")]
        public double Valor { get; set; }

        [JsonProperty("valorDisponible")]
        public double ValorDisponible { get; set; }

        [JsonProperty("codigoTipoGarantia")]
        public int CodigoTipoGarantia { get; set; }

        [JsonProperty("responsabilidadInterna")]
        public int ResponsabilidadInterna { get; set; }

        [JsonProperty("tipoDeGarantia")]
        public string TipoDeGarantia { get; set; }

        [JsonProperty("detalle")]
        public string Detalle { get; set; }

        [JsonProperty("valorResponsabilidadLegal")]
        public int ValorResponsabilidadLegal { get; set; }
    }

    public class InfoSolicitante
    {
        [JsonProperty("codigoTipoIdentificacion")]
        public int CodigoTipoIdentificacion { get; set; }

        [JsonProperty("catRiesgo")]
        public string CatRiesgo { get; set; }

        [JsonProperty("ncphSfnSbd")]
        public int NcphSfnSbd { get; set; }

        [JsonProperty("numeroIdentificacion")]
        public string NumeroIdentificacion { get; set; }

        [JsonProperty("indEliminar")]
        public string IndEliminar { get; set; }

        [JsonProperty("codigoZonaComercial")]
        public int CodigoZonaComercial { get; set; }

        [JsonProperty("condicion")]
        public string Condicion { get; set; }

        [JsonProperty("codigosBn")]
        public string CodigosBn { get; set; }

        [JsonProperty("nivelSegLcTf")]
        public string NivelSegLcTf { get; set; }

        [JsonProperty("nombreORazonSocial")]
        public string NombreORazonSocial { get; set; }

        [JsonProperty("montoSolicitado")]
        public int MontoSolicitado { get; set; }

        [JsonProperty("codigoAgencia")]
        public int CodigoAgencia { get; set; }

        [JsonProperty("scoreCrediticio")]
        public string ScoreCrediticio { get; set; }
    }

    public class PlanInversion
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("codigoPlanInversionIrc")]
        public int CodigoPlanInversionIrc { get; set; }

        [JsonProperty("aporte")]
        public int Aporte { get; set; }

        [JsonProperty("indEliminar")]
        public string IndEliminar { get; set; }

        [JsonProperty("financiamiento")]
        public int Financiamiento { get; set; }

        [JsonProperty("detalle")]
        public string Detalle { get; set; }
    }


    public class Seguro
    {
        [JsonProperty("danosSiniestros")]
        public string DanosSiniestros { get; set; }

        [JsonProperty("certifiProtCredi")]
        public string CertifiProtCredi { get; set; }

        [JsonProperty("montoAcreencias")]
        public int MontoAcreencias { get; set; }

        [JsonProperty("requierePoliza")]
        public string RequierePoliza { get; set; }
    }

    public class Tarjeta
    {
        [JsonProperty("marca")]
        public string Marca { get; set; }

        [JsonProperty("tipoDescri")]
        public string TipoDescri { get; set; }

        [JsonProperty("tasaIntCol")]
        public int TasaIntCol { get; set; }

        [JsonProperty("monto")]
        public int Monto { get; set; }

        [JsonProperty("oficina")]
        public string Oficina { get; set; }

        [JsonProperty("tasaIntDol")]
        public double TasaIntDol { get; set; }

        [JsonProperty("numeroIdSegPlastico")]
        public string NumeroIdSegPlastico { get; set; }

        [JsonProperty("moneda")]
        public string Moneda { get; set; }

        [JsonProperty("nombreSegPlastico")]
        public string NombreSegPlastico { get; set; }

        [JsonProperty("descGarantia")]
        public string DescGarantia { get; set; }
    }

    public class TasaIntere
    {
        [JsonProperty("tasaAnual")]
        public int TasaAnual { get; set; }

        [JsonProperty("tipoInteres")]
        public string TipoInteres { get; set; }

        [JsonProperty("tasaTecho")]
        public int TasaTecho { get; set; }

        [JsonProperty("tasaMensual")]
        public int TasaMensual { get; set; }

        [JsonProperty("tipoAjusteTasaInteres")]
        public string TipoAjusteTasaInteres { get; set; }

        [JsonProperty("tasaTita")]
        public double TasaTita { get; set; }

        [JsonProperty("desgloseComponentesTita")]
        public string DesgloseComponentesTita { get; set; }

        [JsonProperty("tasaPiso")]
        public int TasaPiso { get; set; }
    }




}

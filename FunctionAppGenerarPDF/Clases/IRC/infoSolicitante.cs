namespace AzureFunction.Clases.IRC
{
    public class InfoSolicitante
    {
        public int codigoTipoIdentificacion { get; set; }
        public string numeroIdentificacion { get; set; }
        public string nombreORazonSocial { get; set; }
        public int codigoZonaComercial { get; set; }
        public int codigoAgencia { get; set; }
        public decimal montoSolicitado { get; set; }
        public string condicion { get; set; }
        public string codigosBN { get; set; }
        public string scoreCrediticio { get; set; }
        public string catRiesgo { get; set; }
        public string nivelSegLcTf { get; set; }
        public int ncphSfnSbd { get; set; }
        public string indEliminar { get; set; }
    }
}

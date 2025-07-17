namespace AzureFunction.Clases.IRC
{
    public class FormaEntrega
    {
        public int codigoTipoPago { get; set; }
        public int prioridad { get; set; }
        public string descripcionTipoDestino { get; set; }
        public string informacionDestino { get; set; }
        public string indEliminar { get; set; }
    }
}

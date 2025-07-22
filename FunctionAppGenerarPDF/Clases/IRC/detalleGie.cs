namespace AzureFunction.Clases.IRC
{
    public class DetalleGie
    {
        public int codigoTipoIdentificacion { get; set; }


        public string TipoIdentificacion { get; set; }

        public string numeroIdentificacion { get; set; }
        public string nombreORazonSocial { get; set; }
        public string tipo { get; set; }
        public decimal endeudamientoBN { get; set; }
        public bool Nuevo { get; set; }
        public string indEliminar { get; set; }
    }
}

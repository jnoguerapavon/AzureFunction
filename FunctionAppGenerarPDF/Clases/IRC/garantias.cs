namespace AzureFunction.Clases.IRC
{
    public class Garantias
    {
        public int conseGar { get; set; }
        public int coditoTipoGarantia { get; set; }
        public string tipoDeGarantia { get; set; }
        public string detalle { get; set; }
        public int grado { get; set; }
        public decimal valor { get; set; }
        public decimal responsabilidadInterna { get; set; }
        public decimal valorResponsabilidad { get; set; }
        public decimal gravamenGarantia { get; set; }
        public decimal valorDisponible { get; set; }
        public decimal valorResponsabilidadLegal { get; set; }
        public string indEliminar { get; set; }
    }
}

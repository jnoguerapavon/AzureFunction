using AzureFunction;
using BNCR.Documento.PDF.BL;
using BNCR.GeneradorPDF.text.pdf;
using BNCR.GeneradorPDF.text;
using BNCR.GeneradorPDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunctionAppGenerarPDF.Clases;
using FunctionAppGenerarPDF.Clases.IRC;

namespace FunctionAppGenerarPDF.Utilitarios
{
    public static  class Utils
    {

        public static string CalcularAltoCelda(string? texto, int tamanoFragmento, ref int cellHeight, int altoCelda)
        {
            List<string> fragmentos = new List<string>();

            for (int i = 0; i < texto?.Length; i += tamanoFragmento)
            {
                int longitudFragmento = Math.Min(tamanoFragmento, texto.Length - i);
                string fragmento = texto.Substring(i, longitudFragmento);
                fragmentos.Add(fragmento);
            }

            if (((fragmentos.Count + 1) * altoCelda) > cellHeight)
            {
                cellHeight = (fragmentos.Count + 1) * altoCelda;
            }
            return string.IsNullOrEmpty(texto) ? string.Empty : texto;
        }

        public static void AgregarLogo(string Titulo,int pagePDF, ref int posicionY, ref Document document, int TotalPagina)
        {
            document.SetPage(pagePDF);
            string basePath = AppContext.BaseDirectory;
            string ruta = Path.Combine(basePath, "images", "BN.jpg");
            var image = new Image(30, ruta, 12, 12);
            image.ScaleX = 30;
            image.ScaleY = 12;           
            document.AddImage(image);
        }


        public static void VerificarSaltoPagina(ref int pagePDF, ref int posicionY, ref Document document)
        {
            if (posicionY >= 240)
            {
                pagePDF++;
                document.AddNewPage(PageSize.LETTER, Orientation.portrait);
                document.SetPage(pagePDF);
                posicionY = 40;
            }
        }

        public static void HacerSaltoPagina(ref int pagePDF, ref int posicionY, ref Document document)
        {

            pagePDF++;
            document.AddNewPage(PageSize.LETTER, Orientation.portrait);
            document.SetPage(pagePDF);
            posicionY = 40;
        }

        public static byte[] CargarFirma(string ruta, string Base64, ref Document document, string Cedula, int PosicionX, int PosicionY, int Page)
        {

            string nombrePDF = Cedula + DateTime.Now.Ticks.ToString() + ConstantesCreditos._Extension;
            string rutaPDFAux = ruta + ConstantesCreditos._RutaDescargas + nombrePDF;

            Byte[] imagenBytes = Convert.FromBase64String(Base64);
            var PDFBytes = document.Close();
            File.WriteAllBytes(rutaPDFAux, PDFBytes);

            var documentoPDF = new BNCR.GeneradorPDFNet.Utilitarios();
            documentoPDF.RutaArchivo = rutaPDFAux;
            documentoPDF.Open(Page - 1);
            documentoPDF.InsertarImagen(imagenBytes, PosicionX, PosicionY, 25);
            File.Delete(rutaPDFAux);
            return documentoPDF.Close();
        }


        public static void CrearTitulos(ref Document document, ref int posiciony)
        {
            PdfTable tabla = new PdfTable(new float[] { 200 }, 10, posiciony);
            //Definición para títulos
            var fontTextoCabecera = FontFactory.GetFont(Font.Family.Arial, 11, Font.BOLD, BaseColor.WHITE);
            var HorizontalAlignmentTitulos = Element.ALIGN_CENTER;
            var BackgroundColorTitulosAzul = new BaseColor(30, 61, 140);
            var VerticalAlignmentTitulos = Element.ALIGN_CENTER;
            var BackgroundColorTitulosOliva = new BaseColor(176, 188, 34);
            var fontTextoCabecera2 = FontFactory.GetFont(Font.Family.Arial, 11, Font.BOLD, BaseColor.BLACK);
            //Títulos
            tabla.AddCell(new PdfPCell() { VerticalAlignment= VerticalAlignmentTitulos,  BackgroundColor = BackgroundColorTitulosAzul, HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase("Dirección de Riesgos de Crédito ", fontTextoCabecera) });
            tabla.CellHeight = 8;
            posiciony += 8;
            tabla.CellSpacing = 0.1f;
            tabla.BorderWidth = 0.5f;
            document.Add(tabla);
            tabla = new PdfTable(new float[] { 200 }, 10, posiciony);
            tabla.AddCell(new PdfPCell() { VerticalAlignment = VerticalAlignmentTitulos, BackgroundColor = BackgroundColorTitulosOliva, HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase("Carátula única de crédito", fontTextoCabecera2) });
            tabla.CellHeight = 8;
            tabla.CellSpacing = 0.1f;
            tabla.BorderWidth = 0.5f;
            posiciony += 8;
            document.Add(tabla);
        }


        public static void CrearApartado0(ref Document document, ref int posiciony, DatosIrc? Datos)
        {
            PdfTable tabla = new PdfTable(new float[] { 50,50,50,50 }, 10, posiciony);
            //Definición para títulos
            var fontTextoTitulos = FontFactory.GetFont(Font.Family.Arial, 9, Font.NORMAL, BaseColor.BLACK);
            var HorizontalAlignmentTitulos = Element.ALIGN_CENTER;
            var BackgroundColorTitulosGris = new BaseColor(200, 201, 199);
            var VerticalAlignmentTitulos = Element.ALIGN_CENTER;
            int altoCelda = 0;
            int altoFila = 1;
            int posYTable = posiciony;
            //Títulos
            tabla.AddCell(new PdfPCell() { VerticalAlignment= VerticalAlignmentTitulos,  BackgroundColor = BackgroundColorTitulosGris, HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda("Sucursal de Zona o CC", 50, ref altoCelda, altoFila), fontTextoTitulos) });
            tabla.AddCell(new PdfPCell() { VerticalAlignment = VerticalAlignmentTitulos, HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(Datos?.infoSolicitante?.FirstOrDefault().codigoZonaComercial.ToString(), 50, ref altoCelda, altoFila), fontTextoTitulos) });
            tabla.AddCell(new PdfPCell() { VerticalAlignment = VerticalAlignmentTitulos, BackgroundColor = BackgroundColorTitulosGris, HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda("Oficina", 50, ref altoCelda, altoFila), fontTextoTitulos) });
            tabla.AddCell(new PdfPCell() { VerticalAlignment = VerticalAlignmentTitulos, HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(Datos?.infoSolicitante?.FirstOrDefault().Agencia, 50, ref altoCelda, altoFila), fontTextoTitulos) });

            tabla.AddCell(new PdfPCell() { VerticalAlignment = VerticalAlignmentTitulos, BackgroundColor = BackgroundColorTitulosGris, HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda("Fecha", 50, ref altoCelda, altoFila), fontTextoTitulos) });
            tabla.AddCell(new PdfPCell() { VerticalAlignment = VerticalAlignmentTitulos, HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(DateTime.Now.ToString("dd-MM-yyyy"), 50, ref altoCelda, altoFila), fontTextoTitulos) });
            tabla.AddCell(new PdfPCell() { VerticalAlignment = VerticalAlignmentTitulos, BackgroundColor = BackgroundColorTitulosGris, HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda("Monto solicitado", 50, ref altoCelda, altoFila), fontTextoTitulos) });
            tabla.AddCell(new PdfPCell() { VerticalAlignment = VerticalAlignmentTitulos, HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(Datos?.infoSolicitante?.FirstOrDefault().montoSolicitado.ToString("N2"), 50, ref altoCelda, altoFila), fontTextoTitulos) });
            tabla.CellHeight = 8;
            tabla.CellSpacing = 0.1f;
            tabla.BorderWidth = 0.5f;
            document.Add(tabla);
            posYTable = posYTable + altoCelda;
            posiciony = posYTable;
        }



    }
}

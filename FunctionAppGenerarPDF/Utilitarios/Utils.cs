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

namespace FunctionAppGenerarPDF.Utilitarios
{
    public static  class Utils
    {

        public static string CalcularAltoCelda(string texto, int tamanoFragmento, ref int cellHeight, int altoCelda)
        {
            List<string> fragmentos = new List<string>();

            for (int i = 0; i < texto.Length; i += tamanoFragmento)
            {
                int longitudFragmento = Math.Min(tamanoFragmento, texto.Length - i);
                string fragmento = texto.Substring(i, longitudFragmento);
                fragmentos.Add(fragmento);
            }

            if (((fragmentos.Count + 1) * altoCelda) > cellHeight)
            {
                cellHeight = (fragmentos.Count + 1) * altoCelda;
            }
            return texto;
        }

        public static void CrearEncabezado(string Titulo,int pagePDF, ref int posicionY, ref Document document, int TotalPagina)
        {
            document.SetPage(pagePDF);

            string basePath = AppContext.BaseDirectory;
            string ruta = Path.Combine(basePath, "images", "bnlogoani.jpg");


            var image = new Image(30, ruta, 12, 12);
            image.ScaleX = 30;
            image.ScaleY = 12;

            int Aux = posicionY;

            var fontTextoCabecera = FontFactory.GetFont(Font.Family.Arial, 12, Font.NORMAL, BaseColor.BLACK);

            var HorizontalAlignmentTitulos = Element.ALIGN_CENTER;

            var VerticalAlignmentTitulos = Element.V_ALIGN_TOP;

            var fontTexto = FontFactory.GetFont(Font.Family.Arial, 6, Font.NORMAL, BaseColor.BLACK);

            var BackgroundColorTitulos = new BaseColor(176, 188, 34);

            int altoCelda = 0;

            PdfTable tabla = new PdfTable(new float[] { 35, 120, 40 }, 10, posicionY);
            tabla.AddCell(new PdfPCell() { BackgroundColor = BackgroundColorTitulos, HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda("", 35, ref altoCelda, 8), fontTextoCabecera) });
            altoCelda = altoCelda + 8;
            tabla.AddCell(new PdfPCell() { BackgroundColor = BackgroundColorTitulos, HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(Titulo, 120, ref altoCelda , 8), fontTextoCabecera) });
            tabla.AddCell(new PdfPCell() { BackgroundColor = BackgroundColorTitulos, VerticalAlignment = VerticalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._CodigoFormulario, 35, ref altoCelda, 8), fontTextoCabecera) });

            posicionY += altoCelda;

            tabla.CellHeight = altoCelda;
            document.Add(tabla);
            document.AddImage(image);

            altoCelda = 0;
            PdfTable table = new PdfTable(new float[] { 30, 10 }, 165, Aux + 15);
            string Pages = ConstantesCreditos._Pagina;
            Pages = Pages.Replace(ConstantesCreditos._Inicio, pagePDF.ToString()).Replace(ConstantesCreditos._Fin, TotalPagina.ToString());
            table.AddCell(new PdfPCell() {  HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(Pages, 30, ref altoCelda, 3), fontTexto) });
            table.AddCell(new PdfPCell() {  HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Edicion, 10, ref altoCelda, 3), fontTexto) });
            table.CellHeight = altoCelda;
            document.Add(table);


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

 

    }
}

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

        public static void CrearTablaGenerica(int Orden, List<DatosFormularioGie> Datos, ref Document document, ref int nPage, ref int posiciony, ref int paso, ref int pagePDF, string Cedula = "")
        {

            var fontTexto = FontFactory.GetFont(Font.Family.Arial, 10, Font.NORMAL, BaseColor.BLACK);
            var fontTextoCabecera = FontFactory.GetFont(Font.Family.Arial, 10, Font.BOLD, BaseColor.BLACK);

            var HorizontalAlignmentTitulos = Element.ALIGN_CENTER;
            var VerticalAlignmentTitulos = Element.V_ALIGN_BOTTOM;


            int altoCelda = 0;
            int altoFila = 1;
            int posYTable = posiciony;

            PdfTable tabla = null;


            //Definir encabezado de tabla

            switch (Orden)
            {
                case 1:
                    tabla = new PdfTable(new float[] { 75, 50, 50 }, 25, posiciony);
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo18_Inciso_A_NOMBRE, 75, ref altoCelda, 7), fontTextoCabecera) });
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo18_Inciso_A_CEDULA, 50, ref altoCelda, 7), fontTextoCabecera) });
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo18_Inciso_A_RELACION, 50, ref altoCelda, 7), fontTextoCabecera) });

                    break;
                case 2:
                    tabla = new PdfTable(new float[] { 120, 50 }, 25, posiciony);
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo18_Inciso_C_NOMBRE, 120, ref altoCelda, 7), fontTextoCabecera) });
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo18_Inciso_C_CEDULA, 50, ref altoCelda, 7), fontTextoCabecera) });

                    break;
                case 3:
                    tabla = new PdfTable(new float[] { 75, 50, 50 }, 25, posiciony);
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo19_Inciso_C_NOMBRE, 75, ref altoCelda, 7), fontTextoCabecera) });
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo19_Inciso_C_CEDULA, 50, ref altoCelda, 7), fontTextoCabecera) });
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo19_Inciso_C_PUESTO, 50, ref altoCelda, 7), fontTextoCabecera) });
                    break;
                case 4:
                    tabla = new PdfTable(new float[] { 120, 50 }, 25, posiciony);
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo20_Inciso_A_NOMBRE, 120, ref altoCelda, 7), fontTextoCabecera) });
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo20_Inciso_A_CEDULA, 50, ref altoCelda, 7), fontTextoCabecera) });
                    break;
                case 5:
                    tabla = new PdfTable(new float[] { 120, 50 }, 25, posiciony);
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo20_Inciso_B_NOMBRE, 120, ref altoCelda, 7), fontTextoCabecera) });
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo20_Inciso_B_CEDULA, 50, ref altoCelda, 7), fontTextoCabecera) });
                    break;
                case 6:
                    tabla = new PdfTable(new float[] { 120, 50 }, 25, posiciony);
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo20_Inciso_C_NOMBRE, 120, ref altoCelda, 7), fontTextoCabecera) });
                    tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Articulo20_Inciso_C_CEDULA, 50, ref altoCelda, 7), fontTextoCabecera) });
                    break;
                case 7:
                    tabla = new PdfTable(new float[] { 85, 85 }, 25, posiciony);
                    tabla.AddCell(new PdfPCell() { VerticalAlignment = VerticalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Firma, 85, ref altoCelda, 14), fontTextoCabecera) });
                    tabla.AddCell(new PdfPCell() { VerticalAlignment = VerticalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._cedula + Cedula, 85, ref altoCelda, 14), fontTextoCabecera) });
                    posYTable = posYTable + altoCelda;
                    break;
                default:
                    break;
            }

            tabla.CellHeight = altoCelda;


            document.Add(tabla);

            if (Datos != null)
            {
                foreach (var Item in Datos)
                {

                    int altoCeldaItem = 0;

                    if (posYTable >= 240)
                    {
                        posYTable = 40;
                        paso = 1;
                        pagePDF += 1;
                        nPage += 1;
                        document.AddNewPage(PageSize.LETTER, Orientation.portrait);
                        document.SetPage(pagePDF);



                        switch (Orden)
                        {
                            case 1:
                                tabla = new PdfTable(new float[] { 75, 50, 50 }, 25, 40);
                                break;
                            case 2:
                                tabla = new PdfTable(new float[] { 120, 50 }, 25, 40);
                                break;
                            case 3:
                                tabla = new PdfTable(new float[] { 75, 50, 50 }, 25, 40);
                                break;
                            case 4:
                                tabla = new PdfTable(new float[] { 120, 50 }, 25, 40);
                                break;
                            case 5:
                                tabla = new PdfTable(new float[] { 120, 50 }, 25, 40);
                                break;
                            case 6:
                                tabla = new PdfTable(new float[] { 120, 50 }, 25, 40);
                                break;
                            default:
                                break;
                        }




                    }


                    paso = paso + 1;


                    switch (Orden)
                    {
                        case 1:
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.NombreCliente, 75, ref altoCeldaItem, altoFila), fontTexto));
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.IdentificacionIntegrante, 50, ref altoCeldaItem, altoFila), fontTexto));
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.TipoRelacion, 50, ref altoCeldaItem, altoFila), fontTexto));
                            break;
                        case 2:
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.NombreCliente, 120, ref altoCeldaItem, altoFila), fontTexto));
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.IdentificacionIntegrante, 50, ref altoCeldaItem, altoFila), fontTexto));
                            break;
                        case 3:
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.NombreCliente, 75, ref altoCeldaItem, altoFila), fontTexto));
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.IdentificacionIntegrante, 50, ref altoCeldaItem, altoFila), fontTexto));
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.Puesto, 50, ref altoCeldaItem, altoFila), fontTexto));
                            break;
                        case 4:
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.NombreCliente, 120, ref altoCeldaItem, altoFila), fontTexto));
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.IdentificacionIntegrante, 50, ref altoCeldaItem, altoFila), fontTexto));
                            break;
                        case 5:
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.NombreCliente, 120, ref altoCeldaItem, altoFila), fontTexto));
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.IdentificacionIntegrante, 50, ref altoCeldaItem, altoFila), fontTexto));
                            break;
                        case 6:
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.NombreCliente, 120, ref altoCeldaItem, altoFila), fontTexto));
                            tabla.AddCell(new Phrase(CalcularAltoCelda(Item.IdentificacionIntegrante, 50, ref altoCeldaItem, altoFila), fontTexto));
                            break;
                        default:
                            break;
                    }





                    if (tabla.CellHeight < altoCelda)
                    {
                        tabla.CellHeight = altoCelda;
                    }

                    document.Add(tabla);

                    posYTable = posYTable + altoCelda;

                }
            }


            posiciony = posYTable;

            document.Add(tabla);

        }


    }
}

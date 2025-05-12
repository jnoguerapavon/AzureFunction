using BNCR.Documento.PDF.BL;
using BNCR.GeneradorPDF;
using BNCR.GeneradorPDF.text;
using BNCR.GeneradorPDF.text.pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction.ProcesarReportes
{
    public class Procesar
    {
        public byte[] GenerarBytesPDF_GIE(string ruta, string Cliente, string Cedula, string Base64Firma, List<DatosFormularioGie> _Lista)
        {
            #region FORMATOS
            int nPage = 1;
            int Paso = 1;
            int pagePDF = 1;
            int posicionY = 40;
            int SaltoLinea = 15;
            int posicionYFirma = 0;
            Document document = new Document(PageSize.LETTER, Orientation.portrait);
            document.Open();
            var textoColorNegro = FontFactory.GetFont(Font.Family.Arial, 12, Font.NORMAL, BaseColor.BLACK);
            var textoColorNegrilla = FontFactory.GetFont(Font.Family.Arial, 12, Font.BOLD, BaseColor.BLACK);
            #endregion



            #region Titulos
            var titulo1 = new Paragraph(75, 40, ConstantesCreditos._Declaracion, textoColorNegrilla, Paragraph.CENTER);
            var titulo2 = new Paragraph(75, 50, ConstantesCreditos._Persona_Fisica, textoColorNegrilla, Paragraph.CENTER);
            var titulo3 = new Paragraph(75, 60, ConstantesCreditos._Acuerdo, textoColorNegrilla, Paragraph.CENTER);
            var titulo4 = new Paragraph(75, 70, ConstantesCreditos._Reglamento, textoColorNegrilla, Paragraph.CENTER);

            document.Add(titulo1);
            document.Add(titulo2);
            document.Add(titulo3);
            document.Add(titulo4);
            #endregion


            #region Contenido

            var _Parrafo1 = new Paragraph(10, 85, ConstantesCreditos._Parrafo1, textoColorNegro, Paragraph.JUSTIFY);
            _Parrafo1.AnchoJustificado = 190;
            var NombreDeclarante = ConstantesCreditos._Nombre_Declarante_Label;
            var _Nombre_Declarante_Label = new Paragraph(10, 105, NombreDeclarante.Replace(ConstantesCreditos._Nombre, Cliente), textoColorNegro, Paragraph.LEFT);
            var Cedula_ = ConstantesCreditos._Cedula_Identidad_Label;
            var _Cedula_Identidad_Label = new Paragraph(10, 115, Cedula_.Replace(ConstantesCreditos._cedula_D, Cedula), textoColorNegro, Paragraph.LEFT);
            var _Parrafo2 = new Paragraph(10, 125, ConstantesCreditos._Parrafo2, textoColorNegro, Paragraph.JUSTIFY);
            _Parrafo2.AnchoJustificado = 190;

            document.Add(_Parrafo1);
            document.Add(_Nombre_Declarante_Label);
            document.Add(_Cedula_Identidad_Label);
            document.Add(_Parrafo2);
            #endregion




            #region Articulos

            var __Articulo16_Titulo = new Paragraph(10, 155, ConstantesCreditos._Articulo16_Titulo, textoColorNegrilla, Paragraph.JUSTIFY);
            var __Articulo18_Titulo = new Paragraph(10, 165, ConstantesCreditos._Articulo18_Titulo, textoColorNegrilla, Paragraph.JUSTIFY);


            // _Articulo18_Inciso_A
            var _Articulo18_Inciso_A = new Paragraph(10, 175, ConstantesCreditos._Articulo18_Inciso_A, textoColorNegro, Paragraph.JUSTIFY);
            _Articulo18_Inciso_A.AnchoJustificado = 190;

            document.Add(__Articulo16_Titulo);
            document.Add(__Articulo18_Titulo);
            document.Add(_Articulo18_Inciso_A);

            var Articulos = _Lista.FindAll(x => x.ArticuloVinculacion.Equals((int)ConstantesCreditos.Articulo.Articulo18) && x.IncisoVinculacion.Equals(nameof(ConstantesCreditos.Inciso.A)));
            posicionY = 195;
            CrearTablaGenerica(1, Articulos, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF);

            posicionY += SaltoLinea;
            posicionY += 10;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            var _Articulo18_Inciso_A_Nota = new Paragraph(10, posicionY, ConstantesCreditos._Articulo18_Inciso_A_Nota, textoColorNegro, Paragraph.JUSTIFY);

            document.Add(_Articulo18_Inciso_A_Nota);

            // _Articulo18_Inciso_C
            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);


            var _Articulo18_Inciso_C = new Paragraph(10, posicionY, ConstantesCreditos._Articulo18_Inciso_C, textoColorNegro, Paragraph.JUSTIFY);
            _Articulo18_Inciso_C.AnchoJustificado = 190;
            document.Add(_Articulo18_Inciso_C);

            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            Paso = 1;
            Articulos = _Lista.FindAll(x => x.ArticuloVinculacion.Equals((int)ConstantesCreditos.Articulo.Articulo18) && x.IncisoVinculacion.Equals(nameof(ConstantesCreditos.Inciso.C)));
            CrearTablaGenerica(2, Articulos, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF);

            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            //__Articulo19_Titulo
            posicionY += SaltoLinea;
            var __Articulo19_Titulo = new Paragraph(10, posicionY, ConstantesCreditos._Articulo19_Titulo, textoColorNegrilla, Paragraph.JUSTIFY);
            document.Add(__Articulo19_Titulo);
            // _Articulo19_Inciso_C
            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            var _Articulo19_Inciso_C = new Paragraph(10, posicionY, ConstantesCreditos._Articulo19_Inciso_C, textoColorNegro, Paragraph.JUSTIFY);
            _Articulo19_Inciso_C.AnchoJustificado = 190;
            document.Add(_Articulo19_Inciso_C);

            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            Paso = 1;
            Articulos = _Lista.FindAll(x => x.ArticuloVinculacion.Equals((int)ConstantesCreditos.Articulo.Articulo19) && x.IncisoVinculacion.Equals(nameof(ConstantesCreditos.Inciso.C)));
            CrearTablaGenerica(3, Articulos, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF);

            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += 10;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            var _Articulo19_Inciso_C_Nota = new Paragraph(10, posicionY, ConstantesCreditos._Articulo19_Inciso_C_Nota, textoColorNegro, Paragraph.JUSTIFY);

            document.Add(_Articulo19_Inciso_C_Nota);


            //__Articulo20_Titulo
            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += SaltoLinea;
            var __Articulo20_Titulo = new Paragraph(10, posicionY, ConstantesCreditos._Articulo20_Titulo, textoColorNegrilla, Paragraph.JUSTIFY);
            document.Add(__Articulo20_Titulo);
            // _Articulo20_Inciso_A
            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);


            var _Articulo20_Inciso_A = new Paragraph(10, posicionY, ConstantesCreditos._Articulo20_Inciso_A, textoColorNegro, Paragraph.JUSTIFY);
            _Articulo20_Inciso_A.AnchoJustificado = 190;
            document.Add(_Articulo20_Inciso_A);

            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            Paso = 1;
            Articulos = _Lista.FindAll(x => x.ArticuloVinculacion.Equals((int)ConstantesCreditos.Articulo.Articulo20) && x.IncisoVinculacion.Equals(nameof(ConstantesCreditos.Inciso.A)));
            CrearTablaGenerica(4, Articulos, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF);


            // _Articulo20_Inciso_B
            posicionY += SaltoLinea;
            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            var _Articulo20_Inciso_B = new Paragraph(10, posicionY, ConstantesCreditos._Articulo20_Inciso_B, textoColorNegro, Paragraph.JUSTIFY);
            _Articulo20_Inciso_A.AnchoJustificado = 190;
            document.Add(_Articulo20_Inciso_B);

            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            Paso = 1;
            Articulos = _Lista.FindAll(x => x.ArticuloVinculacion.Equals((int)ConstantesCreditos.Articulo.Articulo20) && x.IncisoVinculacion.Equals(nameof(ConstantesCreditos.Inciso.B)));
            CrearTablaGenerica(5, Articulos, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF);
            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);


            // _Articulo20_Inciso_C
            posicionY += SaltoLinea;
            var _Articulo20_Inciso_C = new Paragraph(10, posicionY, ConstantesCreditos._Articulo20_Inciso_C, textoColorNegro, Paragraph.JUSTIFY);
            _Articulo20_Inciso_A.AnchoJustificado = 190;
            document.Add(_Articulo20_Inciso_C);

            posicionY += SaltoLinea;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            Paso = 1;
            Articulos = _Lista.FindAll(x => x.ArticuloVinculacion.Equals((int)ConstantesCreditos.Articulo.Articulo20) && x.IncisoVinculacion.Equals(nameof(ConstantesCreditos.Inciso.C)));
            CrearTablaGenerica(6, Articulos, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF);
            posicionY += SaltoLinea;
            int Auxpage = pagePDF;
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            #endregion


            #region JURAMENTO
            if (Auxpage.Equals(pagePDF))
            {
                HacerSaltoPagina(ref pagePDF, ref posicionY, ref document);
            }
            posicionYFirma = posicionY;

            /// Juramento
            string Juramento = ConstantesCreditos._Juramento;
            Juramento = Juramento.Replace(ConstantesCreditos._Nombre, Cliente);
            string NombreMes = DateTime.Now.ToString(ConstantesCreditos._Mes, CultureInfo.CreateSpecificCulture(ConstantesCreditos._Idioma));
            Juramento = Juramento.Replace(ConstantesCreditos._fecha, (DateTime.Now.Day.ToString() + " de " + NombreMes));
            Juramento = Juramento.Replace(ConstantesCreditos._ano, DateTime.Now.Year.ToString());
            Juramento = Juramento.Replace(ConstantesCreditos._Hora, DateTime.Now.ToString(ConstantesCreditos._formatoHora));
            var _Juramento = new Paragraph(10, posicionY, Juramento, textoColorNegro, Paragraph.JUSTIFY);
            _Juramento.AnchoJustificado = 190;
            document.Add(_Juramento);
            #endregion


            #region firma y cedula
            // firma y cedula

            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += 10;
            CrearTablaGenerica(7, null, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF, Cedula);
            #endregion



            #region NOTAS

            // Notas
            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += 10;
            var _Notas = new Paragraph(10, posicionY, ConstantesCreditos._notas, textoColorNegrilla, Paragraph.JUSTIFY);
            _Notas.AnchoJustificado = 190;
            document.Add(_Notas);

            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += 10;
            var _Nota1 = new Paragraph(10, posicionY, ConstantesCreditos._Nota1, textoColorNegro, Paragraph.JUSTIFY);
            _Nota1.AnchoJustificado = 190;
            document.Add(_Nota1);

            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += SaltoLinea;

            var _Nota2 = new Paragraph(10, posicionY, ConstantesCreditos._Nota2, textoColorNegro, Paragraph.JUSTIFY);
            _Nota2.AnchoJustificado = 190;
            document.Add(_Nota2);

            VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += SaltoLinea;

            var _Nota3 = new Paragraph(10, posicionY, ConstantesCreditos._Nota3, textoColorNegro, Paragraph.JUSTIFY);
            _Nota3.AnchoJustificado = 190;
            document.Add(_Nota3);

            #endregion





            #region Encabezado de pagina

            for (int x = 1; x <= pagePDF; x++)
            {
                int AuxPosicionY = 5;
                CrearEncabezado(x, ref AuxPosicionY, ref document, pagePDF);
            }


            #endregion

            //var bytes = CargarFirma(ruta, Base64Firma, ref document, Cedula, 90, posicionYFirma + 100, pagePDF);

            return document.Close();
        }

        public string CalcularAltoCelda(string texto, int tamanoFragmento, ref int cellHeight, int altoCelda)
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

        public void CrearTablaGenerica(int Orden, List<DatosFormularioGie> Datos, ref Document document, ref int nPage, ref int posiciony, ref int paso, ref int pagePDF, string Cedula = "")
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

        public  List<DatosFormularioGie> Lista()
        {

            List<DatosFormularioGie> Datos = new List<DatosFormularioGie>();


            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 18,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "A",
                NombreCliente = "Allember Palacios A",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 18,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "A",
                NombreCliente = "Allember Palacios B",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });


            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 18,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "C",
                NombreCliente = "Allember Palacios 18 C",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 18,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "C",
                NombreCliente = "Allember Palacios 18 C",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 19,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "C",
                NombreCliente = "Allember Palacios D",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 19,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "C",
                NombreCliente = "Allember Palacios E",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 20,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "A",
                NombreCliente = "Allember Palacios F",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 20,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "A",
                NombreCliente = "Allember Palacios G",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 20,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "B",
                NombreCliente = "Allember Palacios H",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 20,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "B",
                NombreCliente = "Allember Palacios H",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 20,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "C",
                NombreCliente = "Allember Palacios H",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 20,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "C",
                NombreCliente = "Allember Palacios H",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 18,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "A",
                NombreCliente = "Allember Palacios A",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 18,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "A",
                NombreCliente = "Allember Palacios B",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });


            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 18,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "C",
                NombreCliente = "Allember Palacios 18 C",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 18,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "C",
                NombreCliente = "Allember Palacios 18 C",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 19,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "C",
                NombreCliente = "Allember Palacios D",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 19,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "C",
                NombreCliente = "Allember Palacios E",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 20,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "A",
                NombreCliente = "Allember Palacios F",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 20,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "A",
                NombreCliente = "Allember Palacios G",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 20,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "B",
                NombreCliente = "Allember Palacios H",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 20,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "B",
                NombreCliente = "Allember Palacios H",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 20,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "C",
                NombreCliente = "Allember Palacios H",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });

            Datos.Add(new DatosFormularioGie
            {
                Id = Guid.NewGuid(),
                ArticuloVinculacion = 20,
                IdentificacionIntegrante = "987654321",
                IdPuesto = "02",
                IdSolicitud = 123,
                IdTipoRelacion = "02",
                IncisoVinculacion = "C",
                NombreCliente = "Allember Palacios H",
                Puesto = "Product Owner",
                TipoRelacion = "Oficial QA"
            });



            return Datos;


        }

        private void CrearEncabezado(int pagePDF, ref int posicionY, ref Document document, int TotalPagina)
        {
            document.SetPage(pagePDF);

            string ruta = ConstantesCreditos._Logo;

            var image = new Image(30, ruta, 12, 12);
            image.ScaleX = 30;
            image.ScaleY = 12;

            int Aux = posicionY;

            var fontTextoCabecera = FontFactory.GetFont(Font.Family.Arial, 12, Font.NORMAL, BaseColor.BLACK);

            var HorizontalAlignmentTitulos = Element.ALIGN_CENTER;

            var VerticalAlignmentTitulos = Element.V_ALIGN_TOP;

            var fontTexto = FontFactory.GetFont(Font.Family.Arial, 6, Font.NORMAL, BaseColor.BLACK);


            int altoCelda = 0;

            PdfTable tabla = new PdfTable(new float[] { 35, 120, 40 }, 10, posicionY);
            tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda("", 35, ref altoCelda, 8), fontTextoCabecera) });
            tabla.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._NombreFormulario, 120, ref altoCelda, 8), fontTextoCabecera) });
            tabla.AddCell(new PdfPCell() { VerticalAlignment = VerticalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._CodigoFormulario, 35, ref altoCelda, 8), fontTextoCabecera) });

            posicionY += altoCelda;

            tabla.CellHeight = altoCelda;
            document.Add(tabla);
            document.AddImage(image);

            altoCelda = 0;
            PdfTable table = new PdfTable(new float[] { 30, 10 }, 165, Aux + 15);
            string Pages = ConstantesCreditos._Pagina;
            Pages = Pages.Replace(ConstantesCreditos._Inicio, pagePDF.ToString()).Replace(ConstantesCreditos._Fin, TotalPagina.ToString());
            table.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(Pages, 30, ref altoCelda, 3), fontTexto) });
            table.AddCell(new PdfPCell() { HorizontalAlignment = HorizontalAlignmentTitulos, phrase = new Phrase(CalcularAltoCelda(ConstantesCreditos._Edicion, 10, ref altoCelda, 3), fontTexto) });
            table.CellHeight = altoCelda;
            document.Add(table);


        }


        private void VerificarSaltoPagina(ref int pagePDF, ref int posicionY, ref Document document)
        {
            if (posicionY >= 240)
            {
                pagePDF++;
                document.AddNewPage(PageSize.LETTER, Orientation.portrait);
                document.SetPage(pagePDF);
                posicionY = 40;
            }
        }

        private void HacerSaltoPagina(ref int pagePDF, ref int posicionY, ref Document document)
        {

            pagePDF++;
            document.AddNewPage(PageSize.LETTER, Orientation.portrait);
            document.SetPage(pagePDF);
            posicionY = 40;
        }




        private byte[] CargarFirma(string ruta, string Base64, ref Document document, string Cedula, int PosicionX, int PosicionY, int Page)
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

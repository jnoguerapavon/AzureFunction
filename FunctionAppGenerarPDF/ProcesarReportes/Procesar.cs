using BNCR.Documento.PDF.BL;
using BNCR.GeneradorPDF;
using BNCR.GeneradorPDF.text;
using BNCR.GeneradorPDF.text.pdf;
using FunctionAppGenerarPDF.Clases;
using FunctionAppGenerarPDF.Utilitarios;
using Microsoft.ClearScript.JavaScript;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction.ProcesarReportes
{
    public static class Procesar
    {
        public static async Task<byte[]> GenerarBytesIRCTradicional(string ruta, string? Cliente, string? Identificacion, List<DatosIrc> _Lista)
        {
            #region FORMATOS
            int pagePDF = 1;
            Document document = new Document(PageSize.LETTER, Orientation.portrait);
            document.Open();
            var textoColorNegrilla = FontFactory.GetFont(Font.Family.Arial, 12, Font.BOLD, BaseColor.BLACK);
            #endregion



            #region Titulos
            var titulo1 = new Paragraph(75, 40, "Dirección de Riesgos de Crédito", textoColorNegrilla, Paragraph.CENTER);
            var titulo2 = new Paragraph(75, 50, "Carátula única de crédito", textoColorNegrilla, Paragraph.CENTER);

            document.Add(titulo1);
            document.Add(titulo2);
            #endregion



            #region Encabezado de pagina

            for (int x = 1; x <= pagePDF; x++)
            {
                int AuxPosicionY = 5;
                Utils.CrearEncabezado(ConstantesCreditos._NombreCaratulaCredito,x, ref AuxPosicionY, ref document, pagePDF);
            }


            #endregion


            return document.Close(); 
        }



        public static async Task<byte[]> GenerarBytesFormularioGie(string ruta, string? Cliente, string? Identificacion, List<DatosFormularioGie> _Lista)
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
            var _Cedula_Identidad_Label = new Paragraph(10, 115, Cedula_.Replace(ConstantesCreditos._cedula_D, Identificacion), textoColorNegro, Paragraph.LEFT);
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
            Utils.CrearTablaGenerica(1, Articulos, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF);

            posicionY += SaltoLinea;
            posicionY += 10;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            var _Articulo18_Inciso_A_Nota = new Paragraph(10, posicionY, ConstantesCreditos._Articulo18_Inciso_A_Nota, textoColorNegro, Paragraph.JUSTIFY);

            document.Add(_Articulo18_Inciso_A_Nota);

            // _Articulo18_Inciso_C
            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);


            var _Articulo18_Inciso_C = new Paragraph(10, posicionY, ConstantesCreditos._Articulo18_Inciso_C, textoColorNegro, Paragraph.JUSTIFY);
            _Articulo18_Inciso_C.AnchoJustificado = 190;
            document.Add(_Articulo18_Inciso_C);

            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            Paso = 1;
            Articulos = _Lista.FindAll(x => x.ArticuloVinculacion.Equals((int)ConstantesCreditos.Articulo.Articulo18) && x.IncisoVinculacion.Equals(nameof(ConstantesCreditos.Inciso.C)));
            Utils.CrearTablaGenerica(2, Articulos, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF);

            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            //__Articulo19_Titulo
            posicionY += SaltoLinea;
            var __Articulo19_Titulo = new Paragraph(10, posicionY, ConstantesCreditos._Articulo19_Titulo, textoColorNegrilla, Paragraph.JUSTIFY);
            document.Add(__Articulo19_Titulo);
            // _Articulo19_Inciso_C
            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            var _Articulo19_Inciso_C = new Paragraph(10, posicionY, ConstantesCreditos._Articulo19_Inciso_C, textoColorNegro, Paragraph.JUSTIFY);
            _Articulo19_Inciso_C.AnchoJustificado = 190;
            document.Add(_Articulo19_Inciso_C);

            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            Paso = 1;
            Articulos = _Lista.FindAll(x => x.ArticuloVinculacion.Equals((int)ConstantesCreditos.Articulo.Articulo19) && x.IncisoVinculacion.Equals(nameof(ConstantesCreditos.Inciso.C)));
            Utils.CrearTablaGenerica(3, Articulos, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF);

            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += 10;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            var _Articulo19_Inciso_C_Nota = new Paragraph(10, posicionY, ConstantesCreditos._Articulo19_Inciso_C_Nota, textoColorNegro, Paragraph.JUSTIFY);

            document.Add(_Articulo19_Inciso_C_Nota);


            //__Articulo20_Titulo
            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += SaltoLinea;
            var __Articulo20_Titulo = new Paragraph(10, posicionY, ConstantesCreditos._Articulo20_Titulo, textoColorNegrilla, Paragraph.JUSTIFY);
            document.Add(__Articulo20_Titulo);
            // _Articulo20_Inciso_A
            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);


            var _Articulo20_Inciso_A = new Paragraph(10, posicionY, ConstantesCreditos._Articulo20_Inciso_A, textoColorNegro, Paragraph.JUSTIFY);
            _Articulo20_Inciso_A.AnchoJustificado = 190;
            document.Add(_Articulo20_Inciso_A);

            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            Paso = 1;
            Articulos = _Lista.FindAll(x => x.ArticuloVinculacion.Equals((int)ConstantesCreditos.Articulo.Articulo20) && x.IncisoVinculacion.Equals(nameof(ConstantesCreditos.Inciso.A)));
            Utils.CrearTablaGenerica(4, Articulos, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF);


            // _Articulo20_Inciso_B
            posicionY += SaltoLinea;
            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            var _Articulo20_Inciso_B = new Paragraph(10, posicionY, ConstantesCreditos._Articulo20_Inciso_B, textoColorNegro, Paragraph.JUSTIFY);
            _Articulo20_Inciso_A.AnchoJustificado = 190;
            document.Add(_Articulo20_Inciso_B);

            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            Paso = 1;
            Articulos = _Lista.FindAll(x => x.ArticuloVinculacion.Equals((int)ConstantesCreditos.Articulo.Articulo20) && x.IncisoVinculacion.Equals(nameof(ConstantesCreditos.Inciso.B)));
            Utils.CrearTablaGenerica(5, Articulos, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF);
            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);


            // _Articulo20_Inciso_C
            posicionY += SaltoLinea;
            var _Articulo20_Inciso_C = new Paragraph(10, posicionY, ConstantesCreditos._Articulo20_Inciso_C, textoColorNegro, Paragraph.JUSTIFY);
            _Articulo20_Inciso_A.AnchoJustificado = 190;
            document.Add(_Articulo20_Inciso_C);

            posicionY += SaltoLinea;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);

            Paso = 1;
            Articulos = _Lista.FindAll(x => x.ArticuloVinculacion.Equals((int)ConstantesCreditos.Articulo.Articulo20) && x.IncisoVinculacion.Equals(nameof(ConstantesCreditos.Inciso.C)));
            Utils.CrearTablaGenerica(6, Articulos, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF);
            posicionY += SaltoLinea;
            int Auxpage = pagePDF;
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            #endregion


            #region JURAMENTO
            if (Auxpage.Equals(pagePDF))
            {
                Utils.HacerSaltoPagina(ref pagePDF, ref posicionY, ref document);
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

            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += 10;
            Utils.CrearTablaGenerica(7, null, ref document, ref nPage, ref posicionY, ref Paso, ref pagePDF, Identificacion);
            #endregion



            #region NOTAS

            // Notas
            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += 10;
            var _Notas = new Paragraph(10, posicionY, ConstantesCreditos._notas, textoColorNegrilla, Paragraph.JUSTIFY);
            _Notas.AnchoJustificado = 190;
            document.Add(_Notas);

            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += 10;
            var _Nota1 = new Paragraph(10, posicionY, ConstantesCreditos._Nota1, textoColorNegro, Paragraph.JUSTIFY);
            _Nota1.AnchoJustificado = 190;
            document.Add(_Nota1);

            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += SaltoLinea;

            var _Nota2 = new Paragraph(10, posicionY, ConstantesCreditos._Nota2, textoColorNegro, Paragraph.JUSTIFY);
            _Nota2.AnchoJustificado = 190;
            document.Add(_Nota2);

            Utils.VerificarSaltoPagina(ref pagePDF, ref posicionY, ref document);
            posicionY += SaltoLinea;

            var _Nota3 = new Paragraph(10, posicionY, ConstantesCreditos._Nota3, textoColorNegro, Paragraph.JUSTIFY);
            _Nota3.AnchoJustificado = 190;
            document.Add(_Nota3);

            #endregion





            #region Encabezado de pagina

            for (int x = 1; x <= pagePDF; x++)
            {
                int AuxPosicionY = 5;
                Utils.CrearEncabezado(ConstantesCreditos._NombreFormulario, x, ref AuxPosicionY, ref document, pagePDF);
            }


            #endregion


            return document.Close();
        }


    }
}

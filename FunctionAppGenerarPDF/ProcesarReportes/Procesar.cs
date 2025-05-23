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

            #region Encabezado de pagina

            for (int x = 1; x <= pagePDF; x++)
            {
                int AuxPosicionY = 5;
                Utils.CrearEncabezado(x, ref AuxPosicionY, ref document, pagePDF);
            }


            #endregion


            return document.Close(); 
        }



        public static async Task<byte[]> GenerarBytesFormularioGie(string ruta, string? Cliente, string? Identificacion, List<DatosFormularioGie> _Lista)
        {
            #region FORMATOS
            int pagePDF = 1;
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

            #region Encabezado de pagina

            for (int x = 1; x <= pagePDF; x++)
            {
                int AuxPosicionY = 5;
                Utils.CrearEncabezado(x, ref AuxPosicionY, ref document, pagePDF);
            }


            #endregion


            return document.Close();
        }


    }
}

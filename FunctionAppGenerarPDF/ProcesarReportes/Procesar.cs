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


    }
}

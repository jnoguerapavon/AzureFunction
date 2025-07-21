using BNCR.Documento.PDF.BL;
using BNCR.GeneradorPDF;
using BNCR.GeneradorPDF.text;
using BNCR.GeneradorPDF.text.pdf;
using FunctionAppGenerarPDF.Clases;
using FunctionAppGenerarPDF.Clases.IRC;
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
            int nPage = 1;
            int Paso = 1;
            int pagePDF = 1;
            int posicionY =25;
            Document document = new Document(PageSize.LETTER, Orientation.portrait);
            document.Open();
            #endregion



            #region Titulos


            Utils.CrearTitulos(ref document, ref posicionY,false, "Dirección de Riesgos de Crédito",8);
            #endregion

            #region Aparatado0
            Utils.CrearApartado0(ref document, ref posicionY, _Lista?.FirstOrDefault());
            #endregion


            Utils.CrearTitulos(ref document, ref posicionY, true, "1. Información del (los) Solicitante(s)",8);

            #region Aparatado1
            Utils.CrearApartado1(ref document, ref posicionY, _Lista?.FirstOrDefault(),ref nPage,ref Paso,ref pagePDF);
            #endregion

            Utils.CrearFila(ref document, ref posicionY, new float[] { 30, 170 },  "Códigos con el BNCR (Observaciones)" , _Lista?.FirstOrDefault());

            Utils.CrearTitulos(ref document, ref posicionY, true, "2. Detalle del Grupo de Interés Económico Detalle del Grupo de Interés Económico \n(En caso de llevar Análisis Financiero el detalle del GIE en debe incluir en el informe financiero, no así en la carátula) ",12);



            #region Encabezado de pagina

            for (int x = 1; x <= pagePDF; x++)
            {
                int AuxPosicionY = 5;
                Utils.AgregarLogo(ConstantesCreditos._NombreCaratulaCredito,x, ref AuxPosicionY, ref document, pagePDF);
            }


            #endregion


            return document.Close(); 
        }


    }
}

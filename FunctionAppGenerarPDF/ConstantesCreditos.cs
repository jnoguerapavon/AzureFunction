using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction
{
    public class ConstantesCreditos
    {

        #region Encabezado

        internal const string _Logo = "images/bnlogoani.jpg";
        internal const string _NombreFormulario =      "Nombre:                                                                              DECLARACIÓN JURADA GRUPO INTERÉS ECONÓMICO (PERSONA FÍSICA)";
        internal const string _NombreCaratulaCredito = "Nombre:                                                                                                                Carátula única de crédito";
        internal const string _RutaDescargas = "ContentStaticIB/Descargas/";
        internal const string _CodigoFormulario = "Código: RE24-PR21GR02";
        internal const string _Pagina = "Página: Página @Inicio de @Fin";
        internal const string _Edicion = "Edición: 06";
        internal const string _Inicio = "@Inicio";
        internal const string _Fin = "@Fin";
        internal const string _Extension = ".pdf";
        #endregion

        #region Titulos
        internal const string _Declaracion = "DECLARACIÓN JURADA (1)";
        internal const string _Persona_Fisica = "PERSONA FÍSICA";
        internal const string _Acuerdo = "ACUERDO SUGEF 4-22";
        internal const string _Reglamento = "REGLAMENTO SOBRE GRUPOS DE INTERÉS ECONÓMICO";
        #endregion

        #region Contenido
        internal const string _Parrafo1 = "Para cumplir con lo establecido en el REGLAMENTO SOBRE  GRUPOS DE INTERÉS ECONÓMICO, Acuerdo SUGEF 4-22 de la Superintendencia General de Entidades Financieras, me permito brindar al Banco Nacional de Costa Rica la siguiente información :";
        internal const string _Nombre_Declarante_Label = "Nombre del declarante: @Nombre";
        internal const string _Cedula_Identidad_Label = "Número de Cédula de identidad: @Cedula";

        internal const string _Parrafo2 = "La presente constituye una declaración jurada y por ende, cualquier manifestación falsa será penada con base en el Código Penal, artículo 311 (perjurio): “Se impondrá prisión de tres meses a dos años  al que faltare a la verdad cuando la ley le impone bajo juramento o declaración jurada, la obligación de decirla con relación a hechos propios”.";



        #endregion

        #region Articulos
        internal const string _Articulo16_Titulo = "Artículo 16. Identificación de un grupo de interés económico";

        internal const string _Articulo18_Titulo = "Artículo 18. Relación financiera significativa.";
        internal const string _Articulo18_Inciso_A = "Inciso a) Con cuál persona física o jurídica se origina el 40% o más del monto de las ventas o de las compras de productos y servicios, monto que se determina sobre una base anual conformada por los últimos cuatro trimestres calendario?.";
        internal const string _Articulo18_Inciso_A_NOMBRE = "NOMBRE PERSONA FISICA O JURIDICA";
        internal const string _Articulo18_Inciso_A_CEDULA = " No.DE CEDULA";
        internal const string _Articulo18_Inciso_A_RELACION = "TIPO RELACIÓN";
        internal const string _Articulo18_Inciso_A_Nota = "Nota: Tipo relación: Indicar compras, ventas o ambas.";


        internal const string _Articulo18_Inciso_C = "Inciso c) Con cuál(es) personas físicas o jurídicas tienen financiamientos donde usted figure como codeudor?";
        internal const string _Articulo18_Inciso_C_NOMBRE = "NOMBRE PERSONA FISICA O JURIDICA";
        internal const string _Articulo18_Inciso_C_CEDULA = "No.DE CEDULA";


        internal const string _Articulo19_Titulo = "Artículo 19. Relación administrativa significativa.";
        internal const string _Articulo19_Inciso_C = "Inciso c) De cuáles personas jurídicas es apoderado generalísimo o gerente?.";
        internal const string _Articulo19_Inciso_C_NOMBRE = "NOMBRE PERSONA FISICA O JURIDICA";
        internal const string _Articulo19_Inciso_C_CEDULA = " No.DE CEDULA";
        internal const string _Articulo19_Inciso_C_PUESTO = "PUESTO (*)";
        internal const string _Articulo19_Inciso_C_Nota = "Nota(*) : PUESTO(Indicar si es apoderado generalísimo o gerente).";

        internal const string _Articulo20_Titulo = "Artículo 20. Relación Patrimonial significativa.";
        internal const string _Articulo20_Inciso_A = "Inciso a) En cuáles personas jurídicas participa, como persona física, con el 15% o más del capital social. Para determinar su participación en el capital social, se le sumarán las participaciones individuales que controlan quienes mantienen relaciones de parentesco con el declarante. (Ver nota N° 2, al pie de este documento).";
        internal const string _Articulo20_Inciso_A_NOMBRE = "NOMBRE PERSONA JURIDICA";
        internal const string _Articulo20_Inciso_A_CEDULA = "No. DE CEDULA";


        internal const string _Articulo20_Inciso_B = "Inciso b) En cuáles personas jurídicas participa, como persona física, con el 5% o más del capital social. Para determinar su participación en el capital social, se le sumarán las participaciones individuales que controlan quienes mantienen relaciones de parentesco con el declarante. (Ver nota N° 2, al pie de este documento).";
        internal const string _Articulo20_Inciso_B_NOMBRE = "NOMBRE PERSONA JURIDICA";
        internal const string _Articulo20_Inciso_B_CEDULA = "No. DE CEDULA";

        internal const string _Articulo20_Inciso_C = "Inciso c) Con cuáles sociedades de personas (sociedad en nombre colectivo o en comandita), el declarante tiene una relación de socio?.";
        internal const string _Articulo20_Inciso_C_NOMBRE = "NOMBRE SOCIEDAD";
        internal const string _Articulo20_Inciso_C_CEDULA = "No. DE CEDULA";



        #endregion

        #region juramento

        internal const string _Juramento = "Yo,  @Nombre , bajo la gravedad del juramento, declaro que la información suministrada es correcta y verdadera. Firmo en la Ciudad de San Jose a las @Hora horas, del día @fecha del @ano.";
        internal const string _Nombre = "@Nombre";
        internal const string _Hora = "@Hora";
        internal const string _fecha = "@fecha";
        internal const string _ano = "@ano";
        internal const string _formatoFecha = "d";
        internal const string _formatoHora = "HH:mm";
        internal const string _cedula_D = "@Cedula";
        internal const string _Mes = "MMMM";
        internal const string _Idioma = "es-MX";
        #endregion

        #region firma

        internal const string _Firma = "Firma del Cliente";
        internal const string _cedula = "No. De Cédula: ";

        #endregion


        #region notas

        internal const string _notas = "NOTAS:";

        internal const string _Nota1 = "(1)Declaración basada en el acuerdo SUGEF 4-22 “ Reglamento sobre Grupos de Interés Económico“, aprobado por el Consejo Nacional de Supervisión del Sistema Financiero en Sesión 1776-2022  del 19 de diciembre del 2022, la cual entrará en vigencia a partir del 1º de enero de 2024.";
        internal const string _Nota2 = "(2)Parientes por consanguinidad hasta segundo grado: hijos, padres, hermanos, abuelos y nietos. Parientes por afinidad hasta segundo grado: cónyuges, suegros, abuelos, nueras y yernos; y cuñados (hermanos del cónyuge).";
        internal const string _Nota3 = "(3)De requerirse mayor espacio, favor incluir hojas adicionales haciendo referencia  a los numerales a que corresponde la información.";



        #endregion


        public enum Inciso
        {
            A = 1,
            B = 2,
            C = 3
        };
        public enum Articulo
        {
            Articulo18 = 18,
            Articulo19 = 19,
            Articulo20 = 20
        };










    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Framework.Funciones
{
    /// <summary>
    /// Contiene funciones para el manejo de cadenas.
    /// </summary>
    public static class Cadenas
    {

        /// <summary>
        /// Separa una cadena en base al parametro separador.
        /// Si no se encuentran resultados, se devuelve una lista count cero.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="campoSeparador"></param>
        /// <returns></returns>
        public static List<String> Parsear(String texto, String campoSeparador)
        {
            var resultado = texto.Split(new String[] { campoSeparador }, StringSplitOptions.RemoveEmptyEntries);

            return resultado.ToList();
        }

        /// <summary>
        /// Recibe una lista y la une devolviendo una cadena.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="campoSeparador"></param>
        /// <returns></returns>
        public static String UnirLista(List<String> lista, String campoSeparador)
        {
            var resultado = String.Join(campoSeparador, lista.ToArray());

            return resultado;
        }

        /// <summary>
        /// Recibe una lista y le agrega un decorado a la derecha e izquierda.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="decoradoIzquierda"></param>
        /// <param name="decoradoDerecha"></param>
        /// <returns></returns>
        public static List<String> DecorarLista(List<String> lista, String decoradoIzquierda, String decoradoDerecha)
        {
            var resultado = lista.Select(s => decoradoIzquierda + s + decoradoDerecha).ToList();

            return resultado;
        }

        /// <summary>
        /// Devuelve el texto ubicado entre las marcas indicadas.
        /// Tener en cuenta que la marca de fin se busca siempre empezando despues de la marca de inicio.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="marcaInicio"></param>
        /// <param name="marcaFin"></param>
        /// <returns></returns>
        public static String TextoEntreMarcas(String texto, String marcaInicio, String marcaFin)
        {
            var resultado = TextoSinBasuraDerecha(TextoSinBasuraIzquierda(texto, marcaInicio), marcaFin);

            return resultado;
        }

        /// <summary>
        /// Devuelve el texto ingresado borrando todo caracter que se encuentre a la izquierda de la marca.
        /// Atencion, la marca no se devuelve en el resultado.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="marcaIzquierda"></param>
        /// <returns></returns>
        public static String TextoSinBasuraIzquierda(String texto, String marcaIzquierda)
        {
            var marcaInicio = texto.IndexOf(marcaIzquierda);

            if (marcaInicio == -1) return "";

            return texto.Substring(marcaInicio + marcaIzquierda.Length);
        }

        /// <summary>
        /// Devuelve el texto ingresado borrando todo caracter que se encuentre a la derecha de la marca.
        /// Atencion, la marca no se devuelve en el resultado.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="marcaDerecha"></param>
        /// <returns></returns>
        public static String TextoSinBasuraDerecha(String texto, String marcaDerecha)
        {
            var marcaFin = texto.IndexOf(marcaDerecha);

            if (marcaFin == -1) return "";

            return texto.Substring(0, marcaFin);
        }

        /// <summary>
        /// Permite formatear una cadena que tenga comodines estilo {0} {1}
        /// </summary>
        /// <param name="textoPatron"></param>
        /// <param name="campos"></param>
        /// <returns></returns>
        public static String Formatear(String textoPatron, params Object[] campos)
        {
            return String.Format(textoPatron, campos);
        }

        /// <summary>
        /// Realiza reemplazos dentro de la cadena.
        /// </summary>
        /// <param name="texto">Texto original</param>
        /// <param name="textoBuscar">Texto a buscar</param>
        /// <param name="textoReemplazar">Texto nuevo</param>
        /// <returns></returns>
        public static String Reemplazar(String texto, String textoBuscar, String textoReemplazar)
        {
            return Reemplazar(texto, textoBuscar, textoReemplazar, false);
        }

        /// <summary>
        /// Realiza reemplazos dentro de la cadena, pudiendo indicar si debe contemplar case sensitive.
        /// </summary>
        /// <param name="texto">Texto original</param>
        /// <param name="textoBuscar">Texto a buscar</param>
        /// <param name="textoReemplazar">Texto nuevo</param>
        /// <param name="ignorarCase">True para reemplazar aun encontrando diferencias de mayusculas.</param>
        /// <returns></returns>
        public static String Reemplazar(String texto, String textoBuscar, String textoReemplazar, Boolean ignorarCase)
        {
            if (ignorarCase)
            {
                return Regex.Replace(texto, textoBuscar, textoReemplazar, RegexOptions.IgnoreCase);
            }
            else
            {
                return texto.Replace(textoBuscar, textoReemplazar);
            }
        }

        /// <summary>
        /// En base a un texto que tiene dos patrones señaladores, reemplaza el contenido del medio de los patrones por el texto a reemplazar.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="marcaIzquierda"></param>
        /// <param name="marcaDerecha"></param>
        /// <param name="textoReemplazar"></param>
        /// <returns></returns>
        public static String ReemplazarEntreMarcas(String texto, String marcaIzquierda, String marcaDerecha, String textoReemplazar)
        {
            var textoEntreMarcas = marcaIzquierda + TextoEntreMarcas(texto, marcaIzquierda, marcaDerecha) + marcaDerecha;

            return Reemplazar(texto, textoEntreMarcas, textoReemplazar);
        }


        /// <summary>
        /// Devuelve el asqui del valor ingresado.
        /// </summary>
        /// <param name="caracter"></param>
        /// <returns></returns>
        public static Int32 ObtenerAscii(char caracter)
        {
            var valorAsci = Encoding.ASCII.GetBytes(new char[] { caracter }).First();
            return valorAsci;
        }

        /// <summary>
        /// Recibe una cadena con multiples mayusculas y espacios y devuelve solo las mayusculas.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static String ObtenerSoloMayusculas(String texto)
        {
            var resultado = "";

            foreach (var item in texto)
            {
                if (ObtenerAscii(item) >= 65 && ObtenerAscii(item) <= 90)
                {
                    resultado += item;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Recibe una lista y le quita el decorado que tenga.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="decoradoPorQuitar"></param>
        /// <returns></returns>
        public static List<String> QuitarDecoradoLista(List<String> lista, String decoradoPorQuitar)
        {
            var resultado = new List<String>();

            foreach (var item in lista)
            {
                resultado.Add(item.Replace(decoradoPorQuitar, ""));
            }

            return resultado;
        }

        /// <summary>
        /// Recibe una cadena, devuelve los N caracteres contados indicados.
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="cantidadCaracteres"></param>
        /// <returns></returns>
        public static String TruncarCadena(String cadena, Int32 cantidadCaracteres)
        {
            return cadena.Substring(0, cantidadCaracteres);
        }

        /// <summary>
        /// Recibe una cadena y devuelve un resultado siempre distinto a null.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static String TextoSinNulos(String cadena)
        {
            if (String.IsNullOrEmpty(cadena)) return "";

            return cadena;
        }

        /// <summary>
        /// Recibe un Connection String y devuelve el Servicor
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static string ObtenerServidorBD(string connectionString)
        {
            SqlConnectionStringBuilder stringbuilder = new SqlConnectionStringBuilder(connectionString);

            return stringbuilder.DataSource;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Framework.Funciones
{

    /// <summary>
    /// Contiene metodos para realizar conversiones multiples.
    /// </summary>
    public static class Convertidores
    {

        /// <summary>
        /// Recibe una cadena y retorna un array de bytes.
        /// La cadena tiene que ser ASCII.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static Byte[] CadenaABytes(String cadena)
        {
            return Encoding.ASCII.GetBytes(cadena);
        }

        /// <summary>
        /// Recibe una cadena unicode y devuelve bytes.
        /// Cuando una cadena es unicode, tiene el doble de bytes por letra.
        /// </summary>
        /// <param name="cadenaUnicode"></param>
        /// <returns></returns>
        public static Byte[] CadenaUnicodeABytes(String cadenaUnicode)
        {
            //var ueCodigo = new UnicodeEncoding();
            //return ueCodigo.GetBytes(cadenaUnicode);

            return Encoding.Unicode.GetBytes(cadenaUnicode);
        }

        /// <summary>
        /// Recibe un array de bytes y retorna la cadena representante.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static String BytesACadena(Byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }

        /// <summary>
        /// Recibe un array de bytes unicode y los transforma a cadena unicode.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static String BytesUnicodeACadenaUnicode(Byte[] bytes)
        {
            return Encoding.Unicode.GetString(bytes);
        }

        /// <summary>
        /// Transforma un stream en una cadena string.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static String StreamACadena(Stream stream)
        {
            var bytes = new Byte[stream.Length];
            stream.Position = 0;
            stream.Read(bytes, 0, (Int32)stream.Length);

            return BytesACadena(bytes);
        }


        /// <summary>
        /// Devuelve un stream en base a una cadena.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static Stream CadenaAStream(String cadena)
        {
            var bytes = CadenaABytes(cadena);
            return new MemoryStream(bytes);
        }

        /// <summary>
        /// Devuelve un Booleano que sea False a True, si no devuelve False
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string BooleanoASiNo(bool valor)
        {
            return (valor == true) ? "Sí" : "No";
        }
        /// <summary>
        /// Transforma cualquier tipo de cadena a booleano.
        /// Los valores reconocidos como true son: 1, true, True, TRUE.
        /// Cualquier otro se considera falso.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool CadenaABooleano(string cadena)
        {

            switch (cadena.ToLowerInvariant())
            {
                case "1":
                    return true;
                case "true":
                    return true;
                default:
                    return false;

            }
        }

        /// <summary>
        /// Transforma un numero a un numero con cero a la izquierda, mayormente usado para fechas, como 01/09/09
        /// </summary>
        /// <param name="numero">Numero que desea ponerle un cero.</param>
        /// <param name="totalDigitos">Cantidad total de digitos por retornar</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public static string CeroALaIzquierda(double numero, int totalDigitos)
        {
            return ("00000000000000000000000000" + numero).Substring((("00000000000000000000000000" + numero).Length - totalDigitos));

        }


        /// <summary>
        /// Devuelve la fecha actual para ponerla en nombre de archivo.
        /// Ejemplo: "2015-01-09"
        /// </summary>
        /// <returns></returns>
        public static String FechaParaNombreArchivo()
        {
            return FechaParaNombreArchivo(DateTime.Now);
        }

        /// <summary>
        /// Devuelve la fecha indicada en fecha para nombre de archivo.
        /// Ejemplo: "2015-01-09"
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static String FechaParaNombreArchivo(DateTime fecha)
        {
            return fecha.ToString("yyyy-MM-dd", Cultura.ObtenerCultura());
        }


        /// <summary>
        /// Transforma una fecha a un formato de fecha para utilizar en nombres de archivo.
        /// Se devuelve AHORA por defecto.
        /// </summary>
        /// <returns>Devuelve la fecha ingresada en formato de archivo.</returns>
        /// <remarks></remarks>
        public static String FechaAFechaLargaParaArchivo()
        {
            return FechaAFechaLargaParaArchivo(DateTime.Now);
        }

        /// <summary>
        /// Transforma una fecha a un formato de fecha para utilizar en nombres de archivo.
        /// </summary>
        /// <param name="fechaEspecifica">Fecha especifica a transformar.</param>
        /// <returns>Devuelve la fecha ingresada en formato de archivo.</returns>
        /// <remarks></remarks>
        public static String FechaAFechaLargaParaArchivo(DateTime fechaEspecifica)
        {
            return fechaEspecifica.ToString("yyyy-MM-dd-hh-mm-ss", Cultura.ObtenerCultura());
        }


    }

}

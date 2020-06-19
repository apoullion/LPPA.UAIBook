using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Framework.Funciones
{
    /// <summary>
    /// Permite el trabajo con funciones de numeros.
    /// </summary>
    public class Numeros
    {
        /// <summary>
        /// Devuelve un numero en formato amigable.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static String NumeroDecimalEnString(Decimal numero)
        {
            return numero.ToString("n", Cultura.ObtenerCultura());
        }

        /// <summary>
        /// Devuelve un numero en formato moneda.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static String NumeroDecimalEnMonedaString(Decimal numero)
        {
            return numero.ToString("c", Cultura.ObtenerCultura());
        }

        /// <summary>
        /// Devuelve Verdadero o Falso si la variable es un numero o no
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Boolean EsNumero(String valor)
        {
            Regex isnumber = new Regex("[^0-9]");
            return !isnumber.IsMatch(valor);
        }

        /// <summary>
        /// Transforma cualquier numero en Positivo
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Decimal NumeroSiemprePositivo(Decimal numero)
        {
            return Math.Abs(numero);
        }
    }
}

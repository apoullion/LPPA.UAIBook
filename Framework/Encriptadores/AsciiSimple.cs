using Framework.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Encriptadores
{
    /// <summary>
    /// Permite el encriptado con un metodo Ascii simple.
    /// Permite reversion.
    /// </summary>
    public class AsciiSimple : IEncriptador
    {

        /// <summary>
        /// Devuelve la instancia de este encriptador.
        /// </summary>
        /// <returns></returns>
        public static IEncriptador Instancia()
        {
            return new AsciiSimple();
        }

        /// <summary>
        /// Permite encriptar una cadena.
        /// </summary>
        /// <param name="cadena">Ingrese la cadena a encriptar.</param>
        /// <param name="clave">Ingrese una clave.</param>
        /// <returns></returns>
        public string Encriptar(String cadena, String clave)
        {
            var resultado = "";

            var palabraClave = this.GenerarPalabraClave(clave);

            foreach (var item in cadena)
            {
                var letraAscii = Cadenas.ObtenerAscii(item);

                var cantidadLetras = (letraAscii + palabraClave).ToString().Length;

                resultado += cantidadLetras.ToString() + (letraAscii + palabraClave).ToString();
            }

            return resultado;
        }

        /// <summary>
        /// Permite desencriptar una cadena encriptada, siempre y cuando se ingrese la clave correcta.
        /// </summary>
        /// <param name="cadena">Cadena encriptada</param>
        /// <param name="clave">Clave utilizada cuando fue encriptado.</param>
        /// <returns></returns>
        public string DesEncriptar(String cadena, String clave)
        {
            var resultado = "";

            var palabraClave = this.GenerarPalabraClave(clave);

            for (int i = 0; i < cadena.Length; i++)
            {
                var cantidadLetras = Int32.Parse(cadena.Substring(i, 1));

                var elNumero = Int32.Parse(cadena.Substring(i + 1, cantidadLetras));

                var elCaracter = (char)(elNumero - palabraClave);

                resultado += elCaracter;

                i = i + cantidadLetras;
            }

            return resultado;

        }

        /// <summary>
        /// Devuelve un resumen de la cadena ingresada.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public string GenerarHASH(String cadena)
        {
            var aux = "";
            var iPor = 2;

            foreach (var item in cadena)
            {
                iPor = Cadenas.ObtenerAscii(item) * iPor;

                if (iPor > 1000) iPor = Int32.Parse(iPor.ToString().Substring(1, 2));

                aux += (char)(item) + iPor.ToString();
            }
            return aux;
        }



        private Int32 GenerarPalabraClave(String clave)
        {
            var resultado = 0;

            foreach (var item in clave)
            {
                resultado += Cadenas.ObtenerAscii(item);
            }

            return resultado;
        }

    }
}

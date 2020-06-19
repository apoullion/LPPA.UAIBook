using Framework.Excepciones;
using Framework.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Encriptadores
{
    /// <summary>
    /// Permite la encriptacion con un algoritmo seguro md5.
    /// No es un algoritmo reversible.
    /// </summary>
    public class Md5 : IEncriptador
    {
        /// <summary>
        /// Devuelve una instancia de la clase actual.
        /// </summary>
        /// <returns></returns>
        public static IEncriptador Instancia()
        {
            return new Md5();
        }

        /// <summary>
        /// Permite encriptar una cadena con este algoritmo.
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public string Encriptar(string cadena, string clave)
        {
            return GenerarHASH(cadena + clave);
        }

        /// <summary>
        /// El algoritmo md5 no permite desencriptado.
        /// Si ejecuta esta opcion tendra una DevCityFrameworkException.
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public string DesEncriptar(string cadena, string clave)
        {
            throw new DevCityFrameworkException("La clase md5 no admite desencriptado.");
        }

        /// <summary>
        /// Devuelve un resumen de la cadena ingresada.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public string GenerarHASH(string cadena)
        {
            var ueCodigo = new UnicodeEncoding();

            var md5 = new MD5CryptoServiceProvider();

            var hash = md5.ComputeHash(ueCodigo.GetBytes(cadena));

            return Convert.ToBase64String(hash);
        }

    }
}

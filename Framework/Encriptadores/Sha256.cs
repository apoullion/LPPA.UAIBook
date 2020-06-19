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
    /// Permite la encriptacion con un algoritmo seguro sha256.
    /// No es un algoritmo reversible.
    /// </summary>
    public class Sha256 : IEncriptador
    {

        /// <summary>
        /// Devuelve una instancia del encriptador Sha256
        /// </summary>
        /// <returns></returns>
        public static IEncriptador Instancia()
        {
            return new Sha256();
        }

        /// <summary>
        /// Permite encriptar una cadena con su clave.
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public string Encriptar(string cadena, string clave)
        {
            return GenerarHASH(cadena + clave);
        }

        /// <summary>
        /// Este metodo no puede ser invocado ya que SHA256 no admite reversion.
        /// Si ejecuta este metodo obtendra como resultado una DevCityFrameworkException.
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public string DesEncriptar(string cadena, string clave)
        {
            throw new DevCityFrameworkException("La clase Sha256 no admite desencriptado.");
        }

        /// <summary>
        /// Devuelve el resumen hash de la cadena ingresada.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public string GenerarHASH(string cadena)
        {
            var algoritmo = new SHA256Managed();

            var bytes = Convertidores.CadenaABytes(cadena);

            return Convert.ToBase64String(algoritmo.ComputeHash(bytes));
        }
    }
}

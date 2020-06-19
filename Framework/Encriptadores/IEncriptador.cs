using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Encriptadores
{

    /// <summary>
    /// Contiene metodos para realizar operaciones de encriptacion.
    /// </summary>
    public interface IEncriptador
    {

        /// <summary>
        /// Recibe un texto y lo devuelve encriptado.
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        String Encriptar(String cadena, String clave);

        /// <summary>
        /// Recibe un texto encriptado y lo desencripta.
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        String DesEncriptar(String cadena, String clave);

        /// <summary>
        /// Devuelve un HASH o RESUMEN de una cadena ingresada.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        String GenerarHASH(String cadena);

    }
}

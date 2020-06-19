using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Framework.Sistema
{
    /// <summary>
    /// Devuelve informacion que puede entregar el sistema operativo actual.
    /// </summary>
    public static class Windows
    {
        /// <summary>
        /// Devuelve el nombre de la maquina actual
        /// </summary>
        /// <returns></returns>
        public static String ObtenerNombreMaquina()
        {
            return Environment.MachineName;
        }
        /// <summary>
        /// Devuelve las direcciones Ip de la maquina actual
        /// </summary>
        /// <returns></returns>
        public static List<IPAddress> ObtenerDireccionesMaquina()
        {
            return System.Net.Dns.GetHostAddresses(ObtenerNombreMaquina()).ToList();
        }

        /// <summary>
        /// Devuelve la carpeta temporal del sistema operativo
        /// </summary>
        /// <returns></returns>
        internal static String ObtenerCarpetaTemporal()
        {
            return System.IO.Path.GetTempPath();
        }
    }
}


    
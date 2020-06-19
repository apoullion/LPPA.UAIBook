using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Funciones
{
    /// <summary>
    /// Contiene funcionalidad para evitar el problema de numeros y fechas por diferentes culturas.
    /// </summary>
    public static class Cultura
    {

        /// <summary>
        /// Devuelve la cultura.
        /// Por defecto es es-AR.
        /// </summary>
        /// <returns></returns>
        public static CultureInfo ObtenerCultura()
        {
            return ObtenerCultura("es", "AR");
        }


        /// <summary>
        /// Devuelve la cultura del pais e idioma indicado
        /// </summary>
        /// <param name="idioma">Por defecto "es"</param>
        /// <param name="pais">Por defecto "AR"</param>
        /// <returns></returns>
        public static CultureInfo ObtenerCultura(String idioma, String pais)
        {
            return CultureInfo.GetCultureInfo(idioma.ToLowerInvariant() + "-" + pais.ToUpperInvariant());
        }

    }
}

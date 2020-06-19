using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Diagnostico
{
    /// <summary>
    /// Permite realizar logueos de operaciones varias.
    /// </summary>
    public interface ILogueador
    {

        /// <summary>
        /// Permite loguear un mensaje como critico. (rojo)
        /// </summary>
        /// <param name="mensaje">Mensaje a loguear.</param>
        /// <param name="nombreOrigen">Source de la aplicacion.</param>
        /// <param name="nombreCarpeta">Carpeta a utilizar en caso de agrupar.</param>
        void LogCritico(String mensaje, String nombreOrigen, String nombreCarpeta);

        /// <summary>
        /// Permite loguear un mensaje como informativo. (info)
        /// </summary>
        /// <param name="mensaje">Mensaje a loguear.</param>
        /// <param name="nombreOrigen">Source de la aplicacion.</param>
        /// <param name="nombreCarpeta">Carpeta a utilizar en caso de agrupar.</param>
        void LogInformacion(String mensaje, String nombreOrigen, String nombreCarpeta);

        /// <summary>
        /// Permite loguear un mensaje como alerta. (amarillo)
        /// </summary>
        /// <param name="mensaje">Mensaje a loguear.</param>
        /// <param name="nombreOrigen">Source de la aplicacion.</param>
        /// <param name="nombreCarpeta">Carpeta a utilizar en caso de agrupar.</param>
        void LogAlerta(String mensaje, String nombreOrigen, String nombreCarpeta);

    }

}

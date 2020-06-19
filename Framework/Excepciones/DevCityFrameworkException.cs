using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Excepciones
{

    /// <summary>
    /// Si ha ocurrido una excepcion dentro del framework, se recibe una excepcion de este tipo.
    /// </summary>
    public class DevCityFrameworkException : Exception
    {

        /// <summary>
        /// Permite construir una excepcion con mensaje.
        /// </summary>
        /// <param name="mensaje"></param>
        public DevCityFrameworkException(String mensaje)
            : base(mensaje)
        {

        }

        /// <summary>
        /// Permite construir una excepcion con mensaje y excepcion interna.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public DevCityFrameworkException(String mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }

    }
}

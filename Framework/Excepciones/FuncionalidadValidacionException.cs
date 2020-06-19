using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Excepciones
{
    /// <summary>
    /// Excepcion ocurrida cuando una validacion de funcionalidad ha ocurrido.
    /// Este error se muestra de color naranja (alerta)
    /// </summary>
    public class FuncionalidadValidacionException : Exception
    {

        /// <summary>
        /// Constructor por defecto con un mensaje.
        /// </summary>
        /// <param name="mensaje"></param>
        public FuncionalidadValidacionException(String mensaje)
            : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor para incluir la excepcion original.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public FuncionalidadValidacionException(String mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }

    }
}

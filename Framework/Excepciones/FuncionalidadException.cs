using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Excepciones
{

    /// <summary>
    /// Excepcion ocurrida en cualquier parte de una funcionalidad.
    /// </summary>
    public class FuncionalidadException : Exception
    {

        /// <summary>
        /// Permite construir una excepcion de funcionalidad con un mensaje.
        /// </summary>
        /// <param name="mensaje"></param>
        public FuncionalidadException(String mensaje)
            : base(mensaje)
        {

        }

        /// <summary>
        /// Permite construir una excepcion de funcionalidad indicando mensaje y dejando la inner exception ocurrida.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public FuncionalidadException(String mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }

    }
}

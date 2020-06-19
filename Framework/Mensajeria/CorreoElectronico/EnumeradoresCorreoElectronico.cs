using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Mensajeria.CorreoElectronico
{
    /// <summary>
    /// Contiene enumeradores del correo electronico.
    /// </summary>
    public class EnumeradoresCorreoElectronico
    {


        /// <summary>
        /// Indica el resultado del envio del correo.
        /// </summary>
        public enum ResultadoEnvioCorreoElectronico
        {
            /// <summary>
            /// El correo se envio con exito.
            /// </summary>
            Exito,

            /// <summary>
            /// Hubo un error al intentar crear los archivos de mail (si es que se especifico guardar una copia del mail en el disco rigido)
            /// </summary>
            ErrorCreandoArchivosMail
        }

    }
}

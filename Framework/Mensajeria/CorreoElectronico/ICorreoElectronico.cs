using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Mensajeria.CorreoElectronico
{
    /// <summary>
    /// Contiene los metodos necesarios para el envio de correos.
    /// </summary>
    public interface IMensajeroCorreoElectronico
    {
        /// <summary>
        /// Inicia el lanzamiento del correo electronico.
        /// </summary>
        /// <param name="correoElectronico">Contenido del correo electronico.</param>
        /// <returns></returns>
        EnumeradoresCorreoElectronico.ResultadoEnvioCorreoElectronico EnviarCorreoElectronico(CorreoElectronico correoElectronico);



    }
}

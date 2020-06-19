using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Mensajeria.CorreoElectronico
{
    /// <summary>
    /// Clase que posee los constructores del Destinatario
    /// </summary>
    /// <remarks></remarks>
    public class SeccionDestinatario

    {
        
        /// <summary>
        /// Correo Electronico a quien enviar.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string CorreoElectronico { get; set; }

        /// <summary>
        /// Nombre a Mostrar Destinatario
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string NombreMostrar { get; set; }

        /// <summary>
        /// Puede crear un objeto asignandole directamente los parametros
        /// </summary>
        /// <param name="correoElectronico"></param>
        ///<param name="nombreMostrar"></param>
        /// <remarks></remarks>

        public SeccionDestinatario(string correoElectronico, string nombreMostrar)
        {
            this.CorreoElectronico = correoElectronico;
            this.NombreMostrar = nombreMostrar;
        }

    }
}

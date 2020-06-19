using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Mensajeria.CorreoElectronico;


namespace Framework.Mensajeria.CorreoElectronico
{
    /// <summary>
    /// Contiene datos del correo electronico actual.
    /// </summary>
    public class CorreoElectronico
    {

        /// <summary>
        /// Obtiene una instancia con las listas preconfiguradas de correos.
        /// </summary>
        public CorreoElectronico()
        {
            this.DestinatariosOcultos = new List<SeccionDestinatario>();
            this.Destinatarios = new List<SeccionDestinatario>();
        }

        /// <summary>
        /// Listado de destinatarios
        /// </summary>
        public List<SeccionDestinatario> Destinatarios { get; set; }


        /// <summary>
        /// Listado de destinatarios Ocultos
        /// </summary>
        public List<SeccionDestinatario> DestinatariosOcultos { get; set; }


        /// <summary>
        ///  Correo electronico del remitente.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string RemitenteCorreo { get; set; }


        /// <summary>
        ///  Nombre a mostrar del remitente.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string RemitenteNombreMostrar { get; set; }


        /// <summary>
        /// Titulo del correo electronico
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string TituloCorreo { get; set; }


        /// <summary>
        /// Contiene el cuerpo del correo electronico.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string CuerpoCorreo { get; set; }

        /// <summary>
        ///  Indica si el texto a enviar debe considerarse como HTML o texto plano.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool EsHTML { get; set; }

        ///<summary>
        /// Permite agregar un destinatario a la lista de destinatarios.
        /// </summary>
        /// <param name="correoElectronico"></param>
        /// <param name="nombreMostrar"></param>
        /// <remarks></remarks>

        public void AgregarDestinatario(string correoElectronico, string nombreMostrar)
        {

            // Agrego el destinatario a su lista.
            // Warning!!! Optional parameters not supported

            this.Destinatarios.Add(new SeccionDestinatario(correoElectronico, nombreMostrar));

        }

        /// <summary>
        /// Permite agregar un destinatario oculto a la lista de destinatarios.
        /// </summary>
        /// <param name="correoElectronico"></param>
        /// <param name="nombreMostrar"></param>
        /// <remarks></remarks>
        public void AgregarDestinatarioOculto(string correoElectronico, string nombreMostrar)
        {
            // Agrego el destinatario oculto a su lista.
            this.DestinatariosOcultos.Add(new SeccionDestinatario(correoElectronico, nombreMostrar));
        }

        /// <summary>
        ///  Elimina todo el listado de Destinatarios.
        /// </summary>
        /// <remarks></remarks>
        public void EliminarDestinatarios()
        {
            this.Destinatarios.Clear();
        }

        /// <summary>
        ///  Elimina un destinatario de la lista que cumpla el correo electronico.
        /// </summary>
        /// <param name="correoElectronico"></param>
        /// <remarks></remarks>
        public void EliminarDestinatarios(string correoElectronico)
        {
            // Lo remuevo
            this.Destinatarios.RemoveAll(a => a.CorreoElectronico == correoElectronico);
        }

        /// <summary>
        ///  Elimina todos los destinatarios ocultos.
        /// </summary>
        /// <remarks></remarks>
        public void EliminarDestinatariosOcultos()
        {
            this.DestinatariosOcultos.Clear();
        }

        /// <summary>
        ///  Elimina un destinatario de la lista oculta
        /// </summary>
        /// <param name="correoElectronico"></param>
        /// <remarks></remarks>
        public void EliminarDestinatariosOcultos(string correoElectronico)
        {
            // Lo remuevo
            this.DestinatariosOcultos.RemoveAll(a => a.CorreoElectronico == correoElectronico);
        }
    }
}

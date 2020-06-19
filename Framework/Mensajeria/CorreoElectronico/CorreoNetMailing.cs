using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Diagnostics.CodeAnalysis;

namespace Framework.Mensajeria.CorreoElectronico
{
    /// <summary>
    /// Permite el envio de correos por el componente de .net mailing.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CorreoNetMailing : IMensajeroCorreoElectronico
    {
        /// <summary>
        /// Permite el envio de correo electronico por Net Mailing.
        /// </summary>
        /// <param name="correoElectronico"></param>
        /// <returns></returns>
        /// <remarks></remarks>

        public EnumeradoresCorreoElectronico.ResultadoEnvioCorreoElectronico EnviarCorreoElectronico(CorreoElectronico correoElectronico)
        {

            // Instancia contenedora del smtp de envio (de ser necesario, aca puede agregarse el host y el puerto)
            SmtpClient sMTP = new SmtpClient();

            // Instancia contendora del email.
            MailMessage mensaje = new MailMessage();

            // Cargo la informacion en el mensaje
            // With...
            // De quien se envia
            mensaje.From = new MailAddress(correoElectronico.RemitenteCorreo, correoElectronico.RemitenteNombreMostrar);

            // El titulo del email.
            mensaje.Subject = correoElectronico.TituloCorreo;

            // El contenido del mensaje
            mensaje.Body = correoElectronico.CuerpoCorreo;

            // Indico si es html
            mensaje.IsBodyHtml = correoElectronico.EsHTML;

            // Agrego los destinatarios normales.
            foreach (SeccionDestinatario destinatario in correoElectronico.Destinatarios)
            {

                mensaje.To.Add(new MailAddress(destinatario.CorreoElectronico, destinatario.NombreMostrar));
            }

            // Agrego los destinatarios ocultos.
            foreach (SeccionDestinatario destinatario in correoElectronico.DestinatariosOcultos)
            {

                mensaje.Bcc.Add(new MailAddress(destinatario.CorreoElectronico, destinatario.NombreMostrar));
            }

            //Ingreso las Credenciales del Mail encargado de enviar
            sMTP.Credentials = new NetworkCredential("healthy.fox1@gmail.com", "Diploma2015");
            
            sMTP.Host = "smtp.gmail.com";
            sMTP.Port = 587;
            sMTP.EnableSsl = true;
            try
            {
                // Lo envio
                sMTP.Send(mensaje);
            }
            catch (Exception e)
            {
                Framework.Diagnostico.LogueadorEventViewer.Instancia().LogCritico("El siguiente error es mostrado al generar un mail: " + e.ToString(), "Correo", "Healthy Fox");
            }
            

            // Devuelvo el exito
            return EnumeradoresCorreoElectronico.ResultadoEnvioCorreoElectronico.Exito;

        }
    }
}

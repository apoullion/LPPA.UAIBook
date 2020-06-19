using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Mensajeria;
using Framework.Mensajeria.CorreoElectronico;
using Framework.VariablesGlobales;
using Framework.Diagnostico;
using Framework.Encriptadores;
using DTO;

namespace Services
{

    public class Mail
    {
        public static void EnviarCorreoPorAltaUsuario()
        {
            string saltoLinea = "\n";
            try
            {
                // Genero una Instancia de Mail para armar el formato del Mismo
                var unMail = new CorreoElectronico();

                // Agrego Todos los valores correspondientes a Enviar
                string correoDestinatario = ConfiguracionUsuario.Instance().Mail;
                string nombreMostrar = ConfiguracionUsuario.Instance().Nombre;
                string contraseña = ConfiguracionUsuario.Instance().Contraseña;


                unMail.RemitenteCorreo = "healthy.fox1@gmail.com";
                unMail.RemitenteNombreMostrar = "Healthy Fox";

                unMail.AgregarDestinatario(correoDestinatario, nombreMostrar);

                unMail.TituloCorreo = "Alta Usuario Healthy Fox";

                unMail.CuerpoCorreo =

                    "Estimado/a: " + nombreMostrar + saltoLinea +
                    saltoLinea +
                    "Gracias por utilizar Healthy Fox. Le informamos que de acuerdo a sus datos ingresados registro un usuario con los siguientes datos:" + saltoLinea +
                    saltoLinea +
                    "Nombre y Apellido:" + "" + nombreMostrar + " " + ConfiguracionUsuario.Instance().Apellido + "\n" +
                    "Contraseña: " + contraseña + saltoLinea +
                    saltoLinea +
                    "Que tenga un buen día";

                // Envio el Mail
                var nuevoCorreo = new CorreoNetMailing();
                nuevoCorreo.EnviarCorreoElectronico(unMail);
            }
            catch (Exception e)
            {
                LogueadorEventViewer.Instancia().LogInformacion("El siguiente error fue mostrado al Generar un Mail:" + e.ToString(), "HealthyFox", "Log");
                throw new Exception("Error al Intentar enviar un Mail");

            }

        }

        public static void EnviarCorreoPorCambioDeContraseña(string unaContraseña)
        {
            string saltoLinea = "\n";
            try
            {
                // Genero una Instancia de Mail para armar el formato del Mismo
                var unMail = new CorreoElectronico();

                // Agrego Todos los valores correspondientes a Enviar
                string correoDestinatario = ConfiguracionUsuario.Instance().Mail;
                string nombreMostrar = ConfiguracionUsuario.Instance().Nombre;
                string contraseña = unaContraseña;


                unMail.RemitenteCorreo = "healthy.fox1@gmail.com";
                unMail.RemitenteNombreMostrar = "Healthy Fox";

                unMail.AgregarDestinatario(correoDestinatario, nombreMostrar);

                unMail.TituloCorreo = "Cambio de Contraseña en Healthy Fox";

                unMail.CuerpoCorreo =

                    "Estimado/a: " + nombreMostrar + saltoLinea +
                    saltoLinea +
                    "Gracias por utilizar Healthy Fox. Le informamos que usted ha modificado su contraseña:" + saltoLinea +
                    saltoLinea +
                    "Contraseña: " + contraseña + saltoLinea +
                    saltoLinea +
                    "Que tenga un buen día";

                // Envio el Mail
                var nuevoCorreo = new CorreoNetMailing();
                nuevoCorreo.EnviarCorreoElectronico(unMail);
            }
            catch (Exception e)
            {
                LogueadorEventViewer.Instancia().LogInformacion("El siguiente error fue mostrado al Generar un Mail:" + e.ToString(), "HealthyFox", "Log");
                throw new Exception("Error al Intentar enviar un Mail");

            }

        }

        public static void EnviarCorreoPorPrestamo(DTO.DtoPrestamo prestamo)
        {
            string saltoLinea = "\n";

            try
            {
                // Genero una Instancia de Mail para armar el formato del Mismo
                var unMail = new CorreoElectronico();

                // Agrego Todos los valores correspondientes a Enviar
                string correoDestinatario = "lucas.hartridge9@gmail.com";
                string nombreMostrar = "Lucas Hartridge";
                string Titulo = prestamo.Libro.Titulo;
                string FechaSolicitud = prestamo.PrestamoEstado.Fecha.ToString();
                string FechaRetiroLimite = Framework.Funciones.Fechas.ObtenerDiasHabiles(prestamo.PrestamoEstado.Fecha, 7).ToString();
                

                unMail.RemitenteCorreo = "healthy.fox1@gmail.com";
                unMail.RemitenteNombreMostrar = "Healthy Fox";

                unMail.AgregarDestinatario(correoDestinatario, nombreMostrar);

                unMail.TituloCorreo = "UAI BOOK | Reserva de Libro ";

                unMail.CuerpoCorreo =

                    "Estimado/a: " + nombreMostrar + saltoLinea +
                    saltoLinea +
                    "Gracias por utilizar nuestra Biblioteca virtaul para reservar un Libro. A continuación se Adjuntan los datos del prestmo" + saltoLinea +
                    saltoLinea +
                    "                              DATOS DEL LIBRO                          " + saltoLinea +
                    saltoLinea +
                    "Titulo: " + Titulo + saltoLinea +
                    saltoLinea +
                    "Fecha de Solicitud: " + FechaSolicitud + saltoLinea +
                    saltoLinea +
                    "Fecha de Retiro Limite: " + FechaRetiroLimite + saltoLinea +
                    saltoLinea +
                    "Recuerde que una vez que pasen los 7 dias habiles para retirar el libro el Prestamo se cancelará si el libro no fue retirado" +
                    saltoLinea +
                    "                                       MUCHAS GRACIAS                                    " + saltoLinea +
                    saltoLinea +
                    "Que tenga un buen día";

                // Envio el Mail
                var nuevoCorreo = new CorreoNetMailing();
                nuevoCorreo.EnviarCorreoElectronico(unMail);
            }
            catch (Exception e)
            {
                LogueadorEventViewer.Instancia().LogInformacion("El siguiente error fue mostrado al Generar un Mail:" + e.ToString(), "HealthyFox", "Log");
                throw new Exception("Error al Intentar enviar un Mail");

            }
        }

        public static void EnviarCorreoPorContacto(string mensaje, string nombre, int telefono,string mail)
        {
            string saltoLinea = "\n";

            try
            {
                // Genero una Instancia de Mail para armar el formato del Mismo
                var unMail = new CorreoElectronico();

                // Agrego Todos los valores correspondientes a Enviar
                string correoDestinatario = "lucas.hartridge9@gmail.com";
                string nombreMostrar = nombre;
         
                unMail.RemitenteCorreo = "healthy.fox1@gmail.com";
                unMail.RemitenteNombreMostrar = "Healthy Fox";

                unMail.AgregarDestinatario(correoDestinatario, nombreMostrar);

                unMail.TituloCorreo = "UAI BOOK | Contacto Usuario ";

                unMail.CuerpoCorreo =

                    "La siguiente persona se ha comunicado: " + nombre + saltoLinea +
                    saltoLinea +
                    "Sus datos para contactarse con la persona son" + saltoLinea +
                    saltoLinea +
                    "Mail: " + mail + saltoLinea +
                    saltoLinea +
                    "Telefono: " + telefono + saltoLinea +
                    saltoLinea +
                    "Mensaje: " +  saltoLinea +
                    saltoLinea +
                    mensaje +
                    saltoLinea +
                    "                                       MUCHAS GRACIAS                                    " + saltoLinea +
                    saltoLinea +
                    "Que tenga un buen día";

                // Envio el Mail
                var nuevoCorreo = new CorreoNetMailing();
                nuevoCorreo.EnviarCorreoElectronico(unMail);
            }
            catch (Exception e)
            {
                LogueadorEventViewer.Instancia().LogInformacion("El siguiente error fue mostrado al Generar un Mail:" + e.ToString(), "HealthyFox", "Log");
                throw new Exception("Error al Intentar enviar un Mail");

            }
        }


        public static void EnviarCorreoPorPrestamoAdedudado(List<DtoPrestamo> prestamos)
        {
            string saltoLinea = "\n";

            try
            {
                
                foreach (var item in prestamos)
                {
                    // Genero una Instancia de Mail para armar el formato del Mismo
                    var unMail = new CorreoElectronico();
                    DtoMembershipUser usuarioDeudor = BLL.GestorMaestro.ObtenerUsuarioPorId(item.UserId);

                    // Obtengo el mail de cada usuario
                    string nombreMostrar = usuarioDeudor.FullName;
                    string correoDestinatario = "healthy.fox@gmail.com";
                    unMail.RemitenteCorreo = "healthy.fox1@gmail.com";
                    unMail.RemitenteNombreMostrar = "Healthy Fox";

                    unMail.AgregarDestinatario(correoDestinatario,nombreMostrar);

                    unMail.TituloCorreo = "UAI BOOK | Contacto Usuario ";

                    unMail.CuerpoCorreo =

                    "Buenos Dias:" + nombreMostrar + saltoLinea +
                    saltoLinea +
                    "Le enviamos este mail para informarle que usted posee un libro el cual la fecha del prestamo ha caducado." + saltoLinea +
                    saltoLinea +
                    "Le Pedimos que devuelva el libro esta misma semana, sino sera multado" + saltoLinea +
                    saltoLinea +
                    "                                       MUCHAS GRACIAS                                    " + saltoLinea +
                    saltoLinea +
                    "Que tenga un buen día";

                // Envio el Mail
                var nuevoCorreo = new CorreoNetMailing();
                nuevoCorreo.EnviarCorreoElectronico(unMail);
                }
            }
            catch (Exception e)
            {
                LogueadorEventViewer.Instancia().LogInformacion("El siguiente error fue mostrado al Generar un Mail:" + e.ToString(), "HealthyFox", "Log");
                throw new Exception("Error al Intentar enviar un Mail");

            }

        }    
    }  
}
  
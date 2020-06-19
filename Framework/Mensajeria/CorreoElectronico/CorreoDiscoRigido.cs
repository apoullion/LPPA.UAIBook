using Framework.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Mensajeria.CorreoElectronico
{
    /// <summary>
    /// Esta clase representa una tecnica de correo electronico falsa.
    /// Genera un archivo html exactamente al que recibiria el usuario en su mail.
    /// El archivo se generara en la carpeta temporal del sistema operativo bajo una carpeta del mismo nombre
    /// del producto actual.
    /// </summary>
    public class CorreoDiscoRigido : IMensajeroCorreoElectronico
    {
        /// <summary>
        /// Realiza la generacion de correo electronico. 
        /// En este caso se generara un archivo html en la carpeta temporal del sistema.
        /// Se graba un archivo por cada destinatario, no se graban archivos por destinatarios ocultos.
        /// </summary>
        /// <param name="correoElectronico">Ingrese el correo electronico a simular que va a enviar.</param>
        /// <returns></returns>
        public EnumeradoresCorreoElectronico.ResultadoEnvioCorreoElectronico EnviarCorreoElectronico(CorreoElectronico correoElectronico)
        {

            try
            {
                foreach (var item in correoElectronico.Destinatarios)
                {
                    //Preparo el nombre del archivo.
                    var nombreArchivo = Convertidores.FechaAFechaLargaParaArchivo() + " enviado a " + item.CorreoElectronico + ".htm";
                    var carpetaTemp = Sistema.Windows.ObtenerCarpetaTemporal();
                    carpetaTemp = Carpetas.CombinarDirecciones(carpetaTemp, "DevCity Mailing");
                    carpetaTemp = Carpetas.CombinarDirecciones(carpetaTemp, nombreArchivo);

                    //Por las dudas creo la carpeta.
                    Sistema.SistemaArchivos.Instancia().Carpetas.CrearCarpeta(Carpetas.ObtenerRutaCarpetaDeRutaCompleta(carpetaTemp));

                    //Guardo el archivo.
                    Sistema.SistemaArchivos.Instancia().Archivos.GrabarEnString(carpetaTemp, correoElectronico.CuerpoCorreo);
                }

                return EnumeradoresCorreoElectronico.ResultadoEnvioCorreoElectronico.Exito;
            }
            catch (Exception)
            {
                return EnumeradoresCorreoElectronico.ResultadoEnvioCorreoElectronico.ErrorCreandoArchivosMail;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using Framework.Funciones;


namespace Framework.Diagnostico
{
    /// <summary>
    /// Permite realizar logueos con el componente eventViewer de windows.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LogueadorEventViewer : ILogueador
    {
        private static LogueadorEventViewer _instancia;
        private static EventLog _eventViewer;

        private LogueadorEventViewer()
        {
            _eventViewer = new EventLog();
            
        }
      
        /// <summary>
        /// Devuelve una instancia de esta clase.
        /// </summary>
        /// <returns></returns>
        public static ILogueador Instancia()
       {
           if (_instancia == null)

               _instancia = new LogueadorEventViewer();

           return _instancia;
       }

        /// <summary>
        /// Permite Crear un Log de Tipo Error en Event Viewer
        /// </summary>
        /// <param name="mensaje">Mensaje que se quiere dejar escrito.</param>
        /// <param name="nombreOrigen">Nombre de la Aplicacion que se esta usando.</param>
        /// <param name="nombreCarpeta">Nombre de la Carpeta donde seran creados los eventos dentro de Event Viewer.</param>
        public void LogCritico(string mensaje, string nombreOrigen, string nombreCarpeta)
        {
            if (RegistrarSourceDeAplicacion(nombreOrigen,nombreCarpeta))
            {
                _eventViewer.WriteEntry(mensaje, EventLogEntryType.Error, Matematicas.NumeroAleatorio(11111, 65535), ((short)(50)));

                _eventViewer.Close();
            }
             
        }

        /// <summary>
        /// Permite Crear un Log de Tipo Information Information en Event Viewer
        /// </summary>
        /// <param name="mensaje">Mensaje que se quiere dejar escrito.</param>
        /// <param name="nombreOrigen">Nombre de la Aplicacion que se esta usando.</param>
        /// <param name="nombreCarpeta">Nombre de la Carpeta donde seran creados los eventos dentro de Event Viewer.</param>
        public void LogInformacion(string mensaje, string nombreOrigen, string nombreCarpeta)
        {
            if (RegistrarSourceDeAplicacion(nombreOrigen,nombreCarpeta))
            {
                _eventViewer.WriteEntry(mensaje, EventLogEntryType.Information, Matematicas.NumeroAleatorio(11111, 65535), ((short)(50)));

                _eventViewer.Close();
            }
        }

        /// <summary>
        /// Permite Crear un Log de Tipo Warning en Event Viewer
        /// </summary>
        /// <param name="mensaje">Mensaje que se quiere dejar escrito.</param>
        /// <param name="nombreOrigen">Nombre de la Aplicacion que se esta usando.</param>
        /// <param name="nombreCarpeta">Nombre de la Carpeta donde seran creados los eventos dentro de Event Viewer.</param>
        public void LogAlerta(string mensaje, string nombreOrigen, string nombreCarpeta)
        {
            {
                if (RegistrarSourceDeAplicacion(nombreOrigen, nombreCarpeta))
                {
                    _eventViewer.WriteEntry(mensaje, EventLogEntryType.Warning, Matematicas.NumeroAleatorio(11111, 65535), ((short)(50)));

                    _eventViewer.Close();
                }
            }
        }
     
        private bool RegistrarSourceDeAplicacion(string nombreOrigen,string nombreCarpeta)
        {
            try
            {
                if (!EventLog.SourceExists(nombreOrigen)) 
                {
                    EventLog.CreateEventSource(nombreOrigen,nombreCarpeta);
                }

                _eventViewer.Source = nombreOrigen;
                return true;
            }
            catch (Exception)
            
            {
                return false;
            }
            
        }

    }
}

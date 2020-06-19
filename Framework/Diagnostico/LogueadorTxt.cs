using Framework.Excepciones;
using Framework.Funciones;
using Framework.Sistema;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("FrameworkTests")]
namespace Framework.Diagnostico
{

    /// <summary>
    /// Permite realizar logueos en TXT.
    /// </summary>
    public class LogueadorTxt : ILogueador
    {
        private const String FormatoRenglon = "{0} : {1} --> ({2}) {3}";
        private const String FormatoNombreArchivo = "{0} - {1}.log";
        private const String FormatoFecha = "dd/MM/yyyy hh:mm:ss tt";

        private SistemaArchivos _sa;
        private DateTime _ahora;
        private IFormatProvider _cultureInfo;

        internal LogueadorTxt()
        {
            throw new DevCityFrameworkException("No se puede acceder a una instancia desde este constructor. Utilizar el metodo estatico .Instancia().");
        }

        /// <summary>
        /// Metodo usado para test.
        /// </summary>
        /// <param name="ahora"></param>
        /// <param name="manejadorDiscos"></param>
        /// <param name="manejadorCarpetas"></param>
        /// <param name="manejadorArchivos"></param>
        internal LogueadorTxt(DateTime ahora, IManejoDiscos manejadorDiscos, IManejoCarpetas manejadorCarpetas, IManejoArchivos manejadorArchivos)
        {
            _sa = new SistemaArchivos(manejadorDiscos, manejadorCarpetas, manejadorArchivos);
            this._ahora = ahora;
            this._cultureInfo = Cultura.ObtenerCultura();
        }

        /// <summary>
        /// Devuelve la instancia del logueador.
        /// </summary>
        /// <returns></returns>
        public static ILogueador Instancia()
        {
            return new LogueadorTxt(DateTime.Now, new ManejoDiscos(), new ManejoCarpetas(), new ManejoArchivos());
        }

        /// <summary>
        /// Realiza un log critico.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="nombreOrigen"></param>
        /// <param name="nombreCarpeta"></param>
        public void LogCritico(string mensaje, string nombreOrigen, string nombreCarpeta)
        {
            var nombreArchivo = Cadenas.Formatear(FormatoNombreArchivo, Convertidores.FechaParaNombreArchivo(_ahora), nombreCarpeta);
            var mensajeFinal = Cadenas.Formatear(FormatoRenglon, _ahora.ToString(FormatoFecha, this._cultureInfo), "CRITICO", nombreOrigen, mensaje);

            _sa.Archivos.GrabarEnString(nombreArchivo, mensajeFinal, true);
        }

        /// <summary>
        /// Realiza un log informacion.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="nombreOrigen"></param>
        /// <param name="nombreCarpeta"></param>
        public void LogInformacion(string mensaje, string nombreOrigen, string nombreCarpeta)
        {
            var nombreArchivo = Cadenas.Formatear(FormatoNombreArchivo, Convertidores.FechaParaNombreArchivo(_ahora), nombreCarpeta);
            var mensajeFinal = Cadenas.Formatear(FormatoRenglon, _ahora.ToString(FormatoFecha, this._cultureInfo), "INFO", nombreOrigen, mensaje);

            _sa.Archivos.GrabarEnString(nombreArchivo, mensajeFinal, true);
        }

        /// <summary>
        /// Realiza un log de alerta.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="nombreOrigen"></param>
        /// <param name="nombreCarpeta"></param>
        public void LogAlerta(string mensaje, string nombreOrigen, string nombreCarpeta)
        {
            var nombreArchivo = Cadenas.Formatear(FormatoNombreArchivo, Convertidores.FechaParaNombreArchivo(_ahora), nombreCarpeta);
            var mensajeFinal = Cadenas.Formatear(FormatoRenglon, _ahora.ToString(FormatoFecha, this._cultureInfo), "ALERTA", nombreOrigen, mensaje);

            _sa.Archivos.GrabarEnString(nombreArchivo, mensajeFinal, true);
        }
    }
}

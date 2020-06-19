using Framework.Funciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Aplicaciones
{
    /// <summary>
    /// Contiene metodos que permiten el manejo de informacion de mi aplicacion actual.
    /// </summary>
    public class MiAplicacion
    {
        /// <summary>
        /// Devuelve el nombre de la aplicacion actual.
        /// </summary>
        /// <returns></returns>
        public static String NombreAplicacion()
        {
            return Process.GetCurrentProcess().ProcessName;
        }

        /// <summary>
        /// Devuelve el directorio de la aplicacion, concatenando una direccion ingresada.
        /// </summary>
        /// <param name="direccionConcatenar"></param>
        /// <returns></returns>
        public static String DirectorioAplicacion(String direccionConcatenar)
        {
            return Carpetas.NormalizarNombreCarpeta(Carpetas.CombinarDirecciones(DirectorioAplicacion(), direccionConcatenar));
        }

        /// <summary>
        /// Devuelve el directorio de la aplicacion.
        /// </summary>
        /// <returns></returns>
        public static String DirectorioAplicacion()
        {
            return Carpetas.NormalizarNombreCarpeta(AppDomain.CurrentDomain.BaseDirectory);
        }

        /// <summary>
        /// Devuelve el contenido de la key indicada en el config.
        /// Este metodo devuelve el dato tipado.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nombreConfiguracion"></param>
        /// <returns></returns>
        public static T LeerConfiguracionDesdeConfig<T>(String nombreConfiguracion)
        {
            var configReader = new AppSettingsReader();
            return (T)configReader.GetValue(nombreConfiguracion, typeof(T));
        }


        /// <summary>
        /// Devuelve el contenido de la key indicada en el config.
        /// </summary>
        /// <param name="nombreConfiguracion"></param>
        /// <returns></returns>
        public static String LeerConfiguracionDesdeConfig(String nombreConfiguracion)
        {
            return LeerConfiguracionDesdeConfig<String>(nombreConfiguracion);
        }

        /// <summary>
        /// Devuelve verdadero si se encuentra en modo debug.
        /// </summary>
        /// <returns></returns>
        public static Boolean EstaEnModoDebug()
        {
            return System.Diagnostics.Debugger.IsAttached;
        }

    }
}

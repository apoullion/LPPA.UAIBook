using Framework.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Funciones
{
    /// <summary>
    /// Contiene funciones para ayudar al trabajo de archivos.
    /// No permite trabajar con archivos, utilizar SistemaArchivos para eso.
    /// </summary>
    public static class Archivos
    {

        /// <summary>
        /// Devuelve el nombre del archivo en un path completo.
        /// </summary>
        /// <param name="direccion"></param>
        /// <returns></returns>
        public static String ObtenerNombreArchivo(String direccion)
        {
            //Normalizo la carpeta como primer medida, para saber que no esta mal formateada.
            var carpetaNormalizada = Carpetas.NormalizarNombreCarpeta(direccion);

            //Separo las secciones.
            var listaSecciones = Cadenas.Parsear(carpetaNormalizada, "\\");

            //Si el ultimo tiene forma de nombre de archivo, entonces se remueve.
            if (!listaSecciones.Last().Contains(".")) throw new DevCityFrameworkException("No se puede obtener el nombre del archivo porque el resultado de la busqueda indica que no hay un nombre de archivo valido y con extension.");

            //Retorno el ultimo que es la lista.
            return listaSecciones.Last();
        }
    }
}

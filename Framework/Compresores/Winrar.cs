using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Compresores
{
    /// <summary>
    /// Permite realizar compresion de archivos mediante winRar
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Winrar : ICompresor
    {
        /// <summary>
        /// Permite comprimir una carpeta entera.
        /// </summary>
        /// <param name="rutaArchivoComprimido">Ruta archivo comprimido resultado (incluir extension).</param>
        /// <param name="rutaCarpetaComprimir">Ruta carpeta por comprimir.</param>
        public void ComprimirCarpeta(String rutaArchivoComprimido, String rutaCarpetaComprimir)
        {
            var direccion = Aplicaciones.MiAplicacion.DirectorioAplicacion("compresores\\winrar\\Rar.exe");
            var parametros = " a -r -ep1 " + "\"" + rutaArchivoComprimido + "\" \"" + rutaCarpetaComprimir + "\" -k -t -m5 -o+ -s";
            Aplicaciones.Aplicacion.LanzarAplicacion(direccion, parametros, 0);
        }


        /// <summary>
        /// Permite comprimir un archivo.
        /// </summary>
        /// <param name="rutaArchivoComprimido">Ruta archivo comprimido resultado (incluir extension).</param>
        /// <param name="rutaArchivoComprimir">Ruta del archivo por comprimir.</param>
        public void ComprimirArchivo(string rutaArchivoComprimido, string rutaArchivoComprimir)
        {
            var direccion = Aplicaciones.MiAplicacion.DirectorioAplicacion("compresores\\winrar\\Rar.exe");
            var parametros = " a -ep1 " + "\"" + rutaArchivoComprimido + "\" \"" + rutaArchivoComprimir + "\" -k -t -m5 -o+ -s";
            Aplicaciones.Aplicacion.LanzarAplicacion(direccion, parametros, 0);
        }

        /// <summary>
        /// Permite descomprimir un archivo comprimido.
        /// </summary>
        /// <param name="rutaArchivoComprimido">Ruta del archivo comprimido.</param>
        /// <param name="directorioExtraccion">Ruta donde se dejaran los archivos resultados.</param>
        public void Descomprimir(string rutaArchivoComprimido, string directorioExtraccion)
        {
            var direccion = Aplicaciones.MiAplicacion.DirectorioAplicacion("compresores\\winrar\\UnRar.exe");
            var parametros = " x " + "\"" + rutaArchivoComprimido + "\" \"" + directorioExtraccion + "\"";
            Aplicaciones.Aplicacion.LanzarAplicacion(direccion, parametros, 0);
        }

    }

}
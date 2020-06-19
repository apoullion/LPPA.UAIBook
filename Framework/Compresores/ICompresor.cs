using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Compresores
{

    /// <summary>
    /// Metodos necesarios para comprimir y descomprimir archivos.
    /// </summary>
    public interface ICompresor
    {

        /// <summary>
        /// Permite comprimir una carpeta entera.
        /// </summary>
        /// <param name="rutaArchivoComprimido">Ruta archivo comprimido resultado (incluir extension).</param>
        /// <param name="rutaCarpetaComprimir">Ruta carpeta por comprimir.</param>
        void ComprimirCarpeta(String rutaArchivoComprimido, String rutaCarpetaComprimir);

        /// <summary>
        /// Permite comprimir un archivo.
        /// </summary>
        /// <param name="rutaArchivoComprimido">Ruta archivo comprimido resultado (incluir extension).</param>
        /// <param name="rutaArchivoComprimir">Ruta del archivo por comprimir.</param>
        void ComprimirArchivo(String rutaArchivoComprimido, String rutaArchivoComprimir);

        /// <summary>
        /// Permite descomprimir un archivo comprimido.
        /// </summary>
        /// <param name="rutaArchivoComprimido">Ruta del archivo comprimido.</param>
        /// <param name="directorioExtraccion">Ruta donde se dejaran los archivos resultados.</param>
        void Descomprimir(String rutaArchivoComprimido, String directorioExtraccion);

    }
}

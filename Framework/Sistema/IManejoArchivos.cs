using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Sistema
{

    /// <summary>
    /// Permite el manejo de operaciones sobre los archivos.
    /// </summary>
    public interface IManejoArchivos
    {

        /// <summary>
        /// Devuelve el peso del archivo indicado en Bytes.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        Int64 PesoDeArchivo(String nombreArchivo);

        /// <summary>
        /// Devuelve el contenido del archivo en binario.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        Byte[] LeerEnBinario(String nombreArchivo);

        /// <summary>
        /// Devuelve el contenido del archivo en String.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        String LeerEnASCII(String nombreArchivo);

        /// <summary>
        /// Permite guardar un archivo enviandole el contenido en binario.
        /// Si el archivo existe, es reemplazado.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="contenido"></param>
        void GrabarEnBinario(String nombreArchivo, Byte[] contenido);

        /// <summary>
        /// Permite guardar un archivo enviandole el contenido en string.
        /// Si el archivo existe, se sobreescribe.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="contenido"></param>
        void GrabarEnString(String nombreArchivo, String contenido);

        /// <summary>
        /// Permite guardar un archivo enviandole el contenido en string.
        /// Si el archivo existe, puede appendear o sobreescribir.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="contenido"></param>
        /// <param name="adjuntarAlFinal">Si es falso, elimina el archivo existente.</param>
        void GrabarEnString(String nombreArchivo, String contenido, Boolean adjuntarAlFinal);

        /// <summary>
        /// Mueve un archivo de origen a destino.
        /// Si el archivo destino existe, sera reemplazado.
        /// </summary>
        /// <param name="archivoOrigen"></param>
        /// <param name="archivoDestino"></param>
        void MoverArchivo(String archivoOrigen, String archivoDestino);

        /// <summary>
        /// Copia un archivo de origen a destino.
        /// Si el archivo destino existe, sera reemplazado.
        /// </summary>
        /// <param name="archivoOrigen"></param>
        /// <param name="archivoDestino"></param>
        void CopiarArchivo(String archivoOrigen, String archivoDestino);

        /// <summary>
        /// Borra un archivo del disco.
        /// </summary>
        /// <param name="archivoPorBorrar"></param>
        void BorrarArchivo(String archivoPorBorrar);

        /// <summary>
        /// Indica si el archivo mencionado existe en el sistema.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        Boolean ArchivoExiste(String nombreArchivo);

        /// <summary>
        /// Devuelve la fecha de creacion del archivo.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        DateTime ObtenerFechaCreacionArchivo(String nombreArchivo);

        /// <summary>
        /// Devuelve la fecha de ultima modificacion del archivo.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        DateTime ObtenerFechaModificacionArchivo(String nombreArchivo);

    }
}

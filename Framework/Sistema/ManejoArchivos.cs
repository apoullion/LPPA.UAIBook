using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Sistema
{

    /// <summary>
    /// Permite el manejo de operaciones sobre los archivos.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ManejoArchivos : IManejoArchivos
    {

        /// <summary>
        /// Devuelve el peso del archivo ingresado.
        /// El peso se devuelve en Bytes.
        /// </summary>
        /// <param name="nombreArchivo">Ruta del archivo por pesar.</param>
        /// <returns></returns>
        public Int64 PesoDeArchivo(String nombreArchivo)
        {
            try
            {
                var file = new FileInfo(nombreArchivo);
                return file.Length;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Abre un archivo y lo devuelve en binario.
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo a abrir.</param>
        /// <returns></returns>
        public Byte[] LeerEnBinario(String nombreArchivo)
        {
            try
            {
                if (!ArchivoExiste(nombreArchivo)) return null;

                return File.ReadAllBytes(nombreArchivo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Abre un archivo y lo devuelve en String
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo a abrir.</param>
        /// <returns></returns>
        public String LeerEnASCII(String nombreArchivo)
        {
            try
            {
                if (!ArchivoExiste(nombreArchivo)) return null;

                var lector = new StreamReader(nombreArchivo, Encoding.Default);

                var resultado = lector.ReadToEnd();

                lector.Close();

                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite guardar un archivo en binario.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="contenido"></param>
        public void GrabarEnBinario(String nombreArchivo, Byte[] contenido)
        {
            File.WriteAllBytes(nombreArchivo, contenido);
        }

        /// <summary>
        /// Permite guardar un archivo entregandole un string.
        /// Este metodo reemplaza por defecto todo el archivo si existiera.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="contenido"></param>
        public void GrabarEnString(String nombreArchivo, String contenido)
        {
            GrabarEnString(nombreArchivo, contenido, false);
        }

        /// <summary>
        /// Permite guardar un archivo entregandole un string. 
        /// Puede indicarse si debe reemplazar el archivo o adjuntar al final.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="contenido"></param>
        /// <param name="adjuntarAlFinal"></param>
        public void GrabarEnString(String nombreArchivo, String contenido, bool adjuntarAlFinal)
        {
            var escritor = new StreamWriter(nombreArchivo, false, Encoding.Default);
            escritor.Write(contenido);
            escritor.Close();
        }

        /// <summary>
        /// Permite cambiar de ubicacion un archivo a otro lugar.
        /// </summary>
        /// <param name="archivoOrigen"></param>
        /// <param name="archivoDestino"></param>
        public void MoverArchivo(String archivoOrigen, String archivoDestino)
        {
            File.Move(archivoOrigen, archivoDestino);
        }

        /// <summary>
        /// Permite realizar una copia del archivo.
        /// </summary>
        /// <param name="archivoOrigen"></param>
        /// <param name="archivoDestino"></param>
        public void CopiarArchivo(String archivoOrigen, String archivoDestino)
        {
            File.Copy(archivoOrigen, archivoDestino, true);
        }

        /// <summary>
        /// Permite borrar un archivo.
        /// </summary>
        /// <param name="archivoPorBorrar"></param>
        public void BorrarArchivo(String archivoPorBorrar)
        {
            File.Delete(archivoPorBorrar);
        }

        /// <summary>
        /// Indica si el archivo existe en el sistema.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public Boolean ArchivoExiste(String nombreArchivo)
        {
            return File.Exists(nombreArchivo);
        }

        /// <summary>
        /// Devuelve la fecha en que fue creado el archivo.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public DateTime ObtenerFechaCreacionArchivo(String nombreArchivo)
        {
            return File.GetCreationTime(nombreArchivo);
        }

        /// <summary>
        /// Devuelve la fecha en que fue modificado el archivo.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public DateTime ObtenerFechaModificacionArchivo(String nombreArchivo)
        {
            return File.GetLastWriteTime(nombreArchivo);
        }

    }
}

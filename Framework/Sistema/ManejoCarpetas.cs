using Framework.Funciones;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Excepciones;

namespace Framework.Sistema
{
    /// <summary>
    /// Permite el manejo de operaciones sobre carpetas.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ManejoCarpetas : IManejoCarpetas
    {
        internal ManejoCarpetas()
        {

        }

        /// <summary>
        /// Devuelve un listado de archivos indicado en la carpeta.
        /// </summary>
        /// <param name="direccion"></param>
        /// <returns></returns>
        public List<String> ListarArchivos(String direccion)
        {
            return ListarArchivos(direccion, "*.*");
        }

        /// <summary>
        /// Devuelve un listado de archivos indicado en la carpeta y que cumplan el patron de busqueda.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="patronBusqueda"></param>
        /// <returns></returns>
        public List<String> ListarArchivos(String direccion, String patronBusqueda)
        {
            return Directory.GetFiles(direccion, patronBusqueda).ToList();
        }

        /// <summary>
        /// Devuelve el listado de carpetas contenida en la direccion ingresada.
        /// </summary>
        /// <param name="direccion"></param>
        /// <returns></returns>
        public List<String> ListarCarpetas(String direccion)
        {
            return Directory.GetDirectories(direccion).ToList();
        }

        /// <summary>
        /// Devuelve todas las carpetas ubicadas dentro de la direccion inicial.
        /// </summary>
        /// <param name="direccionInicial"></param>
        /// <returns></returns>
        public List<String> ObtenerCarpetasRecursivamente(String direccionInicial)
        {
            var listadoFinal = new List<String>();

            var evaluadorActual = ListarCarpetas(direccionInicial);

            listadoFinal.AddRange(evaluadorActual);

            var subCarpetasResultantes = new List<String>();

            foreach (var item in evaluadorActual)
            {
                subCarpetasResultantes.AddRange(ListarCarpetas(item));

                if (subCarpetasResultantes.Any()) ObtenerCarpetasRecursivamente(item);
            }

            listadoFinal.AddRange(subCarpetasResultantes);
            evaluadorActual.Clear();

            return listadoFinal.OrderBy(o => o).ToList();
        }

        /// <summary>
        /// Permite crear una carpeta en la direccion indicada.
        /// Si la carpeta o una de sus partes anteriores no existe, tambien sera creada.
        /// </summary>
        /// <param name="direccionCarpeta"></param>
        public void CrearCarpeta(String direccionCarpeta)
        {
            Directory.CreateDirectory(direccionCarpeta);
        }

        /// <summary>
        /// Permite eliminar una carpeta, indicando si debe eliminar su contenido recursivamente.
        /// En caso de que tenga contenido y no debe eliminar recursivamente, obtendra una excepcion.
        /// </summary>
        /// <param name="direccionCarpeta"></param>
        /// <param name="recursivo"></param>
        public void EliminarCarpeta(String direccionCarpeta, bool recursivo)
        {
            try
            {
                Directory.Delete(direccionCarpeta, recursivo);
            }
            catch (Exception ex)
            {
                throw new DevCityFrameworkException("Ocurrio un error al eliminar la carpeta, posiblemente no esta vacia o no tiene permisos para ejecutar esta operacion.", ex);
            }
        }

        /// <summary>
        /// Permite mover una carpeta de una ubicacion a otra.
        /// </summary>
        /// <param name="carpetaOrigen"></param>
        /// <param name="carpetaDestino"></param>
        public void MoverCarpeta(String carpetaOrigen, String carpetaDestino)
        {
            Directory.Move(carpetaOrigen, carpetaDestino);
        }

        /// <summary>
        /// Permite cambiar el nombre a una carpeta, basicamente funciona igual que mover carpeta.
        /// </summary>
        /// <param name="carpetaOrigen"></param>
        /// <param name="carpetaDestino"></param>
        public void RenombrarCarpeta(String carpetaOrigen, String carpetaDestino)
        {
            MoverCarpeta(carpetaOrigen, carpetaDestino);
        }

        /// <summary>
        /// Permite copiar una carpeta junto con su contenido en otra ubicacion.
        /// </summary>
        /// <param name="carpetaOrigen"></param>
        /// <param name="carpetaDestino"></param>
        public void CopiarCarpeta(String carpetaOrigen, String carpetaDestino)
        {
            var dir = new DirectoryInfo(carpetaOrigen);
            var dirs = dir.GetDirectories();

            if (!CarpetaExiste(carpetaDestino)) CrearCarpeta(carpetaDestino);

            foreach (var item in dir.GetFiles())
            {
                var tempPath = Path.Combine(carpetaDestino, item.Name);
                item.CopyTo(tempPath, true);
            }

            foreach (var item in dirs)
            {
                var tempPath = Path.Combine(carpetaDestino, item.Name);
                CopiarCarpeta(item.FullName, tempPath);
            }
        }

        /// <summary>
        /// Indica si la carpeta existe en el sistema.
        /// </summary>
        /// <param name="direccionCarpeta"></param>
        /// <returns></returns>
        public Boolean CarpetaExiste(String direccionCarpeta)
        {
            return Directory.Exists(direccionCarpeta);
        }
    }
}

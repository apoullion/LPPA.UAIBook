using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Sistema
{
    /// <summary>
    /// Permite el manejo de operaciones sobre carpetas.
    /// </summary>
    public interface IManejoCarpetas
    {

        /// <summary>
        /// Devuelve la lista de archivos ubicados en la direccion actual.
        /// </summary>
        /// <param name="direccion"></param>
        /// <returns></returns>
        List<String> ListarArchivos(String direccion);

        /// <summary>
        /// Devuelve la lista de archivos ubicados en la direccion actual, permite devolver filtrado el resultado.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="patronBusqueda"></param>
        /// <returns></returns>
        List<String> ListarArchivos(String direccion, String patronBusqueda);

        /// <summary>
        /// Lista todas las carpetas de la ruta indicada.
        /// </summary>
        /// <param name="direccion"></param>
        /// <returns></returns>
        List<String> ListarCarpetas(String direccion);

        /// <summary>
        /// Devuelve todas las carpetas contenidas en la direccion inicial.
        /// </summary>
        /// <param name="direccionInicial"></param>
        /// <returns></returns>
        List<String> ObtenerCarpetasRecursivamente(String direccionInicial);

        /// <summary>
        /// Permite crear una carpeta en la ruta actual.
        /// Si alguna parte de la ruta no existe, se creara recursivamente.
        /// </summary>
        /// <param name="direccionCarpeta"></param>
        void CrearCarpeta(String direccionCarpeta);

        /// <summary>
        /// Permite eliminar la carpeta indicada y todo su contenido.
        /// </summary>
        /// <param name="direccionCarpeta"></param>
        /// <param name="recursivo"></param>
        void EliminarCarpeta(String direccionCarpeta, Boolean recursivo);

        /// <summary>
        /// Permite cambiar de ubicacion la carpeta indicada.
        /// </summary>
        /// <param name="carpetaOrigen"></param>
        /// <param name="carpetaDestino"></param>
        void MoverCarpeta(String carpetaOrigen, String carpetaDestino);

        /// <summary>
        /// Permite cambiar el nombre de la carpeta (basicamente es un mover carpeta)
        /// </summary>
        /// <param name="carpetaOrigen"></param>
        /// <param name="carpetaDestino"></param>
        void RenombrarCarpeta(String carpetaOrigen, String carpetaDestino);

        /// <summary>
        /// Permite copiar una carpeta entera y su contenido.
        /// </summary>
        /// <param name="carpetaOrigen"></param>
        /// <param name="carpetaDestino"></param>
        void CopiarCarpeta(String carpetaOrigen, String carpetaDestino);

        /// <summary>
        /// Indica si la carpeta existe.
        /// </summary>
        /// <param name="direccionCarpeta"></param>
        /// <returns></returns>
        Boolean CarpetaExiste(String direccionCarpeta);

    }
}

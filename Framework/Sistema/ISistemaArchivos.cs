using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Sistema
{
    /// <summary>
    /// Metodos de la clase que implementara el manejo de archivos.
    /// </summary>
    public interface ISistemaArchivos
    {

        /// <summary>
        /// Contiene funcionalidad para el manejo de archivos del sistema.
        /// </summary>
        IManejoArchivos Archivos { get; set; }

        /// <summary>
        /// Contiene funcionalidad para el manejo de carpetas del sistema.
        /// </summary>
        IManejoCarpetas Carpetas { get; set; }

        /// <summary>
        /// Contiene funcionalidad para el manejo de discos del sistema.
        /// </summary>
        IManejoDiscos Discos { get; set; }

    }
}

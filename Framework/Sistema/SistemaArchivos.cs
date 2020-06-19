using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


[assembly: InternalsVisibleTo("FrameworkTests")]
namespace Framework.Sistema
{
    /// <summary>
    /// Permite el acceso a funciones del FileSystem.
    /// </summary>
    public class SistemaArchivos : ISistemaArchivos
    {

        #region Constructores

        /// <summary>
        /// Constructor para test FriendAssembly o para uso local.
        /// </summary>
        /// <param name="manejoDiscos"></param>
        /// <param name="manejoCarpetas"></param>
        /// <param name="manejoArchivos"></param>
        internal SistemaArchivos(IManejoDiscos manejoDiscos, IManejoCarpetas manejoCarpetas, IManejoArchivos manejoArchivos)
        {
            this.Discos = manejoDiscos;
            this.Carpetas = manejoCarpetas;
            this.Archivos = manejoArchivos;
        }

        #endregion

        /// <summary>
        /// Devuelve una instancia de la clase actual.
        /// </summary>
        /// <returns></returns>
        public static ISistemaArchivos Instancia()
        {
            return new SistemaArchivos(new ManejoDiscos(), new ManejoCarpetas(), new ManejoArchivos());
        }

        /// <summary>
        /// Contiene funcionalidad para el manejo de archivos del sistema.
        /// </summary>
        public IManejoArchivos Archivos { get; set; }

        /// <summary>
        /// Contiene funcionalidad para el manejo de carpetas del sistema.
        /// </summary>
        public IManejoCarpetas Carpetas { get; set; }

        /// <summary>
        /// Contiene funcionalidad para el manejo de discos del sistema.
        /// </summary>
        public IManejoDiscos Discos { get; set; }

    }
}

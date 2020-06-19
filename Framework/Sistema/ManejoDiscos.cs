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
    /// Permite el manejo de los discos del sistema
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ManejoDiscos : IManejoDiscos
    {

        internal ManejoDiscos()
        {

        }


        /// <summary>
        /// Devuelve un listado de las unidades actuales.
        /// </summary>
        /// <returns></returns>
        public List<String> ListarDiscos()
        {
            return Directory.GetLogicalDrives().ToList();
        }
    }
}

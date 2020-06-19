using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Sistema
{
    /// <summary>
    /// Permite el manejo de los discos del sistema
    /// </summary>
    public interface IManejoDiscos
    {
        /// <summary>
        /// Devuelve un listado de las unidades actuales.
        /// </summary>
        /// <returns></returns>
        List<String> ListarDiscos();
    }
}

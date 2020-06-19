using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Funciones
{
    /// <summary>
    /// Clase en donde se Crean diferentes tipos de Claves 
    /// </summary>
    public class Claves
    {
        /// <summary>
        /// Funcion que devuelve un GUID nuevo
        /// </summary>
        /// <returns></returns>
        public static Guid ObtenerGuid()
        {
            Guid unGuid = Guid.NewGuid();
            return unGuid;
        }
    }
}

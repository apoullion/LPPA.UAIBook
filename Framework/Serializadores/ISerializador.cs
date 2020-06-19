using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Serializadores
{

    /// <summary>
    /// Permite realizar funciones de serializado y deserealizado.
    /// </summary>
    public interface ISerializador
    {

        /// <summary>
        /// Recibe un objeto y devuelve su representativo en texto.
        /// </summary>
        /// <param name="objeto">Un objeto de cualquier tipo.</param>
        /// <returns></returns>
        String Serializar(Object objeto);

        /// <summary>
        /// Recibe una cadena representativa de un objeto serializado y devuelve el tipo indicado.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objetoSerializado"></param>
        /// <returns></returns>
        T Deserealizar<T>(String objetoSerializado);

    }
}

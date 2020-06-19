using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Serializadores
{
    /// <summary>
    /// Permite realizar serializado en formato json.
    /// Ayuda en: http://james.newtonking.com/json
    /// </summary>
    public class SerializadorJson : ISerializador
    {

        private SerializadorJson()
        {

        }

        /// <summary>
        /// Entrega la instancia del serializador json.
        /// </summary>
        /// <returns></returns>
        public static ISerializador Instancia()
        {
            return new SerializadorJson();
        }

        /// <summary>
        /// Permite transformar un objeto a texto.
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public String Serializar(Object objeto)
        {
            return JsonConvert.SerializeObject(objeto);
        }

        /// <summary>
        /// Recibe un texto en formato json y lo devuelve a su formato objeto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objetoSerializado"></param>
        /// <returns></returns>
        public T Deserealizar<T>(String objetoSerializado)
        {
            return JsonConvert.DeserializeObject<T>(objetoSerializado);
        }
    }
}

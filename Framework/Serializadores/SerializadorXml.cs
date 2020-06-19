using Framework.Funciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Framework.Serializadores
{

    /// <summary>
    /// Permite deserealizar y serializar objetos a XML.
    /// </summary>
    public class SerializadorXml : ISerializador
    {

        /// <summary>
        /// Obtiene una instancia del serializador.
        /// </summary>
        /// <returns></returns>
        public static ISerializador Instancia()
        {
            return new SerializadorXml();
        }

        /// <summary>
        /// Permite transformar un objeto en texto.
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public String Serializar(Object objeto)
        {
            if (objeto == null) return "";

            var xs = new XmlSerializer(objeto.GetType());

            var s = new System.IO.MemoryStream();

            xs.Serialize(s, objeto);

            return Convertidores.StreamACadena(s);
        }

        /// <summary>
        /// Transforma un texto en formato xml, y devuelve un objeto representativo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objetoSerializado"></param>
        /// <returns></returns>
        public T Deserealizar<T>(String objetoSerializado)
        {
            if (String.IsNullOrEmpty(objetoSerializado)) return default(T);

            var xs = new XmlSerializer(typeof(T));

            var resultado = xs.Deserialize(new MemoryStream(Convertidores.CadenaABytes(objetoSerializado)));

            return (T)resultado;
        }
    }
}

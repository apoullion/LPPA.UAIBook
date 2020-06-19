using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace Framework.Persistencia.Funciones
{
    /// <summary>
    /// Contiene funciones para realizar el mapeo de dataReader a objetos.
    /// </summary>
    internal class MapeadorHelper
    {
        /// <summary>
        /// Devuelve la instancia de este helper.
        /// </summary>
        /// <returns></returns>
        internal static MapeadorHelper Instancia()
        {
            return new MapeadorHelper();
        }

        /// <summary>
        /// Permite transformar un datareader en un objeto que implemente IEntidadPersistente.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resultadoDataReader"></param>
        /// <returns></returns>
        internal List<T> RealizarConversion<T>(System.Data.IDataReader resultadoDataReader) where T : class, IEntidadPersistente, new()
        {
            var columnas = this.ObtenerColumnasDelDatareader(resultadoDataReader);

            var resultadoFinal = new List<T>();

            while (resultadoDataReader.Read())
            {
                var nuevoObjeto = new T();

                foreach (var item in columnas)
                {
                    var campo = resultadoDataReader[columnas.IndexOf(item)].ToString();
                    var pi = nuevoObjeto.GetType().GetProperty(item);

                    if (campo != "")
                    {
                        
                        //Solo mapeo si encuentro dicho campo.
                        if (pi != null) pi.SetValue(nuevoObjeto, resultadoDataReader[columnas.IndexOf(item)]);
                    }          
                }

                resultadoFinal.Add(nuevoObjeto);
            }

            resultadoDataReader.Close();

            return resultadoFinal;
        }

        

        /// <summary>
        /// Permite transformar un datareader en un objeto que implemente IEntidadPersistente de un SP
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resultadoDataReader"></param>
        internal List<T> RealizarConversionSp<T>(System.Data.IDataReader resultadoDataReader) where T : class, IEntidadPersistente, new()
        {
            var columnas = this.ObtenerColumnasDelDatareader(resultadoDataReader);

            var resultadoFinal = new List<T>();

            while (resultadoDataReader.Read())
            {
                var nuevoObjeto = new T();

                foreach (var item in columnas)
                {

                    var pi = nuevoObjeto.GetType().GetProperty(item);
                   
                    //Solo mapeo si encuentro dicho campo.
                    if (pi != null)
                    {
                            pi.SetValue(nuevoObjeto, resultadoDataReader[columnas.IndexOf(item)]);
                    }
                    else
                    {
                        pi = null;
                    }
                }

                resultadoFinal.Add(nuevoObjeto);
            }

            resultadoDataReader.Close();

            return resultadoFinal;
        }
        
        private List<String> ObtenerColumnasDelDatareader(System.Data.IDataReader resultadoDataReader)
        {
            var resultado = new List<String>();

            for (int i = 0; i < resultadoDataReader.FieldCount; i++)
            {
                resultado.Add(resultadoDataReader.GetName(i));
            }
            return resultado;
        }


    }
}

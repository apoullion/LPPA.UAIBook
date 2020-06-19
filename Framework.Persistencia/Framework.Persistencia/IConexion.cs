using Framework.Persistencia.MotorBaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistencia
{
    /// <summary>
    /// Contiene las funciones a implementar por el objeto conexion.
    /// </summary>
    public interface IConexion
    {
        /// <summary>
        /// Inicia la conexion a base de datos.
        /// </summary>
        void ConexionIniciar();

        /// <summary>
        /// Finaliza la conexion a la base de datos.
        /// </summary>
        void ConexionFinalizar();

        /// <summary>
        /// Inicia una transaccion (begin tran)
        /// </summary>
        void TransaccionIniciar();

        /// <summary>
        /// Acepta una transaccion (commit tran)
        /// </summary>
        void TransaccionAceptar();

        /// <summary>
        /// Revierte una transaccion (rollback tran)
        /// </summary>
        void TransaccionCancelar();

        /// <summary>
        /// Realiza una ejecucion que no implica resultados (Generalmente Insert, Update, Delete)
        /// </summary>
        /// <param name="consulta"></param>
        /// <param name="parametros"></param>
        void EjecutarConsultaSinResultado(string consulta, List<ParametroEjecucion> parametros);

        /// <summary>
        /// Realiza una ejecucion que devuelve un unico resultado de tipo nativo (int, string, bool, date)
        /// </summary>
        /// <typeparam name="T">Tipo de dato del resultado.</typeparam>
        /// <param name="consulta"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        T EjecutarConsultaResultadoEscalar<T>(string consulta, List<ParametroEjecucion> parametros);

        /// <summary>
        /// Realiza una ejecucion que devuelve un resultado en forma de lista de un type indicado.
        /// </summary>
        /// <typeparam name="T">Tipo de datos a retornar.</typeparam>
        /// <param name="consulta">Consulta a ejecutar.</param>
        /// <param name="parametros">Parametros involucrados en la consulta.</param>
        /// <returns></returns>
        List<T> EjecutarConsultaResultadoTupla<T>(string consulta, List<ParametroEjecucion> parametros) where T : class, IEntidadPersistente, new();

    }
}

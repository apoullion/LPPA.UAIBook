using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistencia.MotorBaseDatos
{
    internal interface IMotorBaseDatos 
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
        /// Realiza una ejecucion que no implica un resultado, generalmente usado para Insert, Update o Delete.
        /// </summary>
        /// <param name="consulta"></param>
        /// <param name="parametros"></param>
        void EjecutarConsultaSinResultado(string consulta, List<ParametroEjecucion> parametros);

        /// <summary>
        /// Realiza una ejecucion que implica un resultado en forma escalar.
        /// Solo permite devolver un resultado.
        /// </summary>
        /// <typeparam name="T">Tipo de dato del resultado (int, date, string).</typeparam>
        /// <param name="consulta">Query a ejecutar</param>
        /// <param name="parametros">Parametros que necesita la query para su ejecucion.</param>
        /// <returns></returns>
        T EjecutarConsultaResultadoEscalar<T>(string consulta, List<ParametroEjecucion> parametros);

        /// <summary>
        /// Realiza una ejecucion que devuelve un datareader por ser mappeado.
        /// </summary>
        /// <param name="consulta">Query a ejecutar</param>
        /// <param name="parametros">Parametros que necesita la query para su ejecucion.</param>
        /// <returns></returns>
        IDataReader EjecutarConsultaResultadoTupla(string consulta, List<ParametroEjecucion> parametros);

        /// <summary>
        /// Permite Realizar la Ejecucion de un Store Procedure que no devuelve resultados (Insert,Update,Delete)
        /// </summary>
        /// <param name="nombreSp"></param>
        /// <param name="parametros"></param>
        void EjecutarSPSinResultado(string nombreSp, List<ParametroEjecucion> parametros);

        /// <summary>
        /// Realiza una ejecucion de un SP que implica un resultado en forma escalar.
        /// Solo permite devolver un resultado.
        /// </summary>
        /// <typeparam name="T">Tipo de dato del resultado (int, date, string).</typeparam>
        /// <param name="nombreSp">Sp a ejecutar</param>
        /// <param name="parametros">Parametros que necesita la query para su ejecucion.</param>
        /// <returns></returns>
        T EjecutarSPResultadoEscalar<T>(string nombreSp, List<ParametroEjecucion> parametros);

        /// <summary>
        /// Realiza la ejecucion de un SP que devuelve varios Registros
        /// </summary>
        /// <param name="nombreSp"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
       IDataReader EjecutarSPResultadoTupla(string nombreSp, List<ParametroEjecucion> parametros);
    }
}

using Framework.Persistencia.MotorBaseDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Framework.Persistencia
{

    /// <summary>
    /// Permite conectar contra una base de datos especificando un proveedor de conexion.
    /// </summary>
    public class Conexion : IConexion
    {
        private CadenaConexion _cadenaConexion;
        private IMotorBaseDatos _motorBaseDatos;
        private bool _conexionEstaIniciada;
        private DateTime _fechaInicioConexion;
        private bool _transaccionEstaIniciada;

        internal Conexion(CadenaConexion cadenaConexion, IMotorBaseDatos motorBaseDatos)
        {
            //Este metodo es utilizado para test, solo internals pueden entregar el motor de base de datos.
            this.InicializarConexion(cadenaConexion, motorBaseDatos);
        }

        /// <summary>
        /// Devuelve una conexion, ingresando una cadena de conexion para inicializarla.
        /// </summary>
        /// <param name="cadenaConexion"></param>
        public Conexion(CadenaConexion cadenaConexion)
        {
            this.InicializarConexion(cadenaConexion, MotorBaseDatosFactory.ObtenerMotorBaseDatos(cadenaConexion));
        }

        private void InicializarConexion(CadenaConexion cadenaConexion, IMotorBaseDatos motorBaseDatos)
        {
            this._motorBaseDatos = motorBaseDatos;
            this._cadenaConexion = cadenaConexion;
        }

        /// <summary>
        /// Inicia la conexion a la base de datos indicada.
        /// </summary>
        public void ConexionIniciar()
        {
            if (!this._conexionEstaIniciada)
            {
                this._conexionEstaIniciada = true;
                this._fechaInicioConexion = DateTime.Now;

                this._motorBaseDatos.ConexionIniciar();
            }
        }

        /// <summary>
        /// Finaliza la conexion a la base de datos indicada.
        /// </summary>
        public void ConexionFinalizar()
        {
            if (this._conexionEstaIniciada)
            {
                if (!this._transaccionEstaIniciada)
                {
                    this._conexionEstaIniciada = false;
                    this._motorBaseDatos.ConexionFinalizar();
                }
            }

        }

        /// <summary>
        /// Inicia una transaccion en la conexion actual.
        /// </summary>
        public void TransaccionIniciar()
        {
            if (!this._transaccionEstaIniciada)
            {
                this._transaccionEstaIniciada = true;
                this._motorBaseDatos.TransaccionIniciar();
            }
        }

        /// <summary>
        /// Realiza el Commit de la transaccion.
        /// </summary>
        public void TransaccionAceptar()
        {
            if (this._transaccionEstaIniciada)
            {
                this._motorBaseDatos.TransaccionAceptar();
                this._transaccionEstaIniciada = false;
            }
        }

        /// <summary>
        /// Realiza el Rollback de la transaccion.
        /// </summary>
        public void TransaccionCancelar()
        {
            if (this._transaccionEstaIniciada)
            {
                this._motorBaseDatos.TransaccionCancelar();
                this._transaccionEstaIniciada = false;
            }
        }

        /// <summary>
        /// Realiza una consulta la cual no devuelve resultados.
        /// </summary>
        /// <param name="consulta"></param>
        /// <param name="parametros"></param>
        public void EjecutarConsultaSinResultado(string consulta, List<ParametroEjecucion> parametros)
        {
            this._motorBaseDatos.EjecutarConsultaSinResultado(consulta, parametros);
        }

        /// <summary>
        /// Realiza una consulta la cual devuelve un valor simple (como un numero o una fecha)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="consulta"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public T EjecutarConsultaResultadoEscalar<T>(string consulta, List<ParametroEjecucion> parametros)
        {
            return this._motorBaseDatos.EjecutarConsultaResultadoEscalar<T>(consulta, parametros);
        }

        /// <summary>
        /// Realiza una consulta la cual devuelve un conjunto tupla de resultados.
        /// Los resultados son automaticamente formateados al tipo T y siempre se devuelve una coleccion de resultados.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="consulta"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public List<T> EjecutarConsultaResultadoTupla<T>(string consulta, List<ParametroEjecucion> parametros) where T : class, IEntidadPersistente, new()
        {
            var resultadoDataReader = this._motorBaseDatos.EjecutarConsultaResultadoTupla(consulta, parametros);

            return Funciones.MapeadorHelper.Instancia().RealizarConversion<T>(resultadoDataReader);
        }

        /// <summary>
        /// Ejecuta un Store Procedure que no devuelve resultado como Insert,Update,Delete
        /// </summary>
        /// <param name="nombreSp"></param>
        /// <param name="parametros"></param>
        public void EjecutarSPSinResultado(string nombreSp,List<ParametroEjecucion> parametros)
        {
            this._motorBaseDatos.EjecutarSPSinResultado(nombreSp, parametros);

        }

        /// <summary>
        /// Ejecuta un Store Procedure que devuelve una o mas columnas
        /// </summary>
        /// <param name="nombreSp"></param>
        /// <param name="parametros"></param>
        public List<T> EjecutarSPResultadoTupla<T>(string nombreSp, List<ParametroEjecucion> parametros) where T : class, IEntidadPersistente, new()
        {
            var resultadoDataReader = this._motorBaseDatos.EjecutarSPResultadoTupla(nombreSp, parametros);

            return Funciones.MapeadorHelper.Instancia().RealizarConversionSp<T>(resultadoDataReader);
        }


        /// <summary>
        /// Ejecuta un Store Procedure que devuelve unicamente un dato
        /// </summary>
        /// <param name="nombreSp"></param>
        /// <param name="parametros"></param>
        public T EjecutarSPResultadoEscalar<T>(string nombreSp, List<ParametroEjecucion> parametros)
        {
            return this._motorBaseDatos.EjecutarSPResultadoEscalar<T>(nombreSp, parametros);
        }
    }
}

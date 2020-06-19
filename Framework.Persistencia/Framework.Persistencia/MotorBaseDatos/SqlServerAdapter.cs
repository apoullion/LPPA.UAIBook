using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Framework.Persistencia;

namespace Framework.Persistencia.MotorBaseDatos
{
    [ExcludeFromCodeCoverage]
    internal class SqlServerAdapter : IMotorBaseDatos
    {
        private string _cadenaDeConexion;

        private SqlConnection _sqlConnection;
        private SqlTransaction _sqlTransaction;

        public SqlServerAdapter(CadenaConexion cadenaConexion)
        {
            this._cadenaDeConexion = cadenaConexion.CadenaDeConexion;
        }

        public void ConexionIniciar()
        {
            this._sqlConnection = new SqlConnection(this._cadenaDeConexion);

            this._sqlConnection.Open();
        }

        public void ConexionFinalizar()
        {
            this._sqlConnection.Close();
        }

        public void TransaccionIniciar()
        {
            this._sqlTransaction = this._sqlConnection.BeginTransaction();
        }

        public void TransaccionAceptar()
        {
            this._sqlTransaction.Commit();
        }

        public void TransaccionCancelar()
        {
            this._sqlTransaction.Rollback();
        }

        public  void EjecutarConsultaSinResultado(string consulta, List<ParametroEjecucion> parametros)
        {
            var comando = this.ObtenerComando(consulta, parametros);

             comando.ExecuteNonQuery();
        }


        public T EjecutarConsultaResultadoEscalar<T>(string consulta, List<ParametroEjecucion> parametros)
        {
            var comando = this.ObtenerComando(consulta, parametros);

            return (T)comando.ExecuteScalar();
        }

        public System.Data.IDataReader EjecutarConsultaResultadoTupla(string consulta, List<ParametroEjecucion> parametros)
        {
            var comando = this.ObtenerComando(consulta, parametros);

            return comando.ExecuteReader();
        }

        public void EjecutarSPSinResultado(string nombreSp, List<ParametroEjecucion> parametros)
        {
            var comando = this.ObtenerComandoSp(nombreSp, parametros);

            comando.ExecuteNonQuery();
        }

        public T EjecutarSPResultadoEscalar<T>(string nombreSp, List<ParametroEjecucion> parametros)
        {
            var comando = this.ObtenerComandoSp(nombreSp, parametros);

            return (T)comando.ExecuteScalar();
        }

        public System.Data.IDataReader EjecutarSPResultadoTupla(string nombreSp, List<ParametroEjecucion> parametros)
        {
            var comando = this.ObtenerComandoSp(nombreSp, parametros);

            return comando.ExecuteReader();
        }

        private SqlCommand ObtenerComando(string consulta, List<ParametroEjecucion> parametros)
        {
            var comando = new SqlCommand(consulta, this._sqlConnection, this._sqlTransaction);

            comando.CommandType = System.Data.CommandType.Text;

            if (parametros == null) return comando;

            foreach (var item in parametros)
            {
                comando.Parameters.AddWithValue(item.NombreParametro, item.Valor);
            }

            return comando;
        }

        private SqlCommand ObtenerComandoSp(string nombreSp,List<ParametroEjecucion> parametros)
        {
            var comando = new SqlCommand(nombreSp, this._sqlConnection, this._sqlTransaction);

            comando.CommandType = System.Data.CommandType.StoredProcedure;

            if (parametros == null) return comando;

            foreach (var item in parametros)
            {
                comando.Parameters.AddWithValue(item.NombreParametro, item.Valor);
            }

            return comando;
        }
 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistencia
{
    /// <summary>
    /// Representa una cadena de conexion para utilizar en el framework de persistencia.
    /// </summary>
    public class CadenaConexion
    {
        /// <summary>
        /// Motor de base a utilizar.
        /// </summary>
        public TipoMotorBaseDatos MotorBaseDatos { get; set; }

        /// <summary>
        /// Cadena de conexion configurada.
        /// </summary>
        public String CadenaDeConexion { get; set; }

        /// <summary>
        /// Enumeracion de tipos de bases de datos disponibles.
        /// </summary>
        public enum TipoMotorBaseDatos
        {
            /// <summary>
            /// Utilizar la implementacion para sql server.
            /// </summary>
            ClienteSqlServer = 1,

            /// <summary>
            /// Utilizar unicamente para test.d
            /// </summary>
            Mock = 999
        }

        /// <summary>
        /// Crea una instancia de la cadena de conexion.
        /// </summary>
        /// <param name="tipoMotorBaseDatos"></param>
        /// <param name="cadenaConexion"></param>
        public CadenaConexion(TipoMotorBaseDatos tipoMotorBaseDatos, String cadenaConexion)
        {
            this.MotorBaseDatos = tipoMotorBaseDatos;
            this.CadenaDeConexion = cadenaConexion;
        }

        /// <summary>
        /// Crea una instancia de la cadena de conexion.
        /// </summary>
        /// <param name="tipoMotorBaseDatos"></param>
        /// <param name="servidor"></param>
        /// <param name="catalogo"></param>
        public CadenaConexion(TipoMotorBaseDatos tipoMotorBaseDatos, String servidor, String catalogo)
        {
            this.MotorBaseDatos = tipoMotorBaseDatos;
            this.CadenaDeConexion = this.ObtenerCadenaConexion(servidor, catalogo);
        }

        /// <summary>
        /// Crea una instancia de la cadena de conexion.
        /// </summary>
        /// <param name="tipoMotorBaseDatos"></param>
        /// <param name="servidor"></param>
        /// <param name="catalogo"></param>
        /// <param name="nombreUsuario"></param>
        /// <param name="clave"></param>
        public CadenaConexion(TipoMotorBaseDatos tipoMotorBaseDatos, String servidor, String catalogo, String nombreUsuario, String clave)
        {
            this.MotorBaseDatos = tipoMotorBaseDatos;
            this.CadenaDeConexion = this.ObtenerCadenaConexion(servidor, catalogo, nombreUsuario, clave);
        }

        private string ObtenerCadenaConexion(String servidor, String catalogo, String nombreUsuario, String clave)
        {
            return String.Format("Server={0};Database={1};User id={2};Password={3};", servidor, catalogo, nombreUsuario, clave);
        }

        private string ObtenerCadenaConexion(String servidor, String catalogo)
        {
            return String.Format("Server={0};Database={1};Trusted_Connection=True;", servidor, catalogo);
        }
    }
}

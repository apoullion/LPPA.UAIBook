using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevCity.Framework.Persistencia;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using DevCity.Framework.Persistencia.Entidades;
using DevCity.Framework.Persistencia.MotorBaseDatos;
using DevCity.Framework.Nucleo.PatronesDevCity.Persistencia;
using NSubstitute;

namespace DevCity.Framework.Persistencia.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class ConexionTests
    {
        public class UsuarioTesting : IEntidadPersistente
        { }


        [TestMethod()]
        public void ConexionExitosaTest()
        {
            var cadenaConexion = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.Mock, "cadenaconexion");

            var motorBaseDatosMock = NSubstitute.Substitute.For<IMotorBaseDatos>();

            var conexion = new Conexion(cadenaConexion, motorBaseDatosMock);

            conexion.ConexionIniciar();

            conexion.TransaccionIniciar();

            var intTest = conexion.EjecutarConsultaResultadoEscalar<Int32>("Select 1 From algo", new List<ParametroEjecucion>());

            var tuplaTest = conexion.EjecutarConsultaResultadoTupla<UsuarioTesting>("Select * From UsuarioTesting", new List<ParametroEjecucion>());

            conexion.EjecutarConsultaSinResultado("Delete from Algo", new List<ParametroEjecucion>());

            conexion.TransaccionAceptar();

            conexion.ConexionFinalizar();


            motorBaseDatosMock.Received().ConexionIniciar();
            motorBaseDatosMock.Received().ConexionFinalizar();
        }


        [TestMethod()]
        public void ConexionErroneaTest()
        {
            var cadenaConexion = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.Mock, "cadenaconexion");

            var motorBaseDatosMock = NSubstitute.Substitute.For<IMotorBaseDatos>();

            var conexion = new Conexion(cadenaConexion, motorBaseDatosMock);

            try
            {
            conexion.ConexionIniciar();

            conexion.TransaccionIniciar();

                var intTest = conexion.EjecutarConsultaResultadoEscalar<Int32>("Select 1 From algo", new List<ParametroEjecucion>());

                var tuplaTest = conexion.EjecutarConsultaResultadoTupla<UsuarioTesting>("Select * From UsuarioTesting", new List<ParametroEjecucion>());

                conexion.EjecutarConsultaSinResultado("Delete from Algo", new List<ParametroEjecucion>());

                throw new Exception();

            }
            catch (Exception)
            {
                conexion.TransaccionCancelar();

            conexion.ConexionFinalizar();
            }

        }

        [TestMethod()]
        public void ConexionTest()
        {
            var cadenaConexion = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.Mock, "Asodijqowdjqowj");

            var conexion = new Conexion(cadenaConexion);

            Assert.IsNotNull(conexion);
        }
    }
}

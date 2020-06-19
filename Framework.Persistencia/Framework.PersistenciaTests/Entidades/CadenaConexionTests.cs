using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevCity.Framework.Persistencia.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using DevCity.Framework.Nucleo.PatronesDevCity.Persistencia;
namespace DevCity.Framework.Persistencia.Entidades.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class CadenaConexionTests
    {
        [TestMethod()]
        public void CadenaConexionTest()
        {
            Prueba1();
            Prueba2();
            Prueba3();
        }

        private void Prueba3()
        {
            var cn = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, "server", "catalogo", "user", "password");
            Assert.AreEqual("Server=server;Database=catalogo;User id=user;Password=password;", cn.CadenaDeConexion);
        }

        private void Prueba2()
        {
            var cn = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, "server", "catalogo");
            Assert.AreEqual("Server=server;Database=catalogo;Trusted_Connection=True;", cn.CadenaDeConexion);
        }

        private void Prueba1()
        {
            var cn = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, "unacadenaconexion");
            Assert.AreEqual("unacadenaconexion", cn.CadenaDeConexion);
        }
    }
}

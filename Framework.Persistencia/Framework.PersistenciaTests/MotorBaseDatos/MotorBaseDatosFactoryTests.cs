using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevCity.Framework.Persistencia.MotorBaseDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using DevCity.Framework.Nucleo.PatronesDevCity.Persistencia;
namespace DevCity.Framework.Persistencia.MotorBaseDatos.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class MotorBaseDatosFactoryTests
    {
        [TestMethod()]
        public void ObtenerMotorBaseDatosTest()
        {
            var motor = MotorBaseDatosFactory.ObtenerMotorBaseDatos(new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ""));
            Assert.IsInstanceOfType(motor, typeof(SqlServerAdapter));
        }
    }
}

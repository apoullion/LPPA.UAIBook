using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Aplicaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Framework.Aplicaciones.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class MiAplicacionTests
    {
        [TestMethod()]
        public void NombreAplicacionTest()
        {
            var actual = MiAplicacion.NombreAplicacion();

            //Al correr los test, la aplicacion es executionengine
            Assert.AreEqual("vstest.executionengine.x86", actual);
        }

        [TestMethod()]
        public void DirectorioAplicacionTest()
        {
            var actual = MiAplicacion.DirectorioAplicacion();

            var esperado = AppDomain.CurrentDomain.BaseDirectory + "\\";

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod()]
        public void DirectorioAplicacionTest1()
        {
            var actual = MiAplicacion.DirectorioAplicacion("algomas");

            var esperado = AppDomain.CurrentDomain.BaseDirectory + "\\algomas\\";

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod()]
        public void DirectorioAplicacionTest2()
        {
            var actual = MiAplicacion.DirectorioAplicacion("algomas\\lala.txt");

            var esperado = AppDomain.CurrentDomain.BaseDirectory + "\\algomas\\lala.txt";

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod()]
        public void LeerConfiguracionDesdeConfigTest()
        {
            var configuracion1 = MiAplicacion.LeerConfiguracionDesdeConfig<Int32>("Configuracion1");
            var configuracion2 = MiAplicacion.LeerConfiguracionDesdeConfig("Configuracion2");

            Assert.AreEqual(9999999, configuracion1);
            Assert.AreEqual("SIMPSONS", configuracion2);
        }

        [TestMethod()]
        public void EstaEnModoDebugTest()
        {
            Assert.AreEqual(System.Diagnostics.Debugger.IsAttached, MiAplicacion.EstaEnModoDebug());
        }

    }
}

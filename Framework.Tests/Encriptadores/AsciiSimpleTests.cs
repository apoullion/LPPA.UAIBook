using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Encriptadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
namespace Framework.Encriptadores.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class AsciiSimpleTests
    {
        [TestMethod()]
        public void EncriptarTest()
        {
            var prueba = "leonardo";

            var actual = AsciiSimple.Instancia().Encriptar(prueba, "123");

            Assert.AreEqual("32583251326132603247326432503261", actual);
        }

        [TestMethod()]
        public void DesEncriptarTest()
        {
            var prueba = "32583251326132603247326432503261";

            var actual = AsciiSimple.Instancia().DesEncriptar(prueba, "123");

            Assert.AreEqual("leonardo", actual);
        }

        [TestMethod()]
        public void GenerarHASHTest()
        {
            var actual = AsciiSimple.Instancia().GenerarHASH("Leonardo");

            Assert.AreEqual("L152e53o88n68a59r72d20o22", actual);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Sistema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
namespace Framework.Sistema.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class WindowsTests
    {
        [TestMethod()]
        public void ObtenerNombreMaquinaTest()
        {
            var actual = Windows.ObtenerNombreMaquina();

            Assert.AreNotEqual("", actual);
        }

        [TestMethod()]
        public void ObtenerDireccionesMaquinaTest()
        {
            var direccionesMaquinaTest = Framework.Sistema.Windows.ObtenerDireccionesMaquina();
            Assert.IsNotNull(direccionesMaquinaTest);
        }
    }
}

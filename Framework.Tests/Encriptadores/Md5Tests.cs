using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Encriptadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Framework.Excepciones;
namespace Framework.Encriptadores.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class Md5Tests
    {
        [TestMethod()]
        public void GenerarHASHTest()
        {
            var guid = new Guid();

            var actual = Md5.Instancia().GenerarHASH(guid.ToString());

            Assert.AreEqual("OeNCccmTFe0FVuN2Dff3Pg==", actual);
        }

        [TestMethod()]
        public void EncriptarTest()
        {
            var actual = Md5.Instancia().Encriptar("Leonardo", "ABC");

            Assert.AreEqual("5boNimFoslo1xlC+GRKp2w==", actual);
        }

        [TestMethod()]
        public void DesEncriptarTest()
        {
            try
            {
                var x = Md5.Instancia().DesEncriptar("algo", "algo");
                Assert.Fail("Debe arrojar error.");
            }
            catch (DevCityFrameworkException ex)
            {
                Assert.AreEqual("La clase md5 no admite desencriptado.", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail("Debe arrojar error.");
            }
        }
    }
}

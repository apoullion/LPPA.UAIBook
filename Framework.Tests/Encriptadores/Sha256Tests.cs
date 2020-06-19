using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Encriptadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Excepciones;
using System.Diagnostics.CodeAnalysis;
namespace Framework.Encriptadores.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class Sha256Tests
    {
        [TestMethod()]
        public void EncriptarTest()
        {
            var actual = Sha256.Instancia().Encriptar("Leonardo", "ABC");

            Assert.AreEqual("z6V4zG47tKAc4Sdxk0+WXfQmHSd6HlOL0DJFBWbwsC8=", actual);
        }

        [TestMethod()]
        public void DesEncriptarTest()
        {
            try
            {
                var x = Sha256.Instancia().DesEncriptar("algo", "algo");
                Assert.Fail("Debe arrojar error.");
            }
            catch (DevCityFrameworkException ex)
            {
                Assert.AreEqual("La clase Sha256 no admite desencriptado.", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail("Debe arrojar error.");
            }
        }

        [TestMethod()]
        public void GenerarHASHTest()
        {
            var guid = new Guid();

            var actual = Sha256.Instancia().GenerarHASH(guid.ToString());

            Assert.AreEqual("Erk3fL5+XJTopw2dI5KVI9FK+pVHkxMPijlZx7hJrKg=", actual);
        }
    }
}

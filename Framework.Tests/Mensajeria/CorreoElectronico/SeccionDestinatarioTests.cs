using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Mensajeria.CorreoElectronico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Framework.Mensajeria.CorreoElectronico.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class SeccionDestinatarioTests
    {
        [TestMethod()]
        public void SeccionDestinatarioTest()
        {
            string correoElectronico = "lucashartridge@gmail.com";
            string nombreMostrar = "Lucas";

            var resultado = new SeccionDestinatario(correoElectronico, nombreMostrar);

            Assert.AreEqual(correoElectronico, resultado.CorreoElectronico);
            Assert.AreEqual(nombreMostrar, resultado.NombreMostrar);
        }
    }
}

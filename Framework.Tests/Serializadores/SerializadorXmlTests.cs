using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Serializadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
namespace Framework.Serializadores.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class SerializadorXmlTests
    {
        public class UsuarioSerializarTest
        {
            public String Apellido { get; set; }
        }

        [TestMethod()]
        public void SerializarTest()
        {
            var usuarioSerializado = SerializadorXml.Instancia().Serializar(new UsuarioSerializarTest { Apellido = "Simpson" });
            Assert.AreEqual("<?xml version=\"1.0\"?>\r\n<UsuarioSerializarTest xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Apellido>Simpson</Apellido>\r\n</UsuarioSerializarTest>", usuarioSerializado);

            Assert.AreEqual("", SerializadorXml.Instancia().Serializar(null));
        }

        [TestMethod()]
        public void DeserealizarTest()
        {
            var xml = "<?xml version=\"1.0\"?>\r\n<UsuarioSerializarTest xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Apellido>Simpson</Apellido>\r\n</UsuarioSerializarTest>";

            var actual = SerializadorXml.Instancia().Deserealizar<UsuarioSerializarTest>(xml);

            Assert.IsNotNull(actual);
            Assert.AreEqual("Simpson", actual.Apellido);
            Assert.IsInstanceOfType(actual, typeof(UsuarioSerializarTest));

            Assert.IsNull(SerializadorXml.Instancia().Deserealizar<Object>(""));

        }
    }
}

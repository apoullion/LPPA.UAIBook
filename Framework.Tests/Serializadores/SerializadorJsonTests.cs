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
    public class SerializadorJsonTests
    {
        public class TestUser
        {
            public String Apellido { get; set; }
            public Int32 Edad { get; set; }
            public DateTime FechaInscripcion { get; set; }
            public SubClass SubClase { get; set; }
        }
        public class SubClass
        {
            public String A { get; set; }
            public String B { get; set; }
        }

        [TestMethod()]
        public void SerializarTest()
        {
            var prueba = ObtenerInstanciaPrueba();

            var actual = Serializadores.SerializadorJson.Instancia().Serializar(prueba);

            Assert.AreEqual("{\"Apellido\":\"Simpson\",\"Edad\":40,\"FechaInscripcion\":\"2014-11-10T00:00:00\",\"SubClase\":{\"A\":\"Algo\",\"B\":\"Mas\"}}", actual);

        }


        [TestMethod()]
        public void DeserealizarTest()
        {
            var pruebaSerializada = "{\"Apellido\":\"Simpson\",\"Edad\":40,\"FechaInscripcion\":\"2014-11-10T00:00:00\",\"SubClase\":{\"A\":\"Algo\",\"B\":\"Mas\"}}";

            var prueba = ObtenerInstanciaPrueba();

            var actual = Serializadores.SerializadorJson.Instancia().Deserealizar<TestUser>(pruebaSerializada);

            Assert.AreEqual(prueba.Apellido, actual.Apellido);
            Assert.AreEqual(prueba.Edad, actual.Edad);
            Assert.AreEqual(prueba.FechaInscripcion, actual.FechaInscripcion);
            Assert.AreEqual(prueba.SubClase.A, actual.SubClase.A);
            Assert.AreEqual(prueba.SubClase.B, actual.SubClase.B);

        }
        private static TestUser ObtenerInstanciaPrueba()
        {
            var prueba = new TestUser
            {
                Apellido = "Simpson",
                Edad = 40,
                FechaInscripcion = new DateTime(2014, 11, 10),

                SubClase = new SubClass
                {
                    A = "Algo",
                    B = "Mas"
                }

            };
            return prueba;
        }
    }
}

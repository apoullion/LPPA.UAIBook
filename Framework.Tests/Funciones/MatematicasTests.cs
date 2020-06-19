using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Funciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
namespace Framework.Funciones.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class MatematicasTests
    {
        [TestMethod()]
        public void NumeroAleatorioTest()
        {
            Int32[] resultados = new Int32[10];

            for (int i = 0; i < 200; i++)
            {
                var valor = Matematicas.NumeroAleatorio(0, 9);

                resultados[valor]++;
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.IsTrue(resultados[i] > 5);
            }
        }

        [TestMethod()]
        public void ObtenerPorcentajeTest()
        {
            var actual = Matematicas.ObtenerPorcentaje(10, 500);
            Assert.AreEqual(50, actual);

            var actualDecimal = Matematicas.ObtenerPorcentaje(33, 1);
            Assert.AreEqual((Decimal)0.33, actualDecimal);

            var actualDecimal2 = Matematicas.ObtenerPorcentaje(66, 1);
            Assert.AreEqual((Decimal)0.66, actualDecimal2);
        }

        [TestMethod()]
        public void QuitarPorcentajeDevuelveNetoTest()
        {
            var actual = Matematicas.QuitarPorcentajeDevuelveNeto(21, 121);

            Assert.AreEqual(100, actual);
        }

        [TestMethod()]
        public void QuitarPorcentajeTest()
        {
            var actual = Matematicas.QuitarPorcentaje(21, 121);

            Assert.AreEqual(21, actual);
        }

        [TestMethod()]
        public void ObtenerPorcentajePorcientoTest()
        {
            var actual = Matematicas.ObtenerPorcentajePorciento(10, 500);

            Assert.AreEqual(2, actual);
        }

        [TestMethod()]
        public void AplicarDescuentoSobreImporteBrutoTest()
        {
            var actual = Matematicas.AplicarDescuentoSobreImporteBruto(10, 100);

            Assert.AreEqual(90, actual);
        }

        [TestMethod()]
        public void ObtenerDescuentoSobreImporteBrutoTest()
        {
            var actual = Matematicas.ObtenerDescuentoSobreImporteBruto(10, 100);

            Assert.AreEqual(10, actual);
        }


    }
}

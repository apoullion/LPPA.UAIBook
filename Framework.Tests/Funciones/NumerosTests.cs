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
    public class NumerosTests
    {
        [TestMethod()]
        public void NumeroDecimalEnStringTest()
        {
            string valorRetorno = Numeros.NumeroDecimalEnString(10);
            Assert.AreEqual("10,00", valorRetorno);
        }

        [TestMethod()]
        public void NumeroDecimalEnMonedaStringTest()
        {
            string valorRetorno = Numeros.NumeroDecimalEnMonedaString(10);
            Assert.AreEqual("$ 10,00",valorRetorno);
        }

        [TestMethod()]
        public void EsNumeroTest()
        {
            bool valorRetorno = Numeros.EsNumero("10");
            Assert.IsTrue(valorRetorno);
        }

        [TestMethod()]
        public void NumeroSiemprePositivoTest()
        {
            decimal valorRetorno = Numeros.NumeroSiemprePositivo(-10);
            Assert.AreEqual(10, valorRetorno);
        }
    }
}

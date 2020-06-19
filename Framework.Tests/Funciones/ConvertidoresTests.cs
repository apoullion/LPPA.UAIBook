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
    public class ConvertidoresTests
    {

        [TestMethod()]
        public void CadenaABytesTest()
        {
            var actual = Convertidores.CadenaABytes("leo");

            Assert.AreEqual(108, actual[0]);
            Assert.AreEqual(101, actual[1]);
            Assert.AreEqual(111, actual[2]);
        }

        [TestMethod()]
        public void CadenaUnicodeABytesTest()
        {
            var actual = Convertidores.CadenaUnicodeABytes("leo");

            Assert.AreEqual(108, actual[0]);
            Assert.AreEqual(0, actual[1]);
            Assert.AreEqual(101, actual[2]);
        }

        [TestMethod()]
        public void BytesACadenaTest()
        {
            var prueba = new Byte[] { 108, 101, 111 };

            var actual = Convertidores.BytesACadena(prueba);

            Assert.AreEqual("leo", actual);
        }

        [TestMethod()]
        public void BytesUnicodeACadenaUnicodeTest()
        {
            var prueba = Convertidores.CadenaUnicodeABytes("leo");

            var actual = Convertidores.BytesUnicodeACadenaUnicode(prueba);

            Assert.AreEqual("leo", actual);
        }

        [TestMethod()]
        public void StreamACadenaTest()
        {
            var actual = Convertidores.CadenaAStream("Homero");

            var retornado = Convertidores.StreamACadena(actual);

            Assert.AreEqual("Homero", retornado);

        }

        [TestMethod()]
        public void CadenaAStreamTest()
        {
            var actual = Convertidores.CadenaAStream("Homero");

            var retornado = Convertidores.StreamACadena(actual);

            Assert.AreEqual("Homero", retornado);

        }

        [TestMethod()]
        public void BooleanoASiNoTest()
        {
            var verdadera = true;
            var falso = false;

            var valorRetornoVerdadero = Convertidores.BooleanoASiNo(verdadera);
            var valorRetornoFalso = Convertidores.BooleanoASiNo(falso);

            Assert.AreEqual("Sí", valorRetornoVerdadero);
            Assert.AreEqual("No", valorRetornoFalso);
        }

        [TestMethod()]
        public void CadenaABooleanoTest()
        {
            var valor1 = Convertidores.CadenaABooleano("1");
            var valorTrueMinuscula = Convertidores.CadenaABooleano("true");
            var valorTrueMayusculaInicial = Convertidores.CadenaABooleano("True");
            var valorTrueMayuscula = Convertidores.CadenaABooleano("TRUE");
            var valorFalse = Convertidores.CadenaABooleano("Sarasa");

            Assert.AreEqual(true, valor1);
            Assert.AreEqual(true, valorTrueMinuscula);
            Assert.AreEqual(true, valorTrueMayusculaInicial);
            Assert.AreEqual(true, valorTrueMayuscula);
            Assert.AreEqual(false, valorFalse);

        }

        [TestMethod()]
        public void CeroALaIzquierdaTest()
        {
            var valorRetorno = Convertidores.CeroALaIzquierda(25, 6);

            Assert.AreEqual("000025", valorRetorno);
        }



        [TestMethod()]
        public void FechaParaNombreArchivoTest()
        {
            var actual1 = Convertidores.FechaParaNombreArchivo(new DateTime(2015, 01, 09, 10, 25, 36));
            Assert.AreEqual("2015-01-09", actual1);

            var actual2 = Convertidores.FechaParaNombreArchivo();
            var esperado = DateTime.Now.ToString("yyyy-MM-dd");
            Assert.AreEqual(esperado, actual2);
        }

        [TestMethod()]
        public void FechaAFechaLargaParaArchivoTest()
        {
            var prueba = DateTime.Now;

            var esperado = prueba.ToString("yyyy-MM-dd-hh-mm-ss");

            var actual = Convertidores.FechaAFechaLargaParaArchivo(DateTime.Now);
            
            Assert.AreEqual(esperado, actual);
        }

    }
}

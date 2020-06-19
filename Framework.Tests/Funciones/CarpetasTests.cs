using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Funciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Excepciones;
using System.Diagnostics.CodeAnalysis;
namespace Framework.Funciones.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class CarpetasTests
    {
        [TestMethod()]
        public void NormalizarNombreCarpetaTest()
        {
            var prueba1 = @"C:\algo\\algomal\algo bien\algo fin";
            var prueba2 = @"C:\algo\\algomal\algo bien\algo fin\";
            var prueba3 = @"C:\algo\\algomal\algo bien\algo fin\archivo.txt";

            var actual1 = Carpetas.NormalizarNombreCarpeta(prueba1);
            var actual2 = Carpetas.NormalizarNombreCarpeta(prueba2);
            var actual3 = Carpetas.NormalizarNombreCarpeta(prueba3);

            Assert.AreEqual(@"C:\algo\algomal\algo bien\algo fin\", actual1);
            Assert.AreEqual(@"C:\algo\algomal\algo bien\algo fin\", actual2);
            Assert.AreEqual(@"C:\algo\algomal\algo bien\algo fin\archivo.txt", actual3);
        }

        [TestMethod()]
        public void ObtenerRutaCarpetaDeRutaCompletaTest()
        {
            var prueba1 = @"C:\a\b\c\algo.txt";
            var prueba2 = @"C:\a\b\c\";
            var prueba3 = @"C:\a\b\c";

            var actual1 = Carpetas.ObtenerRutaCarpetaDeRutaCompleta(prueba1);
            var actual2 = Carpetas.ObtenerRutaCarpetaDeRutaCompleta(prueba2);
            var actual3 = Carpetas.ObtenerRutaCarpetaDeRutaCompleta(prueba3);

            Assert.AreEqual(@"C:\a\b\c\", actual1);
            Assert.AreEqual(@"C:\a\b\c\", actual2);
            Assert.AreEqual(@"C:\a\b\c\", actual3);

        }


        [TestMethod()]
        public void ObtenerNombreCarpetaDeRutaCompletaTest()
        {
            var prueba1 = @"C:\a\b\c\algo.txt";
            var prueba2 = @"C:\a\b\c\";
            var prueba3 = @"C:\a\b\c";

            var actual1 = Carpetas.ObtenerNombreCarpetaDeRutaCompleta(prueba1);
            var actual2 = Carpetas.ObtenerNombreCarpetaDeRutaCompleta(prueba2);
            var actual3 = Carpetas.ObtenerNombreCarpetaDeRutaCompleta(prueba3);

            Assert.AreEqual(@"c", actual1);
            Assert.AreEqual(@"c", actual2);
            Assert.AreEqual(@"c", actual3);

        }

        [TestMethod()]
        public void NavegarCarpetaTest()
        {
            var carpetaActual1 = "C:\\a\\b\\c\\d\\e\\f";
            var actual1 = Carpetas.NavegarCarpeta(carpetaActual1, 3);
            Assert.AreEqual("C:\\a\\b\\c\\", actual1);

            try
            {
                var carpetaActual2 = "C:\\a\\b\\c\\d\\e\\f";
                var actual2 = Carpetas.NavegarCarpeta(carpetaActual2, 7);
                Assert.Fail("Deberia haber ocurrido una excepcion.");
            }
            catch (DevCityFrameworkException ex)
            {
                Assert.AreEqual("La cantidad de posiciones por retroceder es igual o excede la cantidad de posiciones disponibles por navegar. Existen 7 posicion(es) y se intento retroceder 7 posicion(es).", ex.Message);
            }
        }

        [TestMethod()]
        public void CombinarDireccionesTest()
        {
            var actual1 = Carpetas.CombinarDirecciones("D:\\a\\b\\c", "NuevaCarpeta");
            var actual2 = Carpetas.CombinarDirecciones("D:\\a\\b\\c", "NuevoArchivo.txt");

            Assert.AreEqual("D:\\a\\b\\c\\NuevaCarpeta\\", actual1);
            Assert.AreEqual("D:\\a\\b\\c\\NuevoArchivo.txt", actual2);

        }
    }
}

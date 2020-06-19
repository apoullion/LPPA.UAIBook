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
    public class ArchivosTests
    {
        [TestMethod()]
        public void ObtenerNombreArchivoTest()
        {
            var prueba1 = @"C:\a\b\c\algo.txt";
            var actual1 = Archivos.ObtenerNombreArchivo(prueba1);
            Assert.AreEqual(@"algo.txt", actual1);

            try
            {
                var prueba2 = @"C:\a\b\c\";
                var actual2 = Archivos.ObtenerNombreArchivo(prueba2);
                Assert.Fail("Deberia haber arrojado una excepcion.");
            }
            catch (DevCityFrameworkException ex)
            {
                Assert.AreEqual("No se puede obtener el nombre del archivo porque el resultado de la busqueda indica que no hay un nombre de archivo valido y con extension.", ex.Message);
            }

        }
    }
}

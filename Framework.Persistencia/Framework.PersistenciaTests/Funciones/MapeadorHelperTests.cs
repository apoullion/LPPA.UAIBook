using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevCity.Framework.Persistencia.Funciones;
using System.Data;
using DevCity.Framework.Persistencia.Entidades;
using NSubstitute;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using DevCity.Framework.Nucleo.PatronesDevCity.Persistencia;

namespace DevCity.Framework.Persistencia.Funciones.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class MapeadorHelperTests
    {
        [TestMethod]
        public void MapeadorHelperInstanciaTest()
        {
            var mh = MapeadorHelper.Instancia();
            Assert.IsNotNull(mh);
        }


        [TestMethod]
        public void RealizarConversionTest()
        {
            var mh = MapeadorHelper.Instancia();
            var resultadoDataReaderMock = NSubstitute.Substitute.For<IDataReader>();

            resultadoDataReaderMock.FieldCount.Returns(1);
            resultadoDataReaderMock.GetName(0).Returns("Apellido");
            resultadoDataReaderMock.Read().Returns(true, false);
            resultadoDataReaderMock[0].Returns("Simpson");

            var resultado = mh.RealizarConversion<UsuarioTest>(resultadoDataReaderMock).ToList();

            Assert.AreEqual("Simpson", resultado.First().Apellido);
        }


        public class UsuarioTest : IEntidadPersistente
        {
            public String Apellido { get; set; }
        }
    }
}

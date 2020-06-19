using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Funciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.Funciones.Tests
{
    [TestClass()]
    public class ValidadoresTests
    {
        [TestMethod()]
        public void ValidarMailTest()
        {
            Validadores unValidador = new Validadores();
            string mail = "lucas.hartridge9@gmail.com";
            var valorRetorno = unValidador.ValidarMail(mail);

            var valorRetornoFalse = unValidador.ValidarMail("asd");

            Assert.IsTrue(valorRetorno);
            Assert.IsFalse(valorRetornoFalse);
        }

        [TestMethod()]
        public void CantidadCaracteresTest()
        {
            Validadores unValidador = new Validadores();
           var valorRetorno = unValidador.CantidadCaracteres("Abcde", 1, 3);

            Assert.IsFalse(valorRetorno);
        }

        [TestMethod()]
        public void CadenaSoloLetrasTest()
        {
            Validadores unValidador = new Validadores();
            var valorRetorno = unValidador.CadenaSoloLetras("123");
            Assert.IsFalse(valorRetorno);
        }

        [TestMethod()]
        public void CadenaSoloNumerosTest()
        {
            Validadores unValidador = new Validadores();
            var valorRetorno = unValidador.CadenaSoloNumeros("ASDB");
            Assert.IsFalse(valorRetorno);

        }
    }
}

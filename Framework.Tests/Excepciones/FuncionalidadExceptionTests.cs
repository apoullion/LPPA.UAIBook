using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
namespace Framework.Excepciones.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class FuncionalidadExceptionTests
    {
        [TestMethod()]
        public void FuncionalidadExceptionTest()
        {
            var ex = new FuncionalidadException("Error");

            Assert.AreEqual("Error", ex.Message);
            Assert.IsNull(ex.InnerException);

            var innerEx = new Exception("innerEx");
            var ex2 = new FuncionalidadException("Error", innerEx);

            Assert.AreEqual("Error", ex2.Message);
            Assert.IsNotNull(ex2.InnerException);
            Assert.AreEqual("innerEx", ex2.InnerException.Message);

        }
    }
}

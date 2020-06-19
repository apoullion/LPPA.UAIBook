using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Mensajeria.CorreoElectronico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Framework.Mensajeria.CorreoElectronico.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class CorreoElectronicoTests
    {
        [TestMethod()]
        public void AgregarDestinatarioTest()
        {
            string correoElectronico = "lucas.hartridge9@gmail.com";
            string nombreMostrar = "Lucas";

            var valorRetorno = new CorreoElectronico();

            valorRetorno.AgregarDestinatario(correoElectronico, nombreMostrar);

            var listaDeDestinatarios = valorRetorno.Destinatarios;

            Assert.AreNotEqual(0, listaDeDestinatarios.Count);

        }

        [TestMethod()]
        public void AgregarDestinatarioOcultoTest()
        {
            string correoElectronico = "lucas.hartridge9@gmail.com";
            string nombreMostrar = "Lucas";

            var valorRetorno = new CorreoElectronico();
            valorRetorno.AgregarDestinatarioOculto(correoElectronico, nombreMostrar);

            var listaDeDestinatarios = valorRetorno.DestinatariosOcultos;
            Assert.AreNotEqual(0, listaDeDestinatarios.Count);
        }

        [TestMethod()]
        public void EliminarDestinatariosTest()
        {
            var valorRetorno = new CorreoElectronico();
            valorRetorno.AgregarDestinatario("a@b.com", "aaaa");
            valorRetorno.AgregarDestinatario("c@d.com", "cccc");

            valorRetorno.EliminarDestinatarios("a@b.com");
            Assert.AreEqual(1, valorRetorno.Destinatarios.Count);

            valorRetorno.EliminarDestinatarios();
            Assert.AreEqual(0, valorRetorno.Destinatarios.Count);
        }


        [TestMethod()]
        public void EliminarDestinatariosOcultosTest()
        {
            var valorRetorno = new CorreoElectronico();
            valorRetorno.AgregarDestinatarioOculto("a@b.com", "aaaa");
            valorRetorno.AgregarDestinatarioOculto("c@d.com", "cccc");

            valorRetorno.EliminarDestinatariosOcultos("a@b.com");
            Assert.AreEqual(1, valorRetorno.DestinatariosOcultos.Count);

            valorRetorno.EliminarDestinatariosOcultos();
            Assert.AreEqual(0, valorRetorno.DestinatariosOcultos.Count);
        }


    }
}

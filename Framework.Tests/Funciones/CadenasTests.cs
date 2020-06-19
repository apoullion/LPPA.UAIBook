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
    public class CadenasTests
    {

        [TestMethod()]
        public void ParsearTest()
        {
            var cadena1 = "a@bb@ccc@";
            var cadena2 = "";

            var actual1 = Framework.Funciones.Cadenas.Parsear(cadena1, "@");
            Assert.AreEqual("a", actual1.First());
            Assert.AreEqual("bb", actual1.ElementAt(1));
            Assert.AreEqual("ccc", actual1.ElementAt(2));

            var actual2 = Framework.Funciones.Cadenas.Parsear(cadena2, "@");
            Assert.IsNotNull(actual2);
            Assert.AreEqual(0, actual2.Count);
        }

        [TestMethod()]
        public void UnirListaTest()
        {
            var lista = new List<String>();
            lista.Add("C:");
            lista.Add("users");
            lista.Add("lfucci");

            var actual = Framework.Funciones.Cadenas.UnirLista(lista, "\\");
            Assert.AreEqual("C:\\users\\lfucci", actual);
        }

        [TestMethod()]
        public void DecorarListaTest()
        {
            var lista = new List<String>();
            lista.Add("homero");
            lista.Add("bart");
            lista.Add("lisa");

            var actual = Framework.Funciones.Cadenas.DecorarLista(lista, "@", ">");

            Assert.AreEqual("@homero>", actual.First());
            Assert.AreEqual("@lisa>", actual.Last());
        }

        [TestMethod()]
        public void TextoEntreMarcasTest()
        {
            var texto1 = "aaaaaaa@@bbbbb(cccccc";
            var actual1 = Cadenas.TextoEntreMarcas(texto1, "@@", "(");
            Assert.AreEqual("bbbbb", actual1);

            var texto2 = "aaaaaaa@@bbbbbcccccc";
            var actual2 = Cadenas.TextoEntreMarcas(texto2, "@@", "(");
            Assert.AreEqual("", actual2);

            var texto3 = "aaaaaaa@bbbbb(cccccc";
            var actual3 = Cadenas.TextoEntreMarcas(texto3, "@@", "(");
            Assert.AreEqual("", actual3);

            var texto4 = "aaa(aaaa@@bbbbb(cccccc";
            var actual4 = Cadenas.TextoEntreMarcas(texto4, "@@", "(");
            Assert.AreEqual("bbbbb", actual4);
        }

        [TestMethod()]
        public void TextoSinBasuraIzquierdaTest()
        {
            var texto = "basurabasura@texto";

            var actual = Cadenas.TextoSinBasuraIzquierda(texto, "@");

            Assert.AreEqual("texto", actual);
        }

        [TestMethod()]
        public void TextoSinBasuraDerechaTest()
        {
            var texto = "texto@basurabasura";

            var actual = Cadenas.TextoSinBasuraDerecha(texto, "@");

            Assert.AreEqual("texto", actual);
        }

        [TestMethod()]
        public void FormatearTest()
        {
            var actual = Cadenas.Formatear("El nombre es {0} y el apellido es {1}.", "Homero", "Simpson");

            Assert.AreEqual("El nombre es Homero y el apellido es Simpson.", actual);
        }

        [TestMethod()]
        public void ReemplazarTest()
        {
            var actual1 = Cadenas.Reemplazar("hola {apellido}", "{apellido}", "simpson");
            Assert.AreEqual("hola simpson", actual1);

            var actual2 = Cadenas.Reemplazar("hola {Apellido}", "{apellido}", "simpson");
            Assert.AreEqual("hola {Apellido}", actual2);

            var actual3 = Cadenas.Reemplazar("hola {Apellido}", "{apellido}", "simpson", true);
            Assert.AreEqual("hola simpson", actual3);
        }

        [TestMethod()]
        public void ReemplazarEntreMarcasTest()
        {
            var actual = Cadenas.ReemplazarEntreMarcas("aaa<bbb>ccc", "<", ">", "zzz");
            Assert.AreEqual("aaazzzccc", actual);

            var actual2 = Cadenas.ReemplazarEntreMarcas(">aaa<bbb>ccc<", "<", ">", "zzz");
            Assert.AreEqual(">aaazzzccc<", actual2);
        }

        [TestMethod()]
        public void ObtenerAsciiTest()
        {
            var actual = Cadenas.ObtenerAscii('A');

            Assert.AreEqual(65, actual);
        }

        [TestMethod()]
        public void ObtenerSoloMayusculasTest()
        {
            var actual = Cadenas.ObtenerSoloMayusculas("Esto Es Un Texto");

            Assert.AreEqual("EEUT", actual);
        }

        [TestMethod()]
        public void QuitarDecoradoListaTest()
        {
            var lista = new List<String>();
            lista.Add("@a");
            lista.Add("@b");

            var actual = Cadenas.QuitarDecoradoLista(lista, "@");

            Assert.AreEqual("a", actual.First());
            Assert.AreEqual("b", actual.Last());
        }

        [TestMethod()]
        public void TruncarCadenaTest()
        {
            var actual = Cadenas.TruncarCadena("Leonardo", 3);

            Assert.AreEqual("Leo", actual);
        }

        [TestMethod()]
        public void TextoSinNulosTest()
        {

            Assert.IsNotNull(Cadenas.TextoSinNulos("Leo"));
            Assert.IsNotNull(Cadenas.TextoSinNulos(null));

        }


    }
}

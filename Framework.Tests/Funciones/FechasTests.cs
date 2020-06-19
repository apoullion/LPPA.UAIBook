using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Funciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Framework;

namespace Framework.Funciones.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class FechasTests
    {


        [TestMethod()]
        public void HoyTest()
        {
            var diaHoy = Funciones.Fechas.Hoy();
            var hoy = DateTime.Today;

            Assert.AreEqual(hoy,diaHoy);
        }

        [TestMethod()]
        public void AhoraTest()
        {
            var diaAhora = Funciones.Fechas.Ahora();
            var ahora = DateTime.Now;

            Assert.AreEqual(ahora, diaAhora);
        }

        [TestMethod()]
        public void SoloFechaTest()
        {
            var fecha = DateTime.Now;
            var soloFecha = Funciones.Fechas.SoloFecha(fecha);
            var fechaDeHoy = DateTime.Parse((fecha.Year + ("/"
                            + (fecha.Month + ("/" + fecha.Day))))); ;

        }

        [TestMethod()]
        public void SoloFechaEnStringTest()
        {
           var fechaYHora = DateTime.Now;
           var fechaEnString = Funciones.Fechas.SoloFechaEnString(fechaYHora);
           string fecha = fechaYHora.ToString("d");
               
              
        }

        [TestMethod()]
        public void FechaEnStringTest()
        {
           var fechaYHora = DateTime.Now;
           var fechaEnString = Funciones.Fechas.FechaEnString(fechaYHora);
           string fecha = fechaYHora.ToString("dd/MM/yyyy HH:mm:ss");
            
        }

        [TestMethod()]
        public void PrimerDiaDelMesEnFechaTest()
        {
            var fechaHoy = DateTime.Now;
            var primerDia = Funciones.Fechas.PrimerDiaDelMesEnFecha(Funciones.Fechas.Hoy());
            var primerDiaConFecha = Funciones.Fechas.PrimerDiaDelMesEnFecha(fechaHoy);
            DateTime resultado = new DateTime(fechaHoy.Year, fechaHoy.Month, 1);

            Assert.AreEqual(resultado, primerDia);
            Assert.AreEqual(resultado, primerDiaConFecha);

            var primerDiaAhora = Fechas.PrimerDiaDelMesEnFecha();
            Assert.AreEqual(resultado, primerDiaAhora);
        }

        [TestMethod()]
        public void UltimoDiaDelMesEnFechaTest()
        {
            var fechaHoy = DateTime.Now;
            var ultimoDia = Funciones.Fechas.UltimoDiaDelMesEnFecha(Funciones.Fechas.Hoy());
            var ultimoDiaConFecha = Funciones.Fechas.UltimoDiaDelMesEnFecha(fechaHoy);

            var primerDiaDelMesSiguiente = Funciones.Fechas.PrimerDiaDelMesEnFecha(fechaHoy.AddMonths(1));

            // Si le resto un dia, me queda el ultimo dia del mes anterior.
            DateTime ultimaFecha = primerDiaDelMesSiguiente.AddMilliseconds(-1);
            DateTime resultado = new DateTime(ultimaFecha.Year, ultimaFecha.Month, ultimaFecha.Day);
            
            Assert.AreEqual(resultado, ultimoDia);
            Assert.AreEqual(resultado, ultimoDiaConFecha);

            var ultimoDiaAhora = Fechas.UltimoDiaDelMesEnFecha();
            Assert.AreEqual(resultado, ultimoDiaAhora);

        }

        [TestMethod()]
        public void FechaNulaSqlTest()
        {
            var fechaNulaSQL = Funciones.Fechas.FechaNulaSql();
            var nuevaFecha = new DateTime(1900, 1, 1, 0, 0, 0);

            Assert.AreEqual(nuevaFecha,fechaNulaSQL);
        }

        [TestMethod()]
        public void UltimaHoraDelDiaTest()
        {
            var fecha = DateTime.Now;
            var ultimaHoraDelDia = Funciones.Fechas.UltimaHoraDelDia(fecha);
            var resultado = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59, 999);

            Assert.AreEqual(resultado,ultimaHoraDelDia);
        }

        [TestMethod()]
        public void PrimeraHoraDelDiaTest()
        {
            var fecha = DateTime.Now;
            var primeraHoraDelDia = Funciones.Fechas.PrimeraHoraDelDia(fecha);
            var resultado = new DateTime (fecha.Year, fecha.Month, fecha.Day, 0, 0, 0, 0);

            Assert.AreEqual(resultado, primeraHoraDelDia);
        }


     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Framework.Funciones
{
    /// <summary>
    /// Contiene funciones de fechas
    /// </summary>
    public static class Fechas
    {

        /// <summary>
        /// Devuelve la fecha de hoy, sin horas.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime Hoy()
        {
            // Return SoloFecha(DateTime.Now)
            return DateTime.Today;
        }

        /// <summary>
        /// Devuelve la fecha exacta de ahora.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime Ahora()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// En base a una fecha, devuelve solo los dias quitando el horario.
        /// </summary>
        /// <param name="fechaYHora"></param>
        /// <returns></returns>
        public static DateTime SoloFecha(DateTime fechaYHora)
        {
            return new DateTime(fechaYHora.Year, fechaYHora.Month, fechaYHora.Day);
        }

        /// <summary>
        /// Devuelve solo la fecha normalizada en argentino.
        /// </summary>
        /// <param name="fechaYHora"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static String SoloFechaEnString(DateTime fechaYHora)
        {
            return SoloFecha(fechaYHora).ToString("dd/MM/yyyy", Cultura.ObtenerCultura());
        }


        /// <summary>
        /// Devuelve una fecha normalizada en argentino.
        /// </summary>
        /// <param name="fechaYHora"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static String FechaEnString(DateTime fechaYHora)
        {
            return fechaYHora.ToString("dd/MM/yyyy HH:mm:ss", Cultura.ObtenerCultura());
        }

        /// <summary>
        /// Devuelve el primer dia del mes actual.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime PrimerDiaDelMesEnFecha()
        {
            return PrimerDiaDelMesEnFecha(Hoy());
        }

        /// <summary>
        /// Devuelve el primer dia dentro del mes de la fecha indicada.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime PrimerDiaDelMesEnFecha(DateTime fecha)
        {
            DateTime resultado = new DateTime(fecha.Year, fecha.Month, 1);
            return resultado;
        }

        /// <summary>
        /// Devuelve el ultimo dia del mes actual.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime UltimoDiaDelMesEnFecha()
        {
            return UltimoDiaDelMesEnFecha(Hoy());
        }

        /// <summary>
        /// Devuelve el ultimo dia del mes indicado.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime UltimoDiaDelMesEnFecha(DateTime fecha)
        {
            // Pido el primer dia del mes siguiente...
            DateTime PrimerDiaDelMesSiguiente = PrimerDiaDelMesEnFecha(fecha.AddMonths(1));
            // Si le resto un dia, me queda el ultimo dia del mes anterior.
            DateTime ultimaFecha = PrimerDiaDelMesSiguiente.AddMilliseconds(-1);
            return new DateTime(ultimaFecha.Year, ultimaFecha.Month, ultimaFecha.Day);
        }

        /// <summary>
        /// Devuelve el representante de una fecha nula en sqlServer
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime FechaNulaSql()
        {
            // 1/1/1900 12:00:00 AM
            return new DateTime(1900, 1, 1, 0, 0, 0);
        }

        /// <summary>
        /// Devuelve el representante de una fecha a la ultima hora del dia
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime UltimaHoraDelDia(DateTime fecha)
        {
            return new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59, 999);
        }

        /// <summary>
        /// Devuelve el representante de una fecha a la primera hora del dia
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime PrimeraHoraDelDia(DateTime fecha)
        {
            return new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Devuelve la Fecha con la Cantidad de Dias Agregados
        /// </summary>
        /// <returns></returns>
        public static DateTime AgregarDiasAFecha(int dias)
        {
            var fecha = Ahora();
            return fecha.AddDays(dias);
        }

        /// <summary>
        /// Devuelve la Fecha con la Cantidad de Dias Restados
        /// </summary>
        /// <returns></returns>
        public static DateTime RestarDiasAFecha(int dias)
        {
            var fecha = Ahora();
            return fecha.AddDays(-dias);
        }

        /// <summary>
        /// Obtiene los Dias habiles a partir de una fecha
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="diasAgregados"></param>
        /// <returns></returns>
        public static DateTime ObtenerDiasHabiles(DateTime fechaInicio, int diasAgregados)
        {
            if (fechaInicio.DayOfWeek == DayOfWeek.Saturday) { fechaInicio = fechaInicio.AddDays(2); }
            if (fechaInicio.DayOfWeek == DayOfWeek.Sunday) { fechaInicio = fechaInicio.AddDays(1); }
            Int32 weeks = diasAgregados / 5;
            diasAgregados += weeks * 2;
            if (fechaInicio.DayOfWeek > fechaInicio.AddDays(diasAgregados).DayOfWeek) { diasAgregados += 2; }
            if (fechaInicio.AddDays(diasAgregados).DayOfWeek == DayOfWeek.Saturday) { diasAgregados += 2; }
            
            return fechaInicio.AddDays(diasAgregados); } 
        }
}


using Framework.Excepciones;
using Framework.Funciones;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Framework.Aplicaciones
{
    /// <summary>
    /// Contiene metodos para trabajar con aplicaciones corriendo en el sistema.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class Aplicacion
    {

        /// <summary>
        /// Devuelve un listado de parametros que tiene dentro el proceso lanzado.
        /// </summary>
        /// <param name="proceso"></param>
        /// <returns></returns>
        public static List<String> ObtenerParametrosInicioAplicacion(Process proceso)
        {
            proceso.StartInfo.RedirectStandardOutput = true;
            proceso.StartInfo.UseShellExecute = false;
            proceso.StartInfo.CreateNoWindow = true;

            //var cadena = proceso.StandardOutput.ReadToEnd().ToString();
            var cadena = proceso.StartInfo.Arguments;

            return Cadenas.Parsear(cadena, " ");
        }

        /// <summary>
        /// Recibe un nombre de proceso y devuelve si se encuentra activo en memoria.
        /// </summary>
        /// <param name="nombreProceso"></param>
        /// <returns></returns>
        public static Boolean AplicacionEstaCorriendo(String nombreProceso)
        {
            return Process.GetProcessesByName(nombreProceso).Length > 0;
        }

        /// <summary>
        /// Permite lanzar una aplicacion.
        /// </summary>
        /// <param name="direccionAplicacion">Ubicacion.</param>
        /// <param name="parametros">Parametros para el lanzamiento.</param>
        /// <param name="tiempoEspera">Tiempo a esperar por el timeout de la aplicacion.</param>
        /// <returns>Devuelve el ExitCode, donde cero es Exito.</returns>
        public static Int32 LanzarAplicacion(String direccionAplicacion, String parametros, Int32 tiempoEspera)
        {
            try
            {
                var parseado = Cadenas.Parsear(direccionAplicacion, "\\");

                var proceso = new Process();
                proceso.StartInfo.FileName = parseado.Last();

                proceso.StartInfo.Arguments = parametros;
                proceso.StartInfo.RedirectStandardOutput = false;
                proceso.StartInfo.UseShellExecute = true;


                parseado.RemoveAt(parseado.Count - 1);
                proceso.StartInfo.WorkingDirectory = Cadenas.UnirLista(parseado, "\\");

                proceso.Start();

                if (tiempoEspera == 0) tiempoEspera = Int32.MaxValue;

                proceso.WaitForExit(tiempoEspera);

                return proceso.ExitCode;
            }
            catch (Exception ex)
            {
                throw new DevCityFrameworkException("No se pudo lanzar la aplicacion, compruebe la excepcion interna.", ex);
            }
        }

        /// <summary>
        /// Permite lanzar una aplicacion.
        /// </summary>
        /// <param name="direccionAplicacion">Ubicacion.</param>
        /// <param name="parametros">Parametros para el lanzamiento.</param>
        /// <returns>Devuelve el ExitCode, donde cero es Exito.</returns>
        public static Int32 LanzarAplicacion(String direccionAplicacion, String parametros)
        {
            return LanzarAplicacion(direccionAplicacion, parametros, 0);
        }

        /// <summary>
        /// Permite lanzar una aplicacion.
        /// </summary>
        /// <param name="direccionAplicacion">Ubicacion.</param>
        /// <returns>Devuelve el ExitCode, donde cero es Exito.</returns>
        public static Int32 LanzarAplicacion(String direccionAplicacion)
        {
            return LanzarAplicacion(direccionAplicacion, "", 0);
        }

        /// <summary>
        /// Permite cerrar una o multiples instancias de un proceso en ejecucion.
        /// </summary>
        /// <param name="nombreProceso">El proceso a eliminar.</param>
        /// <param name="cerrarMultiplesInstancias">Si se encuentran multiples instancias y es TRUE, se cerraran todas, sino se cierra solo la primera encontrada.</param>
        public static void CerrarAplicacion(String nombreProceso, Boolean cerrarMultiplesInstancias)
        {
            var procesos = ObtenerProcesoEnEjecucion(nombreProceso);

            for (int i = 0; i < procesos.Count; i++)
            {
                procesos.ElementAt(i).Kill();

                if (!cerrarMultiplesInstancias) return;
            }
        }

        /// <summary>
        /// Obtiene el listado de procesos que cumplan el nombre indicado.
        /// </summary>
        /// <param name="nombreProceso"></param>
        /// <returns></returns>
        public static List<Process> ObtenerProcesoEnEjecucion(String nombreProceso)
        {
            return Process.GetProcessesByName(nombreProceso).ToList();
        }

        /// <summary>
        /// Devuelve un listado de procesos completo.
        /// </summary>
        /// <returns></returns>
        public static List<Process> ObtenerProcesosEnEjecucion()
        {
            return Process.GetProcesses().ToList();
        }

        /// <summary>
        /// Lanza la Pagina Web que se le pasa por parametro
        /// </summary>
        /// <param name="url"></param>
        public static void LanzarPaginaWeb(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
    }
}

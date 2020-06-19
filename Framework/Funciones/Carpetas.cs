using Framework.Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Funciones
{

    /// <summary>
    /// Contiene funciones de ayuda para trabajar con carpetas.
    /// No permite la creacion de carpetas, utilizar SistemaArchivos para ello.
    /// </summary>
    public static class Carpetas
    {

        /// <summary>
        /// Normaliza el nombre de la carpeta para quitar posibles caracteres invalidos en el camino del path.
        /// </summary>
        /// <param name="nombreCarpeta"></param>
        /// <returns></returns>
        public static String NormalizarNombreCarpeta(String nombreCarpeta)
        {
            //Obtengo la lista, sacando posibles caracteres barra repetidos.
            var lista = Cadenas.Parsear(nombreCarpeta, "\\").Where(w => !String.IsNullOrEmpty(w)).ToList();

            //Si la ultima de las partes contiene un punto, se lo considera un archivo.
            if (lista.Last().Contains("."))
            {
                //Lo que vino esta ok.
                return Cadenas.UnirLista(lista, "\\");
            }
            else
            {
                //Siempre finaliza con una barra.
                return Cadenas.UnirLista(lista, "\\") + "\\";
            }

        }

        /// <summary>
        /// Devuelve la ruta completa de la carpeta de la direccion ingresada.
        /// Si la direccion tiene un nombre de archivo, omite dicho nombre de archivo.
        /// Si la ultima de las carpetas tiene un punto en su nombre, se considerara nombre de archivo.
        /// </summary>
        /// <param name="rutaCompleta"></param>
        /// <returns></returns>
        public static String ObtenerRutaCarpetaDeRutaCompleta(String rutaCompleta)
        {
            //Normalizo la carpeta como primer medida, para saber que no esta mal formateada.
            var carpetaNormalizada = NormalizarNombreCarpeta(rutaCompleta);

            //Separo las secciones.
            var listaSecciones = Cadenas.Parsear(carpetaNormalizada, "\\");

            //Si el ultimo tiene forma de nombre de archivo, entonces se remueve.
            if (listaSecciones.Last().Contains(".")) listaSecciones.RemoveAt(listaSecciones.Count - 1);

            //Y vuelvo a unir.
            return NormalizarNombreCarpeta(Cadenas.UnirLista(listaSecciones, "\\"));
        }

        /// <summary>
        /// Devuelve el nombre de la carpeta de la ruta completa.
        /// Si la direccion tiene un nombre de archivo, omite dicho nombre de archivo. 
        /// </summary>
        /// <param name="rutaCompleta"></param>
        /// <returns></returns>
        public static String ObtenerNombreCarpetaDeRutaCompleta(String rutaCompleta)
        {
            //Normalizo la carpeta como primer medida, para saber que no esta mal formateada.
            var carpetaNormalizada = NormalizarNombreCarpeta(rutaCompleta);

            //Separo las secciones.
            var listaSecciones = Cadenas.Parsear(carpetaNormalizada, "\\");

            //Si el ultimo tiene forma de nombre de archivo, entonces se remueve.
            if (listaSecciones.Last().Contains(".")) listaSecciones.RemoveAt(listaSecciones.Count - 1);

            //Solo devuelvo la ultima.
            return listaSecciones.Last();
        }

        /// <summary>
        /// Ingresas una ruta de carpeta y las posiciones por retroceder.
        /// Devuelve la ubicacion actual luego de retroceder.
        /// </summary>
        /// <param name="direccionCarpeta"></param>
        /// <param name="posicionesRetroceder"></param>
        /// <returns></returns>
        public static String NavegarCarpeta(String direccionCarpeta, Int32 posicionesRetroceder)
        {
            //Normalizo la carpeta como primer medida, para saber que no esta mal formateada.
            var carpetaNormalizada = NormalizarNombreCarpeta(direccionCarpeta);

            //Separo las secciones.
            var listaSecciones = Cadenas.Parsear(carpetaNormalizada, "\\");

            //Compruebo que se puede realizar la operacion
            if (posicionesRetroceder >= listaSecciones.Count) throw new DevCityFrameworkException(Cadenas.Formatear("La cantidad de posiciones por retroceder es igual o excede la cantidad de posiciones disponibles por navegar. Existen {0} posicion(es) y se intento retroceder {1} posicion(es).", listaSecciones.Count, posicionesRetroceder));

            //Obtengo solo las partes requeridas
            var resultado = listaSecciones.Take(listaSecciones.Count - posicionesRetroceder).ToList();

            //Y vuelvo a unir.
            return NormalizarNombreCarpeta(Cadenas.UnirLista(resultado, "\\"));
        }


        /// <summary>
        /// Recibe una direccion completa y una nueva carpeta y devuelve la combinacion de ambas.
        /// </summary>
        /// <param name="rutaCarpeta">Ejemplo: D:\\a\\b\\</param>
        /// <param name="carpeta">Ejemplo: NuevaCarpeta</param>
        /// <returns>Ejemplo retorno: D:\a\b\NuevaCarpeta\</returns>
        public static String CombinarDirecciones(String rutaCarpeta, String carpeta)
        {
            var carpetaNormalizada = NormalizarNombreCarpeta(rutaCarpeta);

            return NormalizarNombreCarpeta(Path.Combine(carpetaNormalizada, carpeta));
        }
    }

}

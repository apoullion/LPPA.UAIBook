using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.VariablesGlobales
{
    /// <summary>
    /// Clase que Posee la Configuracion del Idioma
    /// </summary>
    public class ConfiguracionIdioma
    {
        private static ConfiguracionIdioma _dtoIdioma;
        private static int _idIdioma = 1;
        private static string _nombre = "Ingles";

        // Constructor Privado
          private ConfiguracionIdioma() { }

        /// <summary>
        /// Constructor, que implementa el Patron Singleton
        /// Devuelve una Unica Instancia de la Clase, si no exista la crea
        /// </summary>
        /// <returns></returns>
          public static ConfiguracionIdioma Instance()
        {
            if (_dtoIdioma == null)
            {
                _dtoIdioma = new ConfiguracionIdioma();
            }

            _dtoIdioma.IdIdioma = _idIdioma;
            _dtoIdioma.Nombre = _nombre;

            return _dtoIdioma;
        }
        /// <summary>
        /// Metodo que modifica los valores Predeterminados del Idioma
        /// </summary>
        /// <param name="nuevaConfiguracion"></param>
        public static void ModificarConfiguracion(ConfiguracionIdioma nuevaConfiguracion)
        {
            _idIdioma = nuevaConfiguracion.IdIdioma;
            _nombre = nuevaConfiguracion.Nombre;
        }

        /// <summary>
        /// Property que almacena el ID del Idioma
        /// </summary>
          public int IdIdioma { get; set; }

          /// <summary>
          /// Property que almacena el Nombre del Idioma
          /// </summary>
          public string Nombre { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.VariablesGlobales
{
    /// <summary>
    /// Clase que posee los datos del usuario en Sesion
    /// </summary>
   public class ConfiguracionUsuario
    {
       private static ConfiguracionUsuario _dtoUsuario;
       private static int _idUsuario = 1;
       private static string _nombre;
       private static string _apellido;
       private static string _mail;
       private static string _contraseña;
       private static int _idTipoUsuario;

        // Constructor Privado
          private ConfiguracionUsuario() { }

        /// <summary>
        /// Constructor, que implementa el Patron Singleton
        /// Devuelve una Unica Instancia de la Clase, si no exista la crea
        /// </summary>
        /// <returns></returns>
          public static ConfiguracionUsuario Instance()
        {
            if (_dtoUsuario == null)
            {
                _dtoUsuario = new ConfiguracionUsuario();
            }

            return _dtoUsuario;
        }
        /// <summary>
        /// Metodo que modifica los valores Predeterminados del Idioma
        /// </summary>
        /// <param name="nuevaConfiguracion"></param>
        public static void ModificarConfiguracion(ConfiguracionUsuario nuevaConfiguracion)
        {
            _idUsuario = nuevaConfiguracion.IdUsuario;
            _nombre = nuevaConfiguracion.Nombre;
            _apellido = nuevaConfiguracion.Apellido;
            _mail = nuevaConfiguracion.Mail;
            _contraseña = nuevaConfiguracion.Contraseña;
            _idTipoUsuario = nuevaConfiguracion.IdTipoUsuario;
        }

        /// <summary>
        /// Property que almacena el ID del Idioma
        /// </summary>
          public int IdUsuario { get; set; }

          /// <summary>
          /// Property que almacena el Nombre del Usuario
          /// </summary>
          public string Nombre { get; set; }

          /// <summary>
          /// Property que almacena el Apellido del Usuario
          /// </summary>
          public string Apellido { get; set; }

          /// <summary>
          /// Property que almacena el Mail del Usuario
          /// </summary>
          public string Mail { get; set; }

          /// <summary>
          /// Property que almacena la Contraseña del Usuario
          /// </summary>
          public string Contraseña { get; set; }

          /// <summary>
          /// Property que almacena el Id Correspondiente al Tipo de Usuario que pertenece
          /// </summary>
          public int IdTipoUsuario{ get; set;}


    }
}

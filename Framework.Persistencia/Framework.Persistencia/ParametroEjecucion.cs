using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistencia
{
    /// <summary>
    /// Utilice este parametro de ejecucion para enviarse a la base de datos como parametro de un comando.
    /// </summary>
    public class ParametroEjecucion
    {
        /// <summary>
        /// Crea una instancia por defecto vacia.
        /// </summary>
        public ParametroEjecucion()
        {

        }

        /// <summary>
        /// Crea un parametro con sus campos.
        /// </summary>
        /// <param name="nombreParametro">Ingrese el nombre del parametro incluyendo @.</param>
        /// <param name="valor">Ingrese el valor del parametro.</param>
        public ParametroEjecucion(String nombreParametro, Object valor)
        {
            this.NombreParametro = nombreParametro;
            this.Valor = valor;
        }

        /// <summary>
        /// Nombre del parametro, generalmente debe empezar con @.
        /// </summary>
        public String NombreParametro { get; set; }

        /// <summary>
        /// Valor que contiene el parametro.
        /// </summary>
        public Object Valor { get; set; }
    }
}


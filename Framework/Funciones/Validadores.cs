using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Framework.Funciones
{
    /// <summary>
    /// Clase que provee funciones para validar ciertos escenarios utilizando Regex
    /// </summary>
    public class Validadores
    {
        /// <summary>
        /// Funcion que el formato del Mail
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public bool ValidarMail(string mail)
        {
         
            //Devuelve True or False dependiendo si el Mail es Valido o No
            Regex re = new Regex("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
            Match m = re.Match(mail);
            return (m.Captures.Count != 0);
        }

        /// <summary>
        /// Funcion que validad que la cadena de caracteres respete un minimo y maximo de caracteres
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="minimo"></param>
        /// <param name="maximo"></param>
        /// <returns></returns>
        public bool CantidadCaracteres(string cadena, int minimo,int maximo)
        {
            bool r = Regex.IsMatch(cadena, "\\d{" + minimo.ToString() + "," + maximo.ToString() + "}");

            if (r)
            {
                return true;
            }
            else
	        {
               return false;
	        }
	    {
		 
	}
        }

        /// <summary>
        /// Funciona que valida que la cadena solo contenga Letras
        /// </summary>
        /// <param name="cadenaDeTexto"></param>
        /// <returns></returns>
        public bool CadenaSoloLetras(string cadenaDeTexto)
        {
            bool valorRetorno = Regex.IsMatch(cadenaDeTexto, "^[a-zA-Z]+$");

            if (valorRetorno)
            {
                return true;
            }
            else
	        {
                return false;
	        }
        }

        /// <summary>
        /// Funcion que valida que la cadena solo contenga Numeros
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public bool CadenaSoloNumeros(string cadena)
        {
            bool valorRetorno = Regex.IsMatch(cadena, "^[0-9]$");
            if (valorRetorno)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Funcion que recibe el numero de la tarjeta de credito y la compania, que valida su formato
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <param name="companiaTarjeta"></param>
        /// <returns></returns>
        public bool ValidarTarjetaDeCredito(string numeroTarjeta,TipoTarjetaDeCredito companiaTarjeta)
        {
            bool valorRetorno;

            switch (companiaTarjeta)
            {
                case TipoTarjetaDeCredito.AmericanExpress:
                    valorRetorno = Regex.IsMatch(numeroTarjeta,"^3[47][0-9]{13}$");
                    return valorRetorno;

                case TipoTarjetaDeCredito.Mastercard:
                    valorRetorno = Regex.IsMatch(numeroTarjeta,"5[1-5][0-9]{14}$");
                    return valorRetorno;

                case TipoTarjetaDeCredito.Visa:
                    valorRetorno = Regex.IsMatch(numeroTarjeta, "^4[0-9]{12}(?:[0-9]{3})?$");
                    return valorRetorno;

                default :
                    return false;
            }
        }

        /// <summary>
        /// Enumerador de Tarjetas de Creditio
        /// </summary>
        public enum TipoTarjetaDeCredito
        {
            /// <summary>
            /// MasterCard
            /// </summary>
            Mastercard,
            /// <summary>
            /// Visa
            /// </summary>
            Visa,
            /// <summary>
            /// American Express
            /// </summary>
            AmericanExpress,
        };

        /// <summary>
        /// Funcion Encargada de Validar si algun TextBox se encuentra Vacio
        /// </summary>
       
        public bool ValidarTextBox(Form formulario)
        {

            foreach (Control oControls in formulario.Controls) // Buscamos en cada TextBox de nuestro Formulario. 
            {
                if (oControls is TextBox & oControls.Text == String.Empty) // Verificamos que no este vacio. 
                {
                    MessageBox.Show("Por Favor, llene todos los Campos");
                    return true;
                }
            }

            return false;
        }
    }
}

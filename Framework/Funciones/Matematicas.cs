using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Funciones
{
    /// <summary>
    /// Contiene funciones para resolver problemas matematicos.
    /// </summary>
    public static class Matematicas
    {

        private static Random rnd = new Random();

        /// <summary>
        /// Devuelve un numero aleatorio que se encuentre entre los valores pedidos.
        /// </summary>
        /// <param name="desde">Este valor se incluye en el resultado.</param>
        /// <param name="hasta">Este valor se incluye en el resultado.</param>
        /// <returns></returns>
        public static Int32 NumeroAleatorio(Int32 desde, Int32 hasta)
        {
            return rnd.Next(desde, hasta + 1);
        }

        /// <summary>
        /// Se ingresa un numero (500) y un porcentaje (10) y devuelve el valor que representa
        /// dicho porcentaje sobre el total (50).
        /// </summary>
        /// <param name="porcentaje">Ingrese un porcentaje (ejemplo 10%)</param>
        /// <param name="total">Ingrese un valor (ejemplo 100)</param>
        /// <returns></returns>
        public static Decimal ObtenerPorcentaje(Decimal porcentaje, Decimal total)
        {
            return porcentaje * total / 100;
        }

        /// <summary>
        /// Se ingresa un numero en bruto (121) y un porcentaje (21) y devuelve el valor que
        /// representa en neto, quitando el porcentaje agregado aplicando division 1/x (1.21).
        /// </summary>
        /// <param name="porcentaje">Ingrese un porcentaje (ejemplo 21%)</param>
        /// <param name="totalBruto">Ingrese un importe en bruto (ejemplo 121)</param>
        /// <returns></returns>
        public static Decimal QuitarPorcentajeDevuelveNeto(Decimal porcentaje, Decimal totalBruto)
        {
            var porcentajeDivisible = (porcentaje / 100) + 1;

            return totalBruto / porcentajeDivisible;
        }

        /// <summary>
        /// Recibe un importe bruto (121) y un porcentaje (21%) y devuelve cual fue el valor
        /// que resulto del porcentaje agregado (21).
        /// </summary>
        /// <param name="porcentaje">Ejemplo 21%</param>
        /// <param name="totalBruto">Ejemplo 121</param>
        /// <returns></returns>
        public static Decimal QuitarPorcentaje(Decimal porcentaje, Decimal totalBruto)
        {
            var resultadoNeto = QuitarPorcentajeDevuelveNeto(porcentaje, totalBruto);

            return totalBruto - resultadoNeto;
        }

        /// <summary>
        /// Ingresas un valor a evaluar (10) y un total (500) y devuelve
        /// que porcentaje es el valor a evaluar sobre el total (2%)
        /// </summary>
        /// <param name="cantidadEvaluar">Ejemplo 10</param>
        /// <param name="cantidadTotal">Ejemplo 500</param>
        /// <returns></returns>
        public static Decimal ObtenerPorcentajePorciento(Decimal cantidadEvaluar, Decimal cantidadTotal)
        {
            return cantidadEvaluar * 100 / cantidadTotal;
        }

        /// <summary>
        /// Ingresas un valor bruto (100) y un descuento (10%)
        /// Devuelve cual es el nuevo importe con descuento (90)
        /// </summary>
        /// <param name="porcentajeDescontar"></param>
        /// <param name="valorBruto"></param>
        /// <returns></returns>
        public static Decimal AplicarDescuentoSobreImporteBruto(Decimal porcentajeDescontar, Decimal valorBruto)
        {
            var porcentajeDivisible = 1 - (porcentajeDescontar / 100);

            return (valorBruto * porcentajeDivisible);
        }

        /// <summary>
        /// Ingresas un valor bruto (100) y un descuento (10%)
        /// Devuelve el valor descontado.
        /// </summary>
        /// <param name="porcentajeDescontar"></param>
        /// <param name="valorBruto"></param>
        /// <returns></returns>
        public static Decimal ObtenerDescuentoSobreImporteBruto(Decimal porcentajeDescontar, Decimal valorBruto)
        {
            var nuevoValor = AplicarDescuentoSobreImporteBruto(porcentajeDescontar, valorBruto);

            return valorBruto - nuevoValor;
        }


    }
}

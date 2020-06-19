using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using System.Diagnostics.CodeAnalysis;
using Framework.Excepciones;

namespace Framework.Office
{
    /// <summary>
    /// Permite el manejo de una instancia de excel.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DevCityExcel
    {

        /// <summary>
        /// Coordenadas excel utilizada por la busqueda de texto dentro de un documento.
        /// </summary>
        public class CoordenadaExcel
        {
            /// <summary>
            /// Fila del excel indicada en numeros.
            /// </summary>
            public Int32 Fila { get; set; }

            /// <summary>
            /// Columna del excel indicada en numeros.
            /// </summary>
            public Int32 Columna { get; set; }
        }


        private Application _app;

        private String DireccionArchivo { get; set; }


        /// <summary>
        /// Permite abrir un archivo de excel existente.
        /// </summary>
        /// <param name="direccionArchivoAbrir"></param>
        /// <param name="mostrarExcel">Si es true, se visualiza excel. Sino corre excel en memoria.</param>
        public void AbrirArchivo(String direccionArchivoAbrir, Boolean mostrarExcel)
        {
            this._app = new Application();
            this._app.Workbooks.Open(direccionArchivoAbrir);
            this._app.Visible = mostrarExcel;

            this.DireccionArchivo = DireccionArchivo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direccionArchivoNuevo"></param>
        /// <param name="mostrarExcel">Si es true, se visualiza excel. Sino corre excel en memoria.</param>
        public void NuevoExcel(String direccionArchivoNuevo, Boolean mostrarExcel)
        {
            try
            {
                this._app = new Application();
                this._app.Workbooks.Add(1);
                this._app.Visible = mostrarExcel;
                this.DireccionArchivo = direccionArchivoNuevo;
                this._app.DisplayAlerts = false;
            }
            catch (Exception ex)
            {
                throw new DevCityFrameworkException("Ocurrio un error al intentar lanzar una instancia de excel. Posiblemente Excel no se encuentre correctamente instalado.", ex);
            }
        }

        /// <summary>
        /// Cierra la instancia de excel actual.
        /// </summary>
        /// <param name="debeGrabar"></param>
        public void CerrarExcel(Boolean debeGrabar)
        {
            if (debeGrabar) this._app.Workbooks[1].Save();

            this._app.Workbooks[1].Close(debeGrabar, Type.Missing, Type.Missing);
            this._app.Quit();
        }

        /// <summary>
        /// Permite enviar a la impresora un documento de excel.
        /// Se lanzara por la impresora predeterminada del sistema.
        /// </summary>
        public void ImprimirExcel()
        {
            var temp = (Worksheet)this._app.Worksheets[1];

            temp.PrintOutEx();

            //http://stackoverflow.com/questions/854693/printing-excel-using-interop
        }

        /// <summary>
        /// Devuelve lo leido en la posicion indicada. (En formato string)
        /// </summary>
        /// <param name="hoja"></param>
        /// <param name="columna"></param>
        /// <param name="fila"></param>
        /// <returns></returns>
        public String Leer(Int32 hoja, Int32 columna, Int32 fila)
        {
            var resultado = LeerTipado(hoja, columna, fila);

            if (resultado == null) return "";

            return resultado.ToString();
        }

        /// <summary>
        /// Devuelve lo leido en la posicion indicada. (En formato object)
        /// </summary>
        /// <param name="hoja"></param>
        /// <param name="columna"></param>
        /// <param name="fila"></param>
        /// <returns></returns>
        public Object LeerTipado(Int32 hoja, Int32 columna, Int32 fila)
        {
            var sheet = (Worksheet)this._app.Worksheets[hoja];
            var retorno = (Range)sheet.Cells[fila, columna];

            return retorno.Value;
        }

        /// <summary>
        /// Permite escribir en la posicion indicada.
        /// </summary>
        /// <param name="hoja"></param>
        /// <param name="columna"></param>
        /// <param name="fila"></param>
        /// <param name="contenido"></param>
        public void Escribir(Int32 hoja, Int32 columna, Int32 fila, Object contenido)
        {
            var sheet = (Worksheet)this._app.Worksheets[hoja];

            ((Range)sheet.Cells[fila, columna]).Value = contenido;
        }

        /// <summary>
        /// Devuelve la coordenada donde se encuentra el texto buscado.
        /// </summary>
        /// <param name="hoja"></param>
        /// <param name="textoBuscar"></param>
        /// <returns></returns>
        public CoordenadaExcel BuscarCoordenada(Int32 hoja, String textoBuscar)
        {
            var sheet = (Worksheet)this._app.Worksheets[hoja];
            var range = (Range)sheet.Cells;

            var resultado = range.Find(textoBuscar, Type.Missing,
                XlFindLookIn.xlValues,
                XlLookAt.xlWhole,
                XlSearchOrder.xlByColumns,
                XlSearchDirection.xlNext,
                false
                );

            if (resultado == null) return null;

            return new CoordenadaExcel
            {
                Columna = resultado.Column,
                Fila = resultado.Row
            };

        }
    }
}

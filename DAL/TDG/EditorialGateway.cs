using Framework.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TDG
{
    public class EditorialGateway
    {
        public static List<DTO.DtoEditorial> TraerEditoriales()
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);

            unaConexion.ConexionIniciar();

            var parametros = new List<ParametroEjecucion>();

            var resultado = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoEditorial>("Select * From Editorial", parametros);

            unaConexion.ConexionFinalizar();

            return resultado;
        }
    }
}

using Framework.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TDG
{
    public class AutorGateway
    {
        public static List<DTO.DtoAutor> TraerAutores()
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);

            unaConexion.ConexionIniciar();

            var parametros = new List<ParametroEjecucion>();

            var resultado = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoAutor>("Select * From Autor", parametros);

            unaConexion.ConexionFinalizar();

            return resultado;
        }
    }
}

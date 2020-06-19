using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DTO;
using Framework.Persistencia;

namespace DAL.TDG
{
    /// <summary>
    /// Implementacion del TDG Basado en el Patron CRUD
    /// </summary>
   internal class GeneroGateway
    {
       public static void AgregarUnGenero(string nombre, int user)
       {
           CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

           Conexion unaConexion = new Conexion(nuevaCadena);

           unaConexion.ConexionIniciar();

           var parametros = new List<ParametroEjecucion>();

           parametros.Add(new ParametroEjecucion("@Nombre", nombre));
           parametros.Add(new ParametroEjecucion("@CreatedOn", DateTime.Now));
           parametros.Add(new ParametroEjecucion("@CreatedBy", user));
           parametros.Add(new ParametroEjecucion("@ChangedOn", DBNull.Value));
           parametros.Add(new ParametroEjecucion("@ChangedBy", DBNull.Value));

           unaConexion.EjecutarSPSinResultado("GeneroInsert", parametros);
           

           unaConexion.ConexionFinalizar();
           //var conexionString = ConfigurationManager.ConnectionStrings["UaiBook"].ConnectionString;
           //var conexion = new SqlConnection(conexionString);
           //conexion.Open();
           //var comando = new SqlCommand("GeneroInsert", conexion);
           //comando.CommandType = System.Data.CommandType.StoredProcedure;

           //comando.Parameters.Add(new SqlParameter("@Nombre", nombre));
           //comando.Parameters.Add(new SqlParameter("@CreatedOn", DateTime.Now));
           //comando.Parameters.Add(new SqlParameter("@CreatedBy", user));
           //comando.Parameters.Add(new SqlParameter("@ChangedOn", DBNull.Value));
           //comando.Parameters.Add(new SqlParameter("@ChangedBy", DBNull.Value));
           //conexion.Close();
       }

       public static List<DtoGenero> TraerGeneros()
       {
           CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer,".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);

            unaConexion.ConexionIniciar();

            var parametros = new List<ParametroEjecucion>();

            var resultado = unaConexion.EjecutarConsultaResultadoTupla<DtoGenero>("Select * From Genero", parametros);

            unaConexion.ConexionFinalizar();

            return resultado;
       }
             
   
    }
}

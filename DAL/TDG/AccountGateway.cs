using Framework.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TDG
{
    public class AccountGateway
    {
        public static bool ValidarUsuario(DTO.DtoMembershipUser account)
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);
            try
            {
                unaConexion.ConexionIniciar();

                var parametros = new List<ParametroEjecucion>();

                parametros.Add(new ParametroEjecucion("@Email", account.Email));
                parametros.Add(new ParametroEjecucion("@Password", account.Password.ToString()));

                var resultado = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoMembershipUser>("Select * From MembershipUser Where Email = @Email AND Password = @Password", parametros);

                if  (resultado.Count() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Framework.Excepciones.FuncionalidadException ex)
            {
                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("Error al Verificar la cuenta:" + ex.ToString(), "DAL", "UAI BOOK");
                throw new Exception("Error al Verificar la cuenta");
            }
            finally
            {
                unaConexion.ConexionFinalizar();
            }
        }

        public static DTO.DtoMembershipUser ObtenerUsuarioPorId(int id)
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);
            try
            {
                unaConexion.ConexionIniciar();

                var parametros = new List<ParametroEjecucion>();

                parametros.Add(new ParametroEjecucion("@Id",id));
                
                var resultado = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoMembershipUser>("Select * From MembershipUser Where Id = @Id", parametros);

                return resultado.FirstOrDefault(); ;
            }
            catch (Framework.Excepciones.FuncionalidadException ex)
            {
                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("Error al Obtener el Usuario:" + ex.ToString(), "DAL", "UAI BOOK");
                throw new Exception("Error al Traer Usuario");
            }
            finally
            {
                unaConexion.ConexionFinalizar();
            }
        }
    }
    }


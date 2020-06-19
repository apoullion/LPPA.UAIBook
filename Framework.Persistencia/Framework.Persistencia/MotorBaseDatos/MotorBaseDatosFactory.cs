using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Framework.Persistencia.MotorBaseDatos
{
    internal static class MotorBaseDatosFactory
    {
        internal static IMotorBaseDatos ObtenerMotorBaseDatos(CadenaConexion cadenaConexion)
        {
            IMotorBaseDatos resultado = null;

            switch (cadenaConexion.MotorBaseDatos)
            {
               // Instancia de Sql Server
                case CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer:
                    resultado = new SqlServerAdapter(cadenaConexion);
                    break;

                
            }

            return resultado;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Facade
{
    public class AccountFacade
    {

        public static bool ValidarUsuario(DTO.DtoMembershipUser account)
        {
           return DAL.TDG.AccountGateway.ValidarUsuario(account);
        }

        public static DTO.DtoMembershipUser ObtenerUsuarioPorId(int id)
        {
            return DAL.TDG.AccountGateway.ObtenerUsuarioPorId(id);
        }
    }
}

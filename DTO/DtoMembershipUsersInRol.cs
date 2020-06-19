using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Persistencia;

namespace DTO
{
    public class DtoMembershipUsersInRol : IEntidadPersistente
    {
        public int UserId { get; set; }

        public int RolId { get; set; }
    }
}

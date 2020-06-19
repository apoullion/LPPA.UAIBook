using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Persistencia;

namespace DTO
{
    public class DtoMembershipRole : IEntidadPersistente
    {
        public int Id { get; set; }

        public string RolName { get; set; }

        public enum Rol
        {
            /// <summary>
            /// Admin = 1
            /// </summary>
            Admin,
            /// <summary>
            /// Cliente = 2
            /// </summary>
            Cliente,
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Persistencia;

namespace DTO
{
    public class DtoGenero : IEntidadPersistente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ChangedOn { get; set; }

        public int? ChangedBy { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Persistencia;

namespace DTO
{
    public class DtoEditorial : IEntidadPersistente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Domicilio { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string URL { get; set; }
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ChangedOn { get; set; }

        public int ChangedBy { get; set; }

    }
}

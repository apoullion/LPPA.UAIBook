using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Persistencia;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class DtoAutor : IEntidadPersistente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Direccion de Mail Invalida")]
        public string Email { get; set; }
        public string URL { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int ChangedBy { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Persistencia;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class DtoMembershipUser : IEntidadPersistente
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es Requerido")]
        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        [Required(ErrorMessage = "El campo Email es Requerido")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Direccion de Mail Invalida")]

        public string Email { get; set; }

        public string Avatar { get; set; }
    }
}

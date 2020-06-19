using DevCity.Framework.Nucleo.PatronesDevCity.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCity.Framework.Persistencia.Demo.EntidadesDto
{
    public class Cliente : IEntidadPersistente
    {
        public Int32 IdUsuario { get; set; }

        public String Apellido { get; set; }

        public String Nombre { get; set; }

        public Guid Clave { get; set; }

        public Boolean Activo { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}

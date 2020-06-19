using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Persistencia;

namespace DTO
{
    public class DtoBitacora : IEntidadPersistente
    {
        public Guid IdBitacora { get; set; }

        public int IdSeveridad { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public Guid IdUsuario { get; set; }
    }
}

using Framework.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoControlIdioma : IEntidadPersistente
    {
        public string NombreControl { get; set; }
        public int IdIdioma { get; set; }
        public string Valor { get; set; }
    }
}

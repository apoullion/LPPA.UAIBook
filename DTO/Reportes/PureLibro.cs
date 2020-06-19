using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Reportes
{
    public class PureLibro
    {

        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public int GeneroId { get; set; }
        public int EditorialId { get; set; }
        public bool Destacado { get; set; }
        public string Imagen { get; set; }
        public int Cantidad { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int ChangedBy { get; set; }
    }
}
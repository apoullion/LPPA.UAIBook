using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Persistencia;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace DTO
{
    public class DtoPrestamo : IEntidadPersistente
    {
    
        [Key]
        public int Id { get; set; }

        public int LibroId { get; set; }

        public int UserId { get; set; }

        public virtual DtoLibro Libro { get; set; }

        public virtual DtoPrestamoEstado PrestamoEstado {get;set;}

        [NotMapped]
        public SelectList LibrosList { get; set; }
    }
}

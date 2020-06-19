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
    public class DtoLibro : IEntidadPersistente
    {
        [Required(ErrorMessage = "El campo ID es Requerido")]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[\w.']{2,}(\s[\w.']{2,})+$", ErrorMessage = "Ingrese un ISBN Valido")]
        [StringLength(13, ErrorMessage = "EL ISBN debe contener 13 caracteres")]
        public string ISBN { get; set; }

        [RegularExpression(@"^[\w.']{2,}(\s[\w.']{2,})+$",ErrorMessage="Ingrese un Titulo Valido")]
        
        [Required]
        public string Titulo { get; set; }

        [Required]
        public int AutorId { get; set; }

        [Required]
        public int GeneroId { get; set; }

        [Required]
        public int EditorialId { get; set; }

        [Required]
        public bool Destacado { get; set; }

        [Required]
        public string Imagen { get; set; }

        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Ingrese una Cantidad Valida")]
        public int Cantidad { get; set; }

        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int ChangedBy { get; set; }

        public virtual DtoAutor Autor { get; set; }
        public virtual DtoEditorial Editorial { get; set; }
        public virtual DtoGenero Genero { get; set; }

        [NotMapped]
        public SelectList GeneroList { get; set; }

        [NotMapped]
        public SelectList AutorList { get; set; }

        [NotMapped]
        public SelectList EditorialList { get; set; }
    }
}

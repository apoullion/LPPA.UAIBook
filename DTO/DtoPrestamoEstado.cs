using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Persistencia;

namespace DTO
{
    public class DtoPrestamoEstado : IEntidadPersistente
    {
        public int PrestamoId { get; set; }

        public string Estado { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

        public  DateTime ChangedOn { get; set; }
        public int ChangedBy { get; set; }

        public enum TipoEstado
        {
            /// <summary>
            /// Solicitado = 1
            /// </summary>
            Solicitado,
            /// <summary>
            /// Prestado = 2
            /// </summary>
            Prestado,
            /// <summary>
            /// Reintegrado = 3
            /// </summary>
            Reintegrado,
            /// <summary>
            /// Vencido = 4
            /// </summary>
            Vencido,
        };
    }
}

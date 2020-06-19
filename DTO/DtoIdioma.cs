using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Persistencia;

namespace DTO
{
    public class DtoIdioma : IEntidadPersistente
    {
        private string _nombre;
        private int _idIdioma;
        public int IdIdioma
        {
            get { return _idIdioma; }
            set { _idIdioma = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

    }
}

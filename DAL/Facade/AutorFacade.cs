using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Facade
{
    public class AutorFacade
    {
        public static List<DTO.DtoAutor> TraerAutores()
        {
            return TDG.AutorGateway.TraerAutores();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Facade
{
    public class GeneroFacade 
    {

        public static void AgregarGenero(DtoGenero unGenero)
        {
            TDG.GeneroGateway.AgregarUnGenero(unGenero.Nombre, unGenero.CreatedBy);
        }

        public static List<DtoGenero> TraerGeneros()
        {
            return TDG.GeneroGateway.TraerGeneros();
        }
    }
}

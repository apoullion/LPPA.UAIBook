using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Facade
{
    public class EditorialFacade
    {
        public static List<DTO.DtoEditorial> TraerEditoriales()
        {
            return TDG.EditorialGateway.TraerEditoriales();
        }
    }
}

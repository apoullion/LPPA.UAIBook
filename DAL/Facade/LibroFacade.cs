using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Facade
{
    public class LibroFacade
    {
        public static List<DtoLibro> TraerLibros()
        {
            return DAL.TDG.LibroGateway.TraerLibros();
        }

        public static DtoLibro TraerLibroPorId(int? id)
        {
            return DAL.TDG.LibroGateway.TraerLibroPorId(id);
        }

        public static void AgregarUnLibro(DtoLibro libro)
        {
            DAL.TDG.LibroGateway.AgregarUnLibro(libro);
        }

            public static void ActualizarUnLibro(DtoLibro libro)
            {
                DAL.TDG.LibroGateway.ActualizarUnLibro(libro);
            }

            public static void BorrarUnLibro(DtoLibro libro)
            {
                DAL.TDG.LibroGateway.BorrarUnLibro(libro);
            }

        public static void ImportarLibrosXML(List<DtoLibro> libros)
        {
            DAL.TDG.LibroGateway.ImportarLibrosXML(libros);
        }
    }
}

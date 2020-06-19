using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class GestorMaestro 
    {
        public static void AgregarUnGenero(DtoGenero unGenero)
        {
            DAL.Facade.GeneroFacade.AgregarGenero(unGenero);
        }

        public static List<DtoLibro> TraerLibros()
        {
           return DAL.Facade.LibroFacade.TraerLibros();
        }


        public static DtoLibro TraerLibroPorId(int? id)
        {
            return DAL.Facade.LibroFacade.TraerLibroPorId(id);
        }

        public static void AgregarUnPrestamo(DtoPrestamo prestamo)
        {
            DAL.Facade.PrestamoFacade.AgregarUnPrestamo(prestamo);
        }

        public static List<DtoPrestamo> TraerPrestamosPorEstado(DtoPrestamoEstado.TipoEstado tipoEstado)
        {
            return DAL.Facade.PrestamoFacade.TraerPrestamosPorEstado(tipoEstado);
        }

        public static List<DtoAutor> TraerAutores()
        {
            return DAL.Facade.AutorFacade.TraerAutores();
        }

        public static List<DtoEditorial> TraerEditoriales()
        {
            return DAL.Facade.EditorialFacade.TraerEditoriales();
        }

        public static List<DtoGenero> TraerGeneros()
        {
            return DAL.Facade.GeneroFacade.TraerGeneros();
        }

        public static void AgregarUnLibro(DtoLibro libro)
        {
            DAL.Facade.LibroFacade.AgregarUnLibro(libro);
        }

        public static void ActualizarUnLibro(DtoLibro libro)
        {
            DAL.Facade.LibroFacade.ActualizarUnLibro(libro);
        }

        public static void BorrarUnLibro(DtoLibro libro)
        {
            DAL.Facade.LibroFacade.BorrarUnLibro(libro);
        }

        public static bool ValidarUsuario(DtoMembershipUser account)
        {
            return DAL.Facade.AccountFacade.ValidarUsuario(account);
        }

        public static bool EsUnicoPrestamo(DtoPrestamo prestamo)
        {
            return DAL.Facade.PrestamoFacade.EsUnicoPrestamo(prestamo);
        }



        public static void ActualizarEstadoPrestamos()
        {
            DAL.Facade.PrestamoFacade.ActualizarEstadoPrestamos();
        }

        public static List<DtoPrestamo> ObtenerPrestamosAdeudados()
        {
            return DAL.Facade.PrestamoFacade.ObtenerPrestamosAdeudados();
        }

        public static DtoMembershipUser ObtenerUsuarioPorId(int idUsuario)
        {
            return DAL.Facade.AccountFacade.ObtenerUsuarioPorId(idUsuario);
        }

        public static DtoPrestamo TraerPrestamoPorId(int id)
        {
            return DAL.Facade.PrestamoFacade.TraerPrestamoPorId(id);
        }

        public static void ActualizarPrestamoAPrestado(DtoPrestamo prestamo)
        {
            DAL.Facade.PrestamoFacade.ActualizarPrestamoAPrestado(prestamo);
        }

        public static void ImportarLibrosXML(List<DtoLibro> libros)
        {
            DAL.Facade.LibroFacade.ImportarLibrosXML(libros);
        }
    }
}

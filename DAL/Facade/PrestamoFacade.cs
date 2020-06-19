using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Facade
{
    public class PrestamoFacade
    {
        public static void AgregarUnPrestamo(DtoPrestamo unPrestamo)
        {
            TDG.PrestamoGateway.Insert(unPrestamo);
        }

        public static List<DtoPrestamo> TraerPrestamosPorEstado(DtoPrestamoEstado.TipoEstado tipoEstado)
        {
           return TDG.PrestamoGateway.TraerPrestamoPorEstado(tipoEstado);
        }

        public static bool EsUnicoPrestamo(DtoPrestamo prestamo)
        {
            return TDG.PrestamoGateway.EsUnicoPrestamo(prestamo);
        }

        public static void ActualizarEstadoPrestamos()
        {
            TDG.PrestamoGateway.ActualizarEstadoPrestamos();
        }

        public static List<DtoPrestamo> ObtenerPrestamosAdeudados()
        {
            return TDG.PrestamoGateway.ObtenerPrestamosAdeudados();
        }

        public static DtoPrestamo TraerPrestamoPorId(int id)
        {
            return TDG.PrestamoGateway.TraerPrestamoPorId(id);
        }

        public static void ActualizarPrestamoAPrestado(DtoPrestamo prestamo)
        {
            TDG.PrestamoGateway.ActualizarPrestamoAPrestado(prestamo);
        }

    }
}

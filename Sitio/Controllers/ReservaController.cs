using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework;

namespace Sitio.Controllers
{
    public class ReservaController : Controller
    {

        //
        // GET: /Reserva/
        public ActionResult Index()
        {
            BLL.GestorMaestro.ActualizarEstadoPrestamos();
           var prestamos = new List<DTO.DtoPrestamo>();
           prestamos = BLL.GestorMaestro.TraerPrestamosPorEstado(DTO.DtoPrestamoEstado.TipoEstado.Solicitado);

           return View(prestamos);
        }

        //
        // GET: /Reserva/Deudores

        public ActionResult Deudores()
        {
            BLL.GestorMaestro.ActualizarEstadoPrestamos();
            var prestamos = new List<DTO.DtoPrestamo>();
            prestamos = BLL.GestorMaestro.ObtenerPrestamosAdeudados();

            if (prestamos.Count > 0)
            {
                return View(prestamos);
            }
            else
            {
                return RedirectToAction("SinDeuda","Error");
            }

        }

        // POST: /Reserva/Deudores
        [HttpPost]
        public ActionResult Deudores(FormCollection form)
        {
            var prestamos = new List<DTO.DtoPrestamo>();
            prestamos = BLL.GestorMaestro.ObtenerPrestamosAdeudados();

            Services.Mail.EnviarCorreoPorPrestamoAdedudado(prestamos);

            return RedirectToAction("Index", "Home");;
        }
        //
        // GET: /Reserva/Create
        public ActionResult Create(int id)
        {
            DTO.DtoPrestamo prestamo = new DTO.DtoPrestamo();
            var libro = new DTO.DtoLibro();
            prestamo.Libro = libro;

            var prestamoEstado = new DTO.DtoPrestamoEstado();
            prestamo.PrestamoEstado = prestamoEstado;
            prestamo.PrestamoEstado.Estado = DTO.DtoPrestamoEstado.TipoEstado.Solicitado.ToString();
            prestamo.PrestamoEstado.Fecha =  DateTime.Now;

           var libroPedido = BLL.GestorMaestro.TraerLibroPorId(id);
           prestamo.Libro = libroPedido;

            return View(prestamo);
        }

        //
        // POST: /Reserva/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            int libroSeleccionado = Convert.ToInt32(form["txtId"]);

            if(ModelState.IsValid)
            {
                try
                {
                    var prestamo = new DTO.DtoPrestamo();
                    var p = new DTO.DtoPrestamoEstado();
                    var libro = new DTO.DtoLibro();
                    prestamo.Libro = libro;
                    prestamo.PrestamoEstado = p;

                    prestamo.UserId = 1;
                    prestamo.LibroId = Convert.ToInt32(form["txtId"]);
                    prestamo.Libro.Titulo = form["txtTitulo"];
                    prestamo.PrestamoEstado.Fecha = Convert.ToDateTime(form["txtFecha"]);
                    prestamo.PrestamoEstado.Estado = form["txtEstado"];
                    prestamo.Libro.Cantidad = Convert.ToInt32(form["txtCantidad"]);

                    if (BLL.GestorMaestro.EsUnicoPrestamo(prestamo))
                    {
                        BLL.GestorMaestro.AgregarUnPrestamo(prestamo);

                        Services.Mail.EnviarCorreoPorPrestamo(prestamo);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("ReservaExistente", "Error");
                    }
                }
                catch
                {
                    return View(libroSeleccionado);
                }
            }
            else
            {
                return View(libroSeleccionado);
            }
         }

        //
        // GET: /Reserva/EntregarLibro
        public ActionResult EntregarLibro(int id)
        {
            DTO.DtoPrestamo prestamo = new DTO.DtoPrestamo();
            prestamo = BLL.GestorMaestro.TraerPrestamoPorId(id);

            return View(prestamo);
        }

        //
        // POST: /Reserva/EntregarLibro
        [HttpPost]
        public ActionResult EntregarLibro(FormCollection form)
        {
                try
                {
                    var prestamo = new DTO.DtoPrestamo();
                    var prestamoEstado = new DTO.DtoPrestamoEstado();
                    var libro = new DTO.DtoLibro();
                    prestamo.Libro = libro;
                    prestamo.PrestamoEstado = prestamoEstado;

                    prestamo.Id = Convert.ToInt32(form["txtId"]); ;
                    prestamo.PrestamoEstado.Estado = DTO.DtoPrestamoEstado.TipoEstado.Prestado.ToString();
                    prestamo.PrestamoEstado.ChangedOn = DateTime.Now;
                    prestamo.PrestamoEstado.ChangedBy = 251194;
    
                    BLL.GestorMaestro.ActualizarPrestamoAPrestado(prestamo);

                    Services.Mail.EnviarCorreoPorPrestamo(prestamo);

                    return RedirectToAction("Index", "Home");
                }
                
                catch
                {
                    return RedirectToAction("Index", "Reserva");
                }
            }
        
    }
}

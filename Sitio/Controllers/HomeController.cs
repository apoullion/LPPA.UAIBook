using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitio.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var libros = new List<DTO.DtoLibro>();
            libros = BLL.GestorMaestro.TraerLibros();

            return View(libros);
        }

        
        // GET: /Home/Contactp
        public ActionResult Contacto()
        {
            return View();
        }

        // POST: /Home/Contacto
        [HttpPost]
        public ActionResult Contacto(FormCollection form)
        {

            try
            {
                string nombre = form["txtNombre"];
                int telefono = Convert.ToInt32(form["txtTelefono"]);
                string mensaje = form["txtTitulo"];
                string mail = form["txtMail"];
                
                Services.Mail.EnviarCorreoPorContacto(mensaje,nombre,telefono,mail);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View(form);
            }
        }

        // GET: /Home/Acerca
        public ActionResult Acerca()
        {
            return View();
        }
	}
}
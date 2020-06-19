using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DTO;

namespace Sitio.Controllers
{
    public class LibroController : Controller
    {
        //
        // GET: /Libro/
        public ActionResult Index()
        {
            List<DTO.DtoLibro> libros = new List<DTO.DtoLibro>();
            libros = BLL.GestorMaestro.TraerLibros();
            return View(libros);
        }


        // GET: /Libro/Create
        public ActionResult Create()
        {
            DTO.DtoLibro libro = new DTO.DtoLibro();
            List<DTO.DtoLibro> libros = new List<DTO.DtoLibro>();

            DTO.DtoAutor autor = new DTO.DtoAutor();
            List<DTO.DtoAutor> autores = new List<DTO.DtoAutor>();

            DTO.DtoEditorial editorial = new DTO.DtoEditorial();
            List<DTO.DtoEditorial> editoriales = new List<DTO.DtoEditorial>();

            DTO.DtoGenero genero = new DTO.DtoGenero();
            List<DTO.DtoGenero> generos = new List<DTO.DtoGenero>();


            libro.Autor = autor;
            libro.Genero = genero;
            libro.Editorial = editorial;

            autores = BLL.GestorMaestro.TraerAutores();
            editoriales = BLL.GestorMaestro.TraerEditoriales();
            generos = BLL.GestorMaestro.TraerGeneros();

            libro.GeneroList = new SelectList(generos, "Id", "Nombre");
            libro.AutorList = new SelectList(autores, "Id", "Apellido");
            libro.EditorialList = new SelectList(editoriales, "Id", "Nombre");

            return View(libro);
        }

        //
        // POST: /Libro/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var libro = new DTO.DtoLibro();


                libro.CreatedBy = 1;
                libro.CreatedOn = DateTime.Now;
                libro.Titulo = Convert.ToString(form["txtTitulo"]);
                libro.Imagen = Convert.ToString(form["txtImagen"]);
                libro.ISBN = Convert.ToString(form["txtIsbn"]);
                libro.Cantidad = Convert.ToInt32(form["txtCantidad"]);
                libro.AutorId = Convert.ToInt32(form["autorDropDownList"]);
                libro.GeneroId = Convert.ToInt32(form["generoDropDownList"]);
                libro.EditorialId = Convert.ToInt32(form["editorialDropDownList"]);
                libro.Destacado = Convert.ToBoolean(form["chkDestacado"]);

                BLL.GestorMaestro.AgregarUnLibro(libro);

                return RedirectToAction("Index", "Libro");
            }
            else
	        {
                return View(Create());
	        }
       }

        //
        // GET: /Libro/Details
        public ActionResult Details(int? id)
        {
            var libro = new DTO.DtoLibro();
            libro = BLL.GestorMaestro.TraerLibroPorId(id);

            return View(libro);

        }

        //
        // GET: /Libro/Delete
        public ActionResult Delete(int? id)
        {
            var libro = new DTO.DtoLibro();
            libro = BLL.GestorMaestro.TraerLibroPorId(id);

            return View(libro);
        }

        //
        // POST: /Libro/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var libro = new DTO.DtoLibro();
                libro.Id = Convert.ToInt32(id);
                BLL.GestorMaestro.BorrarUnLibro(libro);
                return RedirectToAction("Index", "Libro");
            }
            catch
            {
                return View(id);
            }
        }


        //
        // GET: /Libro/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            DTO.DtoLibro libro = BLL.GestorMaestro.TraerLibroPorId(id);

            DTO.DtoAutor autor = new DTO.DtoAutor();
            List<DTO.DtoAutor> autores = new List<DTO.DtoAutor>();

            DTO.DtoEditorial editorial = new DTO.DtoEditorial();
            List<DTO.DtoEditorial> editoriales = new List<DTO.DtoEditorial>();

            DTO.DtoGenero genero = new DTO.DtoGenero();
            List<DTO.DtoGenero> generos = new List<DTO.DtoGenero>();

            libro.Autor = autor;
            libro.Genero = genero;
            libro.Editorial = editorial;

            autores = BLL.GestorMaestro.TraerAutores();
            editoriales = BLL.GestorMaestro.TraerEditoriales();
            generos = BLL.GestorMaestro.TraerGeneros();

            libro.GeneroList = new SelectList(generos, "Id", "Nombre");
            libro.AutorList = new SelectList(autores, "Id", "Apellido");
            libro.EditorialList = new SelectList(editoriales, "Id", "Nombre");

            return View(libro);
        }

        //
        // POST: /Libro/Edit
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            if (ModelState.IsValid)
	        {
		        DTO.DtoLibro libro = new DTO.DtoLibro();

                libro.ChangedBy = 1;
                libro.ChangedOn = DateTime.Now;
                libro.Id = Convert.ToInt32(form["txtId"]);
                libro.ISBN = Convert.ToString(form["txtIsbn"]);
                libro.Titulo = Convert.ToString(form["txtTitulo"]);
                libro.Imagen = Convert.ToString(form["txtImagen"]);
                libro.ISBN = Convert.ToString(form["txtIsbn"]);
                libro.Cantidad = Convert.ToInt32(form["txtCantidad"]);
                libro.AutorId = Convert.ToInt32(form["autorDropDownList"]);
                libro.GeneroId = Convert.ToInt32(form["generoDropDownList"]);
                libro.EditorialId = Convert.ToInt32(form["editorialDropDownList"]);
                libro.Destacado = Convert.ToBoolean(form["chkDestacado"]);

                BLL.GestorMaestro.ActualizarUnLibro(libro);

                return RedirectToAction("Index", "Libro");
	        }
            else
            {
                DTO.DtoLibro libro = BLL.GestorMaestro.TraerLibroPorId(2);

                DTO.DtoAutor autor = new DTO.DtoAutor();
                List<DTO.DtoAutor> autores = new List<DTO.DtoAutor>();

                DTO.DtoEditorial editorial = new DTO.DtoEditorial();
                List<DTO.DtoEditorial> editoriales = new List<DTO.DtoEditorial>();

                DTO.DtoGenero genero = new DTO.DtoGenero();
                List<DTO.DtoGenero> generos = new List<DTO.DtoGenero>();

                libro.Autor = autor;
                libro.Genero = genero;
                libro.Editorial = editorial;

                autores = BLL.GestorMaestro.TraerAutores();
                editoriales = BLL.GestorMaestro.TraerEditoriales();
                generos = BLL.GestorMaestro.TraerGeneros();

                libro.GeneroList = new SelectList(generos, "Id", "Nombre");
                libro.AutorList = new SelectList(autores, "Id", "Apellido");
                libro.EditorialList = new SelectList(editoriales, "Id", "Nombre");

                return View(libro);
                
            }
        }

        //
        //GET: /Libro/ImportarLibro
        public ActionResult ImportarLibro()
        {
            var serializador = Framework.Serializadores.SerializadorXml.Instancia();
            var libro = new DTO.Reportes.LibroXml();

            var librosPure = new List<DTO.Reportes.PureLibro>();
            librosPure.Add(new DTO.Reportes.PureLibro());
            libro.ImportacionXml = librosPure;
            var resultado = serializador.Serializar(libro);

            var grabarArchivo = new Framework.Sistema.ManejoArchivos();
            grabarArchivo.GrabarEnString("C:\\Users\\Lucas Hartridge\\Desktop\\librosXML.xml", resultado);

            return View();
        }
        //
        //POST: /Libro/ImportarLibro
        [HttpPost]
        public ActionResult ImportarLibro(HttpPostedFile librosXml)
        {
            try
            {
                if (librosXml.ContentLength > 0)
                {
                    var libros = Framework.Serializadores.SerializadorXml.Instancia().Deserealizar<DtoLibro>(librosXml.ToString());
                    var libros2 = new List<DtoLibro>();
                    BLL.GestorMaestro.ImportarLibrosXML(libros2);

                    ViewBag.Message = "Los libros han sido importados exitosamente";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ViewBag.Message = "Error al Importar los Libros";
                return RedirectToAction("ImportarLibro");
            }    
            
            return View();
        }

    }
}




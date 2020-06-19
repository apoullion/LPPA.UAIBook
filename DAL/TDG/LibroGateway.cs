using DTO;
using Framework.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;

namespace DAL.TDG
{
    internal class LibroGateway
    {
        public static List<DtoLibro> TraerLibros()
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);

            unaConexion.ConexionIniciar();

            var parametros = new List<ParametroEjecucion>();

            var resultado = unaConexion.EjecutarConsultaResultadoTupla<DtoLibro>("Select * From Libro", parametros);

            //Obtengo los Generos por cada Libro
            foreach (var item in resultado)
            {
                var parametrosGenero = new List<ParametroEjecucion>();
                parametrosGenero.Add(new ParametroEjecucion("@IdGenero", item.GeneroId));
                item.Genero = unaConexion.EjecutarConsultaResultadoTupla<DtoGenero>("Select * From Genero Where Id = @IdGenero",parametrosGenero).FirstOrDefault();
            }

            //Obtengo los Autores por cada Libro
            foreach (var item in resultado)
            {
                var parametrosAutores = new List<ParametroEjecucion>();
                parametrosAutores.Add(new ParametroEjecucion("@IdAutor", item.AutorId));
                item.Autor = unaConexion.EjecutarConsultaResultadoTupla<DtoAutor>("Select * From Autor Where Id = @IdAutor", parametrosAutores).FirstOrDefault();
            }

            //Obtengo las Editoriales por cada Libro
            foreach (var item in resultado)
            {
                var parametrosEditorial = new List<ParametroEjecucion>();
                parametrosEditorial.Add(new ParametroEjecucion("@IdEditorial", item.EditorialId));
                item.Editorial = unaConexion.EjecutarConsultaResultadoTupla<DtoEditorial>("Select * From Editorial Where Id = @IdEditorial", parametrosEditorial).FirstOrDefault();
            }

            unaConexion.ConexionFinalizar();

            return resultado;
        }

        public static DtoLibro TraerLibroPorId(int? id)
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);

            unaConexion.ConexionIniciar();

            var parametros = new List<ParametroEjecucion>();
            parametros.Add(new ParametroEjecucion("@IdLibro", id));

            var resultado = unaConexion.EjecutarConsultaResultadoTupla<DtoLibro>("Select * From Libro Where Id = @IdLibro", parametros);

            var libro = resultado.FirstOrDefault();

            //Obtengo el Genero del Libro
            var parametrosGenero = new List<ParametroEjecucion>();
            parametrosGenero.Add(new ParametroEjecucion("@IdGenero", libro.GeneroId));
            libro.Genero = unaConexion.EjecutarConsultaResultadoTupla<DtoGenero>("Select * From Genero Where Id = @IdGenero", parametrosGenero).FirstOrDefault();

            //Obtengo el Autor del Libro
            var parametrosAutores = new List<ParametroEjecucion>();
            parametrosAutores.Add(new ParametroEjecucion("@IdAutor", libro.AutorId));
            libro.Autor = unaConexion.EjecutarConsultaResultadoTupla<DtoAutor>("Select * From Autor Where Id = @IdAutor", parametrosAutores).FirstOrDefault();
            
            //Obtengo la Editorial del Libro
            var parametrosEditorial = new List<ParametroEjecucion>();
            parametrosEditorial.Add(new ParametroEjecucion("@IdEditorial", libro.EditorialId));
            libro.Editorial = unaConexion.EjecutarConsultaResultadoTupla<DtoEditorial>("Select * From Editorial Where Id = @IdEditorial", parametrosEditorial).FirstOrDefault();

            unaConexion.ConexionFinalizar();

            return libro;
        }

        public static void AgregarUnLibro(DtoLibro libro)
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);
            try
            {
                unaConexion.ConexionIniciar();
                unaConexion.TransaccionIniciar();

                var parametros = new List<ParametroEjecucion>();

                parametros.Add(new ParametroEjecucion("@ISBN", ConvertirIsbn(libro.ISBN)));
                parametros.Add(new ParametroEjecucion("@Titulo", libro.Titulo));
                parametros.Add(new ParametroEjecucion("@GeneroId", libro.GeneroId));
                parametros.Add(new ParametroEjecucion("@AutorId", libro.AutorId));
                parametros.Add(new ParametroEjecucion("@EditorialId", libro.EditorialId));
                parametros.Add(new ParametroEjecucion("@Imagen", libro.Imagen));
                parametros.Add(new ParametroEjecucion("@Cantidad", libro.Cantidad));
                parametros.Add(new ParametroEjecucion("@Destacado", libro.Destacado));
                parametros.Add(new ParametroEjecucion("@CreatedOn", libro.CreatedOn));
                parametros.Add(new ParametroEjecucion("@CreatedBy", libro.CreatedBy));
                parametros.Add(new ParametroEjecucion("@ChangedOn", DBNull.Value));
                parametros.Add(new ParametroEjecucion("@ChangedBy", DBNull.Value));

                unaConexion.EjecutarConsultaSinResultado("INSERT INTO Libro(ISBN,Titulo,GeneroId,AutorId,EditorialId,Imagen,Cantidad,Destacado,CreatedOn,CreatedBy,ChangedOn,ChangedBy VALUES(@ISBN,@Titulo,@GeneroId,@AutorId,@EditorialId,@Imagen,@Cantidad,@Destacado,@CreatedOn,@CreatedBy,@ChangedOn,@ChangedBy)", parametros);
                unaConexion.TransaccionAceptar();
            }
            catch (Framework.Excepciones.FuncionalidadException ex)
            {
                unaConexion.TransaccionCancelar();
                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("El Siguiente Error es Mostrado Al Crear el Libro:" + ex.ToString(), "DAL", "UAI BOOK");
                throw new Exception("Error al Crear el Libro");
            }
            finally
            {
                unaConexion.ConexionFinalizar();
            }
        }
        
        private static string ConvertirIsbn(string ISBN)
        {

            //Ejemplo ISBN 978-3-16-148410-0
            string resultado = "";
            string guion = "-";

            for (int i = 0; i < ISBN.Length; i ++)
            {
                string letra = Convert.ToString(ISBN[i]);
                if (i == 3 || i == 4 || i == 6 || i == 11)
                {
                    resultado += letra + guion;
                }
                else
                {
                    resultado += letra;
                }         
            }
            return resultado;
        }

        public static void ActualizarUnLibro(DtoLibro libro)
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);
            try
            {
                
                unaConexion.ConexionIniciar();
                unaConexion.TransaccionIniciar();

                var parametros = new List<ParametroEjecucion>();

                parametros.Add(new ParametroEjecucion("@Id",libro.Id));
                parametros.Add(new ParametroEjecucion("@ISBN", libro.ISBN));
                parametros.Add(new ParametroEjecucion("@Titulo", libro.Titulo));
                parametros.Add(new ParametroEjecucion("@GeneroId", libro.GeneroId));
                parametros.Add(new ParametroEjecucion("@AutorId", libro.AutorId));
                parametros.Add(new ParametroEjecucion("@EditorialId", libro.EditorialId));
                parametros.Add(new ParametroEjecucion("@Imagen", libro.Imagen));
                parametros.Add(new ParametroEjecucion("@Cantidad", libro.Cantidad));
                parametros.Add(new ParametroEjecucion("@Destacado", libro.Destacado));
                parametros.Add(new ParametroEjecucion("@ChangedOn", libro.ChangedOn));
                parametros.Add(new ParametroEjecucion("@ChangedBy", libro.ChangedBy));

                unaConexion.EjecutarConsultaSinResultado("UPDATE Libro SET ISBN = @ISBN, Titulo = @Titulo ,GeneroId = @GeneroId, AutorId = @AutorId, EditorialId = @EditorialId,Imagen = @Imagen,Cantidad = @Cantidad, Destacado = @Destacado,ChangedOn = @ChangedOn, ChangedBy = @ChangedBy Where Id = @Id", parametros);
                unaConexion.TransaccionAceptar();
            }
            catch (Framework.Excepciones.FuncionalidadException ex)
            {
                unaConexion.TransaccionCancelar();
                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("El Siguiente Error es Mostrado Al Actualizar el Libro:" + ex.ToString(), "DAL", "UAI BOOK");
                throw new Exception("Error al Actualizar el Libro");
            }
            finally
            {
                unaConexion.ConexionFinalizar();
            }
        }

        public static void BorrarUnLibro(DtoLibro libro)
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);
            try
            {
                unaConexion.ConexionIniciar();

                var parametros = new List<ParametroEjecucion>();
                parametros.Add(new ParametroEjecucion("@Id",libro.Id));

                unaConexion.EjecutarConsultaSinResultado("Delete From Libro Where Id = @LibroId", parametros);

            }
            catch (Framework.Excepciones.FuncionalidadException ex)
            {
                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("El Siguiente Error es Mostrado Al Borrar el Libro:" + ex.ToString(), "DAL", "UAI BOOK");
                throw new Exception("Error al Borrar el Libro");
            }
            finally
            {
                unaConexion.ConexionFinalizar();
            }
        }

        internal static void ImportarLibrosXML(List<DtoLibro> libros)
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);
            try
            {
                unaConexion.ConexionIniciar();
                unaConexion.TransaccionIniciar();
                foreach (var libro in libros)
                {
                    var parametros = new List<ParametroEjecucion>();

                    parametros.Add(new ParametroEjecucion("@ISBN", ConvertirIsbn(libro.ISBN)));
                    parametros.Add(new ParametroEjecucion("@Titulo", libro.Titulo));
                    parametros.Add(new ParametroEjecucion("@GeneroId", libro.GeneroId));
                    parametros.Add(new ParametroEjecucion("@AutorId", libro.AutorId));
                    parametros.Add(new ParametroEjecucion("@EditorialId", libro.EditorialId));
                    parametros.Add(new ParametroEjecucion("@Imagen", libro.Imagen));
                    parametros.Add(new ParametroEjecucion("@Cantidad", libro.Cantidad));
                    parametros.Add(new ParametroEjecucion("@Destacado", libro.Destacado));
                    parametros.Add(new ParametroEjecucion("@CreatedOn", libro.CreatedOn));
                    parametros.Add(new ParametroEjecucion("@CreatedBy", libro.CreatedBy));
                    parametros.Add(new ParametroEjecucion("@ChangedOn", DBNull.Value));
                    parametros.Add(new ParametroEjecucion("@ChangedBy", DBNull.Value));

                    unaConexion.EjecutarConsultaSinResultado("INSERT INTO Libro(ISBN,Titulo,GeneroId,AutorId,EditorialId,Imagen,Cantidad,Destacado,CreatedOn,CreatedBy,ChangedOn,ChangedBy VALUES(@ISBN,@Titulo,@GeneroId,@AutorId,@EditorialId,@Imagen,@Cantidad,@Destacado,@CreatedOn,@CreatedBy,@ChangedOn,@ChangedBy)", parametros);
                }
                unaConexion.TransaccionAceptar();
            }
            catch (Framework.Excepciones.FuncionalidadException ex)
            {
                unaConexion.TransaccionCancelar();
                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("El Siguiente Error es Mostrado Al Crear el Libro:" + ex.ToString(), "DAL", "UAI BOOK");
                throw new Exception("Error al Crear el Libro");
            }
            finally
            {
                unaConexion.ConexionFinalizar();
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Framework.Persistencia;

namespace DAL.TDG
{
    public class PrestamoGateway
    {
        /// <summary>
        /// Metodo para crear un prestamo
        /// </summary>
        /// <param name="unPrestamo"></param>
        public static void Insert(DtoPrestamo unPrestamo)
       {
           CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

           Conexion unaConexion = new Conexion(nuevaCadena);
     

             try 
	            {	        
                 unaConexion.ConexionIniciar();
                 unaConexion.TransaccionIniciar();

                 var parametros = new List<ParametroEjecucion>();
                 parametros.Add(new ParametroEjecucion("@LibroId", unPrestamo.LibroId));
                 parametros.Add(new ParametroEjecucion("@UserId", unPrestamo.UserId));
                 
                //Creo la Cabezera
                unaConexion.EjecutarConsultaSinResultado("Insert Into Prestamo values (@LibroId,@UserId)", parametros);
		
                //Creo el Detalle
                 var parametrosDetalle = new List<ParametroEjecucion>();
                 unPrestamo.PrestamoEstado.PrestamoId = DAL.TDG.PrestamoGateway.ObtenerIdUltimoPrestamo(unaConexion);
                 parametrosDetalle.Add(new ParametroEjecucion("@PrestamoId",unPrestamo.PrestamoEstado.PrestamoId));
                 parametrosDetalle.Add(new ParametroEjecucion("@Estado",unPrestamo.PrestamoEstado.Estado));
                 parametrosDetalle.Add(new ParametroEjecucion("@Fecha",unPrestamo.PrestamoEstado.Fecha));
                 parametrosDetalle.Add(new ParametroEjecucion("@CreatedOn", DateTime.Now));
                 parametrosDetalle.Add(new ParametroEjecucion("@CreatedBy", unPrestamo.UserId));
                 parametrosDetalle.Add(new ParametroEjecucion("@ChangedOn", DBNull.Value));
                 parametrosDetalle.Add(new ParametroEjecucion("@ChangedBy", DBNull.Value));

                 unaConexion.EjecutarConsultaSinResultado("Insert into PrestamoEstado VALUES (@PrestamoId,@Estado,@Fecha,@CreatedOn,@CreatedBy,@ChangedOn,@ChangedBy)", parametrosDetalle);

                 //Actualizo el Stock
                 var cantidadActual = unPrestamo.Libro.Cantidad;
                 var cantidadActualizada = cantidadActual - 1;

                 var parametrosStock = new List<ParametroEjecucion>();
                 parametrosStock.Add(new ParametroEjecucion("@LibroId", unPrestamo.LibroId));
                 parametrosStock.Add(new ParametroEjecucion("@Cantidad", cantidadActualizada));

                 unaConexion.EjecutarConsultaSinResultado("UPDATE Libro SET Cantidad = @Cantidad Where Id = @LibroId", parametrosStock);

                 unaConexion.TransaccionAceptar();
	            }
	            catch (Framework.Excepciones.FuncionalidadException ex)
                {
                unaConexion.TransaccionCancelar();
                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("El Siguiente Error es Mostrado Al Crear el Prestamo:" + ex.ToString(),"DAL","UAI BOOK");
                throw new Exception("Error al Intentar Crear la Solicitud del Prestamo");
                }

                finally
                {
                    unaConexion.ConexionFinalizar();
                }
       }

        /// <summary>
        /// Metodo que trae todos los prestamos con su Estado y Libro, segun el Tipo de Estado 
        /// </summary>
        /// <param name="tipoEstado"></param>
        /// <returns></returns>
        public static List<DtoPrestamo> TraerPrestamoPorEstado(DtoPrestamoEstado.TipoEstado tipoEstado)
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

           Conexion unaConexion = new Conexion(nuevaCadena);
     

             try 
	            {	        
                 unaConexion.ConexionIniciar();

                 var parametros = new List<ParametroEjecucion>();
                 parametros.Add(new ParametroEjecucion("@Estado", tipoEstado.ToString()));
                 
                //Traigo los Prestamos
                 var prestamoEstado = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoPrestamoEstado>("Select * From PrestamoEstado Where Estado = @Estado", parametros);
		
                //Busco el Prestamo
                 var prestamos = new List<DtoPrestamo>();

                 foreach (var item in prestamoEstado)
	            {
		            var parametrosPrestamo = new List<ParametroEjecucion>();
                    parametrosPrestamo.Add(new ParametroEjecucion("@Id", item.PrestamoId));
                   
                    var prestamoBuscadoPorId = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoPrestamo>("SELECT * FROM Prestamo Where Id = @Id", parametrosPrestamo);
                    prestamos.Add(prestamoBuscadoPorId.FirstOrDefault());
	            }

                 var prestamoConEstado = new List<DtoPrestamo>();
                  

                 //Agrego el PrestamoEstado al Prestamo
                 foreach (var item in prestamos)
	            {
                     var estadoLinq = from prestamoEstadoId in prestamoEstado
                                      where prestamoEstadoId.PrestamoId == item.Id
                                      select prestamoEstadoId;

		            item.PrestamoEstado = estadoLinq.FirstOrDefault();
                    prestamoConEstado.Add(item);
	            }

                 //Busco el Libro de cada prestamo               
                 foreach (var item in prestamoConEstado)
                 {
                     var parametrosLibro = new List<ParametroEjecucion>();
                     parametrosLibro.Add(new ParametroEjecucion("@Id", item.LibroId));

                     var resultado = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoLibro>("SELECT * FROM Libro Where Id = @Id", parametrosLibro);
                     item.Libro = resultado.FirstOrDefault();
                 }
                 
                 
                 return prestamoConEstado;

	            }
	            catch (Framework.Excepciones.FuncionalidadException ex)
                {
                unaConexion.TransaccionCancelar();
                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("El Siguiente Error es Mostrado Al Traer el Prestamo:" + ex.ToString(),"DAL","UAI BOOK");
                throw new Exception("Error al Intentar Traer Los Prestamos");
                }

                finally
                {
                    unaConexion.ConexionFinalizar();
                }
       }

        private static int ObtenerIdUltimoPrestamo(Conexion unaConexion)
        {
            return unaConexion.EjecutarConsultaResultadoEscalar<int>("Select MAX(Id) From Prestamo", new List<ParametroEjecucion>());
        }

        //Devuelve TRUE si el usuario no posee prestamos en proceso para el libro solicitado
        public static bool EsUnicoPrestamo(DtoPrestamo prestamo)
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);

            try
            {
                unaConexion.ConexionIniciar();

                var parametros = new List<ParametroEjecucion>();
                parametros.Add(new ParametroEjecucion("@UserId", prestamo.UserId));
                parametros.Add(new ParametroEjecucion("@LibroId", prestamo.LibroId));
                

                //Traigo los Prestamos que correspondan al usuario y al libro pedido que existan actualmente
                var pretamosUsuario = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoPrestamo>("Select * From Prestamo Where UserId = @UserId AND LibroId = @LibroId" , parametros);

                if (pretamosUsuario.Count() > 0)
                {
                    //Busco el Prestamo que se corresponda al ID del Libro que solicito el Usuario buscando
                    // el estado de Solicitado o Reintegrado
                    var prestamos = new List<DtoPrestamoEstado>();

                    foreach (var item in pretamosUsuario)
                    {
                        var parametrosPrestamo = new List<ParametroEjecucion>();
                        parametrosPrestamo.Add(new ParametroEjecucion("@Id", item.Id));
                        parametrosPrestamo.Add(new ParametroEjecucion("@EstadoSolicitado", "Solicitado"));
                        parametrosPrestamo.Add(new ParametroEjecucion("@EstadoPrestado", "Prestado"));


                        var buscarPrestamo = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoPrestamoEstado>("SELECT * FROM PrestamoEstado Where PrestamoId = @Id AND Estado = @EstadoSolicitado OR Estado = @EstadoPrestado", parametrosPrestamo);

                        prestamos.Add(buscarPrestamo.FirstOrDefault());
                    }

                    //Si no existen prestamos que se encuentren actualmente solicitados o
                    //  prestados para el libro pedido por el usuario el usuario puede hacer el prestamo
                        if (prestamos.Count() == 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                }
                else
                {
                    return true;
                }
            }
            catch (Framework.Excepciones.FuncionalidadException ex)
            {
                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("El Siguiente Error es Mostrado Al Verificar que solo exista un prestamo:" + ex.ToString(), "DAL", "UAI BOOK");
                throw new Exception("Error al Intentar Traer Los Prestamos");
            }

            finally
            {
                unaConexion.ConexionFinalizar();
            }
        }

        /// <summary>
        /// Actualizo el estado de los prestamos en Solicitado a Vendido
        /// </summary>
        public static void ActualizarEstadoPrestamos()
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);
            unaConexion.ConexionIniciar();

            try
            {
                
                unaConexion.TransaccionIniciar();
               
                // De todos los prestamos busco aquellos que esten prestados o reintegrados y los almaceno en una lista
                var prestamos = new List<DtoPrestamoEstado>();

                //Busco todos los prestamos que se encuentren Prestados o Solicitados
                var parametrosPrestamoEstado = new List<ParametroEjecucion>();
                var buscarPrestamo = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoPrestamoEstado>("Select * From PrestamoEstado Where Estado = 'Solicitado'", parametrosPrestamoEstado);
                
                prestamos = buscarPrestamo;

                //Filtro todos los resultados que tengo y actualizo se se pasaron de la fecha
                var fechaHoy = DateTime.Now;
                var fechaSolicitado = new DateTime();
                var fechaDevolucion = new DateTime();
                var prestamosActualizados = new List<DtoPrestamoEstado>();

                foreach (var item in prestamos)
                {
                        fechaSolicitado = item.Fecha;
                        fechaDevolucion = Framework.Funciones.Fechas.ObtenerDiasHabiles(fechaSolicitado, 7);

                        //Si la fecha de Hoy es Mayor a el de Retiro se cancela

                        if (fechaHoy > fechaDevolucion)
                        {
                            var parametrosSolicitado = new List<ParametroEjecucion>();
                            parametrosSolicitado.Add(new ParametroEjecucion("@Id", item.PrestamoId));
                            parametrosSolicitado.Add(new ParametroEjecucion("@Estado", DtoPrestamoEstado.TipoEstado.Vencido.ToString()));
                            parametrosSolicitado.Add(new ParametroEjecucion("@ChangedOn", fechaHoy));
                            parametrosSolicitado.Add(new ParametroEjecucion("@ChangedBy", 251194));

                            unaConexion.EjecutarConsultaSinResultado("UPDATE PrestamoEstado SET Estado = @Estado, ChangedOn = @ChangedOn, ChangedBy = @ChangedBy Where PrestamoId = @Id", parametrosSolicitado);

                            prestamosActualizados.Add(item);
                        }
                }
                        
                    //Actualizo el Stock
                    foreach (var itemPrestamo in prestamosActualizados)
                    {
                        var parametrosStock = new List<ParametroEjecucion>();
                        parametrosStock.Add(new ParametroEjecucion("@Id", itemPrestamo.PrestamoId));

                        var resultado = unaConexion.EjecutarConsultaResultadoTupla<DtoPrestamo>("Select * From Prestamo Where Id = @Id", parametrosStock);

                        var parametrosLibro = new List<ParametroEjecucion>();
                        parametrosLibro.Add(new ParametroEjecucion("@LibroId", resultado.FirstOrDefault().LibroId));

                        var cantidad = unaConexion.EjecutarConsultaResultadoEscalar<int>("Select Cantidad From Libro Where Id = @LibroId", parametrosLibro);
                        parametrosLibro.Add(new ParametroEjecucion("@Cantidad", cantidad + 1));

                        unaConexion.EjecutarConsultaSinResultado("UPDATE Libro SET Cantidad = @Cantidad Where Id = @LibroId", parametrosLibro);

                    }
                

                unaConexion.TransaccionAceptar();
            }
            catch (Framework.Excepciones.FuncionalidadException ex)
            {
                unaConexion.TransaccionCancelar();
                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("El Siguiente Error es Mostrado Al Actualizar los Prestamos:" + ex.ToString(), "DAL", "UAI BOOK");
                throw new Exception("Error al Intentar Actualizar Los Prestamos");
            }

            finally
            {
                unaConexion.ConexionFinalizar();
            }
        }

        public static List<DtoPrestamo> ObtenerPrestamosAdeudados()
        {
           CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

           Conexion unaConexion = new Conexion(nuevaCadena);

            try
            {
                unaConexion.ConexionIniciar();
                unaConexion.TransaccionIniciar();

                // De todos los prestamos busco aquellos que esten prestados o reintegrados y los almaceno en una lista
                var prestamos = new List<DtoPrestamoEstado>();

                //Busco todos los prestamos que se encuentren Prestados o Solicitados
                var parametrosPrestamoEstado = new List<ParametroEjecucion>();
                var buscarPrestamo = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoPrestamoEstado>("Select * From PrestamoEstado Where Estado = 'Prestado'", parametrosPrestamoEstado);

                prestamos = buscarPrestamo;

                //Filtro todos los resultados que tengo y actualizo se se pasaron de la fecha
                var fechaHoy = DateTime.Now;
                var fechaPrestado = new DateTime();
                var fechaDevolucion = new DateTime();
                var prestamosNoDevueltos = new List<DtoPrestamoEstado>();
                var prestamosAtrasados = new List<DtoPrestamo>();

                // Mapeo el Prestamo con su Estado
                foreach (var item in prestamos)
                {
                    var unPrestamoEstado = new DtoPrestamoEstado();
                    fechaPrestado = item.ChangedOn;
                    fechaDevolucion = Framework.Funciones.Fechas.ObtenerDiasHabiles(fechaPrestado, 7);

                    if (fechaDevolucion > fechaHoy)
                    {
                        prestamosNoDevueltos.Add(item);
                    }
                }

                //Mapeo los Prestamos
                foreach (var item in prestamosNoDevueltos)
	            {
                    var unPrestamo = new DtoPrestamo();
		            var parametrosPrestamoAdeudados = new List<ParametroEjecucion>();
                    parametrosPrestamoAdeudados.Add(new ParametroEjecucion("@PrestamoId", item.PrestamoId));

                    var resultado = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoPrestamo>("SELECT * FROM Prestamo Where Id = @PrestamoId", parametrosPrestamoAdeudados);

                    unPrestamo = resultado.FirstOrDefault();
                    unPrestamo.PrestamoEstado = item;
                    unPrestamo.Libro = TDG.LibroGateway.TraerLibroPorId(unPrestamo.LibroId);

                    prestamosAtrasados.Add(unPrestamo);
	            }

                return prestamosAtrasados;
            }
            catch (Framework.Excepciones.FuncionalidadException ex)
            {

                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("El Siguiente Error es Mostrado Al Actualizar los Prestamos:" + ex.ToString(), "DAL", "UAI BOOK");
                throw new Exception("Error al Intentar Actualizar Los Prestamos");
            }

            finally
            {
                unaConexion.ConexionFinalizar();
            }      
        }

        public static DtoPrestamo TraerPrestamoPorId(int id)
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);


            try
            {
                unaConexion.ConexionIniciar();

                var parametros = new List<ParametroEjecucion>();
                parametros.Add(new ParametroEjecucion("@Id", id));

                //Traigo los Prestamos
                var prestamoEstado = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoPrestamoEstado>("Select * From PrestamoEstado Where PrestamoId = @Id", parametros);

                //Busco el Prestamo
                var prestamos = new List<DtoPrestamo>();

                foreach (var item in prestamoEstado)
                {
                    var parametrosPrestamo = new List<ParametroEjecucion>();
                    parametrosPrestamo.Add(new ParametroEjecucion("@Id", item.PrestamoId));

                    var prestamoBuscadoPorId = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoPrestamo>("SELECT * FROM Prestamo Where Id = @Id", parametrosPrestamo);
                    prestamos.Add(prestamoBuscadoPorId.FirstOrDefault());
                }

                var prestamoConEstado = new List<DtoPrestamo>();


                //Agrego el PrestamoEstado al Prestamo
                foreach (var item in prestamos)
                {
                    var estadoLinq = from prestamoEstadoId in prestamoEstado
                                     where prestamoEstadoId.PrestamoId == item.Id
                                     select prestamoEstadoId;

                    item.PrestamoEstado = estadoLinq.FirstOrDefault();
                    prestamoConEstado.Add(item);
                }

                //Busco el Libro de cada prestamo               
                foreach (var item in prestamoConEstado)
                {
                    var parametrosLibro = new List<ParametroEjecucion>();
                    parametrosLibro.Add(new ParametroEjecucion("@Id", item.LibroId));

                    var resultado = unaConexion.EjecutarConsultaResultadoTupla<DTO.DtoLibro>("SELECT * FROM Libro Where Id = @Id", parametrosLibro);
                    item.Libro = resultado.FirstOrDefault();
                }


                return prestamoConEstado.FirstOrDefault();

            }
            catch (Framework.Excepciones.FuncionalidadException ex)
            {
                unaConexion.TransaccionCancelar();
                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("El Siguiente Error es Mostrado Al Traer el Prestamo:" + ex.ToString(), "DAL", "UAI BOOK");
                throw new Exception("Error al Intentar Traer Los Prestamos");
            }

            finally
            {
                unaConexion.ConexionFinalizar();
            }
        }

        /// <summary>
        /// Actualizo el Estado del Prestamo de Solicitado a Prestado
        /// </summary>
        /// <param name="prestamo"></param>
        public static void ActualizarPrestamoAPrestado(DtoPrestamo prestamo)
        {
            CadenaConexion nuevaCadena = new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, ".\\SQLEXPRESS", "Biblioteca");

            Conexion unaConexion = new Conexion(nuevaCadena);
            unaConexion.ConexionIniciar();

            try
            {
                // De todos los prestamos busco aquellos que esten prestados o reintegrados y los almaceno en una lista
                var parametros = new List<ParametroEjecucion>();
                parametros.Add(new ParametroEjecucion("@Id", prestamo.Id));
                parametros.Add(new ParametroEjecucion("@Estado", prestamo.PrestamoEstado.Estado));
                parametros.Add(new ParametroEjecucion("@ChangedBy", prestamo.PrestamoEstado.ChangedBy));
                parametros.Add(new ParametroEjecucion("@ChangedOn", prestamo.PrestamoEstado.ChangedOn));
                
                // Actualizo el Estado
                unaConexion.EjecutarConsultaSinResultado("Update PrestamoEstado SET Estado = @Estado,ChangedOn = @ChangedOn, ChangedBy = @ChangedBy Where PrestamoId = @Id", parametros);
               
            }
            catch (Framework.Excepciones.FuncionalidadException ex)
            {
                unaConexion.TransaccionCancelar();
                Framework.Diagnostico.LogueadorTxt.Instancia().LogCritico("El Siguiente Error es Mostrado Al Actualizar los Prestamos:" + ex.ToString(), "DAL", "UAI BOOK");
                throw new Exception("Error al Intentar Actualizar Los Prestamos");
            }

            finally
            {
                unaConexion.ConexionFinalizar();
            }
        }
        
    }
}


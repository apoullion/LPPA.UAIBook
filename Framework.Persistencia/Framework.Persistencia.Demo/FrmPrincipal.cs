using DevCity.Framework.Nucleo.PatronesDevCity.Persistencia;
using DevCity.Framework.Persistencia.Demo.EntidadesDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevCity.Framework.Persistencia.Demo
{
    public partial class FrmPrincipal : Form
    {
        private IConexion conexion;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
        }

        private void BtnDesconectar_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inicio = DateTime.Now;

            this.conexion = new Conexion(new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, txtServidor.Text, txtCatalogo.Text));
            this.conexion.ConexionIniciar();

            var parametros = new List<ParametroEjecucion>();
            var resultado = this.conexion.EjecutarConsultaResultadoTupla<Cliente>("Select * From Usuario", parametros);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultado;

            this.conexion.ConexionFinalizar();

            var fin = DateTime.Now;

            MessageBox.Show("Inicio: " + inicio.ToString() + Environment.NewLine + "Finalizado: " + fin.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.conexion = new Conexion(new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, txtServidor.Text, "master"));
            this.conexion.ConexionIniciar();

            var nombreCatalogo = txtCatalogo.Text;

            this.conexion.EjecutarConsultaSinResultado(@"CREATE DATABASE [" + nombreCatalogo + @"]
                                                         CONTAINMENT = NONE
                                                         ON  PRIMARY 
                                                        ( NAME = N'Pruebas', FILENAME = N'd:\Pruebas.mdf' , SIZE = 5120KB , FILEGROWTH = 1024KB )
                                                         LOG ON 
                                                        ( NAME = N'Pruebas_log', FILENAME = N'd:\Pruebas_log.ldf' , SIZE = 1024KB , FILEGROWTH = 10%)
                                                        ", null);

            this.conexion.ConexionFinalizar();

            this.conexion = new Conexion(new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, txtServidor.Text, nombreCatalogo));
            this.conexion.ConexionIniciar();

            this.conexion.EjecutarConsultaSinResultado(@"CREATE TABLE [dbo].[Mensaje](
	                                                    [IdMensaje] [int] IDENTITY(1,1) NOT NULL,
	                                                    [IdUsuario] [int] NOT NULL,
	                                                    [Mensaje] [varchar](max) NOT NULL,
	                                                    [Titulo] [varchar](50) NULL,
                                                     CONSTRAINT [PK_Mensaje] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [IdMensaje] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                                                    ", null);

            this.conexion.EjecutarConsultaSinResultado(@"CREATE TABLE [dbo].[Usuario](
	                                                    [IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	                                                    [Apellido] [varchar](50) NOT NULL,
	                                                    [Nombre] [varchar](50) NOT NULL,
	                                                    [Clave] [uniqueidentifier] NOT NULL,
	                                                    [Activo] [bit] NOT NULL,
	                                                    [FechaCreacion] [datetime] NOT NULL,
                                                     CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [IdUsuario] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]", null);

            this.conexion.EjecutarConsultaSinResultado(@"ALTER TABLE [dbo].[Mensaje]  WITH CHECK ADD  CONSTRAINT [FK_Mensaje_Usuario] FOREIGN KEY([IdUsuario])
                                                    REFERENCES [dbo].[Usuario] ([IdUsuario])", null);

            this.conexion.EjecutarConsultaSinResultado(@"ALTER TABLE [dbo].[Mensaje] CHECK CONSTRAINT [FK_Mensaje_Usuario]", null);

            this.conexion.ConexionFinalizar();

            MessageBox.Show("Exito!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var inicio = DateTime.Now;

            this.conexion = new Conexion(new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, txtServidor.Text, txtCatalogo.Text));
            this.conexion.ConexionIniciar();

            for (int i = 0; i < 1000; i++)
            {
                var parametros = new List<ParametroEjecucion>();
                parametros.Add(new ParametroEjecucion("@Apellido", "aPe" + (i * DateTime.Now.Ticks).ToString()));
                parametros.Add(new ParametroEjecucion("@Nombre", "Nom" + (i * DateTime.Now.Ticks).ToString()));
                parametros.Add(new ParametroEjecucion("@Clave", Guid.NewGuid()));
                parametros.Add(new ParametroEjecucion("@Activo", true));
                parametros.Add(new ParametroEjecucion("@FechaCreacion", DateTime.Now));

                this.conexion.EjecutarConsultaSinResultado("Insert into Usuario values (@Apellido, @Nombre, @Clave, @Activo, @FechaCreacion)", parametros);
            }

            this.conexion.ConexionFinalizar();

            var fin = DateTime.Now;

            MessageBox.Show("Inicio: " + inicio.ToString() + Environment.NewLine + "Finalizado: " + fin.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var inicio = DateTime.Now;

            this.conexion = new Conexion(new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, txtServidor.Text, txtCatalogo.Text));
            this.conexion.ConexionIniciar();

            for (int i = 0; i < 100000; i++)
            {
                var parametros = new List<ParametroEjecucion>();
                parametros.Add(new ParametroEjecucion("@Apellido", "aPe" + (i * DateTime.Now.Ticks).ToString()));
                parametros.Add(new ParametroEjecucion("@Nombre", "Nom" + (i * DateTime.Now.Ticks).ToString()));
                parametros.Add(new ParametroEjecucion("@Clave", Guid.NewGuid()));
                parametros.Add(new ParametroEjecucion("@Activo", true));
                parametros.Add(new ParametroEjecucion("@FechaCreacion", DateTime.Now));

                this.conexion.EjecutarConsultaSinResultado("Insert into Usuario values (@Apellido, @Nombre, @Clave, @Activo, @FechaCreacion)", parametros);
            }

            this.conexion.ConexionFinalizar();

            var fin = DateTime.Now;

            MessageBox.Show("Inicio: " + inicio.ToString() + Environment.NewLine + "Finalizado: " + fin.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var inicio = DateTime.Now;

            this.conexion = new Conexion(new CadenaConexion(CadenaConexion.TipoMotorBaseDatos.ClienteSqlServer, txtServidor.Text, txtCatalogo.Text));
            this.conexion.ConexionIniciar();

            for (int i = 0; i < 1000000; i++)
            {

                this.conexion.TransaccionIniciar();

                var parametros = new List<ParametroEjecucion>();
                parametros.Add(new ParametroEjecucion("@Apellido", "aPe" + (i * DateTime.Now.Ticks).ToString()));
                parametros.Add(new ParametroEjecucion("@Nombre", "Nom" + (i * DateTime.Now.Ticks).ToString()));
                parametros.Add(new ParametroEjecucion("@Clave", Guid.NewGuid()));
                parametros.Add(new ParametroEjecucion("@Activo", true));
                parametros.Add(new ParametroEjecucion("@FechaCreacion", DateTime.Now));

                this.conexion.EjecutarConsultaSinResultado("Insert into Usuario values (@Apellido, @Nombre, @Clave, @Activo, @FechaCreacion)", parametros);

                var ultimoId = this.conexion.EjecutarConsultaResultadoEscalar<Int32>("Select Max(idUsuario) from Usuario", null);

                var param1 = new List<ParametroEjecucion>();
                param1.Add(new ParametroEjecucion("@IdUsuario", ultimoId));
                param1.Add(new ParametroEjecucion("@Mensaje", DateTime.Now.ToString() + DateTime.Now.Millisecond.ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString()));
                param1.Add(new ParametroEjecucion("@Titulo", "El titulo " + Guid.NewGuid().ToString()));
                this.conexion.EjecutarConsultaSinResultado("Insert into mensaje values (@IdUsuario, @Mensaje, @Titulo)", param1);

                var param2 = new List<ParametroEjecucion>();
                param2.Add(new ParametroEjecucion("@IdUsuario", ultimoId));
                param2.Add(new ParametroEjecucion("@Mensaje", DateTime.Now.ToString() + DateTime.Now.Millisecond.ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString()));
                this.conexion.EjecutarConsultaSinResultado("Insert into mensaje values (@IdUsuario, @Mensaje, null)", param2);

                this.conexion.TransaccionAceptar();

            }

            this.conexion.ConexionFinalizar();

            var fin = DateTime.Now;

            MessageBox.Show("Inicio: " + inicio.ToString() + Environment.NewLine + "Finalizado: " + fin.ToString());
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}

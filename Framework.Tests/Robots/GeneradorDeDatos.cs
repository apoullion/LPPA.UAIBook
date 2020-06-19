using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using System.Collections.ObjectModel;
using System.Linq;
using Framework.Funciones;
using System.Collections.Generic;

namespace DevCity.FrameworkTests.Robots
{
    [TestClass]
    public class Robots
    {

        //    [TestMethod]
        //    private void GenerarUsuarios()
        //    {

        //    var listaPivote = new ObservableCollection<DtoMembershipUser>()
        //    {
        //        new DtoMembershipUser(){ Apellido="Pacheco",     Nombre="Carlos"},
        //        new DtoMembershipUser(){ Apellido="Montoya",     Nombre="Paola"},
        //        new DtoMembershipUser(){ Apellido="Gates",       Nombre="Bill"},
        //        new DtoMembershipUser(){ Apellido="Jobs",        Nombre="Steve"},
        //        new DtoMembershipUser(){ Apellido="Torvalds",    Nombre="Linus"},
        //        new DtoMembershipUser(){ Apellido="Cruise",      Nombre="Tom"},
        //        new DtoMembershipUser(){ Apellido="Cat",         Nombre="Tom"},
        //        new DtoMembershipUser(){ Apellido="Master",      Nombre="Osho"},
        //        new DtoMembershipUser(){ Apellido="Hartridge",   Nombre="Walter"},
        //        new DtoMembershipUser(){ Apellido="Windows",     Nombre="Vista"},
        //        new DtoUsuario(){ Apellido="Eyeq",        Nombre="Silver"},
        //        new DtoUsuario(){ Apellido="Wash",        Nombre="Jorge"},
        //        new DtoUsuario(){ Apellido="Puma",        Nombre="Golden"},
        //        new DtoUsuario(){ Apellido="Adid",        Nombre="Golden"},
        //        new DtoUsuario(){ Apellido="Nik",         Nombre="Golden"},
        //        new DtoUsuario(){ Apellido="William",     Nombre="Patricio"},
        //        new DtoUsuario(){ Apellido="Rodriguez",   Nombre="Maxi"},
        //        new DtoUsuario(){ Apellido="Garcia",      Nombre="Carlos"},
        //        new DtoUsuario(){ Apellido="Salazar",     Nombre="Vegetta"},
        //        new DtoUsuario(){ Apellido="Kenedy",      Nombre="Goten"},
        //        new DtoUsuario(){ Apellido="Robert",      Nombre="Trunks"},
        //        new DtoUsuario(){ Apellido="Daly",        Nombre="Gohan"},
        //        new DtoUsuario(){ Apellido="Hawk",        Nombre="Goku"},
        //        new DtoUsuario(){ Apellido="Simpson",     Nombre="Bart"},
        //        new DtoUsuario(){ Apellido="Simpson",     Nombre="Lisa"},
        //        new DtoUsuario(){ Apellido="Simpson",     Nombre="Homero"},
        //        new DtoUsuario(){ Apellido="Simpson",     Nombre="Bart"},
        //        new DtoUsuario(){ Apellido="Sam",         Nombre="Waldo"},
        //        new DtoUsuario(){ Apellido="Jonhstone",   Nombre="Jorge"},
        //        new DtoUsuario(){ Apellido="Glass",       Nombre="Doors"},


        //    };

        //    var listaFull = from usuario in listaPivote
        //                    from usuario1 in listaPivote
        //                    select new DtoUsuario(){ IdTipoUsuario = (Matematicas.NumeroAleatorio(1,3)),
        //                                                    Nombre=usuario.Nombre,
        //                                                    Apellido=usuario1.Apellido,
        //                                                    Mail= usuario.Nombre + "." + usuario1.Apellido + Framework.Funciones.Matematicas.NumeroAleatorio(1,999) + "@gmail.com",
        //                                                    Contraseña = Framework.Encriptadores.AsciiSimple.Instancia().Encriptar("Test","Test"),
        //                                                    IdUsuario = Framework.Funciones.Claves.ObtenerGuid()
        //                                                    };

        //    DaoUsuario daoUsuario = new DaoUsuario();
        //    List<DtoUsuario> ListaUsuario = new List<DtoUsuario>(listaFull);
        //    daoUsuario.RegistrarListaDeUsuarios(ListaUsuario);

        //}

        //    [TestMethod]
        //    private void GenerarPlanAlimenticio()
        //    {
        //        var daoPlanAlimenticio = new DaoPlanAlimenticio();
        //        var daoPreferencia = new DaoPreferenciaDeAlimento();



        //        List<DtoDetallePlanAlimenticio> detallePlanAlimenticio = new List<DtoDetallePlanAlimenticio>();
        //        DtoPlanAlimenticio unPlanAlimenticio = new DtoPlanAlimenticio();

        //        // Creo una Lista de Momentos del Dia para darle Aleteoridad
        //        List<String> momentosDelDia = new List<string>();
        //        momentosDelDia.Add(DtoPlanAlimenticio.MomentoDelDia.Desayuno.ToString());
        //        momentosDelDia.Add(DtoPlanAlimenticio.MomentoDelDia.Almuerzo.ToString());
        //        momentosDelDia.Add(DtoPlanAlimenticio.MomentoDelDia.Cena.ToString());
        //        momentosDelDia.Add(DtoPlanAlimenticio.MomentoDelDia.Aperitivo.ToString());

        //        // Cargo los Datos del Plan Alimenticio
        //        unPlanAlimenticio.Estado = PreferenciaDeAlimento.Estado.Finalizado.ToString();
        //        unPlanAlimenticio.FechaDeCreacion = DateTime.Now;
        //        unPlanAlimenticio.IdPlanAlimenticio = Framework.Funciones.Claves.ObtenerGuid();
        //        unPlanAlimenticio.IdUsuario = new Guid("04BE83B6-EFE6-41EA-A6B0-DCE3E640D5E1");
        //        unPlanAlimenticio.IdPreferenciaDeAlimento = daoPreferencia.TraerUltimaPreferencia(unPlanAlimenticio.IdUsuario);

        //        // Traigo los Alimentos de la Preferencia
        //        var daoAlimento = new DaoAlimento();
        //        var alimentosDePreferencia = daoAlimento.TraerAlimentosDePreferencia(unPlanAlimenticio.IdPreferenciaDeAlimento);

        //        // Cargo el Detalle con Cada Alimento de la Preferencia
        //        foreach (var item in alimentosDePreferencia)
        //        {
        //            var dtoDetallePlanAlimenticio = new DtoDetallePlanAlimenticio();

        //            var n = Framework.Funciones.Matematicas.NumeroAleatorio(0,3);
        //            dtoDetallePlanAlimenticio.IdAlimento = item.IdAlimento;
        //            dtoDetallePlanAlimenticio.MomentoDelDia = (string)momentosDelDia[n];
        //            dtoDetallePlanAlimenticio.IdPlanAlimenticio = unPlanAlimenticio.IdPlanAlimenticio;

        //            detallePlanAlimenticio.Add(dtoDetallePlanAlimenticio);
        //        }

        //        // Genero el Plan Alimenticio
        //        daoPlanAlimenticio.CrearPlanAlimenticio(detallePlanAlimenticio, unPlanAlimenticio);
        //    }

        //    [TestMethod]
        //    private void GenerarPreferenciasDeAlimento()
        //    {
        //        int dias = 0;

        //        // Agrego 4 Alimentos Aleatorios
        //        var unAlimento = new DtoAlimento();
        //        unAlimento.IdAlimento = Matematicas.NumeroAleatorio(1, 10);
        //        var unAlimento1 = new DtoAlimento();
        //        unAlimento1.IdAlimento = Matematicas.NumeroAleatorio(11, 20);
        //        var unAlimento2 = new DtoAlimento();
        //        unAlimento2.IdAlimento = Matematicas.NumeroAleatorio(21, 30);
        //        var unAlimento3 = new DtoAlimento();
        //        unAlimento3.IdAlimento = Matematicas.NumeroAleatorio(31, 42);

        //        // Guardo todos los Alimentos
        //        var alimentos = new List<DtoAlimento>();
        //        alimentos.Add(unAlimento);
        //        alimentos.Add(unAlimento1);
        //        alimentos.Add(unAlimento2);
        //        alimentos.Add(unAlimento3);

        //        var daoPreferencia = new DaoPreferenciaDeAlimento();

        //        // Genero 490 Preferencias de Alimento hasta el 31/7
        //        for (int i = 0; i < 495; i++)
        //        {
        //            var unaPreferencia = new DtoPreferenciaDeAlimento();

        //            unaPreferencia.IdPreferenciaDeAlimento = Claves.ObtenerGuid();
        //            unaPreferencia.IdUsuario = new Guid("B78BC062-CD9D-4372-AEB2-B6D6E720CCB8");
        //            unaPreferencia.Estado = BLL.PreferenciaDeAlimento.Estado.SinUso.ToString();
        //            unaPreferencia.FechaDeCreacion = new DateTime(1975, 01, 02).AddDays(dias);
        //            daoPreferencia.CrearPreferencia(alimentos, unaPreferencia);
        //            dias += 30;
        //        }

        //    }



    }
}
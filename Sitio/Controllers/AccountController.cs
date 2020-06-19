using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Sitio.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            var account = new DTO.DtoMembershipUser();

            return View(account); ;
        }

        //
        // POST: /Account/Index
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var account = new DTO.DtoMembershipUser();

            account.Email = Convert.ToString(form["txtEmail"]);
            account.Password = Convert.ToString(form["txtPassword"]);

            if (ModelState.IsValid)
            {
                try
                {
                    if (BLL.GestorMaestro.ValidarUsuario(account))
                    {
                        return RedirectToAction("Index", "Libro");
                    }
                    else
                    {
                        return View(account);
                    }
                }
                catch
                {
                    return View(account);
                }
            }
            else
            {
                return View(account);
            }
        }
	}
}
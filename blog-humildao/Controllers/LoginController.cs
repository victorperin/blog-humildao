using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog_humildao.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }
        public ActionResult Registar(string usuario, string senha, string confirmar_senha, string email, string confirmar_email)
        {
            if (confirmar_senha == senha)
            {
                if (confirmar_email == email)
                {
                    Models.MySQL mysql = new Models.MySQL();
                    return View();
                }
                return View();
            }
            return View();
        }
    }
}
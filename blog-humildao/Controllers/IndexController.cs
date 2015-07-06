using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog_humildao.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            List<Models.Post> posts = new List<Models.Post>();
            ViewData["posts"] = posts;

            return View();
        }
    }
}
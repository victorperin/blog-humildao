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
            ViewData["posts"] = Models.IndexModel.getAllPosts();
            return View();
        }
        public ActionResult Post(int id)
        {
            ViewData["post"] = Models.IndexModel.getPost(id);
            return View();
        }
    }
}
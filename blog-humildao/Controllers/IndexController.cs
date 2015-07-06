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

            //exemplo, será retirado quando for inserido o MySQL
            Models.Post post1 = new Models.Post
            {
                id = 1,
                usuario = "Jubiscreuson Welingstom",
                data = new DateTime(2015, 06, 09, 16, 5, 7),
                titulo = "Second Post",
                conteudo = "blablabla,sdaisdjqwe<br/>sidaojqwe"
            };
            Models.Post post2 = new Models.Post
            {
                id = 1,
                usuario = "Jubiscreuson Welingstom",
                data = new DateTime(2015, 06, 08, 10, 15, 23),
                titulo = "First Post",
                conteudo = "huehue! br? br?<br/>sidaojqwe"
            };
            posts.Add(post1);
            posts.Add(post2);
            //exemplo, será retirado quando for inserido o MySQL

            ViewData["posts"] = posts;

            return View();
        }
    }
}
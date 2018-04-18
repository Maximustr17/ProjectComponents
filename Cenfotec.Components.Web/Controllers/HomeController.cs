using Cenfotec.Components.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cenfotec.Components.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UserModels modelo = new UserModels();
            return View(modelo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
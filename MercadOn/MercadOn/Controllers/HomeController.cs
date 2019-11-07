using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MercadOn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult QuemSomos()
        {
            ViewBag.MeuBago = "Igual uma sacola murcha";

            return View();
        }

        public ActionResult Contato()
        {
            ViewBag.Contato = "Ligar na Chácara";

            return View();
        }
    }
}
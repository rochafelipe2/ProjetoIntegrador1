using MercadOn.Models.Mercado;
using MercadOn.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MercadOn.Controllers
{
    public class MercadoProdutoController : Controller
    {
        // GET: MercadoProduto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MercadoProduto()
        {
            return View();
        }

       

        public ActionResult Produto(long ID)
        {
            return View();
        }
    }
}
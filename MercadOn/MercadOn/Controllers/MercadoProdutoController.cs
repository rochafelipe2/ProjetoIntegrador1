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

        public ActionResult MercadoProduto(int idMercado)
        {
            var service = new MercadoService(new ContextMercadOn());

            var model = new MercadoProdutoModel();
            model.Produtos = service.BuscarProdutosPorMercado(idMercado);
            model.idMercado = idMercado;
            model.idCliente = (int)Session["clienteid"];


            return View(model);
        }

       

        public ActionResult Produto(long ID)
        {
           

            return View();
        }
    }
}
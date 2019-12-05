using Entities.Entities;
using MercadOn.Models.Mercado;
using MercadOn.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MercadOn.Controllers
{
    public class MercadoController : Controller
    {
        // GET: Mercado
        public ActionResult Index()
        {
            var mercado = Session["cliente"] as MercadoEntity;
            var model = new MercadoDetail();
            model.NomeMercado = mercado.nome;
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Mercados()
        {
            var service = new MercadoService(new ContextMercadOn());
            var model = new MercadoModel();
            var mercados = service.Consultar().ToList();

            foreach (var item in mercados)
            {
                model.Mercados.Add(new MercadoDetail()
                {
                    NomeMercado = item.nome,
                    Endereco = "Endereço teste",
                    Url = item.url
                });
            }

            return View(model);
        }

        public ActionResult Pedido(int mercadoid, int clienteid)
        {
            return View();
        }
    }
}
using Entities.Entities;
using MercadOn.Models.Administrator;
using MercadOn.Models.Mercado;
using MercadOn.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MercadOn.Controllers
{
    public class AdministradorController : Controller
    {

        private readonly MercadoService mercadoService;
        public AdministradorController()
        {
            this.mercadoService = new MercadoService(new ContextMercadOn());
        }
        // GET: Administrador
        public ActionResult Index()
        {
            var model = new AdministradorModel();
            model.Mercados = mercadoService.Consultar().Select(Converter).ToList();
            return View(model);
        }

        private MercadoDetail Converter(MercadoEntity e)
        {
            return new MercadoDetail()
            {
                NomeMercado = e.nome,
                mercadoid = e.idMercado,
                Status = e.ativo == 1 ? "Ativado" : "Desativado"
            };
        }
    }
}
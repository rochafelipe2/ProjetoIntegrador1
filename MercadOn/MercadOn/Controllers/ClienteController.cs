using Entities.Entities;
using MercadOn.Models.Cliente;
using MercadOn.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MercadOn.Controllers
{
    public class ClienteController : Controller
    {

        private ConsumidorService service;

        public ClienteController()
        {
            service = new ConsumidorService(new ContextMercadOn());
        }
        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = Session["cliente"] as ClienteEntity;
            var model = new ClienteModel();
            model.nome = cliente.nome;
            model.cpf = cliente.cpf;
            return View(model);
        }

        [HttpGet]
        public ActionResult Editar(int clienteid)
        {
            var edited = service.ConsultarPorFiltro(x => x.idCliente == clienteid, x => x.UsuarioEntity).FirstOrDefault();
            var model = new ClienteModel()
            {
                celular = edited.celular,
                cpf = edited.cpf,
                email = edited.UsuarioEntity.email,
                nome = edited.nome,
                clienteid = edited.idCliente
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(ClienteModel model)
        {
            var edited = service.ConsultarPorFiltro(x => x.idCliente == model.clienteid).FirstOrDefault();

            edited.nome = model.nome;
            edited.cpf = model.cpf;
            

            bool atualizado = service.Atualizar(edited);

            if (atualizado)
            {
                @TempData["Status"] = true;
            }
            else
            {
                @TempData["Status"] = false;
            }

            return View();
        }

        public ActionResult Pedidos(int clienteid)
        {
            return View();
        }
    }
}
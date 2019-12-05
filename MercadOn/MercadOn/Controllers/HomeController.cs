using MercadOn.Models.Cliente;
using MercadOn.Models.Mercado;
using MercadOn.Service;
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

        [HttpGet]
        public ActionResult CadastrarCliente()
        {



            return View();
        }


        [HttpPost]
        public ActionResult CadastrarCliente(ClienteModel model)
        {
            ConsumidorService service = new ConsumidorService(new ContextMercadOn());
            var newCliente = service.Adicionar(new Entities.Entities.ClienteEntity() {
                ativo = 1,
                celular = model.celular,
                cpf = model.cpf,
                nome = model.nome,
                UsuarioEntity = new Entities.Entities.UsuarioEntity()
                {
                    ativo = 1,
                    dataCriacao = DateTime.Now,
                    dataAlteracao = DateTime.Now,
                    email = model.email,
                    senha = model.senha
                }
            });

            if (newCliente)
            {
                TempData["Status"] = true;
                return RedirectToAction("CadastrarCliente");
            }
            else
            {
                TempData["Status"] = false;
            }

           

            return View();
        }

        [HttpGet]
        public ActionResult CadastrarMercado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarMercado(NovoMercadoDetail detail)
        {
            MercadoService service = new MercadoService(new ContextMercadOn());
            var newMercado = service.Adicionar(new Entities.Entities.MercadoEntity()
            {
                ativo = 1,
                cnpj = long.Parse(detail.CNPJ),
                nome = detail.Nome,
                url = detail.Url,
                UsuarioEntity = new Entities.Entities.UsuarioEntity()
                {
                    ativo = 1,
                    dataCriacao = DateTime.Now,
                    dataAlteracao = DateTime.Now,
                    email = detail.Email,
                    senha = detail.Senha
                }
            });

            if (newMercado)
            {
                TempData["Status"] = true;
            }
            else
            {
                TempData["Status"] = false;
            }
            return RedirectToAction("CadastrarMercado");
        }
    }
}
using Entities.Entities;
using MercadOn.Models.Cliente;
using MercadOn.Models.Endereco;
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
        private EnderecoService enderecoService;
        public ClienteController()
        {
            var context = new ContextMercadOn();
            service = new ConsumidorService(context);
            enderecoService = new EnderecoService(context);
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
            var endereco = enderecoService.ConsultarPorFiltro(x => x.idUsuario == edited.idUsuario).FirstOrDefault();
            var model = new ClienteModel()
            {
                celular = edited.celular,
                cpf = edited.cpf,
                email = edited.UsuarioEntity.email,
                nome = edited.nome,
                clienteid = edited.idCliente,
                endereco = endereco != null ? this.ConverterEndereco(endereco) : new Models.Endereco.EnderecoDetail()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(ClienteModel model)
        {
            var edited = service.ConsultarPorFiltro(x => x.idCliente == model.clienteid).FirstOrDefault();
            var endereco = model.endereco.id > 0 ? enderecoService.ConsultarPorFiltro(x => x.idEndereco == model.endereco.id).FirstOrDefault() : new EnderecoEntity(); ;
            edited.nome = model.nome;
            edited.cpf = model.cpf;

            ConverterEndereco(model.endereco, ref endereco);

            bool atualizado = service.Atualizar(edited);

            if (atualizado)
            {
                enderecoService.Atualizar(endereco);
                TempData["Status"] = true;
                TempData["Msg"] = "Registro atualizado com sucesso.";
            }
            else
            {
                TempData["Status"] = false;
                TempData["Msg"] = "Registro não atualizado.";
            }

            return RedirectToAction("Editar", new { clienteid  = model .clienteid});
        }

        public ActionResult Pedidos(int clienteid)
        {
            var model = new PedidoModel();
            var pedidoService = new PedidoService(new ContextMercadOn());
            model.Pedidos = pedidoService.BuscarPedidosPorCliente(clienteid).ToList();

            return View(model);
        }

        public ActionResult PedidoDetalhe(int idPedido)
        {
            var pedidoService = new PedidoService(new ContextMercadOn());
            var model = new PedidoItemModel();

            model.Itens = pedidoService.BuscarPedidoDetalhe(idPedido);

            return View(model);
        }

        public EnderecoDetail ConverterEndereco(EnderecoEntity e)
        {
            return new EnderecoDetail()
            {
                bairro = e.bairro,
                cep = e.cep,
                cidade = e.cidade,
                complemento = e.complemento,
                id = e.idEndereco,
                nome = e.nomeEndereco,
                numero = e.numero,
                rua = e.rua
            };
         }

        public EnderecoEntity  ConverterEndereco(EnderecoDetail d, ref EnderecoEntity e)
        {

            e.bairro = d.bairro;
            e.cep = d.cep;
            e.cidade = d.cidade;
            e.complemento = d.complemento;
            e.nomeEndereco = d.nome;
            e.rua = d.rua;

            return e;
        }
    }
}
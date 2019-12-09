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
                    Url = item.url,
                    mercadoid = item.idMercado
                });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Pedido(int mercadoid, int clienteid)
        {
            PedidoModel model = new PedidoModel();
            var Service = new MercadoService(new ContextMercadOn());
            model.mercadoid = mercadoid;
            model.clienteid = clienteid;
            model.Produtos = Service.BuscarProdutosPorMercado(mercadoid);

            return View(model);
        }

        [HttpPost]
        public ActionResult Pedido(PedidoModel model)
        {
            bool verificdor = false;
            var context = new ContextMercadOn();
            var pedidoService = new PedidoService(context);
            var clienteService = new ConsumidorService(context);
            var mercadoService = new MercadoService(context);
            var precoService = new PrecoService(context);
            var pedidoItemService = new PedidoItemService(context);
            PedidoEntity novoPedido = new PedidoEntity();

            novoPedido.ativo = 1;
            novoPedido.ClienteEntity = clienteService.Consultar(model.clienteid);
            novoPedido.dataPedido = DateTime.Now;
            novoPedido.MercadoEntity = mercadoService.Consultar(model.mercadoid);
            novoPedido.dataConfirmado = DateTime.Now;
            var split = model.Carrinho.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var produtosItens = new List<ItemPedidoEntity>();

            try
            {
                foreach (var item in split)
                {
                    int id = int.Parse(item);
                    var produto = precoService.ConsultarPorFiltro(x => x.idProduto == id, x => x.ProdutoEntity).FirstOrDefault();
                    var novoItem = new ItemPedidoEntity()
                    {
                        PedidoEntity = novoPedido,
                        PrecoEntity = produto,
                        quantidade = 1,
                        precoItem = produto.precoProduto
                    };

                    pedidoItemService.Adicionar(novoItem);
                    verificdor = true;
                }
            }
            catch(Exception exp)
            {
                verificdor = false;
            }
            

            //bool adicionado = pedidoService.Adicionar(novoPedido);

            if (verificdor)
            {
                TempData["Status"] = true;
                TempData["Msg"] = "Pedido realizado com sucesso, aguarde entrega.";
            }
            else
            {
                TempData["Status"] = false;
                TempData["Msg"] = "Pedido não realizado, verifique com o administrador.";
            }

            return RedirectToAction("Pedido",new {mercadoid= model.mercadoid, clienteid= model.clienteid });
        }
    }
}
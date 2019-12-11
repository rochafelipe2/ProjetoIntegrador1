using Entities.Entities;
using MercadOn.Models.Categoria;
using MercadOn.Models.Mercado;
using MercadOn.Models.Produto;
using MercadOn.Models.Subcategoria;
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

        private readonly MercadoService service;
        private readonly ProdutoService produtoService;
        private readonly ProdutoPrecoService produtoPrecoService;
        private readonly SubcategoriaService subcategoriaService;
        private readonly CategoriaService categoriaService;
        public MercadoController()
        {
            var context = new ContextMercadOn();
            service = new MercadoService(context);
            produtoService = new ProdutoService(context);
            produtoPrecoService = new ProdutoPrecoService(context);
            subcategoriaService = new SubcategoriaService(context);
            categoriaService = new CategoriaService(context);
        }

        // GET: Mercado
        public ActionResult Index()
        {
            var mercado = Session["mercado"] as MercadoEntity;
            var model = new MercadoDetail();
            model.NomeMercado = mercado.nome;
            model.mercadoid = mercado.idMercado;
            return View(model);
        }

        [HttpGet]
        public ActionResult Mercados()
        {

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

            model.mercadoid = mercadoid;
            model.clienteid = clienteid;
            model.Produtos = service.BuscarProdutosPorMercado(mercadoid);

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
            catch (Exception exp)
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

            return RedirectToAction("Pedido", new { mercadoid = model.mercadoid, clienteid = model.clienteid });
        }

        [HttpGet]
        public ActionResult ProdutoPreco(int idMercado)
        {
            var model = new ProdutoPrecoModel();
            model.Produtos = produtoService.Consultar().Select(Converter).ToList();
            model.ProdutosPreco = service.BuscarProdutosPorMercado(idMercado);
            model.idMercado = idMercado;
            return View(model);
        }

        [HttpPost]
        public ActionResult ProdutoPreco(ProdutoPrecoModel model)
        {
            bool add = produtoPrecoService.Adicionar(new PrecoEntity()
            {
                MercadoEntity = service.Consultar(model.idMercado),
                ProdutoEntity = produtoService.Consultar(model.produtoSelecinado),
                precoProduto = model.preco
            });

            if (add)
            {
                TempData["Status"] = true;
                TempData["Msg"] = "Registro Salvo com sucesso.";
            }
            else
            {
                TempData["Status"] = false;
                TempData["Msg"] = "Erro ao salvar.";
            }

            return RedirectToAction("ProdutoPreco", new { idMercado = model.idMercado });
        }

        [HttpGet]
        public ActionResult Produto()
        {
            var model = new ProdutoModel();
            model.Produtos = produtoService.Consultar().Select(ConverterDetail).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Produto(ProdutoModel model)
        {

            var add = produtoService.Adicionar(new ProdutoEntity()
            {
                ativo = 1,
                nomeProduto = model.nome,
                descricaoProduto = model.descricao,
                marcaProduto = model.marca,
                SubcategoriaEntity = subcategoriaService.Consultar(1),
                url = "/Content/produto-sem-imagem.jpg"
            });

            if (add)
            {
                TempData["Status"] = true;
                TempData["Msg"] = "Registro adicionado com sucesso!";
            }
            else
            {
                TempData["Status"] = false;
                TempData["Msg"] = "Registro não adicionado.";
            }

            return RedirectToAction("Produto");
        }

        public ActionResult Categoria()
        {
            var model = new CategoriaModel();
            model.Categorias = categoriaService.Consultar().Select(ConverterCategoria).ToList();
            return View(model);
        }

        public ActionResult Subcategoria()
        {
            var model = new SubcategoriaModel();
            model.Subcategorias = subcategoriaService.Consultar().Select(ConverterSubcategoria).ToList();
            return View(model);
        }

        private ProdutoViewModel Converter(ProdutoEntity e)
        {
            return new ProdutoViewModel()
            {
                id = e.idProduto,
                nome = e.nomeProduto
            };
        }

        private ProdutoDetail ConverterDetail(ProdutoEntity e)
        {
            return new ProdutoDetail()
            {
                descricao = e.descricaoProduto,
                nome = e.nomeProduto,
                marca = e.marcaProduto
            };
        }

        private CategoriaDetail ConverterCategoria(CategoriaEntity e)
        {
            return new CategoriaDetail()
            {
                id = e.idCategoria,
                nome = e.nomeCategoria
            };
        }

        private SubcategoriaDetail ConverterSubcategoria(SubcategoriaEntity e)
        {
            return new SubcategoriaDetail()
            {
                id = e.idSubcategoria,
                nome = e.nomeSubcategoria,
                categoria = e.CategoriaEntity.nomeCategoria
            };
        }
    }
}
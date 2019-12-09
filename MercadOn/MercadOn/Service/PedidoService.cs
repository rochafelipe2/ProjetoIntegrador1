using Entities.Entities;
using MercadOn.Models.Cliente;
using MercadOn.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Service
{
    public class PedidoService : ServiceBase<PedidoEntity>
    {
        private PedidoItemService pedidoItemService;
        public PedidoService(ContextMercadOn context)
           : base(context)
        {
            pedidoItemService = new PedidoItemService(context);
        }

        public List<PedidoDetail> BuscarPedidosPorCliente(int clienteid)
        {
            return this.ConsultarPorFiltro(x => x.idCliente == clienteid, x => x.MercadoEntity, x => x.ClienteEntity).Select(Converter).ToList();
        }

        public List<PedidoItemDetail> BuscarPedidoDetalhe(int idPedido)
        {
            return pedidoItemService.ConsultarPorFiltro(x => x.idPedido == idPedido, x => x.PrecoEntity.ProdutoEntity ).Select(Converter).ToList();
        }

        private PedidoItemDetail Converter(ItemPedidoEntity e)
        {
            PedidoItemDetail d = new PedidoItemDetail();

            d.pedidoitemid = e.idItemPedido;
            d.produto = e.PrecoEntity.ProdutoEntity.nomeProduto;
            d.quantidade = e.quantidade;
            d.valor = e.precoItem;

            return d;
        }

        private PedidoDetail Converter(PedidoEntity e)
        {
            var service = new PedidoItemService(new ContextMercadOn());
            PedidoDetail d = new PedidoDetail();

            d.Cliente = e.ClienteEntity.nome;
            d.dataPedido = e.dataPedido.ToShortDateString();
            d.Mercado = e.MercadoEntity.nome;
            d.total += service.ConsultarPorFiltro(x => x.idPedido == e.idPedido).Sum(x => x.precoItem);
            d.pedidoid = e.idPedido;
            return d;
        }
    }
}
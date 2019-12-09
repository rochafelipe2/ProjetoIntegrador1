using Entities.Entities;
using MercadOn.Models.Mercado;
using MercadOn.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercadOn.Service
{
    public class MercadoService : ServiceBase<MercadoEntity>
    {
        private PrecoService precoService;
        public MercadoService(ContextMercadOn context)
            : base(context)
        {
            precoService = new PrecoService(context);
        }


        public List<MercadoProdutoDetail> BuscarProdutosPorMercado(int idMercado)
        {
            return precoService.ConsultarPorFiltro(x => x.idMercado == idMercado, x => x.ProdutoEntity).Select(ConverteEtoD).ToList();
        }

        public MercadoProdutoDetail ConverteEtoD(PrecoEntity entity)
        {
            MercadoProdutoDetail d = new MercadoProdutoDetail();
            d.descricao = entity.ProdutoEntity.descricaoProduto;
            d.idProduto = entity.ProdutoEntity.idProduto;
            d.nome = entity.ProdutoEntity.nomeProduto;
            d.preco = entity.precoProduto;
            d.url = entity.ProdutoEntity.url;

            return d;
        }
    }
}
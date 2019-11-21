using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MercadOn.Service
{
    public interface IService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Consultar(params Expression<Func<TEntity, object>>[] includes);
        TEntity Consultar(long ID);
        IEnumerable<TEntity> ConsultarPorFiltro(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        bool Adicionar(TEntity entity);
        bool Atualizar(TEntity entity);
        bool Deletar(long ID);
        bool Deletar(List<long> IDs);

    }
}

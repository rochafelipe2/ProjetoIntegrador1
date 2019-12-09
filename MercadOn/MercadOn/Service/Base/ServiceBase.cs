using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MercadOn.Service.Base
{
    public abstract class ServiceBase<TEntity> : IDisposable, IService<TEntity> where TEntity : class
    {
        protected readonly ContextMercadOn Context;

        public ServiceBase(ContextMercadOn context)
        {

            this.Context = context;
            this.Context.Configuration.LazyLoadingEnabled = false;
        }

        public IEnumerable<TEntity> Consultar(params Expression<Func<TEntity, object>>[] includes)
        {

            try
            {
                IQueryable<TEntity> result;
                if (includes != null)
                {
                    result = includes.Aggregate(((IQueryable<TEntity>)this.Context.Set<TEntity>()), (x, include) => x.Include(include));

                }
                else
                {
                    result = null;
                }


                return result;

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }

        }

        public TEntity Consultar(long ID)
        {
            try
            {
                var result = this.Context.Set<TEntity>().Find(ID);
                //this.Context.Dispose();
                return result;

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        public IEnumerable<TEntity> ConsultarPorFiltro(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> result;
                if (includes != null)
                {
                    result = includes.Aggregate(this.Context.Set<TEntity>().Where(predicate), (x, include) => x.Include(include));

                }
                else
                {
                    result = null;
                }

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            
        }


        public bool Deletar(long ID)
        {
            try
            {
                var removed = this.Context.Set<TEntity>().Find(ID);
                this.Context.Set<TEntity>().Remove(removed);
                this.Context.SaveChanges();
                return true;
            }
            catch (Exception exp)
            {

            }
            return false;
        }

        public bool Deletar(List<long> IDs)
        {
            throw new NotImplementedException();
        }


        public bool Adicionar(TEntity entity)
        {
            try
            {
                this.Context.Set<TEntity>().Add(entity);
                this.Context.SaveChanges();
                //this.Context.Dispose();
                return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return false;
        }

        public bool Atualizar(TEntity entity)
        {
            try
            {
                this.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                this.Context.SaveChanges();
                return true;
            }
            catch (Exception exp)
            {

            }
            return false;
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }


    }
}
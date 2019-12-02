using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public interface IPedidoCabRepository
    {
        IQueryable<PedidoCab> All { get; }

        IQueryable<PedidoCab> AllIncluding(params Expression<Func<PedidoCab, object>>[] includeProperties);

        PedidoCab Find(string id);

        void InsertOrUpdate(PedidoCab pedidoCab);

        void Delete(string id);

        void Save();
    }

    public class PedidoCabRepository : IPedidoCabRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<PedidoCab> All
        {
            get { return this.context.PedidoCab; }
        }

        public IQueryable<PedidoCab> AllIncluding(params Expression<Func<PedidoCab, object>>[] includeProperties)
        {
            IQueryable<PedidoCab> query = this.context.PedidoCab;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public PedidoCab Find(string id)
        {
            return this.context.PedidoCab.Find(id);
        }

        public void InsertOrUpdate(PedidoCab pedidoCab)
        {
            if (pedidoCab.IdPedido == default(string))
            {
                this.context.PedidoCab.Add(pedidoCab);
            }
            else
            {
                this.context.Entry(pedidoCab).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var pedidoCab = this.context.PedidoCab.Find(id);
            this.context.PedidoCab.Remove(pedidoCab);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

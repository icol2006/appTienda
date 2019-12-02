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
    public interface IPedidoDetRepository
    {
        IQueryable<PedidoDet> All { get; }

        IQueryable<PedidoDet> AllIncluding(params Expression<Func<PedidoDet, object>>[] includeProperties);

        PedidoDet Find(string id);

        void InsertOrUpdate(PedidoDet pedidoDet);

        void Delete(string id);

        void Save();

    }

    public class PedidoDetRepository : IPedidoDetRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<PedidoDet> All
        {
            get { return this.context.PedidoDet; }
        }

        public IQueryable<PedidoDet> AllIncluding(params Expression<Func<PedidoDet, object>>[] includeProperties)
        {
            IQueryable<PedidoDet> query = this.context.PedidoDet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public PedidoDet Find(string id)
        {
            return this.context.PedidoDet.Find(id);
        }

        public void InsertOrUpdate(PedidoDet pedidoDet)
        {
            if (pedidoDet.IdPedido == default(string))
            {
                this.context.PedidoDet.Add(pedidoDet);
            }
            else
            {
                this.context.Entry(pedidoDet).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var pedidoDet = this.context.PedidoDet.Find(id);
            this.context.PedidoDet.Remove(pedidoDet);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

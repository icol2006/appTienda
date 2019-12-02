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
    public interface ICompraDetRepository
    {
        IQueryable<CompraDet> All { get; }

        IQueryable<CompraDet> AllIncluding(params Expression<Func<CompraDet, object>>[] includeProperties);

        CompraDet Find(string id);

        void InsertOrUpdate(CompraDet compraDet);

        void Delete(string id);

        void Save();
    }

    public class CompraDetRepository : ICompraDetRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<CompraDet> All
        {
            get { return this.context.CompraDet; }
        }

        public IQueryable<CompraDet> AllIncluding(params Expression<Func<CompraDet, object>>[] includeProperties)
        {
            IQueryable<CompraDet> query = this.context.CompraDet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public CompraDet Find(string id)
        {
            return this.context.CompraDet.Find(id);
        }

        public void InsertOrUpdate(CompraDet compraDet)
        {
            if (compraDet.IdCompra == default(string))
            {
                this.context.CompraDet.Add(compraDet);
            }
            else
            {
                this.context.Entry(compraDet).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var compraDet = this.context.CompraDet.Find(id);
            this.context.CompraDet.Remove(compraDet);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

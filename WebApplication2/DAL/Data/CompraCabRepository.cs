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
    public interface ICompraCabRepository
    {
        IQueryable<CompraCab> All { get; }

        IQueryable<CompraCab> AllIncluding(params Expression<Func<CompraCab, object>>[] includeProperties);

        CompraCab Find(string id);

        void InsertOrUpdate(CompraCab compraCab);

        void Delete(string id);

        void Save();
    }

    public class CompraCabRepository : ICompraCabRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<CompraCab> All
        {
            get { return this.context.CompraCab; }
        }

        public IQueryable<CompraCab> AllIncluding(params Expression<Func<CompraCab, object>>[] includeProperties)
        {
            IQueryable<CompraCab> query = this.context.CompraCab;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public CompraCab Find(string id)
        {
            return this.context.CompraCab.Find(id);
        }

        public void InsertOrUpdate(CompraCab compraCab)
        {
            if (compraCab.IdCompra == default(string))
            {
                this.context.CompraCab.Add(compraCab);
            }
            else
            {
                this.context.Entry(compraCab).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var compraCab = this.context.CompraCab.Find(id);
            this.context.CompraCab.Remove(compraCab);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

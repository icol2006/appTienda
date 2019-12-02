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
    public interface IProveedorRepository
    {
        IQueryable<Proveedor> All { get; }

        IQueryable<Proveedor> AllIncluding(params Expression<Func<Proveedor, object>>[] includeProperties);

        Proveedor Find(string id);

        void InsertOrUpdate(Proveedor proveedor);

        void Delete(string id);

        void Save();
    }


    public class ProveedorRepository : IProveedorRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<Proveedor> All
        {
            get { return this.context.Proveedor; }
        }

        public IQueryable<Proveedor> AllIncluding(params Expression<Func<Proveedor, object>>[] includeProperties)
        {
            IQueryable<Proveedor> query = this.context.Proveedor;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public Proveedor Find(string id)
        {
            return this.context.Proveedor.Find(id);
        }

        public void InsertOrUpdate(Proveedor proveedor)
        {
            if (proveedor.CodPrv == default(string))
            {
                this.context.Proveedor.Add(proveedor);
            }
            else
            {
                this.context.Entry(proveedor).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var proveedor = this.context.Proveedor.Find(id);
            this.context.Proveedor.Remove(proveedor);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

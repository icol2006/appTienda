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
    public interface IProductoRepository
    {
        IQueryable<Producto> All { get; }

        IQueryable<Producto> AllIncluding(params Expression<Func<Producto, object>>[] includeProperties);

        Producto Find(string id);

        void InsertOrUpdate(Producto employee);

        void Delete(string id);

        void Save();
    }

    public class ProductoRepository : IProductoRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<Producto> All
        {
            get { return this.context.Producto; }
        }

        public IQueryable<Producto> AllIncluding(params Expression<Func<Producto, object>>[] includeProperties)
        {
            IQueryable<Producto> query = this.context.Producto;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public Producto Find(string id)
        {
            return this.context.Producto.Find(id);
        }

        public void InsertOrUpdate(Producto producto)
        {
            if (producto.CodPro == default(string))
            {
                this.context.Producto.Add(producto);
            }
            else
            {
                this.context.Entry(producto).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var producto = this.context.Producto.Find(id);
            this.context.Producto.Remove(producto);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

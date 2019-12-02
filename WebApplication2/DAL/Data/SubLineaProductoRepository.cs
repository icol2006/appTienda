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
    public interface ISubLineaProductoRepository
    {
        IQueryable<SubLineaProducto> All { get; }

        IQueryable<SubLineaProducto> AllIncluding(params Expression<Func<SubLineaProducto, object>>[] includeProperties);

        SubLineaProducto Find(string id);

        void InsertOrUpdate(SubLineaProducto subLineaProducto);

        void Delete(string id);

        void Save();
    }


    public class SubLineaProductoRepository : ISubLineaProductoRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<SubLineaProducto> All
        {
            get { return this.context.SubLineaProducto; }
        }

        public IQueryable<SubLineaProducto> AllIncluding(params Expression<Func<SubLineaProducto, object>>[] includeProperties)
        {
            IQueryable<SubLineaProducto> query = this.context.SubLineaProducto;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public SubLineaProducto Find(string id)
        {
            return this.context.SubLineaProducto.Find(id);
        }

        public void InsertOrUpdate(SubLineaProducto subLineaProducto)
        {
            if (subLineaProducto.CodSubLin == default(string))
            {
                this.context.SubLineaProducto.Add(subLineaProducto);
            }
            else
            {
                this.context.Entry(subLineaProducto).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var subLineaProducto = this.context.SubLineaProducto.Find(id);
            this.context.SubLineaProducto.Remove(subLineaProducto);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

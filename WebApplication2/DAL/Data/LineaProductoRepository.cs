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
    public interface ILineaProductoRepository
    {
        IQueryable<LineaProducto> All { get; }

        IQueryable<LineaProducto> AllIncluding(params Expression<Func<LineaProducto, object>>[] includeProperties);

        LineaProducto Find(string id);

        void InsertOrUpdate(LineaProducto lineaProducto);

        void Delete(string id);

        void Save();
    }

    public class LineaProductoRepository : ILineaProductoRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<LineaProducto> All
        {
            get { return this.context.LineaProducto; }
        }

        public IQueryable<LineaProducto> AllIncluding(params Expression<Func<LineaProducto, object>>[] includeProperties)
        {
            IQueryable<LineaProducto> query = this.context.LineaProducto;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public LineaProducto Find(string id)
        {
            return this.context.LineaProducto.Find(id);
        }

        public void InsertOrUpdate(LineaProducto lineaProducto)
        {
            if (lineaProducto.CodLin == default(string))
            {
                this.context.LineaProducto.Add(lineaProducto);
            }
            else
            {
                this.context.Entry(lineaProducto).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var lineaProducto = this.context.LineaProducto.Find(id);
            this.context.LineaProducto.Remove(lineaProducto);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

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
    public interface IKardexProductosRepository
    {
        IQueryable<KardexProductos> All { get; }

        IQueryable<KardexProductos> AllIncluding(params Expression<Func<KardexProductos, object>>[] includeProperties);

        KardexProductos Find(string id);

        void InsertOrUpdate(KardexProductos kardexProductos);

        void Delete(string id);

        void Save();

    }

    public class KardexProductosRepository : IKardexProductosRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<KardexProductos> All
        {
            get { return this.context.KardexProductos; }
        }

        public IQueryable<KardexProductos> AllIncluding(params Expression<Func<KardexProductos, object>>[] includeProperties)
        {
            IQueryable<KardexProductos> query = this.context.KardexProductos;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public KardexProductos Find(string id)
        {
            return this.context.KardexProductos.Find(id);
        }

        public void InsertOrUpdate(KardexProductos kardexProductos)
        {
            if (kardexProductos.IdKardex == default(string))
            {
                this.context.KardexProductos.Add(kardexProductos);
            }
            else
            {
                this.context.Entry(kardexProductos).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var customer = this.context.KardexProductos.Find(id);
            this.context.KardexProductos.Remove(customer);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

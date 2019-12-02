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

    public interface IAlmacenRepository
    {
        IQueryable<Almacen> All { get; }

        IQueryable<Almacen> AllIncluding(params Expression<Func<Almacen, object>>[] includeProperties);

        Almacen Find(string id);

        void InsertOrUpdate(Almacen almacen);

        void Delete(string id);

        void Save();
    }

    public class AlmacenRepository : IAlmacenRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<Almacen> All
        {
            get { return this.context.Almacen; }
        }

        public IQueryable<Almacen> AllIncluding(params Expression<Func<Almacen, object>>[] includeProperties)
        {
            IQueryable<Almacen> query = this.context.Almacen;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public Almacen Find(string id)
        {
            return this.context.Almacen.Find(id);
        }

        public void InsertOrUpdate(Almacen almacen)
        {
            if (almacen.CodAlm == default(string))
            {
                this.context.Almacen.Add(almacen);
            }
            else
            {
                this.context.Entry(almacen).State = EntityState.Modified;
            }
        }

        public void Delete(String id)
        {
            var almacen = this.context.Almacen.Find(id);
            this.context.Almacen.Remove(almacen);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

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

    public interface IDevolucionCabRepository
    {
        IQueryable<DevolucionCab> All { get; }

        IQueryable<DevolucionCab> AllIncluding(params Expression<Func<DevolucionCab, object>>[] includeProperties);

        DevolucionCab Find(string id);

        void InsertOrUpdate(DevolucionCab devolucionCab);

        void Delete(string id);

        void Save();

    }

    public class DevolucionCabRepository : IDevolucionCabRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<DevolucionCab> All
        {
            get { return this.context.DevolucionCab; }
        }

        public IQueryable<DevolucionCab> AllIncluding(params Expression<Func<DevolucionCab, object>>[] includeProperties)
        {
            IQueryable<DevolucionCab> query = this.context.DevolucionCab;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public DevolucionCab Find(string id)
        {
            return this.context.DevolucionCab.Find(id);
        }

        public void InsertOrUpdate(DevolucionCab devolucionCab)
        {
            if (devolucionCab.IdDevolucion == default(string))
            {
                this.context.DevolucionCab.Add(devolucionCab);
            }
            else
            {
                this.context.Entry(devolucionCab).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var devolucionCab = this.context.DevolucionCab.Find(id);
            this.context.DevolucionCab.Remove(devolucionCab);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

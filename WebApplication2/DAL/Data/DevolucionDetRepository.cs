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

    public interface IDevolucionDetRepository
    {
        IQueryable<DevolucionDet> All { get; }

        IQueryable<DevolucionDet> AllIncluding(params Expression<Func<DevolucionDet, object>>[] includeProperties);

        DevolucionDet Find(string id);

        void InsertOrUpdate(DevolucionDet employee);

        void Delete(string id);

        void Save();
    }

    public class DevolucionDetRepository : IDevolucionDetRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<DevolucionDet> All
        {
            get { return this.context.DevolucionDet; }
        }

        public IQueryable<DevolucionDet> AllIncluding(params Expression<Func<DevolucionDet, object>>[] includeProperties)
        {
            IQueryable<DevolucionDet> query = this.context.DevolucionDet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public DevolucionDet Find(string id)
        {
            return this.context.DevolucionDet.Find(id);
        }

        public void InsertOrUpdate(DevolucionDet devolucionDet)
        {
            if (devolucionDet.IdDevolucion == default(string))
            {
                this.context.DevolucionDet.Add(devolucionDet);
            }
            else
            {
                this.context.Entry(devolucionDet).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var devolucionDet = this.context.DevolucionDet.Find(id);
            this.context.DevolucionDet.Remove(devolucionDet);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

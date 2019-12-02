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
    public interface IProAlmRepository
    {
        IQueryable<ProAlm> All { get; }

        IQueryable<ProAlm> AllIncluding(params Expression<Func<ProAlm, object>>[] includeProperties);

        ProAlm Find(string id);

        void InsertOrUpdate(ProAlm proAlm);

        void Delete(string id);

        void Save();

    }


    public class ProAlmRepository : IProAlmRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<ProAlm> All
        {
            get { return this.context.ProAlm; }
        }

        public IQueryable<ProAlm> AllIncluding(params Expression<Func<ProAlm, object>>[] includeProperties)
        {
            IQueryable<ProAlm> query = this.context.ProAlm;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public ProAlm Find(string id)
        {
            return this.context.ProAlm.Find(id);
        }

        public void InsertOrUpdate(ProAlm proAlm)
        {
            if (proAlm.CodAlm == default(string))
            {
                this.context.ProAlm.Add(proAlm);
            }
            else
            {
                this.context.Entry(proAlm).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var customer = this.context.ProAlm.Find(id);
            this.context.ProAlm.Remove(customer);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

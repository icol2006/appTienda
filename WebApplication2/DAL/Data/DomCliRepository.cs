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
    public interface IDomCliRepository
    {
        IQueryable<DomCli> All { get; }

        IQueryable<DomCli> AllIncluding(params Expression<Func<DomCli, object>>[] includeProperties);

        DomCli Find(string id);

        void InsertOrUpdate(DomCli domCli);

        void Delete(string id);

        void Save();

    }

    public class DomCliRepository : IDomCliRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<DomCli> All
        {
            get { return this.context.DomCli; }
        }

        public IQueryable<DomCli> AllIncluding(params Expression<Func<DomCli, object>>[] includeProperties)
        {
            IQueryable<DomCli> query = this.context.DomCli;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public DomCli Find(string id)
        {
            return this.context.DomCli.Find(id);
        }

        public void InsertOrUpdate(DomCli domCli)
        {
            if (domCli.CodDom == default(string))
            {
                this.context.DomCli.Add(domCli);
            }
            else
            {
                this.context.Entry(domCli).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var domCli = this.context.DomCli.Find(id);
            this.context.DomCli.Remove(domCli);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

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
    public interface IDocSunCabRepository
    {
        IQueryable<DocSunCab> All { get; }

        IQueryable<DocSunCab> AllIncluding(params Expression<Func<DocSunCab, object>>[] includeProperties);

        DocSunCab Find(string id);

        void InsertOrUpdate(DocSunCab docSunCab);

        void Delete(string id);

        void Save();

    }

    public class DocSunCabRepository : IDocSunCabRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<DocSunCab> All
        {
            get { return this.context.DocSunCab; }
        }

        public IQueryable<DocSunCab> AllIncluding(params Expression<Func<DocSunCab, object>>[] includeProperties)
        {
            IQueryable<DocSunCab> query = this.context.DocSunCab;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public DocSunCab Find(string id)
        {
            return this.context.DocSunCab.Find(id);
        }

        public void InsertOrUpdate(DocSunCab docSunCab)
        {
            if (docSunCab.IdDocSun == default(string))
            {
                this.context.DocSunCab.Add(docSunCab);
            }
            else
            {
                this.context.Entry(docSunCab).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var customer = this.context.DocSunCab.Find(id);
            this.context.DocSunCab.Remove(customer);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

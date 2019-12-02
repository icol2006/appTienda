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
    public interface IDocSunDetRepository
    {
        IQueryable<DocSunDet> All { get; }

        IQueryable<DocSunDet> AllIncluding(params Expression<Func<DocSunDet, object>>[] includeProperties);

        DocSunDet Find(string id);

        void InsertOrUpdate(DocSunDet docSunDet);

        void Delete(string id);

        void Save();
    }

    public class DocSunDetRepository : IDocSunDetRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<DocSunDet> All
        {
            get { return this.context.DocSunDet; }
        }

        public IQueryable<DocSunDet> AllIncluding(params Expression<Func<DocSunDet, object>>[] includeProperties)
        {
            IQueryable<DocSunDet> query = this.context.DocSunDet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public DocSunDet Find(string id)
        {
            return this.context.DocSunDet.Find(id);
        }

        public void InsertOrUpdate(DocSunDet docSunDet)
        {
            if (docSunDet.IdDocSun == default(string))
            {
                this.context.DocSunDet.Add(docSunDet);
            }
            else
            {
                this.context.Entry(docSunDet).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var customer = this.context.DocSunDet.Find(id);
            this.context.DocSunDet.Remove(customer);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

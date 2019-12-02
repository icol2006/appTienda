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
    public interface ITabFotosRepository
    {
        IQueryable<TabFotos> All { get; }

        IQueryable<TabFotos> AllIncluding(params Expression<Func<TabFotos, object>>[] includeProperties);

        TabFotos Find(string id);

        void InsertOrUpdate(TabFotos tabFotos);

        void Delete(string id);

        void Save();
    }

    public class TabFotosRepository : ITabFotosRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<TabFotos> All
        {
            get { return this.context.TabFotos; }
        }

        public IQueryable<TabFotos> AllIncluding(params Expression<Func<TabFotos, object>>[] includeProperties)
        {
            IQueryable<TabFotos> query = this.context.TabFotos;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public TabFotos Find(string id)
        {
            return this.context.TabFotos.Find(id);
        }

        public void InsertOrUpdate(TabFotos tabFotos)
        {
            if (tabFotos.Codigo == default(string))
            {
                this.context.TabFotos.Add(tabFotos);
            }
            else
            {
                this.context.Entry(tabFotos).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var tabFotos = this.context.TabFotos.Find(id);
            this.context.TabFotos.Remove(tabFotos);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }

}

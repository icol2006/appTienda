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
    public interface IUnidadMedidaRepository
    {
        IQueryable<UnidadMedida> All { get; }

        IQueryable<UnidadMedida> AllIncluding(params Expression<Func<UnidadMedida, object>>[] includeProperties);

        UnidadMedida Find(string id);

        void InsertOrUpdate(UnidadMedida employee);

        void Delete(string id);

        void Save();
    }


    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<UnidadMedida> All
        {
            get { return this.context.UnidadMedida; }
        }

        public IQueryable<UnidadMedida> AllIncluding(params Expression<Func<UnidadMedida, object>>[] includeProperties)
        {
            IQueryable<UnidadMedida> query = this.context.UnidadMedida;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public UnidadMedida Find(string id)
        {
            return this.context.UnidadMedida.Find(id);
        }

        public void InsertOrUpdate(UnidadMedida unidadMedida)
        {
            if (unidadMedida.CodUnidadMed == default(string))
            {
                this.context.UnidadMedida.Add(unidadMedida);
            }
            else
            {
                this.context.Entry(unidadMedida).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var unidadMedida = this.context.UnidadMedida.Find(id);
            this.context.UnidadMedida.Remove(unidadMedida);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

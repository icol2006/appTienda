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
    public interface IClienteRepository
    {
        IQueryable<Cliente> All { get; }

        IQueryable<Cliente> AllIncluding(params Expression<Func<Cliente, object>>[] includeProperties);

        Cliente Find(string id);

        void InsertOrUpdate(Cliente cliente);

        void Delete(string id);

        void Save();
    }

    public class ClienteRepository : IClienteRepository
    {
        private readonly WebDatabaseContext context = new WebDatabaseContext();

        public IQueryable<Cliente> All
        {
            get { return this.context.Cliente; }
        }

        public IQueryable<Cliente> AllIncluding(params Expression<Func<Cliente, object>>[] includeProperties)
        {
            IQueryable<Cliente> query = this.context.Cliente;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public Cliente Find(string id)
        {
            return this.context.Cliente.Find(id);
        }

        public void InsertOrUpdate(Cliente cliente)
        {
            if (cliente.CodCli == default(string))
            {
                this.context.Cliente.Add(cliente);
            }
            else
            {
                this.context.Entry(cliente).State = EntityState.Modified;
            }
        }

        public void Delete(string id)
        {
            var cliente = this.context.Cliente.Find(id);
            this.context.Cliente.Remove(cliente);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}

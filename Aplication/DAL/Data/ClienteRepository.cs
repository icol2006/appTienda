using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public interface IClienteRepository
    {
        List<Cliente> GetList(Expression<Func<Cliente, bool>> Filtro, String[] Includes);

        Cliente GetOne(Expression<Func<Cliente, Boolean>> Filtro, String[] Includes);

        void Update(Cliente cliente);

        Cliente Insert(Cliente cliente);

        void Delete(Cliente cliente);
    }

    public class ClienteRepository : IClienteRepository
    {
        public Cliente GetOne(Expression<Func<Cliente, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<Cliente> query = context.Set<Cliente>();

                if (Includes != null)
                {
                    foreach (String include in Includes)
                    {
                        query = query.Include(include.Trim());
                    }
                }

                return query.Where(Filtro).FirstOrDefault();
            }
        }

        public List<Cliente> GetList(Expression<Func<Cliente, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<Cliente> query = context.Set<Cliente>();

                if (Includes != null)
                {
                    foreach (String include in Includes)
                    {
                        query = query.Include(include.Trim());
                    }
                }

                if (Filtro != null)
                {
                    return query.Where(Filtro).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
        }

        public void Update(Cliente cliente)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<Cliente>(cliente).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Cliente Insert(Cliente cliente)
        {
            try
            {
                cliente.CodCli = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<Cliente>().Add(cliente);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return cliente;
        }

        public void Delete(Cliente cliente)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = cliente != null ? context.Cliente.Remove(cliente) : null;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        
        private String generarPrimaryKey()
        {
            String res = "",cod="";
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            cod= new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            var datos = GetOne(x => x.CodCli.Equals(cod),null);

            if (datos == null)
            {
                res = cod;
            }
            else
            {
                generarPrimaryKey();
            }

            return res;
        }
    }
}

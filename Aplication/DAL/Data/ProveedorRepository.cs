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
    public interface IProveedorRepository
    {
        List<Proveedor> GetList(Expression<Func<Proveedor, bool>> Filtro, String[] Includes);

        Proveedor GetOne(Expression<Func<Proveedor, Boolean>> Filtro, String[] Includes);

        void Update(Proveedor proveedor);

        Proveedor Insert(Proveedor proveedor);

        void Delete(Proveedor proveedor);
    }


    public class ProveedorRepository : IProveedorRepository
    {
        public Proveedor GetOne(Expression<Func<Proveedor, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<Proveedor> query = context.Set<Proveedor>();

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

        public List<Proveedor> GetList(Expression<Func<Proveedor, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<Proveedor> query = context.Set<Proveedor>();

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

        public void Update(Proveedor proveedor)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<Proveedor>(proveedor).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Proveedor Insert(Proveedor proveedor)
        {
            try
            {
                proveedor.CodPrv = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<Proveedor>().Add(proveedor);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return proveedor;
        }

        public void Delete(Proveedor proveedor)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = proveedor != null ? context.Proveedor.Remove(proveedor) : null;
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
            String res = "", cod = "";
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            cod = new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            var datos = GetOne(x => x.CodPrv.Equals(cod), null);

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

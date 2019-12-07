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
    public interface IProductoRepository
    {
        List<Producto> GetList(Expression<Func<Producto, bool>> Filtro, String[] Includes);

        Producto GetOne(Expression<Func<Producto, Boolean>> Filtro, String[] Includes);

        void Update(Producto producto);

        Producto Insert(Producto producto);

        void Delete(Producto producto);
    }

    public class ProductoRepository : IProductoRepository
    {
        public Producto GetOne(Expression<Func<Producto, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<Producto> query = context.Set<Producto>();

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

        public List<Producto> GetList(Expression<Func<Producto, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<Producto> query = context.Set<Producto>();

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

        public void Update(Producto producto)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<Producto>(producto).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Producto Insert(Producto producto)
        {
            try
            {
                producto.CodPro = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<Producto>().Add(producto);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return producto;
        }

        public void Delete(Producto producto)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = producto != null ? context.Producto.Remove(producto) : null;
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

            var datos = GetOne(x => x.CodPro.Equals(cod), null);

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

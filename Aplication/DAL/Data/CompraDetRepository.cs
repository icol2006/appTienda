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
    public interface ICompraDetRepository
    {
        List<CompraDet> GetList(Expression<Func<CompraDet, bool>> Filtro, String[] Includes);

        CompraDet GetOne(Expression<Func<CompraDet, Boolean>> Filtro, String[] Includes);

        void Update(CompraDet CompraDet);

        CompraDet Insert(CompraDet CompraDet);

        void Delete(CompraDet CompraDet);
    }

    public class CompraDetRepository : ICompraDetRepository
    {
        public CompraDet GetOne(Expression<Func<CompraDet, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<CompraDet> query = context.Set<CompraDet>();

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

        public List<CompraDet> GetList(Expression<Func<CompraDet, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<CompraDet> query = context.Set<CompraDet>();

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

        public void Update(CompraDet compraDet)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<CompraDet>(compraDet).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public CompraDet Insert(CompraDet compraDet)
        {
            try
            {
                compraDet.IdCompra = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<CompraDet>().Add(compraDet);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return compraDet;
        }

        public void Delete(CompraDet compraDet)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = compraDet != null ? context.CompraDet.Remove(compraDet) : null;
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
            cod = new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            var datos = GetOne(x => x.IdCompra.Equals(cod), null);

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

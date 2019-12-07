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
    public interface ICompraCabRepository
    {
        List<CompraCab> GetList(Expression<Func<CompraCab, bool>> Filtro, String[] Includes);

        CompraCab GetOne(Expression<Func<CompraCab, Boolean>> Filtro, String[] Includes);

        void Update(CompraCab compraCab);

        CompraCab Insert(CompraCab compraCab);

        void Delete(CompraCab compraCab);
    }

    public class CompraCabRepository : ICompraCabRepository
    {
        public CompraCab GetOne(Expression<Func<CompraCab, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<CompraCab> query = context.Set<CompraCab>();

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

        public List<CompraCab> GetList(Expression<Func<CompraCab, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<CompraCab> query = context.Set<CompraCab>();

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

        public void Update(CompraCab CompraCab)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<CompraCab>(CompraCab).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public CompraCab Insert(CompraCab CompraCab)
        {
            try
            {
                CompraCab.IdCompra = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<CompraCab>().Add(CompraCab);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return CompraCab;
        }

        public void Delete(CompraCab CompraCab)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = CompraCab != null ? context.CompraCab.Remove(CompraCab) : null;
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

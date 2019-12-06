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

    public interface IAlmacenRepository
    {
        List<Almacen> GetList(Expression<Func<Almacen, bool>> Filtro, String[] Includes);

        Almacen GetOne(Expression<Func<Almacen, Boolean>> Filtro, String[] Includes);

        void Update(Almacen almacen); 

        Almacen Insert(Almacen almacen);

        void Delete(Almacen almacen);

    }

    public class AlmacenRepository : IAlmacenRepository
    {
        public Almacen GetOne(Expression<Func<Almacen, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<Almacen> query = context.Set<Almacen>();

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

        public List<Almacen> GetList(Expression<Func<Almacen, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<Almacen> query = context.Set<Almacen>();

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


        public void Update(Almacen almacen)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<Almacen>(almacen).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Almacen Insert(Almacen almacen)
        {
            try
            {
                almacen.CodAlm = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<Almacen>().Add(almacen);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return almacen;
        }

        public void Delete(Almacen almacen)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = almacen != null ? context.Almacen.Remove(almacen) : null;
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
            cod = new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            var datos = GetOne(x => x.CodAlm.Equals(cod), null);

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

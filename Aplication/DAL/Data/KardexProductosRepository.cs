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
    public interface IKardexProductosRepository
    {
        List<KardexProductos> GetList(Expression<Func<KardexProductos, bool>> Filtro, String[] Includes);

        KardexProductos GetOne(Expression<Func<KardexProductos, Boolean>> Filtro, String[] Includes);

        void Update(KardexProductos KardexProductos);

        KardexProductos Insert(KardexProductos KardexProductos);

        void Delete(KardexProductos KardexProductos);

    }

    public class KardexProductosRepository : IKardexProductosRepository
    {
        public KardexProductos GetOne(Expression<Func<KardexProductos, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<KardexProductos> query = context.Set<KardexProductos>();

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

        public List<KardexProductos> GetList(Expression<Func<KardexProductos, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<KardexProductos> query = context.Set<KardexProductos>();

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



        public void Update(KardexProductos kardexProductos)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<KardexProductos>(kardexProductos).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public KardexProductos Insert(KardexProductos kardexProductos)
        {
            try
            {
                kardexProductos.IdKardex = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<KardexProductos>().Add(kardexProductos);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return kardexProductos;
        }

        public void Delete(KardexProductos kardexProductos)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = kardexProductos != null ? context.KardexProductos.Remove(kardexProductos) : null;
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

            var datos = GetOne(x => x.IdKardex.Equals(cod), null);

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

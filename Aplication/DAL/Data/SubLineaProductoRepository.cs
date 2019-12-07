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
    public interface ISubLineaProductoRepository
    {
        List<SubLineaProducto> GetList(Expression<Func<SubLineaProducto, bool>> Filtro, String[] Includes);

        SubLineaProducto GetOne(Expression<Func<SubLineaProducto, Boolean>> Filtro, String[] Includes);

        void Update(SubLineaProducto subLineaProducto);

        SubLineaProducto Insert(SubLineaProducto subLineaProducto);

        void Delete(SubLineaProducto subLineaProducto);
    }


    public class SubLineaProductoRepository : ISubLineaProductoRepository
    {
        public SubLineaProducto GetOne(Expression<Func<SubLineaProducto, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<SubLineaProducto> query = context.Set<SubLineaProducto>();

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

        public List<SubLineaProducto> GetList(Expression<Func<SubLineaProducto, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<SubLineaProducto> query = context.Set<SubLineaProducto>();

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

        public void Update(SubLineaProducto subLineaProducto)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<SubLineaProducto>(subLineaProducto).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public SubLineaProducto Insert(SubLineaProducto subLineaProducto)
        {
            try
            {
                subLineaProducto.CodSubLin = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<SubLineaProducto>().Add(subLineaProducto);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return subLineaProducto;
        }

        public void Delete(SubLineaProducto subLineaProducto)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = subLineaProducto != null ? context.SubLineaProducto.Remove(subLineaProducto) : null;
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

            var datos = GetOne(x => x.CodSubLin.Equals(cod), null);

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

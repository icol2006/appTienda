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
            String res = "";
            int cod = 0;

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var datos = GetList(null, null).LastOrDefault();

                    if (datos == null)
                    {
                        res = "1";
                        res = res.PadLeft(4, '0');
                    }
                    else
                    {
                        cod = Convert.ToInt16(datos.CodSubLin);
                        cod = cod + 1;
                        res = cod + "";
                        res = res.PadLeft(4, '0');
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return res;
        }

    }
}

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
    public interface ILineaProductoRepository
    {
        List<LineaProducto> GetList(Expression<Func<LineaProducto, bool>> Filtro, String[] Includes);

        LineaProducto GetOne(Expression<Func<LineaProducto, Boolean>> Filtro, String[] Includes);

        void Update(LineaProducto lineaProducto);

        LineaProducto Insert(LineaProducto lineaProducto);

        void Delete(LineaProducto lineaProducto);
    }

    public class LineaProductoRepository : ILineaProductoRepository
    {
        public LineaProducto GetOne(Expression<Func<LineaProducto, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<LineaProducto> query = context.Set<LineaProducto>();

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

        public List<LineaProducto> GetList(Expression<Func<LineaProducto, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<LineaProducto> query = context.Set<LineaProducto>();

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

        public void Update(LineaProducto lineaProducto)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<LineaProducto>(lineaProducto).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public LineaProducto Insert(LineaProducto lineaProducto)
        {
            try
            {
                lineaProducto.CodLin = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<LineaProducto>().Add(lineaProducto);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return lineaProducto;
        }

        public void Delete(LineaProducto lineaProducto)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = lineaProducto != null ? context.LineaProducto.Remove(lineaProducto) : null;
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

            var datos = GetOne(x => x.CodLin.Equals(cod), null);

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

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
    public interface ITabFotosRepository
    {
        List<TabFotos> GetList(Expression<Func<TabFotos, bool>> Filtro, String[] Includes);

        TabFotos GetOne(Expression<Func<TabFotos, Boolean>> Filtro, String[] Includes);

        void Update(TabFotos TabFotos);

        TabFotos Insert(TabFotos TabFotos);

        void Delete(TabFotos TabFotos);
    }

    public class TabFotosRepository : ITabFotosRepository
    {
        public TabFotos GetOne(Expression<Func<TabFotos, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<TabFotos> query = context.Set<TabFotos>();

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

        public List<TabFotos> GetList(Expression<Func<TabFotos, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<TabFotos> query = context.Set<TabFotos>();

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

        public void Update(TabFotos tabFotos)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<TabFotos>(tabFotos).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public TabFotos Insert(TabFotos tabFotos)
        {
            try
            {
                tabFotos.Tipo = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<TabFotos>().Add(tabFotos);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tabFotos;
        }

        public void Delete(TabFotos tabFotos)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.TabFotos.Attach(tabFotos);
                    context.Entry(tabFotos).State = EntityState.Deleted;
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
                        res = res.PadLeft(3, '0');
                    }
                    else
                    {
                        cod = Convert.ToInt16(datos.Tipo);
                        cod = cod + 1;
                        res = cod + "";
                        res = res.PadLeft(3, '0');
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

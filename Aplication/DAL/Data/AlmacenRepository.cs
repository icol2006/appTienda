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
            String res = "";
            int cod =0;

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var datos=GetList(null, null).LastOrDefault();

                    if(datos == null)
                    {
                        res = "0001";
                    }
                    else
                    {
                        cod = Convert.ToInt16(datos.CodAlm);
                        cod = cod + 1;
                        res = cod + "";
                        res= res.PadLeft(4, '0');

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

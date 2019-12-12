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
    public interface IProveedorRepository
    {
        List<Proveedor> GetList(Expression<Func<Proveedor, bool>> Filtro, String[] Includes);

        Proveedor GetOne(Expression<Func<Proveedor, Boolean>> Filtro, String[] Includes);

        void Update(Proveedor proveedor);

        Proveedor Insert(Proveedor proveedor);

        void Delete(Proveedor proveedor);
    }


    public class ProveedorRepository : IProveedorRepository
    {
        public Proveedor GetOne(Expression<Func<Proveedor, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<Proveedor> query = context.Set<Proveedor>();

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

        public List<Proveedor> GetList(Expression<Func<Proveedor, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<Proveedor> query = context.Set<Proveedor>();

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

        public void Update(Proveedor proveedor)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<Proveedor>(proveedor).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Proveedor Insert(Proveedor proveedor)
        {
            try
            {
                proveedor.CodPrv = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<Proveedor>().Add(proveedor);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return proveedor;
        }

        public void Delete(Proveedor proveedor)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = proveedor != null ? context.Proveedor.Remove(proveedor) : null;
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
                        res = res.PadLeft(6, '0');
                    }
                    else
                    {
                        cod = Convert.ToInt16(datos.CodPrv);
                        cod = cod + 1;
                        res = cod + "";
                        res = res.PadLeft(6, '0');
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

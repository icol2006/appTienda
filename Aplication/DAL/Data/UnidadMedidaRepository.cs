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
    public interface IUnidadMedidaRepository
    {
        List<UnidadMedida> GetList(Expression<Func<UnidadMedida, bool>> Filtro, String[] Includes);

        UnidadMedida GetOne(Expression<Func<UnidadMedida, Boolean>> Filtro, String[] Includes);

        void Update(UnidadMedida UnidadMedida);

        UnidadMedida Insert(UnidadMedida UnidadMedida);

        void Delete(UnidadMedida UnidadMedida);
    }


    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        public UnidadMedida GetOne(Expression<Func<UnidadMedida, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<UnidadMedida> query = context.Set<UnidadMedida>();

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

        public List<UnidadMedida> GetList(Expression<Func<UnidadMedida, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<UnidadMedida> query = context.Set<UnidadMedida>();

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

        public void Update(UnidadMedida unidadMedida)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<UnidadMedida>(unidadMedida).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public UnidadMedida Insert(UnidadMedida unidadMedida)
        {
            try
            {
                unidadMedida.CodUnidadMed = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<UnidadMedida>().Add(unidadMedida);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return unidadMedida;
        }

        public void Delete(UnidadMedida unidadMedida)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = unidadMedida != null ? context.UnidadMedida.Remove(unidadMedida) : null;
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
                        cod = Convert.ToInt16(datos.CodUnidadMed);
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

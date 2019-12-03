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

    public interface IDevolucionCabRepository
    {
        List<DevolucionCab> GetList(Expression<Func<DevolucionCab, bool>> Filtro, String[] Includes);

        DevolucionCab GetOne(Expression<Func<DevolucionCab, Boolean>> Filtro, String[] Includes);

        void Update(DevolucionCab devolucionCab);

        DevolucionCab Insert(DevolucionCab devolucionCab);

        void Delete(DevolucionCab devolucionCab);

    }

    public class DevolucionCabRepository : IDevolucionCabRepository
    {
        public DevolucionCab GetOne(Expression<Func<DevolucionCab, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<DevolucionCab> query = context.Set<DevolucionCab>();

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

        public List<DevolucionCab> GetList(Expression<Func<DevolucionCab, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<DevolucionCab> query = context.Set<DevolucionCab>();

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

        public void Update(DevolucionCab devolucionCab)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<DevolucionCab>(devolucionCab).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DevolucionCab Insert(DevolucionCab devolucionCab)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<DevolucionCab>().Add(devolucionCab);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return devolucionCab;
        }

        public void Delete(DevolucionCab devolucionCab)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = devolucionCab != null ? context.DevolucionCab.Remove(devolucionCab) : null;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

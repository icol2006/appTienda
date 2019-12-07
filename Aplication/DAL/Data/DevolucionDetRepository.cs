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

    public interface IDevolucionDetRepository
    {
        List<DevolucionDet> GetList(Expression<Func<DevolucionDet, bool>> Filtro, String[] Includes);

        DevolucionDet GetOne(Expression<Func<DevolucionDet, Boolean>> Filtro, String[] Includes);

        void Update(DevolucionDet DevolucionDet);

        DevolucionDet Insert(DevolucionDet DevolucionDet);

        void Delete(DevolucionDet DevolucionDet);
    }

    public class DevolucionDetRepository : IDevolucionDetRepository
    {
        public DevolucionDet GetOne(Expression<Func<DevolucionDet, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<DevolucionDet> query = context.Set<DevolucionDet>();

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

        public List<DevolucionDet> GetList(Expression<Func<DevolucionDet, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<DevolucionDet> query = context.Set<DevolucionDet>();

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

        public void Update(DevolucionDet devolucionDet)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<DevolucionDet>(devolucionDet).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DevolucionDet Insert(DevolucionDet devolucionDet)
        {
            try
            {
                devolucionDet.IdDevolucion = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<DevolucionDet>().Add(devolucionDet);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return devolucionDet;
        }

        public void Delete(DevolucionDet devolucionDet)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = devolucionDet != null ? context.DevolucionDet.Remove(devolucionDet) : null;
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

            var datos = GetOne(x => x.IdDevolucion.Equals(cod), null);

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

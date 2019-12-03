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
    public interface IProAlmRepository
    {
        List<ProAlm> GetList(Expression<Func<ProAlm, bool>> Filtro, String[] Includes);

        ProAlm GetOne(Expression<Func<ProAlm, Boolean>> Filtro, String[] Includes);

        void Update(ProAlm proAlm);

        ProAlm Insert(ProAlm proAlm);

        void Delete(ProAlm proAlm);

    }


    public class ProAlmRepository : IProAlmRepository
    {
        public ProAlm GetOne(Expression<Func<ProAlm, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<ProAlm> query = context.Set<ProAlm>();

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

        public List<ProAlm> GetList(Expression<Func<ProAlm, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<ProAlm> query = context.Set<ProAlm>();

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

        public void Update(ProAlm proAlm)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<ProAlm>(proAlm).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public ProAlm Insert(ProAlm proAlm)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<ProAlm>().Add(proAlm);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return proAlm;
        }

        public void Delete(ProAlm proAlm)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = proAlm != null ? context.ProAlm.Remove(proAlm) : null;
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

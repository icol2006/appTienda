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
    public interface IDocSunCabRepository
    {
        List<DocSunCab> GetList(Expression<Func<DocSunCab, bool>> Filtro, String[] Includes);

        DocSunCab GetOne(Expression<Func<DocSunCab, Boolean>> Filtro, String[] Includes);

        void Update(DocSunCab docSunCab);

        DocSunCab Insert(DocSunCab docSunCab);

        void Delete(DocSunCab docSunCab);

    }

    public class DocSunCabRepository : IDocSunCabRepository
    {
        public DocSunCab GetOne(Expression<Func<DocSunCab, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<DocSunCab> query = context.Set<DocSunCab>();

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

        public List<DocSunCab> GetList(Expression<Func<DocSunCab, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<DocSunCab> query = context.Set<DocSunCab>();

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

        public void Update(DocSunCab DocSunCab)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<DocSunCab>(DocSunCab).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DocSunCab Insert(DocSunCab DocSunCab)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<DocSunCab>().Add(DocSunCab);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DocSunCab;
        }

        public void Delete(DocSunCab DocSunCab)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = DocSunCab != null ? context.DocSunCab.Remove(DocSunCab) : null;
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

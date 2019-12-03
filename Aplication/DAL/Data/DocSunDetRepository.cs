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
    public interface IDocSunDetRepository
    {
        List<DocSunDet> GetList(Expression<Func<DocSunDet, bool>> Filtro, String[] Includes);

        DocSunDet GetOne(Expression<Func<DocSunDet, Boolean>> Filtro, String[] Includes);

        void Update(DocSunDet DocSunDet);

        DocSunDet Insert(DocSunDet DocSunDet);

        void Delete(DocSunDet DocSunDet);
    }

    public class DocSunDetRepository : IDocSunDetRepository
    {
        public DocSunDet GetOne(Expression<Func<DocSunDet, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<DocSunDet> query = context.Set<DocSunDet>();

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

        public List<DocSunDet> GetList(Expression<Func<DocSunDet, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<DocSunDet> query = context.Set<DocSunDet>();

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

        public void Update(DocSunDet DocSunDet)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<DocSunDet>(DocSunDet).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DocSunDet Insert(DocSunDet DocSunDet)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<DocSunDet>().Add(DocSunDet);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DocSunDet;
        }

        public void Delete(DocSunDet DocSunDet)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = DocSunDet != null ? context.DocSunDet.Remove(DocSunDet) : null;
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

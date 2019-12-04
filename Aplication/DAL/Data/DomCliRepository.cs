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
    public interface IDomCliRepository
    {
        List<DomCli> GetList(Expression<Func<DomCli, bool>> Filtro, String[] Includes);

        DomCli GetOne(Expression<Func<DomCli, Boolean>> Filtro, String[] Includes);

        void Update(DomCli domCli);

        DomCli Insert(DomCli domCli);

        void Delete(DomCli domCli);

    }

    public class DomCliRepository : IDomCliRepository
    {

        public DomCli GetOne(Expression<Func<DomCli, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<DomCli> query = context.Set<DomCli>();

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

        public List<DomCli> GetList(Expression<Func<DomCli, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<DomCli> query = context.Set<DomCli>();

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

        public void Update(DomCli DomCli)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<DomCli>(DomCli).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DomCli Insert(DomCli DomCli)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<DomCli>().Add(DomCli);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DomCli;
        }

        public void Delete(DomCli domCli)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    if(domCli!=null)
                    {
                        context.DomCli.Attach(domCli);
                        context.Entry(domCli).State = EntityState.Deleted;
                        context.SaveChanges();
                    }    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

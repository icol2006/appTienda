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
    public interface IPedidoDetRepository
    {
        List<PedidoDet> GetList(Expression<Func<PedidoDet, bool>> Filtro, String[] Includes);

        PedidoDet GetOne(Expression<Func<PedidoDet, Boolean>> Filtro, String[] Includes);

        void Update(PedidoDet pedidoDet);

        PedidoDet Insert(PedidoDet pedidoDet);

        void Delete(PedidoDet pedidoDet);

    }

    public class PedidoDetRepository : IPedidoDetRepository
    {
        public PedidoDet GetOne(Expression<Func<PedidoDet, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<PedidoDet> query = context.Set<PedidoDet>();

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

        public List<PedidoDet> GetList(Expression<Func<PedidoDet, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<PedidoDet> query = context.Set<PedidoDet>();

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

        public void Update(PedidoDet pedidoDet)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<PedidoDet>(pedidoDet).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public PedidoDet Insert(PedidoDet pedidoDet)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<PedidoDet>().Add(pedidoDet);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return pedidoDet;
        }

        public void Delete(PedidoDet pedidoDet)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = pedidoDet != null ? context.PedidoDet.Remove(pedidoDet) : null;
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

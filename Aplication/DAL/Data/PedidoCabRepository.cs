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
    public interface IPedidoCabRepository
    {
        List<PedidoCab> GetList(Expression<Func<PedidoCab, bool>> Filtro, String[] Includes);

        PedidoCab GetOne(Expression<Func<PedidoCab, Boolean>> Filtro, String[] Includes);

        void Update(PedidoCab pedidoCab);

        PedidoCab Insert(PedidoCab pedidoCab);

        void Delete(PedidoCab pedidoCab);
    }

    public class PedidoCabRepository : IPedidoCabRepository
    {
        public PedidoCab GetOne(Expression<Func<PedidoCab, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<PedidoCab> query = context.Set<PedidoCab>();

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

        public List<PedidoCab> GetList(Expression<Func<PedidoCab, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<PedidoCab> query = context.Set<PedidoCab>();

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

        public void Update(PedidoCab PedidoCab)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<PedidoCab>(PedidoCab).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public PedidoCab Insert(PedidoCab PedidoCab)
        {
            try
            {
                PedidoCab.IdPedido = generarPrimaryKey();
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Set<PedidoCab>().Add(PedidoCab);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return PedidoCab;
        }

        public void Delete(PedidoCab PedidoCab)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var res = PedidoCab != null ? context.PedidoCab.Remove(PedidoCab) : null;
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

            var datos = GetOne(x => x.IdPedido.Equals(cod), null);

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

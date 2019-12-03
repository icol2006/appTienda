﻿using DAL.Models;
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
    public interface IVendedorRepository
    {
        List<Vendedor> GetList(Expression<Func<Vendedor, bool>> Filtro, String[] Includes);

        Vendedor GetOne(Expression<Func<Vendedor, Boolean>> Filtro, String[] Includes);

        void Update(Vendedor vendedor);

        Vendedor Insert(Vendedor vendedor);

        void Delete(Vendedor vendedor);

    }


    public class VendedorRepository : IVendedorRepository
    {
        public Vendedor GetOne(Expression<Func<Vendedor, Boolean>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<Vendedor> query = context.Set<Vendedor>();

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

        public List<Vendedor> GetList(Expression<Func<Vendedor, bool>> Filtro, String[] Includes)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DbQuery<Vendedor> query = context.Set<Vendedor>();

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

        public void Update(Vendedor vendedor)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Entry<Vendedor>(vendedor).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Vendedor Insert(Vendedor vendedor)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Set<Vendedor>().Add(vendedor);
                context.SaveChanges();
            }
                return vendedor;   
        }

        public void Delete(Vendedor vendedor)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var res=vendedor!=null?context.Vendedor.Remove(vendedor):null;
                context.SaveChanges();
            }                 
        }

    }
}

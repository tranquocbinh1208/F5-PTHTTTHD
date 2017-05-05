﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Mm.DataAccessLayer
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        public IList<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] navigationproperties)
        {
            List<T> list = null;
            using (var context = new BankManagermentEntities())
            {
                IQueryable<T> dbquery = context.Set<T>();
                // eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationproperties)
                {
                    dbquery = dbquery.Include<T, object>(navigationProperty);
                }
                list = dbquery.AsNoTracking().ToList<T>();
            }
            return list;
        }

        public IList<T> GetList(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationproperties)
        {
            List<T> list = null;
            using (var context = new BankManagermentEntities())
            {
                IQueryable<T> dbquery = context.Set<T>();
                // eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationproperties)
                {
                    dbquery = dbquery.Include<T, object>(navigationProperty);
                }
                list = dbquery.AsNoTracking().Where(where).ToList<T>();
            }
            return list;
        }

        public T GetSingle(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationproperties)
        {
            T item = null;
            using (var context = new BankManagermentEntities())
            {
                IQueryable<T> dbquery = context.Set<T>();
                // eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationproperties)
                {
                    dbquery = dbquery.Include<T, object>(navigationProperty);
                }
                item = dbquery.AsNoTracking().SingleOrDefault(where);
            }
            return item;
        }

        public void add(params T[] items)
        {
            using (var context = new BankManagermentEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Added;
                }
                context.SaveChanges();
            }
        }

        public void update(params T[] items)
        {
            using (var context = new BankManagermentEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();
            }

        }

        public void remove(params T[] items)
        {
            using (var context = new BankManagermentEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }
    }
}

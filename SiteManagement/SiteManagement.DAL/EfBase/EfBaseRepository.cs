using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SiteManagement.DAL.EfBase
{
    public class EfBaseRepository<T, TBContext> : IEfBaseRepository<T>
        where T : class
        where TBContext : DbContext
    {
        protected readonly TBContext _context;

        public EfBaseRepository(TBContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            return _context.Add(entity).Entity;

        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        /// <summary>
        /// null ise bütün dataları dönecek, değil ise koşulu sağlayan dataları dönecek
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return _context.Set<T>().ToList();
            }
            else
            {
                return _context.Set<T>().Where(expression);
            }
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

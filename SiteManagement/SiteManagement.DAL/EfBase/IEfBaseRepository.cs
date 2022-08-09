using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SiteManagement.DAL.EfBase
{
    public interface IEfBaseRepository<T> where T : class
    {
        T Add(T entity);

        T Update(T entity);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null);

        void Delete(T entity);

        T Get(Expression<Func<T, bool>> expression);

        void SaveChanges();
    }
}

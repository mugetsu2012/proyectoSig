using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControlEscuela.Core
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T GetById(object id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Table { get; }

        T FindBy(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null);

        List<T> GetList(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null);

        T FindByTracking(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null);

        List<T> GetListTracking(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null);

        void SaveChanges();
    }
}

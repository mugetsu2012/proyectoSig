using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using ControlEscuela.Core;

namespace ControlEscuela.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private IDbSet<T> _entities;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                Entities.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception fail = CrearExecption(dbEx);
                throw fail;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                bool isDetached = _dbContext.Entry(entity).State == EntityState.Detached;
                if (isDetached)
                    Entities.Attach(entity);

                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception fail = CrearExecption(dbEx);
                throw fail;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                bool isDetached = _dbContext.Entry(entity).State == EntityState.Detached;
                if (isDetached)
                    Entities.Attach(entity);

                _dbContext.Entry(entity).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception fail = CrearExecption(dbEx);
                throw fail;
            }
        }

        public T FindBy(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null)
        {
            IQueryable<T> query = Entities.Where(predicate);
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query,
                    (current, include) => current.Include(include));
            }
            return query.AsNoTracking().FirstOrDefault();
        }

        public List<T> GetList(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null)
        {
            IQueryable<T> query = Entities.Where(predicate);
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query,
                    (current, include) => current.Include(include));
            }
            return query.AsNoTracking().ToList();
        }

        public T FindByTracking(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null)
        {
            IQueryable<T> query = Entities.Where(predicate);
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query,
                    (current, include) => current.Include(include));
            }
            return query.FirstOrDefault();
        }

        public List<T> GetListTracking(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null)
        {
            IQueryable<T> query = Entities.Where(predicate);
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query,
                    (current, include) => current.Include(include));
            }
            return query.ToList();
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception fail = CrearExecption(dbEx);
                throw fail;
            }
        }

        public IQueryable<T> Table
        {
            get { return this.Entities; }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        #region Utilidades privadas

        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _dbContext.Set<T>();
                }

                return _entities;
            }
        }

        private Exception CrearExecption(DbEntityValidationException dbEx)
        {
            var msg = string.Empty;

            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    msg +=
                        $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage} " +
                        Environment.NewLine;
                }
            }

            var fail = new Exception(msg, dbEx);

            return fail;
        }

        #endregion

    }
}
using Helper.Collections;
using Infrastructure.Databases.Interfaces;
using FastMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Databases.EntityFramework
{
    public class EntityFrameworkRepositoryBase : IRepositoryBase
    {
        private readonly DbContext _context;

        protected EntityFrameworkRepositoryBase(DbContext context)
        {
            _context = context;
            _context.Configuration.AutoDetectChangesEnabled = false;
            _context.Configuration.LazyLoadingEnabled = false;
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public virtual int Count<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return Queryable(filter).Count();
        }

        public virtual Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return Queryable(filter).CountAsync();
        }

        public virtual void Delete<TEntity>(object id) where TEntity : class
        {
            var entity = _context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            AttachEntity(entity);
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return Queryable(filter).Any();
        }

        public virtual Task<bool> ExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return Queryable(filter).AnyAsync();
        }

        public virtual TEntity First<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            return Queryable(filter, includeProperties).FirstOrDefault();
        }

        public virtual async Task<TEntity> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            return await Queryable(filter, includeProperties).FirstOrDefaultAsync();
        }

        public virtual void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void InsertOrUpdate<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().AddOrUpdate(entity);
        }

        public virtual IEnumerable<TEntity> List<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            return Queryable(filter, includeProperties).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> ListAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            return await Queryable(filter, includeProperties).ToListAsync();
        }

        public PagedList<TResult> PagedList<TEntity, TResult>(PagedListParameters parameters) where TEntity : class where TResult : class
        {
            var query = Queryable<TEntity>().Project().To<TResult>();
            return new PagedList<TResult>(query, parameters);
        }

        public virtual void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ThrowValidationException(e);
            }
        }

        public virtual Task SaveChangesAsync()
        {
            try
            {
                return _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                ThrowValidationException(e);
            }

            return Task.FromResult(0);
        }

        public virtual TEntity SelectById<TEntity>(object id) where TEntity : class
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual Task<TEntity> SelectByIdAsync<TEntity>(object id) where TEntity : class
        {
            return _context.Set<TEntity>().FindAsync(id);
        }

        public TEntity Single<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            return Queryable(filter, includeProperties).SingleOrDefault();
        }

        public virtual async Task<TEntity> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            return await Queryable(filter, includeProperties).SingleOrDefaultAsync();
        }

        public virtual void Update<TEntity>(TEntity entity) where TEntity : class
        {
            AttachEntity(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        protected virtual IQueryable<TEntity> Queryable<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null) { query = query.Where(filter); }

            includeProperties?.ToList().ForEach(includeProperty => query = query.Include(includeProperty));

            return query;
        }

        private static void ThrowValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " Validation Errors: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }

        private void AttachEntity<TEntity>(TEntity entity) where TEntity : class
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(entity);
            }
        }
    }
}
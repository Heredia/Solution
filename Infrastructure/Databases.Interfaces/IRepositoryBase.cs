using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Helper.Collections;

namespace Infrastructure.Databases.Interfaces
{
    public interface IRepositoryBase
    {
        int Count<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;

        Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;

        void Delete<TEntity>(object id) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;

        Task<bool> ExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;

        TEntity First<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class;

        Task<TEntity> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class;

        void Insert<TEntity>(TEntity entity) where TEntity : class;

        void InsertOrUpdate<TEntity>(TEntity entity) where TEntity : class;

        IEnumerable<TEntity> List<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class;

        Task<IEnumerable<TEntity>> ListAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class;

        PagedList<TResult> PagedList<TEntity, TResult>(PagedListParameters parameters) where TEntity : class where TResult : class;

        void SaveChanges();

        Task SaveChangesAsync();

        TEntity SelectById<TEntity>(object id) where TEntity : class;

        Task<TEntity> SelectByIdAsync<TEntity>(object id) where TEntity : class;

        TEntity Single<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class;

        Task<TEntity> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
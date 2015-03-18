using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SAB.Framework.DbRepository.Infra;

namespace SAB.Framework.DbRepository.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IObjectState
    {
        TEntity Find(params object[] keyValues);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void InsertOrUpdateGraph(TEntity entity);
        void InsertGraphRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject);
        IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query);
        IQueryFluent<TEntity> Query();
        IQueryable<TEntity> Queryable();
        IGenericRepository<T> GetRepository<T>() where T : class, IObjectState;
    }
}
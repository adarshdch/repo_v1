using System;
using System.Data;
using SAB.Framework.DbRepository.Infra;
using SAB.Framework.DbRepository.Repositories;

namespace SAB.Framework.DbRepository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void Dispose(bool disposing);
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}
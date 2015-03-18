using System.Threading;
using System.Threading.Tasks;
using SAB.Framework.DbRepository.Infra;
using SAB.Framework.DbRepository.Repositories;

namespace SAB.Framework.DbRepository.UnitOfWork
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IGenericRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
    }
}
using System.Threading;
using System.Threading.Tasks;
using SAB.Framework.DbRepository.Infra;

namespace SAB.Framework.DbRepository.Repositories
{
    public interface IGenericRepositoryAsync<TEntity> : IGenericRepository<TEntity> where TEntity : class, IObjectState
    {
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
    }
}
using Labor_Exchange.Core.Entities;
using Labor_Exchange.Application.Paging;
using System.Linq.Expressions;

namespace Labor_Exchange.Application.IRepositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task AddAsync(TEntity item);

        Task DeleteAsync(TEntity item);

        Task<TEntity> GetOneAsync(int id);

        Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters);

        Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters,
                                              Expression<Func<TEntity, bool>> predicate);

        Task<int> GetCountEntities();

        Task SaveAsync();
    }
}

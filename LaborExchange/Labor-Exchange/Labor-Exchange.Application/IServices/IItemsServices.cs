using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;

namespace Labor_Exchange.Application.IServices
{
    public interface IItemsServices
    {
        Task<PagedList<EntityBase>> GetEntitiesPageAsync(PageParameters pageParameters);

        Task<PagedList<EntityBase>> GetEntitiesPageAsync(PageParameters pageParameters, int filter);
    }
}

using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;
using Labor_Exchange.Application.IRepositories;

namespace Labor_Exchange.Infrastructure.Services
{
    public class Service : IItemsServices
    {
        private readonly IRepository<EntityBase> _entityRepository;

        public Service(IRepository<EntityBase> entityRepository)
        {
            this._entityRepository = entityRepository;
        }

        public async Task<PagedList<EntityBase>> GetEntitiesPageAsync(PageParameters pageParameters)
        {
            return await this._entityRepository.GetPageAsync(pageParameters);
        }

        public async Task<PagedList<EntityBase>> GetEntitiesPageAsync(PageParameters pageParameters, int filter)
        {
            return await this._entityRepository.GetPageAsync(pageParameters, x => x.Id == filter);
        }
    }
}

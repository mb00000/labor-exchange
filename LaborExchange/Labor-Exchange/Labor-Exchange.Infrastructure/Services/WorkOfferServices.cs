using Labor_Exchange.Application.IRepositories;
using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;

namespace Labor_Exchange.Infrastructure.Services
{
    public class WorkOfferServices : IWorkOfferServices
    {
        private readonly IRepository<WorkOffer> _workOfferRepository;

        public WorkOfferServices(IRepository<WorkOffer> workOfferRepository)
        {
            this._workOfferRepository = workOfferRepository;
        }
        public async Task AddWorkOffer(WorkOffer workOffer)
        {
            await this._workOfferRepository.AddAsync(workOffer);
        }

        public async Task<PagedList<WorkOffer>> GetWorkOffersPageAsync(PageParameters pageParameters)
        {
            return await this._workOfferRepository.GetPageAsync(pageParameters);
        }

        public async Task<PagedList<WorkOffer>> GetWorkOffersPageAsync(PageParameters pageParameters, int filter)
        {
            return await this._workOfferRepository.GetPageAsync(pageParameters, x => x.Id == filter);
        }
    }
}

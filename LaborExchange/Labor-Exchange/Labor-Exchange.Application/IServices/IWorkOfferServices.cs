using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;

namespace Labor_Exchange.Application.IServices
{
    public interface IWorkOfferServices
    {
        Task<PagedList<WorkOffer>> GetWorkOffersPageAsync(PageParameters pageParameters);

        Task<PagedList<WorkOffer>> GetWorkOffersPageAsync(PageParameters pageParameters, int filter);

        Task AddWorkOffer(WorkOffer workOffer);
    }
}

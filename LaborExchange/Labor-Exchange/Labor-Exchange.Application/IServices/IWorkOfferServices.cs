using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;
using System.Linq.Expressions;

namespace Labor_Exchange.Application.IServices
{
    public interface IWorkOfferServices
    {
        Task<PagedList<WorkOffer>> GetWorkOffersPageAsync(PageParameters pageParameters, bool predicate);

        Task<PagedList<WorkOffer>> GetWorkOffersPageAsync(PageParameters pageParameters, string filter, int option);

        Task ChangeStoragedStatus(int id);

        Task AddWorkOffer(WorkOffer workOffer);

        Task RemoveByIdAsync(int Id);

        Task GenerateWorkOffersPDF(string path, int id);

        Task SaveChangesAsync();

        Task<int> GetWorkOffersCount();

        Task<WorkOffer> GetOneAsync(int id);
    }
}

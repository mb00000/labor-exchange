using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;

namespace Labor_Exchange.Application.IServices
{
    public interface ICompanyServices
    {
        Task<PagedList<Company>> GetCompaniesPageAsync(PageParameters pageParameters);

        Task<PagedList<Company>> GetCompaniesPageAsync(PageParameters pageParameters, int filter);

        Task AddCompany(Company company);
    }
}

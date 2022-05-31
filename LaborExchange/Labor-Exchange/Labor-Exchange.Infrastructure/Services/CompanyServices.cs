using Labor_Exchange.Application.IRepositories;
using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;

namespace Labor_Exchange.Infrastructure.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyServices(IRepository<Company> companyRepository)
        {
            this._companyRepository = companyRepository;
        }

        public async Task AddCompany(Company company)
        {
            await this._companyRepository.AddAsync(company);
        }

        public async Task<PagedList<Company>> GetCompaniesPageAsync(PageParameters pageParameters)
        {
            return await this._companyRepository.GetPageAsync(pageParameters);
        }

        public async Task<PagedList<Company>> GetCompaniesPageAsync(PageParameters pageParameters, int filter)
        {
            return await this._companyRepository.GetPageAsync(pageParameters, x => x.Id == filter);
        }
    }
}

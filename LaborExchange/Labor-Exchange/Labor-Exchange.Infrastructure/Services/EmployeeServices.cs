using Labor_Exchange.Application.IRepositories;
using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;

namespace Labor_Exchange.Infrastructure.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeServices(IRepository<Employee> employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task AddEmployee(Employee employee)
        {
            await this._employeeRepository.AddAsync(employee);
        }

        public async Task<PagedList<Employee>> GetEmployeesPageAsync(PageParameters pageParameters)
        {
            return await this._employeeRepository.GetPageAsync(pageParameters);
        }

        public async Task<PagedList<Employee>> GetEmployeesPageAsync(PageParameters pageParameters, int filter)
        {
            return await this._employeeRepository.GetPageAsync(pageParameters, x => x.Id == filter);
        }
    }
}

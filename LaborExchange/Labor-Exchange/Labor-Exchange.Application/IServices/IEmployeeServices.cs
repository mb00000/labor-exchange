using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;

namespace Labor_Exchange.Application.IServices
{
    public interface IEmployeeServices
    {
        Task<PagedList<Employee>> GetEmployeesPageAsync(PageParameters pageParameters);

        Task<PagedList<Employee>> GetEmployeesPageAsync(PageParameters pageParameters, int filter);

        Task AddEmployee(Employee employee);
    }
}

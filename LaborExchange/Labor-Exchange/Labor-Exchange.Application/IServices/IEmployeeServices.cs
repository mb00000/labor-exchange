using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;

namespace Labor_Exchange.Application.IServices
{
    public interface IEmployeeServices
    {
        Task<PagedList<Employee>> GetEmployeesPageAsync(PageParameters pageParameters);

        Task<PagedList<Employee>> GetEmployeesPageAsync(PageParameters pageParameters, string filter, int option);

        Task AddEmployee(Employee employee);

        Task GenerateEmployeesPDF(string path, int id);

        Task RemoveByIdAsync(int Id);

        Task SaveChangesAsync();

        Task<int> GetEmployeesCount();

        Task<Employee> GetOneAsync(int id);
    }
}

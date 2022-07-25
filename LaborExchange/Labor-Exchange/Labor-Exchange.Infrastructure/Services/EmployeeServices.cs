using Labor_Exchange.Application.IRepositories;
using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

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

        public async Task<PagedList<Employee>> GetEmployeesPageAsync(PageParameters pageParameters, string filter, int option)
        {
            if(option == 1)
            {
                return await this._employeeRepository.GetPageAsync(pageParameters, i => i.Profession.StartsWith(filter));

            }
            else
            {
                return await this._employeeRepository.GetPageAsync(pageParameters, i=> i.Profession==filter);
            }
        }

        public async Task RemoveByIdAsync(int Id)
        {
            var employee = await this._employeeRepository.GetOneAsync(Id);
            await this._employeeRepository.DeleteAsync(employee);
        }

        public async Task GenerateEmployeesPDF(string path, int id)
        {
            var document = new PdfDocument();
            var page = document.Pages.Add();
            var employee = await this._employeeRepository.GetOneAsync(id);
            var font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            var graphics = page.Graphics;

            graphics.DrawString($"{employee.Profession} is looking for a work!", font, PdfBrushes.Black, new PointF(170, 30));
            graphics.DrawString($"My name is {employee.Name}, I have {employee.Education}.", font, PdfBrushes.Black, new PointF(120, 60));
            graphics.DrawString($"My last work is {employee.LastWork}", font, PdfBrushes.Black, new PointF(100, 90));
            graphics.DrawString($"I have left it because of {employee.ReasonOfDismisal}", font, PdfBrushes.Black, new PointF(120, 120));
            graphics.DrawString($"I expect of my work: {employee.Requirements}", font, PdfBrushes.Black, new PointF(110, 150));
            graphics.DrawString($"Now I lives in {employee.Housing}. I am {employee.MartialStatus}.", font, PdfBrushes.Black, new PointF(160, 180));
            graphics.DrawString($"Looking forward to your offers!", font, PdfBrushes.Black, new PointF(180,210));
            graphics.DrawString($"If you need {employee.Profession} and I suit you, you can contact me.", font, PdfBrushes.Black, new PointF(100, 240));
            graphics.DrawString($"Tel: {employee.Contacts}", font, PdfBrushes.Black, new PointF(210, 270));
            using (var fs = File.Create(path))
            {
                document.Save(fs);
            }
        }

        public async Task SaveChangesAsync()
        {
            await this._employeeRepository.SaveAsync();
        }

        public async Task<Employee> GetOneAsync(int id)
        {
            return await this._employeeRepository.GetOneAsync(id);
        }

        public async Task<int> GetEmployeesCount()
        {
            return await this._employeeRepository.GetCountEntities();
        }
    }
}

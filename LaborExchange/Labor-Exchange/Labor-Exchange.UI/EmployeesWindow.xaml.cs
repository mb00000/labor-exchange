using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;
using Labor_Exchange.Infrastructure.ApplicationContext;
using Labor_Exchange.Infrastructure.DataInitialaizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Labor_Exchange.UI
{
    /// <summary>
    /// Interaction logic for EmployeesWindow.xaml
    /// </summary>
    public partial class EmployeesWindow : Window
    {
        private readonly IEmployeeServices _employeeServices;

        private PageParameters _pageParameters = new();

        private PagedList<Employee> _employees = new();
        public EmployeesWindow(IEmployeeServices employeeServices)
        {
            this._employeeServices = employeeServices;

            var context = new EFContext();

            InitializeComponent();
            new Action(async () => await this.SetPage(1))();
            this.Employees.ItemsSource = this._employees;
        }

        private async Task SetPage(int pageNumber)
        {
            this._pageParameters.PageNumber = pageNumber;
            this._employees = await this._employeeServices.GetEmployeesPageAsync(this._pageParameters);
            this.Employees.ItemsSource = this._employees;
        }
    }
}

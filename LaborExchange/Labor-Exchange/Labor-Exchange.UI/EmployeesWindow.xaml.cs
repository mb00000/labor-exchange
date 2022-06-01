using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;
using Labor_Exchange.Infrastructure.ApplicationContext;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Labor_Exchange.UI
{
    /// <summary>
    /// Interaction logic for EmployeesWindow.xaml
    /// </summary>
    public partial class EmployeesWindow : Window
    {
        private readonly IEmployeeServices _employeeServices;

        private Employee _newEmployee = new Employee();

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

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            var name = Name.Text;
            this._newEmployee.Name = name;
        }

        private void Profession_TextChanged(object sender, TextChangedEventArgs e)
        {
            var profession = Profession.Text;
            this._newEmployee.Profession = profession;
        }

        private void Education_TextChanged(object sender, TextChangedEventArgs e)
        {
            var education = Education.Text;
            this._newEmployee.Education = education;
        }

        private void LastWork_TextChanged(object sender, TextChangedEventArgs e)
        {
            var lastWork = LastWork.Text;
            this._newEmployee.LastWork = lastWork;
        }

        private void ReasonOfDismisal_TextChanged(object sender, TextChangedEventArgs e)
        {
            var reasonOfDismisal = ReasonOfDismisal.Text;
            this._newEmployee.ReasonOfDismisal = reasonOfDismisal;
        }

        private void MartialStatus_TextChanged(object sender, TextChangedEventArgs e)
        {
            var martialStatus = MartialStatus.Text;
            this._newEmployee.MartialStatus = martialStatus;
        }

        private void Housing_TextChanged(object sender, TextChangedEventArgs e)
        {
            var housing = Housing.Text;
            this._newEmployee.Housing = housing;
        }

        private void Contacts_TextChanged(object sender, TextChangedEventArgs e)
        {
            var contacts = Contacts.Text;
            this._newEmployee.Contacts = contacts;
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            this._employeeServices.AddEmployee(_newEmployee);
            this._employees.Add(this._newEmployee);
            this._newEmployee = new Employee();
            this.RefreshGrid();
        }

        private void RefreshGrid()
        {
            this.Employees.Items.Refresh();
        }

        private async void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if(this._employees.PageNumber < this._employees.TotalItems)
            {
                await this.SetPage(this._employees.PageNumber + 1);
            }
        }

        private async void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (this._employees.PageNumber > 1)
            {
                await this.SetPage(this._employees.PageNumber - 1);
            }
        }
    }
}

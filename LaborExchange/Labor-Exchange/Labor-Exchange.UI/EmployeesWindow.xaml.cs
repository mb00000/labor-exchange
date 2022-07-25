using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;
using Labor_Exchange.Infrastructure.ApplicationContext;
using Microsoft.Win32;
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

        private readonly IWorkOfferServices _workOfferServices;

        private PagedList<WorkOffer> _workOffers = new();

        private PageParameters _workOffersPageParameters = new();

        private PageParameters _employeePageParameters = new();

        private PagedList<Employee> _employees = new();

        public EmployeesWindow(IEmployeeServices employeeServices, IWorkOfferServices workOfferServices)
        {
            this._employeeServices = employeeServices;
            this._workOfferServices = workOfferServices;

            var context = new EFContext();

            InitializeComponent();
            new Action(async () => await this.SetPage(1))();
            this.Employees.ItemsSource = this._employees;
            this.Searched.ItemsSource = this._workOffers;
        }

        private async Task SetPage(int pageNumber)
        {
            this._employeePageParameters.PageNumber = pageNumber;
            this._employees = await this._employeeServices.GetEmployeesPageAsync(this._employeePageParameters);
            this.Employees.ItemsSource = this._employees;
        }

        private async void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employeeId = Convert.ToInt32((sender as Button)?.Tag);
            await this._employeeServices.RemoveByIdAsync(employeeId);
            await this.SetPage(this._employeePageParameters.PageNumber);
            this.RefreshGrid();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var newEmployee = new Employee
            {
                Name = this.Name.Text,
                Profession = this.Profession.Text,
                Education = this.Education.Text,
                LastWork = this.LastWork.Text,
                ReasonOfDismisal = this.ReasonOfDismisal.Text,
                MartialStatus = this.MartialStatus.Text,
                Housing = this.Housing.Text,
                Contacts = this.Contacts.Text,
                Requirements = this.Requirements.Text,
            };
            this._employeeServices.AddEmployee(newEmployee);
            this._employees.Add(newEmployee);
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

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            this._employeePageParameters.PageNumber = 1;
            this._employees = await this._employeeServices.GetEmployeesPageAsync(this._employeePageParameters, this.EmployeeSearch.Text, 1);
            this.Employees.ItemsSource = this._employees;
        }

        private async void GeneratePdf_Click(object sender, RoutedEventArgs e)
        {
            if (_employees.Count > 0)
            {
                var employeeId = Convert.ToInt32((sender as Button)?.Tag);
                var saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF (*.pdf)|*.pdf";
                if (saveDialog.ShowDialog() == true)
                {
                    var path = System.IO.Path.GetFullPath(saveDialog.FileName);
                    await this._employeeServices.GenerateEmployeesPDF(path, employeeId);
                }
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await this._employeeServices.SaveChangesAsync();
            await this._workOfferServices.SaveChangesAsync();
        }

        private async void SearchWorkOffers_Click(object sender, RoutedEventArgs e)
        {
            int employeeId = Convert.ToInt32((sender as Button)?.Tag);
            var employee = await this._employeeServices.GetOneAsync(employeeId);
            this._workOffersPageParameters.PageSize = await this._workOfferServices.GetWorkOffersCount();
            this._workOffers = await this._workOfferServices.GetWorkOffersPageAsync(_workOffersPageParameters, employee.Profession, 0);
            this.Searched.ItemsSource = this._workOffers;
        }

        private async void GeneratePdfWorkOffer_Click(object sender, RoutedEventArgs e)
        {
            if (_workOffers.Count > 0)
            {
                var workOfferId = Convert.ToInt32((sender as Button)?.Tag);
                var saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF (*.pdf)|*.pdf";
                if (saveDialog.ShowDialog() == true)
                {
                    var path = System.IO.Path.GetFullPath(saveDialog.FileName);
                    await this._workOfferServices.GenerateWorkOffersPDF(path, workOfferId);
                }
            }
        }
    }
}
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
    /// Interaction logic for WorkOffersWindow.xaml
    /// </summary>
    public partial class WorkOffersWindow : Window
    {
        private readonly IWorkOfferServices _workOfferServices;

        private PageParameters _workOfferPageParameters = new();

        private PagedList<WorkOffer> _workOffers = new();

        private readonly IEmployeeServices _employeeServices;

        private PageParameters _employeePegeParameters = new();

        private PagedList<Employee> _employees = new();

        public WorkOffersWindow(IWorkOfferServices workOfferServices, IEmployeeServices employeeServices)
        {
            this._workOfferServices = workOfferServices;
            this._employeeServices = employeeServices;

            EFContext context = new EFContext();
            InitializeComponent();

            new Action(async () => await this.SetPage(1))();
            this.WorkOffers.ItemsSource = this._workOffers;
        }

        private async Task SetPage(int pageNumber)
        {
            this._workOfferPageParameters.PageNumber = pageNumber;
            this._workOffers = await this._workOfferServices.GetWorkOffersPageAsync(this._workOfferPageParameters, false);
            this.WorkOffers.ItemsSource = this._workOffers;
        }

        private void AddWorkOffer_Click(object sender, RoutedEventArgs e)
        {
            var newWorkOffer = new WorkOffer
            {
                Company = this.Company.Text,
                Position = this.Position.Text,
                Conditions = this.Conditions.Text,
                Housing = this.Housing.Text,
                Requirements = this.Requirements.Text,
                Contacts = this.Contacts.Text,
            };
            this._workOfferServices.AddWorkOffer(newWorkOffer);
            this._workOffers.Add(newWorkOffer);
            this.RefreshGrid();
        }

        private void RefreshGrid()
        {
            this.WorkOffers.Items.Refresh();
        }

        private async void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (this._workOffers.PageNumber < this._workOffers.TotalItems)
            {
                await this.SetPage(this._workOffers.PageNumber + 1);
            }
        }

        private async void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (this._workOffers.PageNumber > 1)
            {
                await this.SetPage(this._workOffers.PageNumber - 1);
            }
        }

        private async void DeleteWorkOffer_Click(object sender, RoutedEventArgs e)
        {
            var workOfferId = Convert.ToInt32((sender as Button)?.Tag);
            await this._workOfferServices.RemoveByIdAsync(workOfferId);
            await this.SetPage(this._workOfferPageParameters.PageNumber);
            this.RefreshGrid();
        }

        private async void AddToStorage_Click(object sender, RoutedEventArgs e)
        {
            var workOfferId = Convert.ToInt32((sender as Button)?.Tag);
            await this._workOfferServices.ChangeStoragedStatus(workOfferId);
            await this.SetPage(_workOfferPageParameters.PageNumber);
        }

        private async void WorkOfferSearch_Click(object sender, RoutedEventArgs e)
        {
            this._workOfferPageParameters.PageNumber = 1;
            this._workOffers = await this._workOfferServices.GetWorkOffersPageAsync(this._workOfferPageParameters, this.WorkOfferSearch.Text, 1);
            this.WorkOffers.ItemsSource = this._workOffers;
        }

        private async void GeneratePdf_Click(object sender, RoutedEventArgs e)
        {
            if (_workOffers.Count > 0)
            {
                var workOfferId = Convert.ToInt32((sender as Button)?.Tag);
                var saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF (*.pdf)|*.pdf";
                if (saveDialog.ShowDialog() == true)
                {
                    var path = System.IO.Path.GetFullPath(saveDialog.FileName);
                    await this._workOfferServices.GenerateWorkOffersPDF(path,workOfferId);
                }
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await this._workOfferServices.SaveChangesAsync();
            await this._employeeServices.SaveChangesAsync();
        }

        private async void SearchEmployees_Click(object sender, RoutedEventArgs e)
        {
            var workOfferId = Convert.ToInt32((sender as Button)?.Tag);
            var workOffer = await this._workOfferServices.GetOneAsync(workOfferId);
            this._employeePegeParameters.PageSize = await this._employeeServices.GetEmployeesCount();
            this._employees = await this._employeeServices.GetEmployeesPageAsync(_employeePegeParameters, workOffer.Position, 0);
            this.Searched.ItemsSource = this._employees;
        }

        private async void GeneratePdfEmployee_Click(object sender, RoutedEventArgs e)
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
    }
}

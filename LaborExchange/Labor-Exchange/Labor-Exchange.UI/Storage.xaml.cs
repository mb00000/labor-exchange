using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;
using Labor_Exchange.Infrastructure.ApplicationContext;
using Microsoft.Win32;

namespace Labor_Exchange.UI
{
    /// <summary>
    /// Interaction logic for Storage.xaml
    /// </summary>
    public partial class Storage : Window
    {
        private readonly IWorkOfferServices _workOfferServices;

        private PageParameters _pageParameters = new();

        private PagedList<WorkOffer> _workOffers = new();

        public Storage(IWorkOfferServices workOfferServices)
        {
            this._workOfferServices = workOfferServices;

            var context = new EFContext();
            InitializeComponent();

            new Action(async () => await this.SetPage(1))();
            this.StorageGrid.ItemsSource = this._workOffers;
        }

        private async void DeleteWorkOffer_Click(object sender, RoutedEventArgs e)
        {
            var workOfferId = Convert.ToInt32((sender as Button)?.Tag);
            await this._workOfferServices.RemoveByIdAsync(workOfferId);
            await this.SetPage(this._pageParameters.PageNumber);
            this.RefreshGrid();
        }

        private async Task SetPage(int pageNumber)
        {
            this._pageParameters.PageNumber = pageNumber;
            this._workOffers = await this._workOfferServices.GetWorkOffersPageAsync(this._pageParameters, true);
            this.StorageGrid.ItemsSource = this._workOffers;
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

        private void RefreshGrid()
        {
            this.StorageGrid.Items.Refresh();
        }

        private async void StorageSearch_Click(object sender, RoutedEventArgs e)
        {
            this._pageParameters.PageNumber = 1;
            this._workOffers = await this._workOfferServices.GetWorkOffersPageAsync(this._pageParameters, this.SearchParameter.Text, 1);
            this.StorageGrid.ItemsSource = this._workOffers;
        }

        private async void DeleteFromStorage_Click(object sender, RoutedEventArgs e)
        {
            var workOfferId = Convert.ToInt32((sender as Button)?.Tag);
            await this._workOfferServices.ChangeStoragedStatus(workOfferId);
            await this.SetPage(_pageParameters.PageNumber);
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
                    await this._workOfferServices.GenerateWorkOffersPDF(path, workOfferId);
                }
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await this._workOfferServices.SaveChangesAsync();
        }
    }
}

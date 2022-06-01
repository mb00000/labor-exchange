using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;
using Labor_Exchange.Infrastructure.ApplicationContext;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Labor_Exchange.UI
{
    /// <summary>
    /// Interaction logic for WorkOffersWindow.xaml
    /// </summary>
    public partial class WorkOffersWindow : Window
    {
        private readonly IWorkOfferServices _workOfferServices;

        private PageParameters _pageParameters = new();

        private PagedList<WorkOffer> _workOffers = new();

        public WorkOffersWindow(IWorkOfferServices workOfferServices)
        {
            this._workOfferServices = workOfferServices;

            EFContext context = new EFContext();
            InitializeComponent();

            new Action(async () => await this.SetPage(1))();
            this.WorkOffers.ItemsSource = this._workOffers;
        }

        private async Task SetPage(int pageNumber)
        {
            this._pageParameters.PageNumber = pageNumber;
            this._workOffers = await this._workOfferServices.GetWorkOffersPageAsync(this._pageParameters);
            this.WorkOffers.ItemsSource = this._workOffers;
        }
    }
}

using System.Threading.Tasks;
using System.Windows;
using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;
using Labor_Exchange.Infrastructure.DataInitialaizer;
using Labor_Exchange.Infrastructure.ApplicationContext;


namespace Labor_Exchange.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IItemsServices _itemsService;

        private PageParameters _pageParameters = new();

        private PagedList<EntityBase> _items = new();

        public MainWindow(IItemsServices itemsService)
        {
            this._itemsService = itemsService;

            var context = new EFContext();
            DBInitialaizer.Initialize(context);

            InitializeComponent();
        }

        private async Task SetPage(int pageNumber)
        {
            this._pageParameters.PageNumber = pageNumber;
            this._items = await this._itemsService.GetEntitiesPageAsync(this._pageParameters);
        }

        private async Task Search(int pageNumber)
        {
            this._pageParameters.PageNumber = pageNumber;
            this._items = await this._itemsService.GetEntitiesPageAsync(this._pageParameters, this._items[_items.Count].Id);
        }

        private void Add(object sender, RoutedEventArgs e)
        {

        }
        
        private void EmployeesTable(object sender, RoutedEventArgs e)
        {
            var employeesWindow = new EmployeesWindow(_itemsService);
            employeesWindow.Show();
        }

        private void WorkOffersTable(object sender, RoutedEventArgs e)
        {
            var workOffersWindow = new WorkOffersWindow();
            workOffersWindow.Show();
        }

        private void CreateCompany(object sender, RoutedEventArgs e)
        {
            var createCompanyWindow = new CreateCompanyWindow();
            createCompanyWindow.Show();
        }

        private void CreateEmployee(object sender, RoutedEventArgs e)
        {
            var createEmployeeWindow = new CreateEmployeeWindow();
            createEmployeeWindow.Show();
        }
    }
}

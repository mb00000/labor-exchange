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
        private readonly IEmployeeServices _employeeServices;

        private readonly IWorkOfferServices _workOfferServices;


        public MainWindow(IEmployeeServices employeeServices)
        {
            this._employeeServices = employeeServices;

            var context = new EFContext();
            DBInitialaizer.Initialize(context);

            InitializeComponent();
        }

        private void EmployeesTable(object sender, RoutedEventArgs e)
        {
            var employeesWindow = new EmployeesWindow(this._employeeServices);
            employeesWindow.Show();
        }

        private void WorkOffersTable(object sender, RoutedEventArgs e)
        {
            var workOffersWindow = new WorkOffersWindow(_workOfferServices);
            workOffersWindow.Show();
        }

        private void CreateCompany(object sender, RoutedEventArgs e)
        {
            var createCompanyWindow = new CreateCompanyWindow();
            createCompanyWindow.Show();
        }
    }
}

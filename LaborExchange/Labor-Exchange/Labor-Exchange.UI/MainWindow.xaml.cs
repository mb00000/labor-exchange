using System.Windows;
using Labor_Exchange.Application.IServices;
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

        public MainWindow(IEmployeeServices employeeServices, IWorkOfferServices workOfferServices)
        {
            this._workOfferServices = workOfferServices;
            this._employeeServices = employeeServices;

            var context = new EFContext();
            //DBInitialaizer.Initialize(context);

            InitializeComponent();
        }

        private void EmployeesTable(object sender, RoutedEventArgs e)
        {
            var employeesWindow = new EmployeesWindow(this._employeeServices, this._workOfferServices);
            employeesWindow.Show();
        }

        private void WorkOffersTable(object sender, RoutedEventArgs e)
        {
            var workOffersWindow = new WorkOffersWindow(this._workOfferServices, this._employeeServices);
            workOffersWindow.Show();
        }

        private void Storage_Click(object sender, RoutedEventArgs e)
        {
            var storage = new Storage(_workOfferServices);
            storage.Show();
        }
    }
}
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;
using Labor_Exchange.Infrastructure.DataInitialaizer;
using Labor_Exchange.Infrastructure.ApplicationContext;
using System.IO;
using Microsoft.Win32;

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
            //new Action(async () => await this.SetPage(1))();
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

        private void WorkOffersTable(object sender, RoutedEventArgs e)
        {

        }

        private void EmployeesTable(object sender, RoutedEventArgs e)
        {

        }

        private void CreateEmployee(object sender, RoutedEventArgs e)
        {

        }

        private void CreateCompany(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

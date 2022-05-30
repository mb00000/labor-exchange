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
        private readonly IItemsServices _itemsService;

        private PageParameters _pageParameters = new();

        private PagedList<EntityBase> _items = new();
        public EmployeesWindow(IItemsServices itemsService)
        {
            this._itemsService = itemsService;

            var context = new EFContext();

            InitializeComponent();
            new Action(async () => await this.SetPage(1))();
            this.Employees.ItemsSource = this._items;
        }

        private async Task SetPage(int pageNumber)
        {
            this._pageParameters.PageNumber = pageNumber;
            this._items = await this._itemsService.GetEntitiesPageAsync(this._pageParameters);
            this.Employees.ItemsSource = this._items;
        }
    }
}

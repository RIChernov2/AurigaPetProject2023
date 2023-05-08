using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.UIviaWPF.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AurigaPetProject2023.UIviaWPF.Windows
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();

            //_model = new ManagerPropertyViewModel();
            _model = new ManagerViewModel();
            this.DataContext = _model;

            productTypeManagement.DataContext = _model.ManagerPropertyViewModel;
            addProductControl.DataContext = _model.ManagerAddProductViewModel;

            //mainTabControl.SelectedItem = tabSecond;
        }
        private ManagerViewModel _model;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _model.ManagerPropertyViewModel.LoadProductTypesCommand.Execute(null);
            //productTypesDataGrid.ItemsSource = _model.ProductTypes;
            
        }

        private void mainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tab = (TabControl)sender;
            if((TabItem)tab.SelectedItem == newProductTab)
            {
                if(_model.ManagerPropertyViewModel.ProductTypes == null || _model.ManagerPropertyViewModel.ProductTypes.Count == 0)
                {
                    _model.ManagerPropertyViewModel.LoadProductTypesCommand.Execute(null);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ProductManager(unitOfWork);
                List <Product> list = manager.GetAll();
            }
        }
    }
}

using AurigaPetProject2023.UIviaWPF.ViewModels;
using System.Windows;
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
        }
        private ManagerViewModel _model;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _model.ManagerPropertyViewModel.LoadProductTypesCommand.Execute(null);
            //productTypesDataGrid.ItemsSource = _model.ProductTypes;
            
        }
    }
}

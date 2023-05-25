using System.Windows;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.ViewModels;

namespace AurigaPetProject2023.UIviaWPF.Windows
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow(IUserResponseInfo userInfo)
        {
            InitializeComponent();

            _model = new UserViewModel();
            _model.SetUserInfo(userInfo);
            this.DataContext = _model;
        }

        UserViewModel _model;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _model.LoadRentItemsCommand.Execute(null);
        }
    }
}

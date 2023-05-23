using AurigaPetProject2023.DataAccess.Helpers;
using AurigaPetProject2023.UIviaWPF.ViewModels;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace AurigaPetProject2023.UIviaWPF.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //loginTextBox.Text = "Manager";
            //passwordBox.Password = "123";

            //loginTextBox.Text = "User1";
            loginTextBox.Text = "+79267654321";
            passwordBox.Password = "111";

            statusLabel.Visibility = Visibility.Hidden;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((MainWindowViewModel)DataContext).ShowMouseDownCommand.Execute(null);
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ((MainWindowViewModel)DataContext).ShowMouseUpCommand.Execute(null);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateBaseHelper.RunStartMigration();
            migrationButton.Background = new SolidColorBrush(Colors.LightGreen);
        }
    }
}

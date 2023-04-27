using AurigaPetProject2023.UIviaWPF.ViewModels;
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

namespace AurigaPetProject2023.UIviaWPF.Widows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            loginTextBox.Text = "Manager";
            passwordBox.Password = "123";
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
    }
}

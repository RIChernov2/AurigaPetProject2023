using System;
using System.ComponentModel;
using System.Windows;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using AurigaPetProject2023.UIviaWPF.Windows;
using CommunityToolkit.Mvvm.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class MainWindowViewModel : BaseModel
    {
        public MainWindowViewModel()
        {
            _model = new MainWindowModel();
            LoginCommand = new RelayCommand(Login);
            ShowMouseDownCommand = new RelayCommand(MouseDown);
            ShowMouseUpCommand = new RelayCommand(MouseUp);

        }
        private MainWindowModel _model;
        public string LoginName
        {
            get { return _model.LoginName; }
            set
            {
                _model.LoginName = value;
                OnPropertyChanged(nameof(LoginName));
            }
        }
        public string Password
        {
            get { return _model.Password; }
            set
            {
                _model.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public RelayCommand LoginCommand { get; private set; }
        public RelayCommand ShowMouseDownCommand { get; private set; }
        public RelayCommand ShowMouseUpCommand { get; private set; }

        private MainWindow _window => (MainWindow)Application.Current.MainWindow;
        private void Login()
        {
            _window.statusLabel.Visibility = Visibility.Hidden;
            Password = _window.passwordBox.Password;
            IUserLoginResponseInfo responseInfo = _model.Login();

            if (responseInfo == null)
            {
                _window.statusLabel.Visibility = Visibility.Visible;
            }
            else
            {
                _window.statusLabel.Visibility = Visibility.Hidden;
                RunApplicationWindow(_window, responseInfo);
            }
        }
        private void RunApplicationWindow(MainWindow window, IUserLoginResponseInfo user)
        {
            if (user.Roles.Contains(1) || user.Roles.Contains(2))
            {
                ManagerWindow managerWindow = new ManagerWindow();

                managerWindow.Closed += (sender, e) => window.Close();
                window.Hide();
                managerWindow.Show();
            }
            else if (user.Roles.Contains(3))
            {
                UserWindow managerWindow = new UserWindow();

                managerWindow.Closed += (sender, e) => window.Close();
                window.Hide();
                managerWindow.Show();
            }
            else
            {
                throw new Exception("Ошибка определения ролей");
            }
        }

        private void MouseDown()
        {
            _window.passwordShowingTextBox.Text = _window.passwordBox.Password;
            _window.passwordBox.Visibility = Visibility.Hidden;
            _window.passwordShowingTextBox.Visibility = Visibility.Visible;
        }

        private void MouseUp()
        {
            _window.passwordShowingTextBox.Text = "";
            _window.passwordShowingTextBox.Visibility = Visibility.Hidden;
            _window.passwordBox.Visibility = Visibility.Visible;
        }
    }
}

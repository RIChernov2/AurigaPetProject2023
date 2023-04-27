using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.DataAccess.Repositories.DbRepositories;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UI.Entities;
using AurigaPetProject2023.UI.Forms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurigaPetProject2023.UI
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();

            statusLabel.Visible = false;
            statusLabel.Text = "Пользователя не найдено, проверьте верность введенных данных";
            statusLabel.ForeColor = System.Drawing.Color.Red;

        }

        // автоматический ввод логина пароля
        private void StartWindow_Shown(object sender, EventArgs e)
        {
            // автоматический ввод логина пароля
            loginTextBox.Text = "manager";
            passwordTextBox.Text = "123";
            //loginButton.PerformClick();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            statusLabel.Visible = false;

            IUserLoginResponseInfo user;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                UsersStorageManager repository = new UsersStorageManager(unitOfWork);
                UserLoginInfo loginInfo = new UserLoginInfo(loginTextBox.Text, passwordTextBox.Text);
                //user = await repository.GetUserForLoginAsync(loginInfo)

                var task = Task.Run(async () => await repository.GetUserForLoginAsync(loginInfo)) ;
                task.Wait();
                user = task.Result;
            }

            if(user == null)
            {
                statusLabel.Visible = true;
            }
            else
            {
                statusLabel.Visible = false;
                RunApplicationWindow(user);
            }

            this.ActiveControl = null;
        }
        private void RunApplicationWindow(IUserLoginResponseInfo user)
        {
            if(user.Roles.Contains(1) || user.Roles.Contains(2))
            {
                //using (ManagerWindowWF form = new ManagerWindowWF())
                //{
                //    this.Hide();
                //    form.ShowDialog();
                //    this.Close();
                //}

                ManagerWindow managerWindow = new ManagerWindow();

                managerWindow.Closed += (sender, e) => this.Close();
                this.Hide();
                managerWindow.Show();
            }
            else if (user.Roles.Contains(3))
            {
                using (UserWindowWF form = new UserWindowWF())
                {
                    this.Hide();
                    form.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                throw new Exception("Ошибка определения ролей");
            }
        }
        private void showPasswordLabel_MouseDown(object sender, MouseEventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = false;
        }
        private void showPasswordLabel_MouseUp(object sender, MouseEventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void showPasswordLabel_Click(object sender, EventArgs e)
        {

        }
    }
}


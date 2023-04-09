using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurigaPetProject2023.UI
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 15; i++)
            //{
            //    Debug.WriteLine(HashHelper.GetHash("123")); 
            //}
            //return;
            
            User user = HashHelper.GetUser(loginTextBox.Text, passwordTextBox.Text);
            if(user == null)
            {
                statusLabel.Text = "Пользователя не найдено";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                statusLabel.ForeColor = System.Drawing.Color.Green;
                if (user.IsManager)
                {
                    statusLabel.Text = "Пользователь - менеджер";
                }
                else statusLabel.Text = "Пользователя - обычный пользователь";
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

        
    }
}

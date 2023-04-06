using AurigaPetProject2023.DataAccess.Helpers;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartMigration_Click(object sender, EventArgs e)
        {
            DateBaseHelper.RunStartMigration();
        }
    }
}

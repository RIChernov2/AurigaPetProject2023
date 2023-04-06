using System;
using AurigaPetProject2023.DataAccess.Helpers;
using AurigaPetProject2023.DataAccess.Repositories;
using AurigaPetProject2023.DataAccess.Repositories.DbRepositories;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using AurigaPetProject2023.DataAccess.Entities;
using System.Diagnostics;

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

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                var task1 = Task.Run(MyTest);
                //var task1 = MyTest();
                Task.WaitAll(task1);
            }
            catch (AggregateException ex)
            {
                Debug.WriteLine("------------------============-----------");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("------------------============-----------");
            }



            //}

        }

        private async Task  MyTest()
        {
            using (NewContext context = new NewContext())
            {
                ProductTypeRepository repository = new ProductTypeRepository(context);

                //Task<IReadOnlyList<ProductType>> a  = repository.GetAsync();

                var list = await repository.GetAsync();
                foreach (var item in list)
                {
                    Debug.WriteLine($"{item.ProductTypeID} - {item.Name} - {item.IsUnique}");
                }

                ProductType type1 = new ProductType() { Name = "Маска", IsUnique = false };
                ProductType type2 = new ProductType() { ProductTypeID = 10, Name = "Стул", IsUnique = false };

                var task1 = repository.CreateAsync(type1);
                Task.WaitAll(task1);

                var task2 = repository.CreateAsync(type2);
                Task.WaitAll(task2);
            }

        }


    }
}

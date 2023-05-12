using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AurigaPetProject2023.UIviaWPF.Windows.Controls
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddItem : UserControl
    {
        public AddItem()
        {
            InitializeComponent();
        }

    }
}



// private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        ManagerAddItemViewModel viewModel = (ManagerAddItemViewModel)this.DataContext;
        //        Item newItem = new Item();
        //        newItem.ItemTypeID = viewModel.NewItemSelectedType.ItemTypeID;
        //        newItem.Description = viewModel.NewItemDescription;

//        using (UnitOfWork unitOfWork = new UnitOfWork())
//        {
//            var manager = new ItemStorageManager(unitOfWork);
//            //List<Item> list = manager.GetAll();

//            //Item newItem = new Item();
//            //newItem.ItemTypeID = 7;
//            //newItem.Description = "Супер мешок";

//            manager.Create(newItem);
//        }
//    }
//    catch (Exception exc)
//    {

//        MessageBox.Show("Не удалось добавить оборудование. Тест ошибки:" 
//            + Environment.NewLine + exc.Message
//            + "Inner Exception Message:" + Environment.NewLine + exc.InnerException.InnerException.Message);
//    }


//}

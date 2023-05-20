using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.UIviaWPF.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            _model = new ManagerViewModels();
            this.DataContext = _model;

            itemTypeManagement.DataContext = _model.ManagerItemPropertyViewModel;
            addItemControl.DataContext = _model.ManagerAddItemViewModel;

            //mainTabControl.SelectedItem = tabSecond;
        }
        private ManagerViewModels _model;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _model.ManagerItemPropertyViewModel.LoadItemTypesCommand.Execute(null);
            //productTypesDataGrid.ItemsSource = _model.ProductTypes;
            
        }

        private void mainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // короче тут похоже вот эта туннельность событий работает, надо убедиться, что не datadrid вызвала
            // а вобще это конечно шляпа мб? ну то есть нужно ли это пытаться ставить на смену складки, или просто подгрузить?
            if (e.Source is not TabControl)
            {
                return;
            }

            TabControl tab = (TabControl)sender;
            if((TabItem)tab.SelectedItem == newItemTab)
            {
                //if(_model.ManagerItemPropertyViewModel.ItemTypes == null || _model.ManagerItemPropertyViewModel.ItemTypes.Count == 0)
                if(!_model.ManagerItemPropertyViewModel.ItemTypesIsLoaded)
                {
                    _model.ManagerItemPropertyViewModel.LoadItemTypesCommand.Execute(null);
                }
            }
            else if ((TabItem)tab.SelectedItem == disabledItemTab)
            {
                if (!_model.ManagerDisableViewModel.ItemsIsLoaded)
                {
                    _model.ManagerDisableViewModel.LoadItemsCommand.Execute(null);
                }
            }
            else if ((TabItem)tab.SelectedItem == repeirItemTab)
            {
                if (!_model.ManagerRepairItemViewModel.ItemsIsLoaded)
                {
                    _model.ManagerRepairItemViewModel.LoadItemsCommand.Execute(null);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //using (UnitOfWork unitOfWork = new UnitOfWork())
            //{
            //    var manager = new ItemStorageManager(unitOfWork);
            //    List <Item> list = manager.GetAll();
            //}


            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemStorageManager(unitOfWork);
                //List<Item> list = manager.GetAll();
                //List<ItemWithStatus> list2 = manager.GetItemsWithStatus();

                //foreach (var item in list2)
                //{
                //    Debug.WriteLine(item);
                //}

                //foreach (var item in list2.Where(x => x.InRent || x.InRepair || x.Disabled))
                //{
                //    Debug.WriteLine(item);
                //}

                List<ItemWithDisableInfo> list3 = manager.GetDisabled();
                List<Item> list4 = manager.GetAvailiable();
                //List<Item> list4 = manager.GetNotDisabledAsync();


                //Item newItem = new Item();
                //newItem.ItemTypeID = 7;
                //newItem.Description = "Супер мешок";

                //manager.Create(newItem);
            }
        }


    }
}

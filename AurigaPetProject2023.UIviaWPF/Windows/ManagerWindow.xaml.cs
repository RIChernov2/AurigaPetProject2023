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
        }


        private void mainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // короче тут похоже вот эта туннельность событий работает, надо убедиться, что не datadrid вызвала
            // а вобще это конечно шляпа мб? ну то есть нужно ли это пытаться ставить на смену складки, или просто подгрузить?
            if (e.Source is not TabControl)
            {
                return;
            }

            ManagerViewModels _model = (ManagerViewModels)this.DataContext;


            TabControl tab = (TabControl)sender;
            if((TabItem)tab.SelectedItem == rentTab)
            {
                if (!_model.ManagerRentItemViewModel.AvaliableItemsIsLoaded)
                {
                    _model.ManagerRentItemViewModel.LoadAvaliableItemsCommand.Execute(null);
                }

                if (!_model.ManagerRentItemViewModel.UsersIsLoaded)
                {
                    _model.ManagerRentItemViewModel.LoadUsersCommand.Execute(null);
                }
            }
            else if ((TabItem)tab.SelectedItem == repairItemTab)
            {
                if (!_model.ManagerRepairItemViewModel.AvaliableItemsIsLoaded)
                {
                    _model.ManagerRepairItemViewModel.LoadAvaliableItemsCommand.Execute(null);
                }

                if (!_model.ManagerRepairItemViewModel.RepairingItemsIsLoaded)
                {
                    _model.ManagerRepairItemViewModel.LoadRepairItemsCommand.Execute(null);
                }
            }
            else if ((TabItem)tab.SelectedItem == disabledItemTab)
            {
                if (!_model.ManagerDisableViewModel.AvaliableItemsIsLoaded)
                {
                    _model.ManagerDisableViewModel.LoadAvaliableItemsCommand.Execute(null);
                }

                if (!_model.ManagerDisableViewModel.DisabledItemsIsLoaded)
                {
                    _model.ManagerDisableViewModel.LoadDisableItemsCommand.Execute(null);
                }

            }
            else if ((TabItem)tab.SelectedItem == newItemTab)
            {
                if (!_model.ManagerItemPropertyViewModel.ItemTypesIsLoaded)
                {
                    _model.ManagerItemPropertyViewModel.LoadItemTypesCommand.Execute(null);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }


    }
}

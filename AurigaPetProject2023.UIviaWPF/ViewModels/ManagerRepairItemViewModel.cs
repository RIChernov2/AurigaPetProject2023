using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerRepairItemViewModel : BaseModel, INotifyPropertyChanged
    {
        public ManagerRepairItemViewModel()
        {
            _model = ManagerRepairItemModel.GetInstance();

            LoadItemsCommand = new RelayCommand(_model.LoadItems);
        }
        private ManagerRepairItemModel _model;
        public bool ItemsIsLoaded
        {
            get { return _model.ItemsIsLoaded; }
            set
            {
                _model.ItemsIsLoaded = value;
                OnPropertyChanged(nameof(ItemsIsLoaded));
            }
        }

        public BindingList<ItemWithRepairingInfoInfo> RepairingItems => _model.RepairingItems;
        public ItemWithRepairingInfoInfo SelectedRepairingItem
        {
            get { return _model.SelectedRepairingItem; }
            set
            {
                _model.SelectedRepairingItem = value;
                OnPropertyChanged(nameof(SelectedRepairingItem));
            }
        }


        public ICommand LoadItemsCommand { get; }
    }
}

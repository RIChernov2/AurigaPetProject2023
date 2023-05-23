using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerItemPropertyViewModel : BaseModel
    {
        //public ManagerItemPropertyViewModel ()
        //{
        //    //_model = ManagerModel.GetInstance();
        //}
        public ManagerItemPropertyViewModel ()
        {
            _model = ManagerItemTypeModel.GetInstance();

            LoadItemTypesCommand = new RelayCommand(LoadItemTypes);
            AddItemTypeCommand = new RelayCommand(AddItemType);
            UpdateItemTypeCommand = new RelayCommand(UpdateItemType);
            DeleteItemTypeCommand = new RelayCommand(DeleteItemType);

            _newItemType = new ItemType();


            // подписываемся на события в модели
            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private ManagerItemTypeModel _model;

        public BindingList<ItemType> ItemTypes => _model.ItemTypes;


        public bool ItemTypesIsLoaded
        {
            get { return _model.ItemTypesIsLoaded; }
            set
            {
                _model.ItemTypesIsLoaded = value;
                OnPropertyChanged(nameof(ItemTypesIsLoaded));
            }
        }
        public string NewItemTypeName
        {
            get { return _model.NewItemTypeName; }
            set
            {
                _model.NewItemTypeName = value;
                OnPropertyChanged(nameof(NewItemTypeName));
            }
        }
        public bool NewItemTypeIsUnique
        {
            get { return _model.NewItemTypeIsUnique; }
            set
            {
                _model.NewItemTypeIsUnique = value;
                OnPropertyChanged(nameof(NewItemTypeIsUnique));
            }
        }



        public LabelInfo NewItemTypeStatusInfo
        {
            get { return _model.NewItemTypeStatusInfo; }
            set
            {
                _model.NewItemTypeStatusInfo = value;
                OnPropertyChanged(nameof(NewItemTypeStatusInfo));
            }
        }


        public ItemType SelectedItemType
        {
            get { return _selectedItemType; }
            set
            {
                _selectedItemType = value;
                OnPropertyChanged(nameof(SelectedItemType));
            }
        }
        private ItemType _selectedItemType;
        private ItemType _newItemType;
        public ItemType NewItemType { set => _newItemType = value; }



        public ICommand LoadItemTypesCommand { get; }

        private void LoadItemTypes() => _model.LoadItemTypes();
        public ICommand AddItemTypeCommand { get; }
        private void AddItemType() => _model.AddItemType();
        public ICommand UpdateItemTypeCommand { get; }

        private void UpdateItemType()
        {
            if (SelectedItemType == null) return;

            if (MessageBox.Show("Вы уверены, что хотите изменить данный элэмент?" +
                $"{Environment.NewLine}{Environment.NewLine}Текущее значение:" +
                $"{Environment.NewLine}{SelectedItemType}" +
                $"{Environment.NewLine}{Environment.NewLine}Новое значение:" +
                $"{Environment.NewLine}{_newItemType}",
                "Подтверждение удаления",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _model.UpdateProductType(_newItemType);
                //LoadItemTypes();
            }
        }

        public ICommand DeleteItemTypeCommand { get; }

        private void DeleteItemType()
        {
            if (SelectedItemType == null) return;

            // проверка стоит здесь, а не в модели, так как тестировал, что будет, если не завязывать свойство на модель
            // ну то есть SelectedItemType нет в модеи, чтобы его отобразить в контекстном меню
            if (MessageBox.Show("Вы уверены, что хотите удалить данный элэмент:" +
                $"{Environment.NewLine}{Environment.NewLine}{SelectedItemType}",
                "Подтверждение удаления",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _model.DeleteItemType(SelectedItemType.ItemTypeID);
            }
        }

    }
}

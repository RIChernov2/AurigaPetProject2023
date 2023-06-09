﻿using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerDisableItemViewModel : BaseModel
    {
        public ManagerDisableItemViewModel()
        {
            _model = ManagerDisableItemModel.GetInstance();

            LoadDisableItemsCommand = new RelayCommand(_model.LoadDisabledItems);
            DisableItemCommand = new RelayCommand(_model.DisableItem);

            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private ManagerDisableItemModel _model;
        public bool DisabledItemsIsLoaded
        {
            get { return _model.DisabledItemsIsLoaded; }
            set
            {
                _model.DisabledItemsIsLoaded = value;
                OnPropertyChanged(nameof(DisabledItemsIsLoaded));
            }
        }


        public string DisableReason
        {
            get { return _model.DisableReason; }
            set
            {
                _model.DisableReason = value;
                OnPropertyChanged(nameof(DisableReason));
            }
        }
        public LabelInfo DisableOperationStatusInfo
        {
            get { return _model.DisableOperationStatusInfo; }
            set
            {
                _model.DisableOperationStatusInfo = value;
                OnPropertyChanged(nameof(DisableOperationStatusInfo));
            }
        }
        public Item SelectedAvaliableItem
        {
            get { return _model.SelectedAvaliableItem; }
            set
            {
                _model.SelectedAvaliableItem = value;
                OnPropertyChanged(nameof(SelectedAvaliableItem));
            }
        }
        public ItemWithDisableInfo SelectedDisabledItem
        {
            get { return _model.SelectedDisabledItem; }
            set
            {
                _model.SelectedDisabledItem = value;
                OnPropertyChanged(nameof(SelectedDisabledItem));
            }
        }
        public ObservableCollection<Item> AvaliableItems => _model.AvaliableItems;
        public BindingList<ItemWithDisableInfo> DisabledItems => _model.DisabledItems;

        public ICommand LoadDisableItemsCommand { get; }
        public ICommand DisableItemCommand { get; }

    }
}

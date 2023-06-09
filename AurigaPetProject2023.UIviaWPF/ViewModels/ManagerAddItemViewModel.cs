﻿using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerAddItemViewModel : BaseModel
    {

        public ManagerAddItemViewModel()
        {
            _model = ManagerItemTypeModel.GetInstance();
            AddItemCommand = new RelayCommand(AddItem);

            // подписываемся на события в модели
            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private ManagerItemTypeModel _model;

        public BindingList<ItemType> ItemTypes => _model.ItemTypes;

        public string NewItemDescription
        {
            get => _model.NewItemDescription;
            set
            {
                _model.NewItemDescription = value;
                OnPropertyChanged(nameof(NewItemDescription));
            }
        }
        public ItemType NewItemSelectedType
        {
            get => _model.NewItemSelectedType;
            set
            {
                _model.NewItemSelectedType = value;
                OnPropertyChanged(nameof(NewItemSelectedType));
            }
        }


        public ICommand AddItemCommand { get; }
        private void AddItem() => _model.AddItem();


    }
}

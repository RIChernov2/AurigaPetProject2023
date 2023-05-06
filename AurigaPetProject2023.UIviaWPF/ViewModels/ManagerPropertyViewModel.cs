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
    public class ManagerPropertyViewModel: BaseModel, INotifyPropertyChanged
    {
        public ManagerPropertyViewModel()
        {
            _model = new ManagerModel();
        }
        public ManagerPropertyViewModel(ManagerModel model)
        {
            _model = model;

            LoadProductTypesCommand = new RelayCommand(LoadProductTypes);
            AddProductTypeCommand = new RelayCommand(AddProductType);
            UpdateProductTypeCommand = new RelayCommand(UpdateProductType);
            DeleteProductTypeCommand = new RelayCommand(DeleteProductType);

            _newProductType = new ProductType();


            // подписываемся на события в модели
            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private void OnMyModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(e.PropertyName)) OnPropertyChanged(e.PropertyName);
        }

        private ManagerModel _model;

        public BindingList<ProductType> ProductTypes => _model.ProductTypes;


        public bool ProductTypesIsLoaded
        {
            get { return _model.ProductTypesIsLoaded; }
            set
            {
                _model.ProductTypesIsLoaded = value;
                OnPropertyChanged(nameof(ProductTypesIsLoaded));
            }
        }
        public string NewProductTypeName
        {
            get { return _model.NewProductTypeName; }
            set
            {
                _model.NewProductTypeName = value;
                OnPropertyChanged(nameof(NewProductTypeName));
            }
        }
        public bool NewProductTypeIsUnique
        {
            get { return _model.NewProductTypeIsUnique; }
            set
            {
                _model.NewProductTypeIsUnique = value;
                OnPropertyChanged(nameof(NewProductTypeIsUnique));
            }
        }
        public string NewProductTypeStatusText
        {
            get { return _model.NewProductTypeStatusText; }
            set
            {
                _model.NewProductTypeStatusText = value;
                OnPropertyChanged(nameof(NewProductTypeStatusText));
            }
        }
        public Visibility NewProductTypeStatusVisibility
        {
            get { return _model.NewProductTypeStatusVisibility; }
            set
            {
                _model.NewProductTypeStatusVisibility = value;
                OnPropertyChanged(nameof(NewProductTypeStatusVisibility));
            }
        }

        public ProductType SelectedProductType
        {
            get { return _selectedProductType; }
            set
            {
                _selectedProductType = value;
                OnPropertyChanged(nameof(SelectedProductType));
            }
        }
        private ProductType _selectedProductType;
        private ProductType _newProductType;
        public ProductType NewProductType { set => _newProductType = value; }

        public Brush NewProductTypeStatusColor
        {
            get { return _model.NewProductTypeStatusColor; }
            set
            {
                _model.NewProductTypeStatusColor = value;
                OnPropertyChanged(nameof(NewProductTypeStatusColor));
            }
        }

        public ICommand LoadProductTypesCommand { get; }

        private void LoadProductTypes() => _model.LoadProductTypes();
        public ICommand AddProductTypeCommand { get; }
        private void AddProductType() => _model.AddProductType();
        public ICommand UpdateProductTypeCommand { get; }

        private void UpdateProductType()
        {
            if (SelectedProductType == null) return;

            if (MessageBox.Show("Вы уверены, что хотите изменить данный элэмент?" +
                $"{Environment.NewLine}{Environment.NewLine}Текущее значение:" +
                $"{Environment.NewLine}{SelectedProductType}" +
                $"{Environment.NewLine}{Environment.NewLine}Новое значение:" +
                $"{Environment.NewLine}{_newProductType}",
                "Подтверждение удаления",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _model.UpdateProductType(_newProductType);
                LoadProductTypes();
            }
        }

        public ICommand DeleteProductTypeCommand { get; }

        private void DeleteProductType()
        {
            if (SelectedProductType == null) return;
            //Messadialog = new CommonDialog();

            //_model.DeleteProductType(SelectedProductType.ProductTypeID);
            if (MessageBox.Show("Вы уверены, что хотите удалить данный элэмент:" +
                $"{Environment.NewLine}{Environment.NewLine}{SelectedProductType}",
                "Подтверждение удаления",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _model.DeleteProductType(SelectedProductType.ProductTypeID);
                LoadProductTypes();
            }
        }

    }
}

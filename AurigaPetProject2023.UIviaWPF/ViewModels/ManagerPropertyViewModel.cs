using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

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
        public bool NewProductTypeStatusEnable
        {
            get { return _model.NewProductTypeStatusEnable; }
            set
            {
                _model.NewProductTypeStatusEnable = value;
                OnPropertyChanged(nameof(NewProductTypeStatusEnable));
            }
        }




        public ICommand LoadProductTypesCommand { get; }

        private void LoadProductTypes() => _model.LoadProductTypes();
        public ICommand AddProductTypeCommand { get; }
        private void AddProductType() => _model.AddProductType();




    }
}

using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerAddProductViewModel : BaseModel, INotifyPropertyChanged
    {
        public ManagerAddProductViewModel()
        {
            _model = new ManagerModel();
        }
        public ManagerAddProductViewModel(ManagerModel model)
        {
            _model = model;
            AddProductCommand = new RelayCommand(AddProduct);

            // подписываемся на события в модели
            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private ManagerModel _model;
        private void OnMyModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.PropertyName)) OnPropertyChanged(e.PropertyName);
        }


        public BindingList<ProductType> ProductTypes => _model.ProductTypes;

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        private ProductType _selectedProductType;
        public ProductType SelectedProductType
        {
            get => _selectedProductType;
            set
            {
                _selectedProductType = value;
                OnPropertyChanged(nameof(SelectedProductType));
            }
        }
        public LabelInfo NewProductStatusInfo
        {
            get { return _model.NewProductStatusInfo; }
            set
            {
                _model.NewProductStatusInfo = value;
                OnPropertyChanged(nameof(NewProductStatusInfo));
            }
        }


        public ICommand AddProductCommand;
        private void AddProduct()
        {
            //Product product = new Product();
            //product.Description = Description;
            //product.ProductTypeID = SelectedProductType?.ProductTypeID;

            //_model.AddProduct();
        }

    }
}

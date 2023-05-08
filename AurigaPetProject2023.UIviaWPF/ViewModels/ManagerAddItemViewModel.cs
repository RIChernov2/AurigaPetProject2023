using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerAddItemViewModel : BaseModel, INotifyPropertyChanged
    {
        public ManagerAddItemViewModel()
        {
            _model = new ManagerModel();
        }
        public ManagerAddItemViewModel(ManagerModel model)
        {
            _model = model;
            AddItemCommand = new RelayCommand(AddProduct);

            // подписываемся на события в модели
            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private ManagerModel _model;
        private void OnMyModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.PropertyName)) OnPropertyChanged(e.PropertyName);
        }


        public BindingList<ItemType> ItemTypes => _model.ItemTypes;

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
        private ItemType _selectedItemType;
        public ItemType SelectedItemType
        {
            get => _selectedItemType;
            set
            {
                _selectedItemType = value;
                OnPropertyChanged(nameof(SelectedItemType));
            }
        }
        public LabelInfo NewItemStatusInfo
        {
            get { return _model.NewItemStatusInfo; }
            set
            {
                _model.NewItemStatusInfo = value;
                OnPropertyChanged(nameof(NewItemStatusInfo));
            }
        }


        public ICommand AddItemCommand;
        private void AddProduct()
        {
            //Product product = new Product();
            //product.Description = Description;
            //product.ProductTypeID = SelectedProductType?.ProductTypeID;

            //_model.AddProduct();
        }

    }
}

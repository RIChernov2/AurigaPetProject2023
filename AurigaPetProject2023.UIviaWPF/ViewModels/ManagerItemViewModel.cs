using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerItemViewModel:BaseModel
    {
        public ManagerItemViewModel()
        {
            _model = ManagerItemModel.GetInstance();
            LoadAvaliableItemsCommand = new RelayCommand(_model.LoadAvaliableItems);

            // подписываемся на события в модели
            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private ManagerItemModel _model;

        public bool AvaliableItemsIsLoaded
        {
            get { return _model.AvaliableItemsIsLoaded; }
            set
            {
                _model.AvaliableItemsIsLoaded = value;
                OnPropertyChanged(nameof(AvaliableItemsIsLoaded));
            }
        }
        public ICommand LoadAvaliableItemsCommand { get; }
    }
}

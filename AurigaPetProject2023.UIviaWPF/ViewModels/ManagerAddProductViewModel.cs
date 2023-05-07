using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.UIviaWPF.Entities;
using AurigaPetProject2023.UIviaWPF.Models;
using System.ComponentModel;

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

            // подписываемся на события в модели
            _model.PropertyChanged += OnMyModelPropertyChanged;
        }

        private ManagerModel _model;
        private void OnMyModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.PropertyName)) OnPropertyChanged(e.PropertyName);
        }


        public BindingList<ProductType> ProductTypes => _model.ProductTypes;
    }
}

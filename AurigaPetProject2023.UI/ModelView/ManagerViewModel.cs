using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.UI.Models;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;

namespace AurigaPetProject2023.UI.ModelView
{
    public class ManagerViewModel : INotifyPropertyChanged
    {
        public ManagerViewModel()
        {
            // не нужно ли через параметры конструктора перезавать?
            // не нужно ли сделать через интерфейс IManagerModel ?
            _model = new ManagerModel();

            LoadProductTypesCommand = new RelayCommand(LoadProductTypes);
        }
        private ManagerModel _model;

        public BindingList<ProductType> ProductTypes => _model.ProductTypes;

        public ICommand LoadProductTypesCommand { get; }

        private void LoadProductTypes() => _model.LoadProductTypes();

        #region Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

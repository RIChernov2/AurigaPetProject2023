using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.UIviaWPF.Entities;
using System.ComponentModel;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class ManagerItemModel : BaseModel, INotifyPropertyChanged
    {
        private ManagerItemModel()
        {

            AvaliableItems = new BindingList<Item>();
            AvaliableItemsIsLoaded = false;

            DisabledItems = new BindingList<Item>();
            DisabledItemsIsLoaded = false;
        }

        private static ManagerItemModel _model;
        public static ManagerItemModel GetInstance()
        {
            if (_model == null)
            {
                _model = new ManagerItemModel();
            }

            return _model;
        }

        #region AvaliableItems

        public BindingList<Item> AvaliableItems { get; private set; }
        public bool AvaliableItemsIsLoaded
        {
            get { return _avaliableItemsIsLoaded; }
            set
            {
                _avaliableItemsIsLoaded = value;
                OnPropertyChanged(nameof(AvaliableItemsIsLoaded));
            }
        }
        private bool _avaliableItemsIsLoaded;
        public void LoadAvaliableItems()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemStorageManager(unitOfWork);
                var list = manager.GetAvailiable();

                AvaliableItems.Clear();
                foreach (var item in list)
                {
                    AvaliableItems.Add(item);
                }
                AvaliableItemsIsLoaded = true;
            }
        }

        #endregion

        #region DisabledItems
        public BindingList<Item> DisabledItems { get; private set; }

        public bool DisabledItemsIsLoaded
        {
            get { return _disabledItemsIsLoaded; }
            set
            {
                _disabledItemsIsLoaded = value;
                OnPropertyChanged(nameof(DisabledItemsIsLoaded));
            }
        }
        private bool _disabledItemsIsLoaded;

        public void LoadDisabledItems()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemStorageManager(unitOfWork);
                var list = manager.GetAvailiable();

                DisabledItems.Clear();
                foreach (var item in list)
                {
                    DisabledItems.Add(item);
                }
                DisabledItemsIsLoaded = true;
            }
        }

        #endregion
    }
}

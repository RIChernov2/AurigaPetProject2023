using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.UIviaWPF.Entities;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class ManagerModel : BaseModel, INotifyPropertyChanged
    {

        private  ManagerModel()
        {
            ItemTypes = new BindingList<ItemType>();
            ItemTypesIsLoaded = false;
            NewItemTypeStatusInfo = new LabelInfo();
        }

        private static ManagerModel _model;
        public static ManagerModel GetInstance()
        {
            if (_model == null)
            {
                _model = new ManagerModel();
            }

            return _model;
        }

        #region Управление типами товаров #############################################

        public BindingList<ItemType> ItemTypes { get; private set; }
        

        public bool ItemTypesIsLoaded
        {
            get { return _itemTypesIsLoaded; }
            set
            {
                _itemTypesIsLoaded = value;
                OnPropertyChanged(nameof(ItemTypesIsLoaded));
            }
        }
        private bool _itemTypesIsLoaded;

        public string NewItemTypeName
        {
            get { return _newItemTypeName; }
            set
            {
                _newItemTypeName = value;
                OnPropertyChanged(nameof(NewItemTypeName));
            }
        }
        private string _newItemTypeName;

        public bool NewItemTypeIsUnique
        {
            get { return _newItemTypeIsUnique; }
            set
            {
                _newItemTypeIsUnique = value;
                OnPropertyChanged(nameof(NewItemTypeIsUnique));
            }
        }
        private bool _newItemTypeIsUnique;

        public LabelInfo NewItemTypeStatusInfo
        {
            get { return _newItemTypeStatusInfo; }
            set
            {
                _newItemTypeStatusInfo = value;
                OnPropertyChanged(nameof(NewItemTypeStatusInfo));
            }
        }
        private LabelInfo _newItemTypeStatusInfo;

        public void LoadItemTypes()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemTypesStorageManager(unitOfWork);
                var list = manager.GetAll();

                //ProductTypes = new BindingList<ProductType>(list);
                ItemTypes.Clear();
                foreach (var item in list)
                {
                    ItemTypes.Add(item);
                }
                ItemTypesIsLoaded = true;
            }
        }
        public void AddItemType()
        {
            //NewProductTypeStatusVisibility = Visibility.Hidden;


            if (!ItemTypesIsLoaded) return;
            if (string.IsNullOrEmpty(NewItemTypeName))
            {
                ChangeStatusColorAndVisibility(Brushes.Red);
                NewItemTypeStatusInfo.Text = "Нельзя добавить категорию без названия";
                return;
            }

            if (ItemTypes.Select(x => x.Name.ToLower()).Contains(NewItemTypeName.ToLower()))
            {
                //NewProductTypeStatusEnable = true;
                ChangeStatusColorAndVisibility(Brushes.Red);
                NewItemTypeStatusInfo.Text = $"Уже существует категория с названием \"{NewItemTypeName}\"";
                return;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemTypesStorageManager(unitOfWork);
                var result = manager.Create(new ItemType() { Name = NewItemTypeName, IsUnique = NewItemTypeIsUnique });
                LoadItemTypes();
                if (result == 1)
                {
                    ChangeStatusColorAndVisibility(Brushes.Green);
                    NewItemTypeStatusInfo.Text = $"Категория с названием \"{NewItemTypeName}\" успешно добавлена";
                    NewItemTypeName = "";
                    NewItemTypeIsUnique = false;
                }
                else
                {
                    ChangeStatusColorAndVisibility(Brushes.Red);
                    NewItemTypeStatusInfo.Text = $"Ошибка в процессе добавления категории с названием \"{NewItemTypeName}\"";
                }
            }
        }

        private void ChangeStatusColorAndVisibility(Brush color)
        {
            if (NewItemTypeStatusInfo.Color != color)
            {
                NewItemTypeStatusInfo.Color = color;
            }
            NewItemTypeStatusInfo.Visibility = Visibility.Visible;

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 2000; //millisec
            timer.Elapsed += (sender, e) =>
            {
                //MessageBox.Show("Elapsed");
                NewItemTypeStatusInfo.Visibility = Visibility.Hidden;
                timerEnabled = false;
                if (timer != null) timer.Dispose();
            };

            if (!timerEnabled)
            {
                timerEnabled = true;
                timer.Start();
            }

        }
        private bool timerEnabled;

        public void UpdateProductType(ItemType productType)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemTypesStorageManager(unitOfWork);
                var result = manager.Update(productType);
                //LoadItemTypes();
                if (result == 1)
                {
                    MessageBox.Show($"Категория успешно изменения");
                    LoadItemTypes();
                }
                else
                {
                    MessageBox.Show($"Ошибка в процессе изменения категории"); ;
                }
                NewItemTypeStatusInfo.Visibility = Visibility.Hidden;
            }
        }
        public void DeleteItemType(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ItemTypesStorageManager(unitOfWork);
                var result = manager.Delete(id);
                LoadItemTypes();
                if (result == 1)
                {
                    MessageBox.Show($"Категория успешно удалена");
                }
                else
                {
                    MessageBox.Show($"Ошибка в процессе удаления категории");
                }
                NewItemTypeStatusInfo.Visibility = Visibility.Hidden;
            }
        }

        #endregion

        #region управление Item ########################################################

        private string _newItemDescription;
        public string NewItemDescription
        {
            get => _newItemDescription;
            set
            {
                _newItemDescription = value;
                OnPropertyChanged(nameof(NewItemDescription));
            }
        }

        private ItemType _newItemSelectedType;
        public ItemType NewItemSelectedType
        {
            get => _newItemSelectedType;
            set
            {
                _newItemSelectedType = value;
                OnPropertyChanged(nameof(NewItemSelectedType));
            }
        }

        //public LabelInfo NewItemStatusInfo
        //{
        //    get { return _newItemStatusInfo; }
        //    set
        //    {
        //        _newItemStatusInfo = value;
        //        OnPropertyChanged(nameof(NewItemStatusInfo));
        //    }
        //}
        //private LabelInfo _newItemStatusInfo;


        public void AddItem()
        {
            if (!ItemTypesIsLoaded) return;
            if (NewItemSelectedType == null) return;
            if (string.IsNullOrEmpty(NewItemDescription)) return;

            Item newItem = new Item();
            newItem.ItemTypeID = NewItemSelectedType.ItemTypeID;
            newItem.Description = NewItemDescription;
            newItem.ItemType = NewItemSelectedType;

            if (MessageBox.Show("Вы уверены, что хотите давить данный элэмент:" +
                    $"{Environment.NewLine}{Environment.NewLine}{PrintItem(newItem)}",
                    "Подтверждение добавления",
                    MessageBoxButton.YesNo) == MessageBoxResult.No) return;


            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    var manager = new ItemStorageManager(unitOfWork);
                    int result = manager.Create(newItem);
                    string message = result == 1 ? "Оборудование добавлено" : "Ошибка добавления оборудования";
                    MessageBox.Show(message);
                    if(result == 1)
                    {
                        NewItemDescription = "";
                        NewItemSelectedType = null;

                    }
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Не удалось добавить оборудование. Тест ошибки:"
                    + Environment.NewLine + exc.Message
                    + "Inner Exception Message:" + Environment.NewLine + exc.InnerException.InnerException.Message);
            }
        }

        private string PrintItem(Item item)
        {
            string unique = item.ItemType.IsUnique ? "Да" : "Нет";
            return $"Описание \"{item.Description}\"{Environment.NewLine}Уникальный: \"{unique}\"";
        }





        #endregion


    }
}

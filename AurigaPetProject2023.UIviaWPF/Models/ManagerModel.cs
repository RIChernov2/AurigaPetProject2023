using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.UIviaWPF.Entities;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class ManagerModel : BaseModel, INotifyPropertyChanged
    {
        public BindingList<ProductType> ProductTypes { get; private set; }

        public ManagerModel()
        {
            ProductTypes = new BindingList<ProductType>();
            ProductTypesIsLoaded = false;
        }

        #region Управление типами товаров


        public bool ProductTypesIsLoaded
        {
            get { return _productTypesIsLoaded; }
            set
            {
                _productTypesIsLoaded = value;
                OnPropertyChanged(nameof(ProductTypesIsLoaded));
            }
        }
        private bool _productTypesIsLoaded;


        public string NewProductTypeName
        {
            get { return _newProductTypeName; }
            set
            {
                _newProductTypeName = value;
                OnPropertyChanged(nameof(ProductTypesIsLoaded));
            }
        }
        private string _newProductTypeName;

        public bool NewProductTypeIsUnique
        {
            get { return _newProductTypeIsUnique; }
            set
            {
                _newProductTypeIsUnique = value;
                OnPropertyChanged(nameof(ProductTypesIsLoaded));
            }
        }
        private bool _newProductTypeIsUnique;

        public Visibility NewProductTypeStatusVisibility
        {
            get { return _newProductTypeStatusVisibility; }
            set
            {
                _newProductTypeStatusVisibility = value;
                OnPropertyChanged(nameof(NewProductTypeStatusVisibility));
            }
        }
        private Visibility _newProductTypeStatusVisibility;

        public string NewProductTypeStatusText
        {
            get { return _newProductTypeStatusText; }
            set
            {
                _newProductTypeStatusText = value;
                OnPropertyChanged(nameof(NewProductTypeStatusText));
            }
        }
        private string _newProductTypeStatusText;


        public void LoadProductTypes()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ProductTypesStorageManager(unitOfWork);
                var list = manager.GetAll();

                //ProductTypes = new BindingList<ProductType>(list);
                ProductTypes.Clear();
                foreach (var item in list)
                {
                    ProductTypes.Add(item);
                }
                ProductTypesIsLoaded = true;
            }
        }
        public void AddProductType()
        {
            //NewProductTypeStatusVisibility = Visibility.Hidden;


            if (!ProductTypesIsLoaded) return;
            if (string.IsNullOrEmpty(NewProductTypeName))
            {
                ChangeStatusColorAndVisibility(Brushes.Red);
                NewProductTypeStatusText = "Нельзя добавить категорию без названия";
                return;
            }

            if (ProductTypes.Select(x => x.Name.ToLower()).Contains(NewProductTypeName.ToLower()))
            {
                //NewProductTypeStatusEnable = true;
                ChangeStatusColorAndVisibility(Brushes.Red);
                NewProductTypeStatusText = $"Уже существует категория с названием \"{NewProductTypeName}\"";
                return;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ProductTypesStorageManager(unitOfWork);
                var result = manager.Create(new ProductType() { Name = NewProductTypeName, IsUnique = NewProductTypeIsUnique });
                LoadProductTypes();
                if (result == 1)
                {
                    ChangeStatusColorAndVisibility(Brushes.Green);
                    NewProductTypeStatusText = $"Категория с названием \"{NewProductTypeName}\" успешно добавлена";
                }
                else
                {
                    ChangeStatusColorAndVisibility(Brushes.Red);
                    NewProductTypeStatusText = $"Ошибка в процессе добавления категории с названием \"{NewProductTypeName}\"";
                }
            }
        }

        public Brush NewProductTypeStatusColor
        {
            get { return _newProductTypeStatusColor; }
            set
            {
                _newProductTypeStatusColor = value;
                OnPropertyChanged(nameof(NewProductTypeStatusColor));
            }
        }
        private Brush _newProductTypeStatusColor;
        private void ChangeStatusColorAndVisibility(Brush color)
        {
            if (NewProductTypeStatusColor != color)
            {
                NewProductTypeStatusColor = color;
            }
            NewProductTypeStatusVisibility = Visibility.Visible;

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 2000; //millisec
            timer.Elapsed += (sender, e) =>
            {
                //MessageBox.Show("Elapsed");
                NewProductTypeStatusVisibility = Visibility.Hidden;
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

        public void UpdateProductType(ProductType productType)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ProductTypesStorageManager(unitOfWork);
                var result = manager.Update(productType);
                LoadProductTypes();
                if (result == 1)
                {
                    MessageBox.Show($"Категория успешно изменения");
                }
                else
                {
                    MessageBox.Show($"Ошибка в процессе изменения категории"); ;
                }
                NewProductTypeStatusVisibility = Visibility.Hidden;
            }
        }
        public void DeleteProductType(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ProductTypesStorageManager(unitOfWork);
                var result = manager.Delete(id);
                LoadProductTypes();
                if (result == 1)
                {
                    MessageBox.Show($"Категория успешно удалена");
                }
                else
                {
                    MessageBox.Show($"Ошибка в процессе удаления категории");
                }
                NewProductTypeStatusVisibility = Visibility.Hidden;
            }
        }

        #endregion
    }
}

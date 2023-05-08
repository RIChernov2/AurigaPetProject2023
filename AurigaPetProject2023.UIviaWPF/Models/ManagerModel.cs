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
            NewProductTypeStatusInfo = new LabelInfo();
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

        public LabelInfo NewProductTypeStatusInfo
        {
            get { return _newProductTypeStatusInfo; }
            set
            {
                _newProductTypeStatusInfo = value;
                OnPropertyChanged(nameof(ProductTypesIsLoaded));
            }
        }
        private LabelInfo _newProductTypeStatusInfo;

        public LabelInfo NewProductStatusInfo
        {
            get { return _newProductStatusInfo; }
            set
            {
                _newProductStatusInfo = value;
                OnPropertyChanged(nameof(NewProductStatusInfo));
            }
        }
        private LabelInfo _newProductStatusInfo;


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
                NewProductTypeStatusInfo.Text = "Нельзя добавить категорию без названия";
                return;
            }

            if (ProductTypes.Select(x => x.Name.ToLower()).Contains(NewProductTypeName.ToLower()))
            {
                //NewProductTypeStatusEnable = true;
                ChangeStatusColorAndVisibility(Brushes.Red);
                NewProductTypeStatusInfo.Text = $"Уже существует категория с названием \"{NewProductTypeName}\"";
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
                    NewProductTypeStatusInfo.Text = $"Категория с названием \"{NewProductTypeName}\" успешно добавлена";
                }
                else
                {
                    ChangeStatusColorAndVisibility(Brushes.Red);
                    NewProductTypeStatusInfo.Text = $"Ошибка в процессе добавления категории с названием \"{NewProductTypeName}\"";
                }
            }
        }

        public void AddProduct(Product product)
        {
            if (!ProductTypesIsLoaded) return;
        }


        private void ChangeStatusColorAndVisibility(Brush color)
        {
            if (NewProductTypeStatusInfo.Color != color)
            {
                NewProductTypeStatusInfo.Color = color;
            }
            NewProductTypeStatusInfo.Visibility = Visibility.Visible;

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 2000; //millisec
            timer.Elapsed += (sender, e) =>
            {
                //MessageBox.Show("Elapsed");
                NewProductTypeStatusInfo.Visibility = Visibility.Hidden;
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
                NewProductTypeStatusInfo.Visibility = Visibility.Hidden;
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
                NewProductTypeStatusInfo.Visibility = Visibility.Hidden;
            }
        }

        #endregion
    }
}

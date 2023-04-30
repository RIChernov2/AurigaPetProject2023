﻿using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.UIviaWPF.Entities;
using System.ComponentModel;
using System.Linq;
using System.Windows;

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

        public bool NewProductTypeStatusEnable
        {
            get { return _newProductTypeStatusEnable; }
            set
            {
                _newProductTypeStatusEnable = value;
                OnPropertyChanged(nameof(NewProductTypeStatusEnable));
            }
        }
        private bool _newProductTypeStatusEnable;

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
            NewProductTypeStatusEnable = false;


            if (!ProductTypesIsLoaded) return;
            if (string.IsNullOrEmpty(NewProductTypeName))
            {
                NewProductTypeStatusEnable = true;
                NewProductTypeStatusText = "Нельзя добавить категорию без названия";
                return;
            }

            if(ProductTypes.Select(x=>x.Name.ToLower()).Contains(NewProductTypeName.ToLower()))
            {
                NewProductTypeStatusEnable = true;
                NewProductTypeStatusText = $"Уже существует категория с названием \"{NewProductTypeName}\"";
                return;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var manager = new ProductTypesStorageManager(unitOfWork);
                var result = manager.Create(new ProductType() { Name = NewProductTypeName, IsUnique = NewProductTypeIsUnique });
                LoadProductTypes();
                if(result == 1)
                {
                    NewProductTypeStatusText = $"Категория с названием \"{NewProductTypeName}\" успешно добавлена";
                }
                else
                {
                    NewProductTypeStatusText = $"Ошибка в процессе добавления категории с названием \"{NewProductTypeName}\"";
                }
                NewProductTypeStatusEnable = true;
            }
        }

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
                NewProductTypeStatusEnable = true;
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
                    MessageBox.Show ($"Ошибка в процессе удаления категории");
                }
                NewProductTypeStatusEnable = true;
            }
        }

        #endregion
    }
}

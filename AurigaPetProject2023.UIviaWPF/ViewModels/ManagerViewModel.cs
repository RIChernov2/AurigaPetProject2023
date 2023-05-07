using AurigaPetProject2023.UIviaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurigaPetProject2023.UIviaWPF.ViewModels
{
    public class ManagerViewModel
    {
        public ManagerViewModel()
        {
            // не нужно ли через параметры конструктора перезавать?
            // не нужно ли сделать через интерфейс IManagerModel ?
            _model = new ManagerModel();
            ManagerPropertyViewModel = new ManagerPropertyViewModel(_model);
            ManagerAddProductViewModel = new ManagerAddProductViewModel(_model);
        }
        private ManagerModel _model;

        public ManagerPropertyViewModel ManagerPropertyViewModel { get; }
        public ManagerAddProductViewModel ManagerAddProductViewModel { get; }
    }
}

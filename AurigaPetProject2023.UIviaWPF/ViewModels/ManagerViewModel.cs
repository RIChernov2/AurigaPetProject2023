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
            ManagerItemPropertyViewModel = new ManagerItemPropertyViewModel ();
            ManagerAddItemViewModel = new ManagerAddItemViewModel();
        }


        public ManagerItemPropertyViewModel  ManagerItemPropertyViewModel { get; }
        public ManagerAddItemViewModel ManagerAddItemViewModel { get; }
    }
}

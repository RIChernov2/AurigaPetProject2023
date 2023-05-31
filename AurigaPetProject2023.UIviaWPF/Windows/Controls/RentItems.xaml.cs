using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.ValidationRules;
using AurigaPetProject2023.UIviaWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AurigaPetProject2023.UIviaWPF.Windows.Controls
{
    /// <summary>
    /// Interaction logic for RentItems.xaml
    /// </summary>
    public partial class RentItems : UserControl
    {
        public RentItems()
        {
            InitializeComponent();



            var a = Validation.GetValidationAdornerSite(priceTextbox);
            var b = Validation.GetValidationAdornerSiteFor(priceTextbox);

            //priceTextbox.GetVa(Validation.ErrorEvent, OnPriceErrorEventHandler);
            //Validation.AddErrorHandler(priceTextbox, PriceValidationErrorHandler);

            //priceTextbox.

            PriceValidationRule validationRule = priceTextbox.GetBindingExpression(TextBox.TextProperty)?.ParentBinding.ValidationRules
                .OfType<PriceValidationRule>()
                .FirstOrDefault();

            validationRule.OnValidationFailed += SetZeroCost;
        }

        private void SetZeroCost()
        {
            ((ManagerRentItemViewModel)this.DataContext).PriceValidationFailingCommand.Execute(null);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (sender is not ComboBox cbox) return;
            //if (cbox.SelectedItem is not IUserWithDiscountInfo itemWithRentInfo) return;

            //ManagerRentItemViewModel model = (ManagerRentItemViewModel)this.DataContext;

            //ICollectionView collectionView =  CollectionViewSource.GetDefaultView(model.RentItems);
            ////collectionView.Filter = (item) =>
            ////{
            ////    //ItemWithRentInfo myItem = (ItemWithRentInfo)item;
            ////    ItemWithRentInfo myItem = item as ItemWithRentInfo;

            ////    return myItem.RentInfo.UserID == itemWithRentInfo.UserID;

            ////};

            //collectionView.Filter = (item) => true;
        }
    }
}

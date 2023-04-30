using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.UIviaWPF.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ProductTypeManagement.xaml
    /// </summary>
    public partial class ProductTypeManagement : UserControl
    {
        static ProductTypeManagement()
        {
            MyBindingProperty = DependencyProperty.Register("MyBinding", typeof(Binding),
                typeof(ProductTypeManagement), new FrameworkPropertyMetadata(null) {BindsTwoWayByDefault = true });

        }
        public ProductTypeManagement()
        {
            InitializeComponent();
        }

        public Binding MyBinding
        {
            get { return (Binding)GetValue(MyBindingProperty); }
            set { SetValue(MyBindingProperty, value); }
        }

        public static readonly DependencyProperty MyBindingProperty;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManagerPropertyViewModel model = (ManagerPropertyViewModel)this.DataContext;
            model.NewProductType = new ProductType()
            {
                Name = newProductTypeNameTextBox.Text,
                IsUnique = newProductTypeIsUniqueCheckBox.IsChecked == true ? true : false,
                ProductTypeID = model.SelectedProductType.ProductTypeID
            };
        }
    }
}

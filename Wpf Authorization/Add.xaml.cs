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
using System.Windows.Shapes;

namespace Wpf_Authorization
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
         

        public Add()
        {
            InitializeComponent();
        }

       public void Button_Click(object sender, RoutedEventArgs e)
        {
            string productarticlenumber = ProductArticleNumberElem.Text;
            string productname = ProductNameElem.Text;
            string productdescription = ProductDescriptionElem.Text;
            int productcost = int.Parse(ProductCostElem.Text);
            string productmanufacturer = ProductManufacturerElem.Text;
            ComboBoxItem item = (ComboBoxItem)ProductCategoryElem.SelectedItem;
            int productdiscountamount = int.Parse(ProductDiscountAmountElem.Text);
            int productquantityinstock = int.Parse(ProductQuantityInStockElem.Text);

                    
        Product currentProduct = Helpers.connection.Product.FirstOrDefault(x => x.ProductArticleNumber == productarticlenumber);
             if (currentProduct != null){
                MessageBox.Show("Товар уже существует");
                    return;
            }

        Product product = new Product();
         product.ProductArticleNumber = productarticlenumber;
         product.ProductName = productname;
         product.ProductDescription = productdescription;
         product.ProductCost = productcost;
         product.ProductManufacturer = productmanufacturer;
         product.ProductCategory = item.Content.ToString();
         product.ProductDiscountAmount = productdiscountamount;
         product.ProductQuantityInStock = productquantityinstock;

                Helpers.connection.Product.Add(product);
                Helpers.connection.SaveChanges();

                MessageBox.Show("Товар добавлен!");
                new MainWindow().Show();
                Close();

       }

        private void ProductCategoryElem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

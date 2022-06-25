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
using Wpf_Authorization.Pages;

namespace Wpf_Authorization
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        private User user = Store.user;
             Connection connection = new Connection();
        public Client()
        {
            InitializeComponent();
            fioElement.Content = $"{user.UserSurname} {user.UserName} {user.UserPatronymic}";
            productListElem.ItemsSource = connection.Product.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Store.user = null;
            new MainWindow().Show();
            Close();
        }

        private void findElem_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Product> products = connection.Product.Where(x => x.ProductName.Contains(findElem.Text)).ToList();
            productListElem.ItemsSource = products;
        }

        private void sortElem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)sortElem.SelectedItem;
            string selected = item.Content.ToString();

            if (selected == "По возрастанию")
            {
                List<Product> products = connection.Product.OrderBy(x => x.ProductManufacturer).ToList();

                productListElem.ItemsSource = products;
            }
            else
            {
                List<Product> products = connection.Product.OrderByDescending(x => x.ProductManufacturer).ToList();
                productListElem.ItemsSource = products;
            }
        }
    }
}

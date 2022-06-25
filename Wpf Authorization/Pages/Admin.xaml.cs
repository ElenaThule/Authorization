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

namespace Wpf_Authorization.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Connection connection = new Connection();
        private User user = Store.user;
        public Admin()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Add().Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        
        {
            Product product = (Product)productListElem.SelectedItem;
            new Edit(product).Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            {
                Product product = (Product)productListElem.SelectedItem;

                if (product == null)
                {
                    MessageBox.Show("Вы не выбрали товар, который хотите удалить");
                    return;
                }

                connection.Product.Remove(product);
                connection.SaveChanges();

                productListElem.ItemsSource = connection.Product.ToList();
            }
        }
    }
}

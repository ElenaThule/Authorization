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
using Wpf_Authorization.Pages;

namespace Wpf_Authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { public Connection connection = new Connection();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = loginElement.Text;
            string password = passwordElement.Password;

            User user = Helpers.Auth(login, password);

            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }


            if (user.UserPassword != password)
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }

            Store.user = user;
            if (user.UserRole == 1)
            {new Admin().Show();
                Close();
            }
            else if (user.UserRole !=1)
            {
                new Client().Show();
                Close();
            }

            MessageBox.Show($"Добро пожаловать, {user.UserName} {user.UserPatronymic} {user.UserSurname}");
        
        }
    }
}

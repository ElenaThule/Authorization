using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Authorization
{
    public class Helpers
    {
       public static Connection connection = new Connection();
        public static  User Auth(string login, string password)
        {
            User user = connection.User.FirstOrDefault(x => x.UserLogin == login);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return null;
            }
            if (user.UserPassword != password)
            {
                MessageBox.Show("Неверный пароль");
                return null;
            }
            return user;
        }
        
    }
}

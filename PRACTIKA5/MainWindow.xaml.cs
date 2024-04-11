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

namespace PRACTIKA5
{
    public partial class MainWindow : Window
    {
        crafty_handsEntities shop = new crafty_handsEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordBox.Password = new string('*', PasswordBox.Password.Length);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SellerWindow sellerWindow = new SellerWindow();
            sellerWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var log = shop.employees.ToList();
            int i = log.FindIndex(b => b.logins == LoginBox.Text);
            int r = log.FindIndex(b => b.passwords == PasswordBox.Password);
            if (i == r && i != -1)
            {
                var login = log.Single(u => u.ID_employee == i + 1);
                int role = Convert.ToInt32(login.specialization_ID);
                switch (role)
                {
                    case 1:
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                        break;
                    case 2:
                        SellerWindow window = new SellerWindow();
                        window.Show();
                        this.Close();
                        break;
                }
            }
            else 
            {
                MessageBox.Show("Неверный логин или пароль");
            }

        }
    }
}

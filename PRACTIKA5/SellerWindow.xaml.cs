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

namespace PRACTIKA5
{
    public partial class SellerWindow : Window
    {
        public SellerWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new WareHousePage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new DepartamentPage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new CategoryPage();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new ProductPage();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new OrderPage();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new Order_DetailsPage();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new DiscountPage();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

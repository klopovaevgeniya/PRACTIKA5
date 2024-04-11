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
    public partial class Order_DetailsPage : Page
    {
        crafty_handsEntities shop = new crafty_handsEntities();

        public Order_DetailsPage()
        {
            InitializeComponent();
            DetailsGrid.ItemsSource = shop.order_details.ToList();
            OrderBox.ItemsSource = shop.orders.ToList();
            ProductBox.ItemsSource= shop.products.ToList();
            EmployeeBox.ItemsSource = shop.employees.ToList();
        }

        private void DetailsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DetailsGrid.SelectedItem  != null)
            {
                var selected = DetailsGrid.SelectedItem as order_details;
                OrderBox.SelectedItem = selected.orders;
                ProductBox.SelectedItem = selected.products;
                EmployeeBox.SelectedItem = selected.employees;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            order_details i = new order_details();
            i.order_ID = (OrderBox.SelectedItem as orders).ID_order;
            i.product_ID = (ProductBox.SelectedItem as products).ID_product;
            i.employee_ID = (EmployeeBox.SelectedItem as employees).ID_employee;
            shop.order_details.Add(i);
            shop.SaveChanges();
            OrderBox.ItemsSource = shop.order_details.ToList();
            OrderBox.SelectedIndex = -1;
            ProductBox.SelectedIndex = -1;
            EmployeeBox.SelectedIndex = -1;

            if (OrderBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ.");
                return;
            }

            if (ProductBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите продукт.");
                return;
            }

            if (EmployeeBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника.");
                return;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DetailsGrid.SelectedItem != null) 
            {
                if (OrderBox.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите заказ.");
                    return;
                }

                if (ProductBox.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите продукт.");
                    return;
                }

                if (EmployeeBox.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите сотрудника.");
                    return;
                }
                var selected = DetailsGrid.SelectedItem as order_details;
                selected.order_ID = Convert.ToInt32((OrderBox.SelectedItem as orders).ID_order);
                selected.product_ID = Convert.ToInt32((ProductBox.SelectedItem as products).ID_product);
                selected.employee_ID = Convert.ToInt32((EmployeeBox.SelectedItem as employees).ID_employee);
                shop.SaveChanges();
                DetailsGrid.ItemsSource = shop.order_details.ToList();
                OrderBox.SelectedIndex = -1;
                ProductBox.SelectedIndex = -1;
                EmployeeBox.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Выберите детали чека!!!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DetailsGrid.SelectedItem != null)
                {
                    shop.order_details.Remove(DetailsGrid.SelectedItem as order_details);
                    shop.SaveChanges();
                    DetailsGrid.ItemsSource = shop.order_details.ToList();
                    OrderBox.SelectedIndex = -1;
                    ProductBox.SelectedIndex = -1;
                    EmployeeBox.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Выберите детали чека");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нельзя удалить запись, на которую есть ссылка!");
            }

        }
    }
}

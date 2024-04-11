using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class SupplierPage : Page
    {
        crafty_handsEntities shop = new crafty_handsEntities();

        public SupplierPage()
        {
            InitializeComponent();
            SupplierGrid.ItemsSource = shop.suppliers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CompanyBox.Text))
            {
                MessageBox.Show("Зполните поле компании");
                CompanyBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(NameBox.Text) || NameBox.Text.Any(Char.IsDigit))
            {
                MessageBox.Show("Проверьте поле имени");
                CompanyBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(PhoneBox.Text) || !PhoneBox.Text.StartsWith("+79"))
            {
                MessageBox.Show("Неккоректные данные телефона/Зполните поле телефон");
                CompanyBox.Focus();
                return;
            }
            if (PhoneBox.Text.Length > 13)
            {
                MessageBox.Show("Номер телефона должен содержать не более 13 символов.");
                return;
            }
            if (string.IsNullOrEmpty(EmailBox.Text) || !EmailBox.Text.Contains('@'))
            {
                MessageBox.Show("Неккоректные данные почты/Заполните поле почта");
                EmailBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(DeliveryBox.Text))
            {
                MessageBox.Show("Заполните поле доставки");
                DeliveryBox.Focus();
                return;
            }


            suppliers i = new suppliers();
            i.company = CompanyBox.Text;
            i.name_of_supplier = NameBox.Text;
            i.phone_number = PhoneBox.Text;
            i.email = EmailBox.Text;
            i.date_of_delivery = DeliveryBox.Text;
            shop.suppliers.Add(i);
            shop.SaveChanges();
            SupplierGrid.ItemsSource = shop.suppliers.ToList();
            CompanyBox.Clear();
            NameBox.Clear();
            PhoneBox.Clear();
            EmailBox.Clear();
            DeliveryBox.Clear();
        }

        private void SupplierGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SupplierGrid.SelectedItem != null)
            {
                var selected = SupplierGrid.SelectedItem as suppliers;
                CompanyBox.Text = selected.company;
                NameBox.Text = selected.name_of_supplier;
                PhoneBox.Text = selected.phone_number;
                EmailBox.Text = selected.email;
                DeliveryBox.Text = selected.date_of_delivery; 
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CompanyBox.Text))
            {
                MessageBox.Show("Зполните поле компании");
                CompanyBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(NameBox.Text) || NameBox.Text.Any(Char.IsDigit))
            {
                MessageBox.Show("Проверьте поле имени");
                CompanyBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(PhoneBox.Text) || !PhoneBox.Text.StartsWith("+79"))
            {
                MessageBox.Show("Неккоректные данные телефона/Зполните поле телефон");
                CompanyBox.Focus();
                return;
            }
            if (PhoneBox.Text.Length > 13)
            {
                MessageBox.Show("Номер телефона должен содержать не более 13 символов.");
                return;
            }
            if (string.IsNullOrEmpty(EmailBox.Text) || !EmailBox.Text.Contains('@'))
            {
                MessageBox.Show("Неккоректные данные почты/Заполните поле почта");
                EmailBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(DeliveryBox.Text))
            {
                MessageBox.Show("Заполните поле доставки");
                DeliveryBox.Focus();
                return;
            }

            if(SupplierGrid.SelectedItem != null)
            {
                var selected = SupplierGrid.SelectedItem as suppliers;
                selected.company = CompanyBox.Text;
                selected.name_of_supplier = NameBox.Text;
                selected.phone_number = PhoneBox.Text;
                selected.email = EmailBox.Text;
                selected.date_of_delivery = DeliveryBox.Text;
                shop.SaveChanges();
                SupplierGrid.ItemsSource = shop.suppliers.ToList();
                CompanyBox.Clear();
                NameBox.Clear();
                PhoneBox.Clear();
                EmailBox.Clear();
                DeliveryBox.Clear();
            }
            else
            {
                MessageBox.Show("Выберите поставщика!!!");
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SupplierGrid.SelectedItem != null)
                {
                    shop.suppliers.Remove(SupplierGrid.SelectedItem as suppliers);
                    shop.SaveChanges();
                    SupplierGrid.ItemsSource = shop.suppliers.ToList();
                    CompanyBox.Clear();
                    NameBox.Clear();
                    PhoneBox.Clear();
                    EmailBox.Clear();
                    DeliveryBox.Clear();
                }
                else
                {
                    MessageBox.Show("Выберите поставщика");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нельзя удалить запись, на которую есть ссылка!");
            }
            
        }
    }
}

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
    public partial class WareHousePage : Page
    {
        crafty_handsEntities shop = new crafty_handsEntities();

        public WareHousePage()
        {
            InitializeComponent();
            WareHouseGrid.ItemsSource = shop.warehouse.ToList();
            ProductBox.ItemsSource = shop.products.ToList();
            SupplierBox.ItemsSource = shop.suppliers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(QuantityBox.Text))
            {
                MessageBox.Show("Введите количество товара на складе.");
                QuantityBox.Focus();
                return;
            }
            else if (!int.TryParse(QuantityBox.Text, out int quantity))
            {
                MessageBox.Show("Количество товара на складе должно быть числом.");
                QuantityBox.Focus();
                return;
            }
            else if (quantity <= 0)
            {
                MessageBox.Show("Количество товара на складе должно быть больше нуля.");
                QuantityBox.Focus();
                return;
            }
            if (ProductBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите товар.");
                ProductBox.Focus();
                return;
            }
            if (SupplierBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите поставщика.");
                SupplierBox.Focus();
                return;
            }
            warehouse i = new warehouse();
            i.quantity = Convert.ToInt32(QuantityBox.Text);
            i.product_ID = (ProductBox.SelectedItem as products).ID_product;
            i.supplier_ID = (SupplierBox.SelectedItem as suppliers).ID_supplier;
            shop.warehouse.Add(i);
            shop.SaveChanges();
            WareHouseGrid.ItemsSource = shop.warehouse.ToList();
        }

        private void WareHouseGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(WareHouseGrid.SelectedItem != null)
            {
                var selected = WareHouseGrid.SelectedItem as warehouse;
                QuantityBox.Text = selected.quantity.ToString();
                ProductBox.SelectedItem = selected.products;
                SupplierBox.SelectedItem = selected.suppliers;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(QuantityBox.Text))
            {
                MessageBox.Show("Введите количество товара на складе.");
                QuantityBox.Focus();
                return;
            }
            else if (!int.TryParse(QuantityBox.Text, out int quantity))
            {
                MessageBox.Show("Количество товара на складе должно быть числом.");
                QuantityBox.Focus();
                return;
            }
            else if (quantity <= 0)
            {
                MessageBox.Show("Количество товара на складе должно быть больше нуля.");
                QuantityBox.Focus();
                return;
            }
            if (ProductBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите товар.");
                ProductBox.Focus();
                return;
            }
            if (SupplierBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите поставщика.");
                SupplierBox.Focus();
                return;
            }

            if (WareHouseGrid.SelectedItem != null)
            {
                var selected = WareHouseGrid.SelectedItem as warehouse;
                selected.quantity = Convert.ToInt32(QuantityBox.Text);
                selected.product_ID = Convert.ToInt32((ProductBox.SelectedItem as products).ID_product);
                selected.supplier_ID = Convert.ToInt32((SupplierBox.SelectedItem as suppliers).ID_supplier);
                shop.SaveChanges();
                WareHouseGrid.ItemsSource = shop.warehouse.ToList();
            }
            else
            {
                MessageBox.Show("Выберите склад!!!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WareHouseGrid.SelectedItem != null)
                {
                    shop.warehouse.Remove(WareHouseGrid.SelectedItem as warehouse);
                    shop.SaveChanges();
                    WareHouseGrid.ItemsSource = shop.warehouse.ToList();
                }
                else
                {
                    MessageBox.Show("Выберите склад");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нельзя удалить запись, на которую есть ссылка!");

            }
        }
    }
}

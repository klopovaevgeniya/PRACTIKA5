using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRACTIKA5
{
    public partial class ProductPage : Page
    {
        crafty_handsEntities shop = new crafty_handsEntities();

        public ProductPage()
        {
            InitializeComponent();
            ProductGrid.ItemsSource = shop.products.ToList();
            CategoryBox.ItemsSource = shop.categories.ToList();
        }

        private void ProductGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductGrid.SelectedItem != null)
            {
                var selected = ProductGrid.SelectedItem as products;
                NameBox.Text = selected.name_of_product;
                PriceBox.Text = selected.price.ToString();
                DescriptionBox.Text = selected.descriptions;
                CategoryBox.SelectedItem = selected.categories;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя продукта.");
                return;
            }
            if (Regex.IsMatch(NameBox.Text, @"[0-9]"))
            {
                MessageBox.Show("Имя продукта не может содержать цифры.");
                return;
            }
            if (!Regex.IsMatch(NameBox.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Название категории может содержать только буквы.");
                return;
            }

            if (string.IsNullOrEmpty(PriceBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите цену продукта.");
                return;
            }
            if (string.IsNullOrEmpty(DescriptionBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите описание продукта.");
                return;
            }
            if (CategoryBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите категорию для продукта.");
                return;
            }
            products i = new products();
            i.name_of_product = NameBox.Text;
            i.price = Convert.ToInt32(PriceBox.Text);
            i.descriptions = DescriptionBox.Text;
            i.category_ID = (CategoryBox.SelectedItem as categories).ID_category;
            shop.products.Add(i);
            shop.SaveChanges();
            ProductGrid.ItemsSource = shop.products.ToList();
            NameBox.Clear();
            PriceBox.Clear();
            DescriptionBox.Clear();

            try
            {
                i.price = Convert.ToInt32(PriceBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Цена продукта должна быть целым числом.");
                return;
            }

            if (i.price < 0)
            {
                MessageBox.Show("Цена продукта не может быть отрицательной.");
                return;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem != null)
            {
                if (string.IsNullOrEmpty(PriceBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите цену продукта.");
                    return;
                }

                if (string.IsNullOrEmpty(NameBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите имя продукта.");
                    return;
                }
                if (Regex.IsMatch(NameBox.Text, @"[0-9]"))
                {
                    MessageBox.Show("Имя продукта не может содержать цифры.");
                    return;
                }
                if (!Regex.IsMatch(NameBox.Text, @"^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Название категории может содержать только буквы.");
                    return;
                }
                if (string.IsNullOrEmpty(DescriptionBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите описание продукта.");
                    return;
                }
                var selected = ProductGrid.SelectedItem as products;
                selected.name_of_product = NameBox.Text;
                selected.price = Convert.ToInt32(PriceBox.Text);
                selected.descriptions = DescriptionBox.Text;
                selected.category_ID = Convert.ToInt32((CategoryBox.SelectedItem as categories).ID_category);
                shop.SaveChanges();
                ProductGrid.ItemsSource = shop.products.ToList();

                if (selected.price < 0)
                {
                    MessageBox.Show("Цена продукта не может быть отрицательной.");
                    return;
                }

                try
                {
                    selected.price = Convert.ToInt32(PriceBox.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Цена продукта должна быть целым числом.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Выберите продукт");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProductGrid.SelectedItem != null)
                {
                    shop.products.Remove(ProductGrid.SelectedItem as products);
                    shop.SaveChanges();
                    ProductGrid.ItemsSource = shop.products.ToList();
                }
                else
                {
                    MessageBox.Show("Не выбран продукт для удаления");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нельзя удалить запись, на которую есть ссылка!");

            }
        }
    }
}

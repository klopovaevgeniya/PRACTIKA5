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
    public partial class CategoryPage : Page
    {
        crafty_handsEntities shop = new crafty_handsEntities();

        public CategoryPage()
        {
            InitializeComponent();
            CategoryGrid.ItemsSource = shop.categories.ToList();
            DepartamentBox.ItemsSource = shop.departaments.ToList();
        }

        private void CategoryGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryGrid.SelectedItem != null)
            {
                var selected = CategoryGrid.SelectedItem as categories;
                NameBox.Text = selected.name_of_category;
                DescriptionBox.Text = selected.descriptions;
                DepartamentBox.SelectedItem = selected.departaments;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название категории.");
                return;
            }
            if (!Regex.IsMatch(NameBox.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Название категории может содержать только буквы.");
                return;
            }
            if (shop.categories.Any(c => c.name_of_category == NameBox.Text))
            {
                MessageBox.Show("Категория с таким названием уже существует.");
                return;
            }
            if (string.IsNullOrEmpty(DescriptionBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите описание категории.");
                return;
            }
            if (DepartamentBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите отдел для категории.");
                return;
            }
            categories i = new categories();
            i.name_of_category = NameBox.Text;
            i.descriptions = DescriptionBox.Text;
            i.departament_ID = (DepartamentBox.SelectedItem as departaments).ID_departament;
            shop.categories.Add(i);
            shop.SaveChanges();
            CategoryGrid.ItemsSource = shop.categories.ToList();
            NameBox.Clear();
            DescriptionBox.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название категории.");
                return;
            }
            if (!Regex.IsMatch(NameBox.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Название категории может содержать только буквы.");
                return;
            }
            if (string.IsNullOrEmpty(DescriptionBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите описание категории.");
                return;
            }
            if (DepartamentBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите отдел для категории.");
                return;
            }
            if (CategoryGrid.SelectedItem != null)
            {
                var selected = CategoryGrid.SelectedItem as categories;
                selected.name_of_category = NameBox.Text;
                selected.descriptions = DescriptionBox.Text;
                selected.departament_ID = Convert.ToInt32((DepartamentBox.SelectedItem as departaments).ID_departament);
                shop.SaveChanges();
                CategoryGrid.ItemsSource = shop.categories.ToList();
                NameBox.Clear();
                DescriptionBox.Clear();
            }
            else
            {
                MessageBox.Show("Выберите категорию!!!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CategoryGrid.SelectedItem != null)
                {
                    shop.categories.Remove(CategoryGrid.SelectedItem as categories);
                    shop.SaveChanges();
                    CategoryGrid.ItemsSource = shop.categories.ToList();
                    NameBox.Clear();
                    DescriptionBox.Clear();
                }
                else
                {
                    MessageBox.Show("Выберите категорию");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нельзя удалить запись, на которую есть ссылка!");
            }
        }
    }
}

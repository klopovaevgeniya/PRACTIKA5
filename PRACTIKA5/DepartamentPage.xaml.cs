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
    
    public partial class DepartamentPage : Page
    {
        crafty_handsEntities shop = new crafty_handsEntities();

        public DepartamentPage()
        {
            InitializeComponent();
            DepartamentGrid.ItemsSource = shop.departaments.ToList();
        }

        private void DepartamentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DepartamentGrid.SelectedItem != null)
            {
                var selected = DepartamentGrid.SelectedItem as departaments;
                NameBox.Text = selected.name_of_departament;
                DescriptionBox.Text = selected.descriptions;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя отдела.");
                return;
            }
            if (shop.departaments.Any(d => d.name_of_departament == NameBox.Text))
            {
                MessageBox.Show("Отдел с таким названием уже существует.");
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
            if (string.IsNullOrEmpty(DescriptionBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите описание отдела.");
                return;
            }

            departaments i = new departaments();
            i.name_of_departament = NameBox.Text;
            i.descriptions = DescriptionBox.Text;
            shop.departaments.Add(i);
            shop.SaveChanges();
            DepartamentGrid.ItemsSource = shop.departaments.ToList();
            NameBox.Clear();
            DescriptionBox.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(DepartamentGrid.SelectedItem != null)
            {
                if (string.IsNullOrEmpty(NameBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите имя отдела.");
                    return;
                }
                if (string.IsNullOrEmpty(DescriptionBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите описание отдела.");
                    return;
                }

                var selected = DepartamentGrid.SelectedItem as departaments;
                selected.name_of_departament = NameBox.Text;
                selected.descriptions = DescriptionBox.Text;
                shop.SaveChanges();
                DepartamentGrid.ItemsSource = shop.departaments.ToList();
                NameBox.Clear();
                DescriptionBox.Clear();
            }
            else
            {
                MessageBox.Show("Выберите отдел!!!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DepartamentGrid.SelectedItem != null)
                {

                    shop.departaments.Remove(DepartamentGrid.SelectedItem as departaments);
                    shop.SaveChanges();
                    DepartamentGrid.ItemsSource = shop.departaments.ToList();
                    NameBox.Clear();
                    DescriptionBox.Clear();
                }
                else
                {
                    MessageBox.Show("Выберите отдел");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Нельзя удалить запись, на которую есть ссылка!");
            }
        }
    }
}

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
    public partial class SpecializationPage : Page
    {
        crafty_handsEntities shop = new crafty_handsEntities();

        public SpecializationPage()
        {
            InitializeComponent();
            SpecialGrid.ItemsSource = shop.specializations.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Поле не было заполнено");
                NameBox.Focus();
                return;
            }
            if (!Regex.IsMatch(NameBox.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Поле компании может содержать только буквы.");
                NameBox.Focus();
                return;
            }

            specializations i = new specializations();
            i.name_of_specialization = NameBox.Text;
            shop.specializations.Add(i);
            shop.SaveChanges();
            SpecialGrid.ItemsSource = shop.specializations.ToList();
            NameBox.Clear();
        }

        private void SpecialGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SpecialGrid.SelectedItem != null)
            {
                var selected = SpecialGrid.SelectedItem as specializations;
                NameBox.Text = selected.name_of_specialization;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Поле не было заполнено");
                NameBox.Focus();
                return;
            }
            if (!Regex.IsMatch(NameBox.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Поле компании может содержать только буквы.");
                NameBox.Focus();
                return;
            }
            if (SpecialGrid.SelectedItem != null)
            {
                var selected = SpecialGrid.SelectedItem as specializations;
                selected.name_of_specialization = NameBox.Text;
                shop.SaveChanges();
                SpecialGrid.ItemsSource = shop.specializations.ToList();
                NameBox.Clear();
            }
            else
            {
                MessageBox.Show("Выберите специальность!!!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SpecialGrid.SelectedItem != null)
                {
                    shop.specializations.Remove(SpecialGrid.SelectedItem as specializations);
                    shop.SaveChanges();
                    SpecialGrid.ItemsSource = shop.specializations.ToList();
                    NameBox.Clear();
                }
                else
                {
                    MessageBox.Show("Выберите специльность");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нельзя удалить запись, на которую есть ссылка!");
                
            }
        }
    }
}

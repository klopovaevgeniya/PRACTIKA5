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
    public partial class DiscountPage : Page
    {
        crafty_handsEntities shop = new crafty_handsEntities();

        public DiscountPage()
        {
            InitializeComponent();
            Discountgrid.ItemsSource = shop.discount.ToList();
        }

        private void Discountgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Discountgrid.SelectedItem != null)
            {
                var selected = Discountgrid.SelectedItem as discount;
                NameBox.Text = selected.name_of_discount;
                ProcentBox.Text = selected.discount_percentage;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            discount i = new discount();
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название скидки.");
                return;
            }
            if (!Regex.IsMatch(NameBox.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Название категории может содержать только буквы.");
                return;
            }
            if (string.IsNullOrEmpty(ProcentBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите процент скидки.");
                return;
            }

            if (ProcentBox.Text.StartsWith("-"))
            {
                MessageBox.Show("Процент скидки не может быть отрицательным.");
                return;
            }

            if (!ProcentBox.Text.Contains("%"))
            {
                MessageBox.Show("Процент скидки должен содержать символ %.");
                return;
            }

            if (shop.discount.Any(d => d.name_of_discount == NameBox.Text))
            {
                MessageBox.Show("Скидка с таким названием уже существует.");
                return;
            }

            i.name_of_discount = NameBox.Text;
            i.discount_percentage = ProcentBox.Text;
            shop.discount.Add(i);
            shop.SaveChanges();
            Discountgrid.ItemsSource = shop.discount.ToList();
            NameBox.Clear();
            ProcentBox.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название скидки.");
                return;
            }
            if (!Regex.IsMatch(NameBox.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Название категории может содержать только буквы.");
                return;
            }
            if (string.IsNullOrEmpty(ProcentBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите процент скидки.");
                return;
            }

            if (!ProcentBox.Text.Contains("%"))
            {
                MessageBox.Show("Процент скидки должен содержать символ %.");
                return;
            }

            if (ProcentBox.Text.StartsWith("-"))
            {
                MessageBox.Show("Процент скидки не может быть отрицательным.");
                return;
            }
            if (Discountgrid.SelectedItem != null)
            {
                var selected = Discountgrid.SelectedItem as discount;
                selected.name_of_discount = NameBox.Text;
                selected.discount_percentage = ProcentBox.Text;
                shop.SaveChanges();
                Discountgrid.ItemsSource = shop.discount.ToList();
                NameBox.Clear();
                ProcentBox.Clear();
            }
            else
            {
                MessageBox.Show("Выберите скидку!!!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Discountgrid.SelectedItem != null)
                {
                    shop.discount.Remove(Discountgrid.SelectedItem as discount);
                    shop.SaveChanges();
                    Discountgrid.ItemsSource = shop.discount.ToList();
                    NameBox.Clear();
                    ProcentBox.Clear();
                }
                else
                {
                    MessageBox.Show("Выберте скидку");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нельзя удалить запись, на которую есть ссылка!");
            }
        }
    }
}

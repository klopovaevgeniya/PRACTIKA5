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
    public partial class OrderPage : Page
    {
        crafty_handsEntities shop = new crafty_handsEntities();

        public OrderPage()
        {
            InitializeComponent();
            OrderGrid.ItemsSource = shop.orders.ToList();
            PaymentBox.ItemsSource = shop.orders.ToList();
            DiscountBox.ItemsSource = shop.discount.ToList();
        }

        private void OrderGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderGrid.SelectedItem != null)
            {
                var selected = OrderGrid.SelectedItem as orders;
                NumberBox.Text = selected.number_of_order;
                AmountBox.Text = selected.total_amount.ToString();
                PaymentBox.SelectedItem = selected;
                DiscountBox.SelectedItem = selected.discount;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            orders i = new orders();

            if (string.IsNullOrEmpty(NumberBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите номер заказа.");
                return;
            }

            if (!NumberBox.Text.Contains("№"))
            {
                MessageBox.Show("Номер заказа должен содержать символ №.");
                return;
            }
            if (Regex.IsMatch(NumberBox.Text, @"[a-zA-Z]"))
            {
                MessageBox.Show("Номер чека не может содержать буквы.");
                return;
            }
            if (NumberBox.Text.StartsWith("-"))
            {
                MessageBox.Show("Номер чека не может быть отрицательным");
                return;
            }

            try
            {
                i.total_amount = Convert.ToInt32(AmountBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Общая сумма чека должна быть целым числом.");
                return;
            }

            if (i.total_amount < 0)
            {
                MessageBox.Show("Общая сумма чека не может быть отрицательной.");
                return;
            }

            if (PaymentBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите способ оплаты.");
                return;
            }

            if (DiscountBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите скидку.");
                return;
            }

            i.number_of_order = NumberBox.Text;
            i.total_amount = Convert.ToInt32(AmountBox.Text);
            i.payment_method = (PaymentBox.SelectedItem).ToString();
            i.discount_ID = (DiscountBox.SelectedItem as discount).ID_discount;
            shop.orders.Add(i);
            OrderGrid.ItemsSource = shop.orders.ToList();
            shop.SaveChanges();
            NumberBox.Clear();
            AmountBox.Clear();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem != null)
            {
                var selected = OrderGrid.SelectedItem as orders;
                selected.number_of_order = NumberBox.Text;
                selected.total_amount = Convert.ToInt32(AmountBox.Text);
                selected.payment_method = PaymentBox.SelectedItem.ToString();
                selected.discount_ID = Convert.ToInt32((DiscountBox));
                shop.SaveChanges();
                OrderGrid.ItemsSource = shop.orders.ToList();
                NumberBox.Clear();
                AmountBox.Clear();

                if (string.IsNullOrEmpty(NumberBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите номер заказа.");
                    return;
                }

                if (Regex.IsMatch(NumberBox.Text, @"[a-zA-Z]"))
                {
                    MessageBox.Show("Номер заказа не может содержать буквы.");
                    return;
                }

                if (!NumberBox.Text.Contains("№"))
                {
                    MessageBox.Show("Номер заказа должен содержать символ №.");
                    return;
                }

                try
                {
                    selected.total_amount = Convert.ToInt32(AmountBox.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Общая сумма заказа должна быть целым числом.");
                    return;
                }

                if (selected.total_amount < 0)
                {
                    MessageBox.Show("Общая сумма заказа не может быть отрицательной.");
                    return;
                }

                if (PaymentBox.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите способ оплаты.");
                    return;
                }

                if (DiscountBox.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите скидку.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Выберите чек!!!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrderGrid.SelectedItem != null)
                {
                    shop.orders.Remove(OrderGrid.SelectedItem as orders);
                    shop.SaveChanges();
                    OrderGrid.ItemsSource = shop.orders.ToList();
                    NumberBox.Clear();
                    AmountBox.Clear();
                }
                else
                {
                    MessageBox.Show("Выберите чек для удаления");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нельзя удалить запись, на которую есть ссылка!");

            }
        }
    }
}

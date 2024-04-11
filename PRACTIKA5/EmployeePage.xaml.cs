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
    public partial class EmployeePage : Page
    {
        crafty_handsEntities shop = new crafty_handsEntities();
        public EmployeePage()
        {
            InitializeComponent();
            EmployeeGrid.ItemsSource = shop.employees.ToList();
            SpecialBox.ItemsSource = shop.specializations.ToList();
            DepartamentBox.ItemsSource = shop.departaments.ToList();
            OrderBox.ItemsSource = shop.orders.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FirstnameBox.Text) || FirstnameBox.Text.Any(Char.IsDigit))
            {
                MessageBox.Show("Проверьте правильность имени");
                FirstnameBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(SurnameBox.Text) || SurnameBox.Text.Any(Char.IsDigit))
            {
                MessageBox.Show("Проверьте правильность фамилии");
                SurnameBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(MidlenameBox.Text) || MidlenameBox.Text.Any(Char.IsDigit))
            {
                MessageBox.Show("Проверьте правильность фамилии");
                MidlenameBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(PhoneBox.Text) || !PhoneBox.Text.StartsWith("+79"))
            {
                MessageBox.Show("Проверьте правильность номера телефона");
                PhoneBox.Focus();
                return;
            }

            if (PhoneBox.Text.Length > 13)
            {
                MessageBox.Show("Номер телефона должен содержать не более 13 символов.");
                return;
            }

            if (string.IsNullOrEmpty(LoginBox.Text))
            {
                MessageBox.Show("Введите логин");
                LoginBox.Focus();
                return;
            }

            if (shop.employees.Any(c => c.logins == LoginBox.Text))
            {
                MessageBox.Show("Логин уже существует.");
                LoginBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите пароль");
                PasswordBox.Focus();
                return;
            }

            if (SpecialBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите специализацию сотрудника.");
                SpecialBox.Focus();
                return;
            }

            if (DepartamentBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите департамент сотрудника.");
                DepartamentBox.Focus();
                return;
            }

            if (OrderBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите заказ сотрудника.");
                OrderBox.Focus();
                return;
            }

            employees i = new employees();
            i.firstname = FirstnameBox.Text;
            i.surname = SurnameBox.Text;
            i.midlename = MidlenameBox.Text;
            i.phone_number = PhoneBox.Text;
            i.logins = LoginBox.Text;
            i.passwords = PasswordBox.Password;
            i.specialization_ID = (SpecialBox.SelectedItem as specializations).ID_specialization;
            i.departament_ID = (DepartamentBox.SelectedItem as departaments).ID_departament;
            i.order_ID = (OrderBox.SelectedItem as orders).ID_order;
            shop.employees.Add(i);
            shop.SaveChanges();
            EmployeeGrid.ItemsSource = shop.employees.ToList();
            FirstnameBox.Clear();
            SurnameBox.Clear();
            MidlenameBox.Clear();
            PhoneBox.Clear();
            LoginBox.Clear();
            PasswordBox.Clear();
            SpecialBox.SelectedIndex = -1;
            DepartamentBox.SelectedIndex = -1;
            OrderBox.SelectedIndex = -1;
        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordBox.Password = new string('*', PasswordBox.Password.Length);
        }

        private void EmployeeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem != null)
            {
                var selected = EmployeeGrid.SelectedItem as employees;
                FirstnameBox.Text = selected.firstname;
                SurnameBox.Text = selected.surname;
                MidlenameBox.Text = selected.midlename;
                PhoneBox.Text = selected.phone_number;
                LoginBox.Text = selected.logins;
                PasswordBox.Password = selected.passwords;
                SpecialBox.SelectedItem = selected.specializations;
                DepartamentBox.SelectedItem = selected.departaments;
                OrderBox.SelectedItem = selected.orders;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FirstnameBox.Text) || FirstnameBox.Text.Any(Char.IsDigit))
            {
                MessageBox.Show("Проверьте правильность имени");
                FirstnameBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(SurnameBox.Text) || SurnameBox.Text.Any(Char.IsDigit))
            {
                MessageBox.Show("Проверьте правильность фамилии");
                SurnameBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(MidlenameBox.Text) || MidlenameBox.Text.Any(Char.IsDigit))
            {
                MessageBox.Show("Проверьте правильность фамилии");
                MidlenameBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(PhoneBox.Text) || !PhoneBox.Text.StartsWith("+79"))
            {
                MessageBox.Show("Проверьте правильность номера телефона");
                PhoneBox.Focus();
                return;
            }
            if (PhoneBox.Text.Length > 13)
            {
                MessageBox.Show("Номер телефона должен содержать не более 13 символов.");
                return;
            }
            if (string.IsNullOrEmpty(LoginBox.Text))
            {
                MessageBox.Show("Введите логин");
                LoginBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите пароль");
                PasswordBox.Focus();
                return;
            }

            if (SpecialBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите специализацию сотрудника.");
                SpecialBox.Focus();
                return;
            }

            if (DepartamentBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите департамент сотрудника.");
                DepartamentBox.Focus();
                return;
            }

            if (OrderBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите заказ сотрудника.");
                OrderBox.Focus();
                return;
            }
            if (EmployeeGrid.SelectedItem != null)
            {
                var selected = EmployeeGrid.SelectedItem as employees;
                selected.firstname = FirstnameBox.Text;
                selected.surname = SurnameBox.Text;
                selected.midlename = MidlenameBox.Text;
                selected.phone_number = PhoneBox.Text;
                selected.logins = LoginBox.Text;
                selected.passwords = PasswordBox.Password;
                selected.specialization_ID = Convert.ToInt32((SpecialBox.SelectedItem as specializations).ID_specialization);
                selected.departament_ID = Convert.ToInt32((DepartamentBox.SelectedItem as departaments).ID_departament);
                selected.order_ID = Convert.ToInt32((OrderBox.SelectedItem as orders).ID_order);
                shop.SaveChanges();
                EmployeeGrid.ItemsSource = shop.employees.ToList();
                FirstnameBox.Clear();
                SurnameBox.Clear();
                MidlenameBox.Clear();
                PhoneBox.Clear();
                LoginBox.Clear();
                PasswordBox.Clear();
                SpecialBox.SelectedIndex = -1;
                DepartamentBox.SelectedIndex = -1;
                OrderBox.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Выберите сотрудника!!!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {

                if (EmployeeGrid.SelectedItem != null)
                {
                    shop.employees.Remove(EmployeeGrid.SelectedItem as employees);
                    shop.SaveChanges();
                    EmployeeGrid.ItemsSource = shop.employees.ToList();
                    FirstnameBox.Clear();
                    SurnameBox.Clear();
                    MidlenameBox.Clear();
                    PhoneBox.Clear();
                    LoginBox.Clear();
                    PasswordBox.Clear();
                    SpecialBox.SelectedIndex = -1;
                    DepartamentBox.SelectedIndex = -1;
                    OrderBox.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Выберите сотрудника");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нельзя удалить запись, на которую есть ссылка!");
            }
        }
    }
}

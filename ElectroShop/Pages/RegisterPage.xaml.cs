using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ElectroShop.ApplicationData;

namespace ElectroShop.Pages
{
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text.Trim();
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Password.Trim();
            string passwordRepeat = txtPasswordRepeat.Password.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите имя");
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Введите логин");
                txtLogin.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль");
                txtPassword.Focus();
                return;
            }

            if (password != passwordRepeat)
            {
                MessageBox.Show("Пароли не совпадают");
                txtPassword.Clear();
                txtPasswordRepeat.Clear();
                txtPassword.Focus();
                return;
            }

            var existingUser = AppConnect.model01.Users.FirstOrDefault(x => x.Login == login);

            if (existingUser != null)
            {
                MessageBox.Show("Такой логин уже занят");
                txtLogin.Focus();
                return;
            }

            Users newUser = new Users();
            newUser.FullName = name;
            newUser.Login = login;
            newUser.Password = password;
            newUser.Email = string.IsNullOrWhiteSpace(email) ? null : email;
            newUser.Phone = string.IsNullOrWhiteSpace(phone) ? null : phone;
            newUser.RoleID = 2;
            newUser.IsBlocked = false;
            newUser.CreatedAt = DateTime.Now;

            AppConnect.model01.Users.Add(newUser);
            AppConnect.model01.SaveChanges();

            Carts newCart = new Carts();
            newCart.UserID = newUser.UserID;
            newCart.CreatedAt = DateTime.Now;

            AppConnect.model01.Carts.Add(newCart);
            AppConnect.model01.SaveChanges();

            MessageBox.Show("Регистрация прошла успешно");
            AppFrame.frmMain.GoBack();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain.GoBack();
        }
    }
}
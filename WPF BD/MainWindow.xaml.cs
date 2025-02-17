using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WPF_BD
{
    public partial class MainWindow : Window
    {
        private static List<User> Users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            if (Users.Any(u => u.Username == username))
            {
                MessageBox.Show("Пользователь с таким именем уже существует.");
                return;
            }

            string salt = PasswordHasher.GenerateSalt();
            string passwordHash = PasswordHasher.HashPassword(password, salt);

            User newUser = new User { Username = username, PasswordHash = passwordHash, Salt = salt };
            Users.Add(newUser);

            MessageBox.Show("Регистрация прошла успешно.");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            User user = Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
                return;
            }

            bool passwordCorrect = PasswordHasher.VerifyPassword(password, user.PasswordHash, user.Salt);

            if (passwordCorrect)
            {
                MessageBox.Show("Авторизация прошла успешно!");
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }
    }
}

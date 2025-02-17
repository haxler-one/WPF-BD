using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace WPF_BD
{
    public partial class MainWindow : Window
    {
        private static List<User> Users = new List<User>();
        private const string UsersFilePath = "users.txt"; // Имя файла

        public MainWindow()
        {
            InitializeComponent();
            LoadUsersFromFile(); // Загружаем данные при запуске
        }

        private void LoadUsersFromFile()
        {
            if (File.Exists(UsersFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(UsersFilePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            Users.Add(new User { Username = parts[0], PasswordHash = parts[1], Salt = parts[2] });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                }
            }
        }

        private void SaveUsersToFile()
        {
            try
            {
                List<string> lines = Users.Select(u => $"{u.Username},{u.PasswordHash},{u.Salt}").ToList();
                File.WriteAllLines(UsersFilePath, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
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
            SaveUsersToFile(); // Сохраняем после регистрации

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

        // Сохраняем данные при закрытии приложения
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            SaveUsersToFile();
            base.OnClosing(e);
        }
    }
}

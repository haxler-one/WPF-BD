using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WPF_BD
{
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataTable data = DatabaseSingleton.Instance.ExecuteQuery("SELECT * FROM Сотрудник"); // Замените на вашу таблицу
            if (data != null)
            {
                listView.ItemsSource = data.DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page5());
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }
    }
}
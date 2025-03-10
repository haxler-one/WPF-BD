using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WPF_BD
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataTable data = DatabaseSingleton.Instance.ExecuteQuery("SELECT * FROM Продукт"); // Замените на вашу таблицу
            if (data != null)
            {
                listView.ItemsSource = data.DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }
    }
}
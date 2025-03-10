using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WPF_BD
{
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataTable data = DatabaseSingleton.Instance.ExecuteQuery("SELECT * FROM Продажа"); // Замените на вашу таблицу
            if (data != null)
            {
                dataGrid.ItemsSource = data.DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page4());
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}
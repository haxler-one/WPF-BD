using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WPF_BD
{
    public partial class Page5 : Page
    {
        public Page5()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataTable data = DatabaseSingleton.Instance.ExecuteQuery("SELECT * FROM Покупатель"); // Замените на вашу таблицу
            if (data != null)
            {
                dataGrid.ItemsSource = data.DefaultView;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page4());
        }
    }
}
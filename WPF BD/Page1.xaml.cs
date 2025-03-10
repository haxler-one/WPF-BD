using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WPF_BD
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataTable data = DatabaseSingleton.Instance.ExecuteQuery("SELECT * FROM Магазин"); // Замените на вашу таблицу
            if (data != null)
            {
                dataGrid.ItemsSource = data.DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}
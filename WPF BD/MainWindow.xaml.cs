using System.Windows;
using System.Windows.Navigation;

namespace WPF_BD
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new Page1());
        }
    }
}
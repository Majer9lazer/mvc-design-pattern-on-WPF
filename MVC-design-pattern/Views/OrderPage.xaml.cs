using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace MVC_design_pattern.Views
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void ShowMenuClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameStatic.Source = new Uri("Views/BurgerMenuPage.xaml", UriKind.RelativeOrAbsolute);
        }


        private void GotFocusMainMenu(object sender, RoutedEventArgs e)
        {
            OrderBurgerBackgroundImage.Opacity = 0.3;
            OrderMainMenu.Opacity = 1;
        }

        private void CreateBurgerMenuItemClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameStatic.Source = new Uri("Views/CreateBurgerPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void ExitToMainPage_MenuItemClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameStatic.Source = new Uri("Views/LogInPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void ApllicationExit_MenuItemClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("До скорых встреч!");
            Application.Current.Shutdown();
        }

        private void LostFocus_MainMenu(object sender, RoutedEventArgs e)
        {
            OrderBurgerBackgroundImage.Opacity = 0.7;
        }

        private void ShowOrders_MenuItemClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameStatic.Source = new Uri("Views/ShowUserOrders.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}

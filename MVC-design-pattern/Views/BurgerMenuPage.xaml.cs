using System;
using System.Windows;
using System.Windows.Controls;
using MVC_design_pattern.Controllers;

namespace MVC_design_pattern.Views
{
    /// <summary>
    /// Interaction logic for BurgerMenuPage.xaml
    /// </summary>
    public partial class BurgerMenuPage : Page
    {
        private readonly BurgerMenuController _burgerMenuController = new BurgerMenuController();
        public BurgerMenuPage()
        {
            InitializeComponent();
            BurgersMenuListView.ItemsSource = _burgerMenuController.GetBurgers();
        }


        private void ExitToMainMenu_MenuItemClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameStatic.Source= new Uri("Views/OrderPage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}

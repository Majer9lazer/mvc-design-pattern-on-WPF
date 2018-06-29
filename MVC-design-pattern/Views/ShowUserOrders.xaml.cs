using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using MVC_design_pattern.Controllers;

namespace MVC_design_pattern.Views
{
    /// <summary>
    /// Логика взаимодействия для ShowUserOrders.xaml
    /// </summary>
    public partial class ShowUserOrders : Page
    {
        private readonly UserOrdersController _userOrdersController = new UserOrdersController();
        public ShowUserOrders()
        {
            InitializeComponent();
            UserNameLabel.Dispatcher.InvokeAsync(() =>
            {
                UserNameLabel.Content = LogInPage._loginController.GetCurrentUser().UserName;
            });
            
            var query = _userOrdersController.GetUserOrders(LogInPage._loginController.GetCurrentUser().UserId).Select(s => new
            {
                s.Burger,
                s.OrderName,
                TotalPrice = _userOrdersController.GetTotalPriceForBurger(s.Burger.BurgerId)
            }).ToList();
            OrderListView.Dispatcher.InvokeAsync(() => { OrderListView.ItemsSource = query; });
        }

        private void Exit_ButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("До встречи");
            Application.Current.Shutdown();
        }

        private void ExitToMainMenu(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameStatic.Source = new Uri("Views/OrderPage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}

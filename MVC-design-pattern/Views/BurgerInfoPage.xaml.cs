using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using MVC.DAL.Factory;
using MVC.DAL.Model;
using MVC_design_pattern.Controllers;
using Newtonsoft.Json;

namespace MVC_design_pattern.Views
{
    /// <summary>
    /// Логика взаимодействия для BurgerInfoPage.xaml
    /// </summary>
    public partial class BurgerInfoPage : Page
    {
        public static BurgerComponentsController ComponentsController = new BurgerComponentsController();
        private BuildBurgerController _burgerController = new BuildBurgerController();
        private Burger burger = new Burger();
        public BurgerInfoPage()
        {
            InitializeComponent();
            try
            {
                burger = ComponentsController.ReturnBurger();
                List<ProductClass> products = JsonConvert.DeserializeObject<List<ProductClass>>(burger.BurgerComonents);
                var select = products.Select(s => new
                {
                    s.Name,
                    s.PriceForHundredGrams,
                    s.Weight,
                    TotalPrice = s.PriceForHundredGrams * s.Weight
                });
                BurgerComponentsListView.ItemsSource = select.ToList();
                BurgerNameLabel.Content = $"{burger.BurgerName}";
                TotalPriceLabel.Content = $"Итоговая цена : {select.Select(s => s.TotalPrice).Sum()}";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string message = _burgerController.BuiltBurger(burger, $"Order_{burger.BurgerName}",
                    LogInPage._loginController.GetCurrentUser());
                if (message == "0")
                {
                    MessageBox.Show("Ваш бургер был заказан");
                    MainWindow.MainFrameStatic.Source = new Uri("Views/OrderPage.xaml", UriKind.RelativeOrAbsolute);
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
        private void ExitToOrderPage(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameStatic.Source = new Uri("Views/OrderPage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}

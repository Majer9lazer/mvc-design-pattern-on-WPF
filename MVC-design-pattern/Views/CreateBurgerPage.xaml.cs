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
using MVC.DAL.Factory.Prototype;
using MVC_design_pattern.Controllers;

namespace MVC_design_pattern.Views
{
    /// <summary>
    /// Interaction logic for CreateBurgerPage.xaml
    /// </summary>
    public partial class CreateBurgerPage : Page
    {
        private BuildBurgerController _buildBurgerController = new BuildBurgerController();
        private Random _rnd = new Random();
        public CreateBurgerPage()
        {
            InitializeComponent();
        }

        private void AddSausageButtonClick(object sender, RoutedEventArgs e)
        {
            CountOfSausagesLabel.Dispatcher.InvokeAsync(() =>
                {
                    CountOfSausagesLabel.Content =
                        $"Количество сосисек : {_buildBurgerController.AddSausage(new Sausage(_rnd.NextDouble() * 5, _rnd.Next(7, 10), "Сосиска"))}";
                });
        }
        private void AddHamButtonClick(object sender, RoutedEventArgs e)
        {
            CountOfHamsLabel.Dispatcher.InvokeAsync(() =>
            {
                CountOfHamsLabel.Content =
                    $"Количество ветчины : {_buildBurgerController.AddHam(new Ham(_rnd.NextDouble() * 5, _rnd.Next(7, 10), "Кусок ветчины"))}";
            });
        }
        private void AddBeefButtonClick(object sender, RoutedEventArgs e)
        {
            CountOfBeefsLabel.Dispatcher.InvokeAsync(() =>
            {
                CountOfBeefsLabel.Content =
                    $"Количество говядины : {_buildBurgerController.AddBeef(new Beef(_rnd.NextDouble() * 5, _rnd.Next(7, 10), "Кусок говядины"))}";
            });
        }
        private void AddCheeseSliceClick(object sender, RoutedEventArgs e)
        {
            CountOfCheeseSlicesLabel.Dispatcher.InvokeAsync(() =>
            {
                CountOfCheeseSlicesLabel.Content =
                    $"Кусочков сыра : " +
                    $"{_buildBurgerController.AddCheeseSlice()}";
            });
        }

        private void FormOrderButtonClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(BurgerNameTextBox.Text))
            {
                //string content = CountOfSausagesLabel.Content.ToString();
                //content = content.Substring(content.IndexOf(":", StringComparison.Ordinal) + 1);
                //MessageBox.Show(content);
                string message = _buildBurgerController.BuiltBurger(BurgerNameTextBox.Text, $"Order_{BurgerNameTextBox.Text}",
                        LogInPage._loginController.GetCurrentUser());
                if (message == "0")
                {
                    MessageBox.Show("Ура ваш бургер был собран!");
                    MainWindow.MainFrameStatic.Source = new Uri("Views/OrderPage.xaml", UriKind.RelativeOrAbsolute);
                    CountOfSausagesLabel.Content = "Количество сосисек : 0";
                    CountOfHamsLabel.Content = "Количество ветчины : 0";
                    CountOfBeefsLabel.Content = "Количество говядины : 0";
                    CountOfCheeseSlicesLabel.Content = "Кусочков сыра : 0";
                }
                else
                    MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Вы не заполнили поле с названием бургера");
            }
        }

        private void ExitToMainMenu_MenuItemClcik(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrameStatic.Source = new Uri("Views/OrderPage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}

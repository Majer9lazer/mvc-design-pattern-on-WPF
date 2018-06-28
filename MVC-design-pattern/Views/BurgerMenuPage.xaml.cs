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

       
    }
}

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
using MVC.DAL.Model;
using MVC_design_pattern.Controllers;

namespace MVC_design_pattern.Views
{
    /// <summary>
    /// Логика взаимодействия для LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        private LoginController _loginController= new LoginController();
     public LogInPage()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_loginController.Login(UserNameTextBox.Text));
            UserNameTextBox.Text = "";
        }
    }
}

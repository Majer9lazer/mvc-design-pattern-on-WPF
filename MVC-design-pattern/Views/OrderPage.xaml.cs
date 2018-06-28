﻿using System;
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
            OrderBurgerBackgroundImage.Opacity = 0.5;
        }
    }
}

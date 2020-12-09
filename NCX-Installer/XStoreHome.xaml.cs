using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Compression;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for XStoreHome.xaml
    /// </summary>
    public partial class XStoreHome : Page
    {
        public XStoreHome()
        {
            InitializeComponent();
            if (Settings1.Default.lightTheme == true)
            {
                this.Background = Brushes.White;
                label1.Foreground = Brushes.Black; label2.Foreground = Brushes.Black; btn6.Foreground = Brushes.Black;
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            XSCSharpCol page = new XSCSharpCol();
            NavigationService.Navigate(page);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            XSDSiD page = new XSDSiD();
            NavigationService.Navigate(page);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            XSC64TL page = new XSC64TL();
            NavigationService.Navigate(page);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XWareHome page = new XWareHome();
            NavigationService.Navigate(page);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            MainMenu page = new MainMenu();
            NavigationService.Navigate(page);
        }

        private void btn3_Click_1(object sender, RoutedEventArgs e)
        {
            Library page = new Library();
            NavigationService.Navigate(page);
        }

        private void btn1_Click_1(object sender, RoutedEventArgs e)
        {
            Settings page = new Settings();
            NavigationService.Navigate(page);
        }

        private void btn2_Click_1(object sender, RoutedEventArgs e)
        {
            About page = new About();
            NavigationService.Navigate(page);
        }
    }
}

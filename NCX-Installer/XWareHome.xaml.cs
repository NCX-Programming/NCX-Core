using System;
using System.Collections.Generic;
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

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for XWareHome.xaml
    /// </summary>
    public partial class XWareHome : Page
    {
        public XWareHome()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            XWareHome page = new XWareHome();
            NavigationService.Navigate(page);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XWareNews page = new XWareNews();
            NavigationService.Navigate(page);
        }
    }
}

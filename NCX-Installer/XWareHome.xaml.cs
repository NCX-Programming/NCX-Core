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
            if (Settings1.Default.lightTheme == true)
            {
                this.Background = Brushes.White;
                label1.Foreground = Brushes.Black; label2.Foreground = Brushes.Black;
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            XWareNews page = new XWareNews();
            NavigationService.Navigate(page);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            XWareUpdater page = new XWareUpdater();
            NavigationService.Navigate(page);
        }
    }
}

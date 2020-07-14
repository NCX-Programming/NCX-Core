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
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for FirstTime1.xaml
    /// </summary>
    public partial class FirstTime1 : Window
    {
        public FirstTime1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

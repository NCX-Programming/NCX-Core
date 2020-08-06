using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            if (File.Exists("C:/Program Files/NCX/CSharp Collection/CSharpCollectionVol1.exe"))
            {
                btn1.Visibility = Visibility.Visible;
                btn2.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            Hide();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            Environment.Exit(0);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            XStore win = new XStore();
            win.Show();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("C:/Program Files/NCX/CSharp Collection/CSharpCollectionVol1.exe"))
            {
                Process.Start("C:/Program Files/NCX/CSharp Collection/CSharpCollectionVol1.exe");
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            NavSettings.Default.comingFrom = "cscol";
            XStore win = new XStore();
            win.Show();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            NavSettings.Default.comingFrom = "am";
            XStore win = new XStore();
            win.Show();
        }
    }
}

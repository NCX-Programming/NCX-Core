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
using System.Diagnostics;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for ArchivedProjects.xaml
    /// </summary>
    public partial class ArchivedProjects : Window
    {
        public ArchivedProjects()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/NinjaCheetah/VisualBasic-Collection-Vol.1";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/NinjaCheetah/AutoMod";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            Hide();
        }
    }
}

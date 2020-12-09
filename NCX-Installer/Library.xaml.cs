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
using System.IO;
using System.Diagnostics;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for Library.xaml
    /// </summary>
    public partial class Library : Page
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public Library()
        {
            InitializeComponent();
            if (File.Exists("C:/Program Files/NCX/CSharpCollection/CSharpCollection.exe"))
            {
                btn5.Visibility = Visibility.Visible;
                btn6.Visibility = Visibility.Visible;
            }
            if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater/NCX-Core Updater.exe")))
            {
                btn7.Visibility = Visibility.Visible;
                btn8.Visibility = Visibility.Visible;
            }
            if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe")))
            {
                btn9.Visibility = Visibility.Visible;
                btn10.Visibility = Visibility.Visible;
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            MainMenu page = new MainMenu();
            NavigationService.Navigate(page);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            XStoreHome page = new XStoreHome();
            NavigationService.Navigate(page);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("C:/Program Files/NCX/CSharpCollection/CSharpCollection.exe"))
            {
                Process.Start("C:/Program Files/NCX/CSharpCollection/CSharpCollection.exe");
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            XSCSharpCol page = new XSCSharpCol();
            NavigationService.Navigate(page);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater/NCX-Core Updater.exe")))
            {
                ExecuteAsAdmin(System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater/NCX-Core Updater.exe"));
                // Process.Start(System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater/NCX-Core Updater.exe"));
                string text = Settings1.Default.version;
                File.WriteAllText(System.IO.Path.Combine(SavePath, "version.txt"), text);
            }
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            XWareUpdater page = new XWareUpdater();
            NavigationService.Navigate(page);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe")))
            {
                Process.Start(System.IO.Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe"));
            }
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            XWareNews page = new XWareNews();
            NavigationService.Navigate(page);
        }

        public void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Settings page = new Settings();
            NavigationService.Navigate(page);
        }
    }
}

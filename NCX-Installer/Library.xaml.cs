using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.IO;
using System.Diagnostics;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for Library.xaml
    /// </summary>
    public partial class Library : Page
    {
        static readonly string docFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public Library()
        {
            InitializeComponent();
            if (Settings1.Default.lightTheme == true)
            {
                Background = Brushes.White;
                label1.Foreground = Brushes.Black; btn5.Foreground = Brushes.Black; btn6.Foreground = Brushes.Black;
                btn7.Foreground = Brushes.Black; btn8.Foreground = Brushes.Black; btn9.Foreground = Brushes.Black;
                btn10.Foreground = Brushes.Black;
            }
            if (File.Exists("C:/Program Files/NCX/CSharpCollection/CSharpCollection.exe"))
            {
                btn5.Visibility = Visibility.Visible;
                btn6.Visibility = Visibility.Visible;
            }
            if (File.Exists(Path.Combine(docFolderPath, "NCX-Core/NCXCoreUpdater/NCX-Core Updater.exe")))
            {
                btn7.Visibility = Visibility.Visible;
                btn8.Visibility = Visibility.Visible;
            }
            if (File.Exists(Path.Combine(docFolderPath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe")))
            {
                btn9.Visibility = Visibility.Visible;
                btn10.Visibility = Visibility.Visible;
            }
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
            
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Path.Combine(docFolderPath, "NCX-Core/NCXCoreUpdater/NCX-Core Updater.exe")))
            {
                ExecuteAsAdmin(Path.Combine(docFolderPath, "NCX-Core/NCXCoreUpdater/NCX-Core Updater.exe"));
                string text = Settings1.Default.version;
                File.WriteAllText(Path.Combine(docFolderPath, "version.txt"), text);
            }
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            XWareUpdater page = new XWareUpdater();
            NavigationService.Navigate(page);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Path.Combine(docFolderPath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe")))
            {
                Process.Start(Path.Combine(docFolderPath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe"));
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

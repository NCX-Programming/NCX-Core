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
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Windows.Resources;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for XSCSharpCol.xaml
    /// </summary>
    public partial class XSCSharpCol : Page
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public XSCSharpCol()
        {
            InitializeComponent();
            if (File.Exists("C:/Program Files/NCX/CSharpCollection/CSharpCollection.exe"))
            {
                btn7.Visibility = Visibility.Visible;
            }
            if (Settings1.Default.lightTheme == true)
            {
                this.Background = Brushes.White;
                label1.Foreground = Brushes.Black; label2.Foreground = Brushes.Black; label3.Foreground = Brushes.Black;
                label4.Foreground = Brushes.Black; btn7.Foreground = Brushes.Black; btn10.Foreground = Brushes.Black;
                btn11.Foreground = Brushes.Black; btn8.Foreground = Brushes.Black; btn8.Background = Brushes.White;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/NinjaCheetah/CSharp-Collection";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/NinjaCheetah";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            XStoreHome page = new XStoreHome();
            NavigationService.Navigate(page);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                btn8.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Visible;
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/CSharp-Collection/releases/latest/download/CSharpCollectionSetup.msi"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "CSharpCollectionSetup.msi")
                );
            }
        }

        public void DownloadCompleted(object sender, EventArgs e)
        {
            label1.Content = "Download Complete";
            Directory.SetCurrentDirectory(SavePath);
            Process p = new Process();
            p.StartInfo.FileName = "msiexec";
            p.StartInfo.Arguments = "/i CSharpCollectionSetup.msi";
            p.Start();
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("C:/Program Files/NCX/CSharpCollection/CSharpCollection.exe"))
            {
                Process.Start("C:/Program Files/NCX/CSharpCollection/CSharpCollection.exe");
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            MainMenu page = new MainMenu();
            NavigationService.Navigate(page);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Library page = new Library();
            NavigationService.Navigate(page);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            About page = new About();
            NavigationService.Navigate(page);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            Settings page = new Settings();
            NavigationService.Navigate(page);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            XStoreHome page = new XStoreHome();
            NavigationService.Navigate(page);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            img1.Source = (ImageSource)FindResource("image1");
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            img1.Source = (ImageSource)FindResource("image2");
        }
    }
}

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
using System.Net;
using System.Diagnostics;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for XSDSiD.xaml
    /// </summary>
    public partial class XSDSiD : Page
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public XSDSiD()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/YourKalamity/lazy-dsi-file-downloader";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/YourKalamity";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            XStoreHome page = new XStoreHome();
            NavigationService.Navigate(page);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                btn5.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Visible;
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/YourKalamity/lazy-dsi-file-downloader/releases/latest/download/lazy-dsi-file-downloader-v3.0.0.exe"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "lazy-dsi-file-downloader-v3.0.0.exe")
                );
            }
        }

        public void DownloadCompleted(object sender, EventArgs e)
        {
            label1.Content = "Download Complete";
            Directory.SetCurrentDirectory(SavePath);
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}

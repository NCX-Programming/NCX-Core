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
using System.Net;
using System.Diagnostics;
using System.IO;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for XSC64TL.xaml
    /// </summary>
    public partial class XSC64TL : Page
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public XSC64TL()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/IanSkinner1982/C64-title-loader";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/IanSkinner1982";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            XStoreHome page = new XStoreHome();
            NavigationService.Navigate(page);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            XSC64TLP page = new XSC64TLP();
            NavigationService.Navigate(page);
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
                    new System.Uri("https://github.com/IanSkinner1982/C64-title-loader/releases/latest/download/loader.d64"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "loader.d64")
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

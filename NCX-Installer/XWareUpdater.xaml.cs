using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
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
    /// Interaction logic for XWareUpdater.xaml
    /// </summary>
    public partial class XWareUpdater : Page
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public XWareUpdater()
        {
            InitializeComponent();
            if (Settings1.Default.lightTheme == true)
            {
                this.Background = Brushes.White;
                label1.Foreground = Brushes.Black; label2.Foreground = Brushes.Black; label3.Foreground = Brushes.Black;
                label4.Foreground = Brushes.Black; btn6.Foreground = Brushes.Black; btn7.Foreground = Brushes.Black;
                btn9.Foreground = Brushes.Black; btn8.Foreground = Brushes.Black; btn8.Background = Brushes.White;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/NinjaCheetah";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/NinjaCheetah/NCX-XWare";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            XWareHome page = new XWareHome();
            NavigationService.Navigate(page);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/")))
            {
                if (Directory.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater/")))
                {
                    using (WebClient wc = new WebClient())
                    {
                        btn8.Visibility = Visibility.Hidden;
                        label1.Visibility = Visibility.Visible;
                        progressBar1.Visibility = Visibility.Visible;
                        wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                        wc.DownloadFileCompleted += DownloadCompleted;
                        wc.DownloadFileAsync(
                            // Param1 = Link of file
                            new System.Uri("https://github.com/NinjaCheetah/NCX-XWare/releases/latest/download/NCXCoreUpdater.zip"),
                            // Param2 = Path to save
                            System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater/NCXCoreUpdater.zip")
                        );
                    }
                }
                else
                {
                    Directory.CreateDirectory(System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater"));
                    using (WebClient wc = new WebClient())
                    {
                        btn8.Visibility = Visibility.Hidden;
                        label1.Visibility = Visibility.Visible;
                        progressBar1.Visibility = Visibility.Visible;
                        wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                        wc.DownloadFileCompleted += DownloadCompleted;
                        wc.DownloadFileAsync(
                            // Param1 = Link of file
                            new System.Uri("https://github.com/NinjaCheetah/NCX-XWare/releases/latest/download/NCXCoreUpdater.zip"),
                            // Param2 = Path to save
                            System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater/NCXCoreUpdater.zip")
                        );
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(System.IO.Path.Combine(SavePath, "NCX-Core"));
                Directory.CreateDirectory(System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater"));
                using (WebClient wc = new WebClient())
                {
                    btn8.Visibility = Visibility.Hidden;
                    label1.Visibility = Visibility.Visible;
                    progressBar1.Visibility = Visibility.Visible;
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += DownloadCompleted;
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri("https://github.com/NinjaCheetah/NCX-XWare/releases/latest/download/NCXCoreUpdater.zip"),
                        // Param2 = Path to save
                        System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater/NCXCoreUpdater.zip")
                    );
                }
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        public void DownloadCompleted(object sender, EventArgs e)
        {
            ZipFile.ExtractToDirectory(System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater/NCXCoreUpdater.zip"), System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater"), true);
            File.Delete(System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater/NCXCoreUpdater.zip"));
            label1.Content = "Download Complete";
            NavSettings.Default.filesDownloaded = true;
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {

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

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            XStoreHome page = new XStoreHome();
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

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater/NCX-Core Updater.exe")))
            {
                ExecuteAsAdmin(System.IO.Path.Combine(SavePath, "NCX-Core/NCXCoreUpdater/NCX-Core Updater.exe"));
                string text = Settings1.Default.version;
                File.WriteAllText(System.IO.Path.Combine(SavePath, "version.txt"), text);
            }
        }

        public void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }
    }
}

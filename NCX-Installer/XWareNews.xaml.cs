using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for XWareNews.xaml
    /// </summary>
    public partial class XWareNews : Page
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public XWareNews()
        {
            InitializeComponent();
            if (File.Exists(Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe")))
            {
                btn7.Visibility = Visibility.Visible;
            }
            if (Settings1.Default.lightTheme == true)
            {
                this.Background = Brushes.White;
                label1.Foreground = Brushes.Black; label2.Foreground = Brushes.Black; label3.Foreground = Brushes.Black;
                label4.Foreground = Brushes.Black; btn6.Foreground = Brushes.Black; btn9.Foreground = Brushes.Black;
                btn8.Foreground = Brushes.Black; btn8.Background = Brushes.White; btn7.Foreground = Brushes.Black;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            XWareHome page = new XWareHome();
            NavigationService.Navigate(page);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/NinjaCheetah/NCX-XWare";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/NinjaCheetah";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Path.Combine(SavePath, "NCX-Core/")))
            {
                if (Directory.Exists(Path.Combine(SavePath,"NCX-Core/NCXNewsPlus/")))
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
                            new System.Uri("https://github.com/NinjaCheetah/NCX-XWare/releases/latest/download/NCXNewsPlus.zip"),
                            // Param2 = Path to save
                            Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.zip")
                        );
                    }
                }
                else
                {
                    Directory.CreateDirectory(Path.Combine(SavePath, "NCX-Core/NCXNewsPlus"));
                    using (WebClient wc = new WebClient())
                    {
                        btn8.Visibility = Visibility.Hidden;
                        label1.Visibility = Visibility.Visible;
                        progressBar1.Visibility = Visibility.Visible;
                        wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                        wc.DownloadFileCompleted += DownloadCompleted;
                        wc.DownloadFileAsync(
                            // Param1 = Link of file
                            new System.Uri("https://github.com/NinjaCheetah/NCX-XWare/releases/latest/download/NCXNewsPlus.zip"),
                            // Param2 = Path to save
                            Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.zip")
                        );
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(SavePath, "NCX-Core"));
                Directory.CreateDirectory(Path.Combine(SavePath, "NCX-Core/NCXNewsPlus"));
                using (WebClient wc = new WebClient())
                {
                    btn8.Visibility = Visibility.Hidden;
                    label1.Visibility = Visibility.Visible;
                    progressBar1.Visibility = Visibility.Visible;
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += DownloadCompleted;
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri("https://github.com/NinjaCheetah/NCX-XWare/releases/latest/download/NCXNewsPlus.zip"),
                        // Param2 = Path to save
                        Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.zip")
                    );
                }
            }
        }

        public void DownloadCompleted(object sender, EventArgs e)
        {
            ZipFile.ExtractToDirectory(Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.zip"), Path.Combine(SavePath, "NCX-Core/NCXNewsPlus"), true);
            File.Delete(Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.zip"));
            label1.Content = "Download Complete";
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("C:/Program Files/NCX/CSharp Collection/CSharpCollectionVol1.exe"))
            {
                Process.Start("C:/Program Files/NCX/CSharp Collection/CSharpCollectionVol1.exe");
            }
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe")))
            {
                Process.Start(Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe"));
            }
        }
    }
}

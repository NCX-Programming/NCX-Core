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
            if (Settings1.Default.lightTheme == true)
            {
                this.Background = Brushes.White;
                label1.Foreground = Brushes.Black; label2.Foreground = Brushes.Black; label3.Foreground = Brushes.Black;
                btn7.Foreground = Brushes.Black; btn12.Foreground = Brushes.Black; btn8.Foreground = Brushes.Black;
                btn8.Background = Brushes.White; btn10.Foreground = Brushes.Black; btn10.Background = Brushes.White;
                btn11.Foreground = Brushes.Black; btn11.Background = Brushes.White; label4.Foreground = Brushes.Black;
            }
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                btn8.Visibility = Visibility.Hidden;
                btn10.Visibility = Visibility.Hidden;
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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            img1.Source = (ImageSource)FindResource("image1");
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            img1.Source = (ImageSource)FindResource("image2");
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

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (Settings1.Default.betaVer == true)
            {
                btn11.Visibility = Visibility.Hidden;
                btn10.Visibility = Visibility.Visible;
                btn8.Visibility = Visibility.Visible;
            }
            else
            {
                using (WebClient wc = new WebClient())
                {
                    btn11.Visibility = Visibility.Hidden;
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
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                btn8.Visibility = Visibility.Hidden;
                btn10.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Visible;
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://ncx-programming.github.io/ncxprogramming.github.io/loader-nightly.d64"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "loader-nightly.d64")
                );
            }
        }

        private void btn13_Click(object sender, RoutedEventArgs e)
        {
            img1.Source = (ImageSource)FindResource("image3");
        }
    }
}

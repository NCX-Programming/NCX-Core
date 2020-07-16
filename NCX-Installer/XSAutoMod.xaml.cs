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

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for XSAutoMod.xaml
    /// </summary>
    public partial class XSAutoMod : Page
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public XSAutoMod()
        {
            InitializeComponent();
            if (File.Exists("C:/Program Files/NCX/AutoMod/AutoMod.exe"))
            {
                btn6.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/NinjaCheetah/automod-rewrite";
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

        private void btn5_click(object sender, RoutedEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                btn5.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Visible;
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/automod-rewrite/releases/latest/download/AutoModSetup.msi"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "AutoModSetup.msi")
                );
            }
        }

        public void DownloadCompleted(object sender, EventArgs e)
        {
            label1.Content = "Download Complete";
            Directory.SetCurrentDirectory(SavePath);
            Process p = new Process();
            p.StartInfo.FileName = "msiexec";
            p.StartInfo.Arguments = "/i AutoModSetup.msi";
            p.Start();
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            XSAMP page = new XSAMP();
            NavigationService.Navigate(page);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("C:/Program Files/NCX/AutoMod/AutoMod.exe"))
            {
                Process.Start("C:/Program Files/NCX/AutoMod/AutoMod.exe");
            }
        }
    }
}

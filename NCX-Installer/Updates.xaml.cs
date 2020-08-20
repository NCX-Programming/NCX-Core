using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for Updates.xaml
    /// </summary>
    public partial class Updates : Window
    {
        public Updates()
        {
            InitializeComponent();
        }

        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public decimal updateNum;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = "Fetching release data...";
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/NCX-Installer-News/releases/latest/download/updateNotice.txt"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "updateNotice.txt")
                );
            }
        }

        public void DownloadCompleted(object sender, EventArgs e)
        {
            string text = File.ReadAllText(System.IO.Path.Combine(SavePath, "updateNotice.txt"));
            // updateNum = Decimal.Parse(text);
            updateNum = Convert.ToDecimal(text);
            label1.Content = "Fetching release data...";
            if (updateNum == Settings1.Default.version)
            {
                label1.Content = "You are using the latest release!";
                btn2.Content = "Check Again";
            }
            else if (updateNum > Settings1.Default.version)
            {
                label1.Content = "There is an update available: v" + updateNum;
                btn4.Visibility = Visibility.Visible;
                btn3.Visibility = Visibility.Hidden;
            }
            else if (updateNum < Settings1.Default.version)
            {
                label1.Content = "Either this is a beta or something has gone very wrong";
                btn2.Content = "Check Again";
            }
        }

        public void DownloadCompleted2(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(SavePath);
            Process p = new Process();
            p.StartInfo.FileName = "msiexec";
            p.StartInfo.Arguments = "/i NCXCoreSetup.msi";
            p.Start();
            Environment.Exit(0);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = "Downloading latest release...";
            btn1.Visibility = Visibility.Hidden;
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted2;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/NCX-Core/releases/latest/download/NCXCoreSetup.msi"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "NCXCoreSetup.msi")
                );
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            string message = "Are you sure you would like to uninstall NCX-Installer?";
            string caption = "Confirm Uninstallation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Exclamation;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                Start_Unistall();
            }
            else
            {
                // No code here  
            }
        }

        public void Start_Unistall()
        {
            btn1.Visibility = Visibility.Hidden;
            btn2.Visibility = Visibility.Hidden;
            btn3.Visibility = Visibility.Hidden;
            btn4.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Visible;
            if (File.Exists(System.IO.Path.Combine(SavePath, "updateNotice.txt")))
            {
                File.Delete(System.IO.Path.Combine(SavePath, "updateNotice.txt"));
            }
            if (File.Exists(System.IO.Path.Combine(SavePath, "newsLatest.txt")))
            {
                File.Delete(System.IO.Path.Combine(SavePath, "newsLatest.txt"));
            }
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted3;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/NCX-Core/releases/latest/download/NCXCoreSetup.msi"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "NCXCoreSetup.msi")
                );
            }
        }

        public void DownloadCompleted3(object sender, EventArgs e)
        {

            string message = "Thank you for using NCX-Installer. I hope that you enjoyed the program while you used it.";
            string caption = "Goodbye!";
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.OK)
            {
                // Process.Start(System.IO.Path.Combine(SavePath, "NinjaCheetahInstallerSetup.msi"));
                Directory.SetCurrentDirectory(SavePath);
                Process p = new Process();
                p.StartInfo.FileName = "msiexec";
                p.StartInfo.Arguments = "/i NCXCoreInstaller.msi";
                p.Start();
                Environment.Exit(0);
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

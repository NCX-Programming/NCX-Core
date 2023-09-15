using System;
using System.IO;
using System.Net;
using System.Windows;
using Newtonsoft.Json;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string newstext;
        public int slot;

        public class Store
        {
            public string name1 { get; set; }
            public string icon1 { get; set; }
            public string name2 { get; set; }
            public string icon2 { get; set; }
            public string name3 { get; set; }
            public string icon3 { get; set; }
            public string name4 { get; set; }
            public string icon4 { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            NavSettings.Default.filesDownloaded = false;
            if (!Directory.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/")))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(SavePath, "NCX-Core"));   
            }
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/NCX-Installer-News/releases/latest/download/newsLatest.txt"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "NCX-Core/newsLatest.txt")
                );
            }
        }

        public void DownloadCompleted(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted2;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/ncx-core-files/releases/latest/download/ncxCoreMainMenu.json"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "NCX-Core/ncxCoreMainMenu.json")
                );
            }
        }

        public void DownloadCompleted2(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted3;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/ncx-core-files/releases/latest/download/XStore.json"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "NCX-Core/XStore.json")
                );
            }
        }

        public void DownloadCompleted3(object sender, EventArgs e)
        {
            string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "NCX-Core/XStore.json"));
            Store store = JsonConvert.DeserializeObject<Store>(json);

            slot = 1;
            DownloadIcon(store.icon1);
        }

        public void DownloadIcon(string link)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted4;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri($"{link}"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, $"NCX-Core/slot{slot}.png")
                );
            }
        }

        public void DownloadCompleted4(object sender, EventArgs e)
        {
            string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "NCX-Core/XStore.json"));
            Store store = JsonConvert.DeserializeObject<Store>(json);
            switch (slot)
            {
                case 1:
                    if (store.name2 != "")
                    {
                        slot = 2;
                        DownloadIcon(store.icon2);
                    }
                    break;
                case 2:
                    if (store.name3 != "")
                    {
                        slot = 3;
                        DownloadIcon(store.icon3);
                    }
                    break;
                case 3:
                    if (store.name4 != "")
                    {
                        slot = 4;
                        DownloadIcon(store.icon4);
                    }
                    break;
                case 4:
                    break;
            }
            img1.Visibility = Visibility.Hidden;
            _NavigationFrame.Navigate(new MainMenu());
            HomeButton.Visibility = Visibility.Visible;
            LibraryButton.Visibility = Visibility.Visible;
            StoreButton.Visibility = Visibility.Visible;
            AboutButton.Visibility = Visibility.Visible;
            SettingsButton.Visibility = Visibility.Visible;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            Environment.Exit(0);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new MainMenu());
        }

        private void LibraryButton_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new Library());
        }

        private void StoreButton_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new XStoreHome());
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new About());
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new Settings());
        }
    }
}

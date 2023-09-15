using System;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string newstext;
        public string[,] downloads = { 
            {"https://github.com/NinjaCheetah/NCX-Installer-News/releases/latest/download/newsLatest.txt", "NCX-Core/newsLatest.txt"},
            {"https://github.com/NinjaCheetah/ncx-core-files/releases/latest/download/ncxCoreMainMenu.json", "NCX-Core/ncxCoreMainMenu.json"}, 
            {"https://github.com/NinjaCheetah/ncx-core-files/releases/latest/download/XStore.json", "NCX-Core/XStore.json"} 
        };
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
            if (!Directory.Exists(Path.Combine(SavePath, "NCX-Core/")))
            {
                Directory.CreateDirectory(Path.Combine(SavePath, "NCX-Core"));   
            }
            Task initDownloads = Task.Run(async () =>
            {
                for (int i = 0; i < downloads.GetLength(0); i++)
                {
                    using var client = new HttpClient();
                    using var s = await client.GetStreamAsync($"{downloads[i, 0]}");
                    using var fs = new FileStream(Path.Combine(SavePath, $"{downloads[i, 1]}"), FileMode.OpenOrCreate);
                    await s.CopyToAsync(fs);
                }
                string json = File.ReadAllText(Path.Combine(SavePath, "NCX-Core/XStore.json"));
                Store store = JsonSerializer.Deserialize<Store>(json);
                slot = 1;
                DownloadIcon(store.icon1);
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
            });
            initDownloads.Wait();
            img1.Visibility = Visibility.Hidden;
            _NavigationFrame.Navigate(new MainMenu());
            HomeButton.Visibility = Visibility.Visible;
            LibraryButton.Visibility = Visibility.Visible;
            StoreButton.Visibility = Visibility.Visible;
            AboutButton.Visibility = Visibility.Visible;
            SettingsButton.Visibility = Visibility.Visible;
        }

        public void DownloadIcon(string link)
        {
            using (var client = new HttpClient())
            {
                using (var s = client.GetStreamAsync($"{link}"))
                {
                    using (var fs = new FileStream(Path.Combine(SavePath, $"NCX-Core/slot{slot}.png"), FileMode.OpenOrCreate))
                    {
                        s.Result.CopyTo(fs);
                    }
                }
            }
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

using System;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

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
            {"https://github.com/NinjaCheetah/ncx-core-files/releases/latest/download/XStore.json", "NCX-Core/XStore2.json"} 
        };
        public int slot;

        public class Store
        {
            public Dictionary<string, StoreItem> storeItems { get; set; }
        }

        public class StoreItem
        {
            public string name { get; set; }
            public string author { get; set; }
            public string project { get; set; }
            public string desc { get; set; }
            public string iconURL { get; set; }
            public string downloadURL { get; set; }
            public string file { get; set; }
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
                string[] itemList = store.storeItems.Keys.ToArray();
                Console.WriteLine($"{store.storeItems[itemList[0]].name}");
                for (int i = 0; i < itemList.Length; i++)
                {
                    using var client = new HttpClient();
                    using var s = await client.GetStreamAsync($"{store.storeItems[itemList[i]].iconURL}");
                    using var fs = new FileStream(Path.Combine(SavePath, $"NCX-Core/slot{i+1}.png"), FileMode.OpenOrCreate);
                    await s.CopyToAsync(fs);
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

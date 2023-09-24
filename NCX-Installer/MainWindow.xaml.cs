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
        static readonly string docFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string newstext;
        public string[,] downloads = { 
            {"https://github.com/NinjaCheetah/NCX-Installer-News/releases/latest/download/newsLatest.txt", "NCX-Core/newsLatest.txt"},
            {"https://github.com/NinjaCheetah/ncx-core-files/releases/latest/download/ncxCoreMainMenu.json", "NCX-Core/ncxCoreMainMenu.json"}, 
            {"https://github.com/NinjaCheetah/ncx-core-files/releases/latest/download/XStore.json", "NCX-Core/XStore2.json"} 
        };

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
            // Wait to run init code until the content is on screen so we can see my nice loading banner
            ContentRendered += MainWindow_ContentRendered;
        }

        private void MainWindow_ContentRendered(object sender, EventArgs e)
        {
            // Create the NCX-Core folder if it isn't already there
            if (!Directory.Exists(Path.Combine(docFolderPath, "NCX-Core/")))
            {
                Directory.CreateDirectory(Path.Combine(docFolderPath, "NCX-Core"));
            }
            // Handle downloads async
            // TODO: Handle download errors so that bad internet doesn't immediately crash it
            Task initDownloads = Task.Run(async () =>
            {
                // Download all files in the file array
                for (int i = 0; i < downloads.GetLength(0); i++)
                {
                    using var client = new HttpClient();
                    using var s = await client.GetStreamAsync($"{downloads[i, 0]}");
                    using var fs = new FileStream(Path.Combine(docFolderPath, $"{downloads[i, 1]}"), FileMode.OpenOrCreate);
                    await s.CopyToAsync(fs);
                }
                // Parse XStore.json to download all icons
                string json = File.ReadAllText(Path.Combine(docFolderPath, "NCX-Core/XStore.json"));
                // Create array of dictionaries of store items
                Store store = JsonSerializer.Deserialize<Store>(json);
                // Build a list of the available dictionaries
                string[] itemList = store.storeItems.Keys.ToArray();
                for (int i = 0; i < itemList.Length; i++)
                {
                    using var client = new HttpClient();
                    using var s = await client.GetStreamAsync($"{store.storeItems[itemList[i]].iconURL}");
                    using var fs = new FileStream(Path.Combine(docFolderPath, $"NCX-Core/slot{i + 1}.png"), FileMode.OpenOrCreate);
                    await s.CopyToAsync(fs);
                }
            });
            try
            {
                initDownloads.Wait();
                // Hide displayed launch image and show the main UI
                img1.Visibility = Visibility.Hidden;
                _NavigationFrame.Navigate(new MainMenu());
                HomeButton.Visibility = Visibility.Visible;
                LibraryButton.Visibility = Visibility.Visible;
                StoreButton.Visibility = Visibility.Visible;
                AboutButton.Visibility = Visibility.Visible;
                SettingsButton.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                // If we error out, hide the launch image and go to the error instead
                img1.Visibility = Visibility.Hidden;
                _NavigationFrame.Navigate(new ErrorPage(2));
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

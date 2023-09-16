using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for XStorePage.xaml
    /// </summary>
    public partial class XStorePage : Page
    {
        static readonly string docFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static readonly string deskFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public int slot;
        public Store store;
        public string[] itemList;

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

        public XStorePage(int slotCtx)
        {
            InitializeComponent();
            // Set global slot number to the one passed via argument
            slot = slotCtx;
            if (Settings1.Default.lightTheme == true)
            {
                Background = Brushes.White;
                label1.Foreground = Brushes.Black; appNameLbl.Foreground = Brushes.Black;
                authNameLbl.Foreground = Brushes.Black; descText.Foreground = Brushes.Black;
            }
            // Parse XStore.json and build dictionaries and dictionary array, set to global variables for ease of access in callbacks
            string json = File.ReadAllText(Path.Combine(docFolderPath, "NCX-Core/XStore.json"));
            store = JsonSerializer.Deserialize<Store>(json);
            itemList = store.storeItems.Keys.ToArray();
            // Set text to the program name, author, and description, and paint the icon
            appNameLbl.Content = store.storeItems[itemList[slot - 1]].name;
            authNameLbl.Content = store.storeItems[itemList[slot - 1]].author;
            descText.Text = store.storeItems[itemList[slot - 1]].desc;
            FileStream f = File.OpenRead(Path.Combine(docFolderPath, $"NCX-Core/slot{slot}.png"));
            var imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = f;
            imageSource.EndInit();
            img1.Source = imageSource;
        }

        private void sourceBtn_Click(object sender, RoutedEventArgs e)
        {
            // Open GitHub page for the current program
            string url = $"https://github.com/{store.storeItems[itemList[slot - 1]].author}/{store.storeItems[itemList[slot - 1]].project}";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void authorBtn_Click(object sender, RoutedEventArgs e)
        {
            // Open GitHub page for the author of the current program
            string url = $"https://github.com/{store.storeItems[itemList[slot - 1]].author}";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private async void downloadBtn_Click(object sender, RoutedEventArgs e)
        {
            // Download the file asynchronously, then set the label saying it's done
            downloadBtn.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Visible;
            await Task.Run(async () =>
            {
                using var client = new HttpClient();
                using var s = await client.GetStreamAsync(store.storeItems[itemList[slot - 1]].downloadURL);
                using var fs = new FileStream(Path.Combine(deskFolderPath, store.storeItems[itemList[slot - 1]].file), FileMode.OpenOrCreate);
                await s.CopyToAsync(fs);
            });
            label1.Content = "Download Complete";
        }
    }
}

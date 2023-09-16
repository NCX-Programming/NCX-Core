using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for XStoreHome.xaml
    /// </summary>
    public partial class XStoreHome : Page
    {
        static readonly string docFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

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

        public XStoreHome()
        {
            InitializeComponent();
            Button[] buttonArray = { prgmBtn1, prgmBtn2, prgmBtn3, prgmBtn4 };
            if (Settings1.Default.lightTheme == true)
            {
                Background = Brushes.White;
                label1.Foreground = Brushes.Black; label2.Foreground = Brushes.Black; XWareBtn.Foreground = Brushes.Black;
            }
            // Make sure XStore.json exists before we try to read it
            // TODO: Actually like, handle this? If it doesn't exist just nothing will happen, but we should probably obtain it
            if (File.Exists(Path.Combine(docFolderPath, "NCX-Core/XStore.json")))
            {
                // Parse XStore.json and build dictionaries and dictionary array
                string json = File.ReadAllText(Path.Combine(docFolderPath, "NCX-Core/XStore.json"));
                Store store = JsonSerializer.Deserialize<Store>(json);
                string[] itemList = store.storeItems.Keys.ToArray();
                // Iterate over existing icons and set the buttons in the store to them
                for (int i = 0; i < itemList.Length; i++)
                {
                    var brush = new ImageBrush();
                    FileStream f = File.OpenRead(Path.Combine(docFolderPath, $"NCX-Core/slot{i+1}.png"));
                    var imageSource = new BitmapImage();
                    imageSource.BeginInit();
                    imageSource.StreamSource = f;
                    imageSource.EndInit();
                    brush.ImageSource = imageSource;
                    // Reveal button and then paint it, that way only needed buttons appear
                    buttonArray[i].Visibility = Visibility.Visible;
                    buttonArray[i].Background = brush;
                    // Set the tooltip to the name of the program
                    buttonArray[i].ToolTip = store.storeItems[itemList[i]].name;
                }
            }
            else
            {
                //Error errPage = new Error(1);
                //NavigationService.Navigate(errPage);
                NavigationService.Navigate(new ErrorPage(0));
            }
        }

        private void prgmBtn1_Click(object sender, RoutedEventArgs e)
        {
            XStorePage page = new XStorePage(1);
            NavigationService.Navigate(page);
        }

        private void prgmBtn2_Click(object sender, RoutedEventArgs e)
        {
            XStorePage page = new XStorePage(2);
            NavigationService.Navigate(page);
        }

        private void prgmBtn3_Click(object sender, RoutedEventArgs e)
        {
            XStorePage page = new XStorePage(3);
            NavigationService.Navigate(page);
        }

        private void prgmBtn4_Click(object sender, RoutedEventArgs e)
        {
            XStorePage page = new XStorePage(4);
            NavigationService.Navigate(page);
        }

        private void XWareBtn_Click(object sender, RoutedEventArgs e)
        {
            XWareHome page = new XWareHome();
            NavigationService.Navigate(page);
        }
    }
}

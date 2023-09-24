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
            Loaded += XStoreHome_Loaded;
        }

        private void XStoreHome_Loaded(object sender, RoutedEventArgs e)
        {
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
                    FileStream f = File.OpenRead(Path.Combine(docFolderPath, $"NCX-Core/slot{i + 1}.png"));
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
                /* Throw error 01 (XStore File Error), because the XStore.json file probably doesn't exist. Yes, we could (and probably should) try 
                 * and get it, but it's easier to just tell the user to restart NCX-Core and let it fix itself since it always downloads it. */
                NavigationService.Navigate(new ErrorPage(1));
            }
        }

        /* The following are the buttons that are actually asigned the programs in the store. When you click one, it sends you to XStorePage
         * with the context of which one you pressed. There could be some confusion here because these numbers are lowered by one in most of the
         * code that actually uses them since the actual array they refer to starts at 0, but having them be 1-4 here makes the UI easier to work
         * with in my opinion. */
        private void prgmBtn1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new XStorePage(1));
        }

        private void prgmBtn2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new XStorePage(2));
        }

        private void prgmBtn3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new XStorePage(3));
        }

        private void prgmBtn4_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new XStorePage(4));
        }

        private void XWareBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new XWareHome());
        }
    }
}

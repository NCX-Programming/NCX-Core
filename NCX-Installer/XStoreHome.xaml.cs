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
using System.Net.Http;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for XStoreHome.xaml
    /// </summary>
    public partial class XStoreHome : Page
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string icon;
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

        public XStoreHome()
        {
            InitializeComponent();
            Button[] buttonArray = { tmpbtn1, tmpbtn2, tmpbtn3, tmpbtn4 };
            if (Settings1.Default.lightTheme == true)
            {
                this.Background = Brushes.White;
                label1.Foreground = Brushes.Black; label2.Foreground = Brushes.Black; btn6.Foreground = Brushes.Black;
            }
            if (File.Exists(Path.Combine(SavePath, "NCX-Core/XStore.json")))
            {
                string json = File.ReadAllText(Path.Combine(SavePath, "NCX-Core/XStore.json"));
                Store store = JsonSerializer.Deserialize<Store>(json);
                string[] itemList = store.storeItems.Keys.ToArray();
                Console.WriteLine($"{store.storeItems[itemList[0]].name}");
                for (int i = 0; i < itemList.Length; i++)
                {
                    var brush = new ImageBrush();
                    FileStream f = File.OpenRead(Path.Combine(SavePath, $"NCX-Core/slot{i+1}.png"));
                    var imageSource = new BitmapImage();
                    imageSource.BeginInit();
                    imageSource.StreamSource = f;
                    imageSource.EndInit();
                    brush.ImageSource = imageSource;
                    buttonArray[i].Background = brush;
                    buttonArray[i].ToolTip = store.storeItems[itemList[i]].name;
                }

                /*string json = File.ReadAllText(Path.Combine(SavePath, "NCX-Core/XStore.json"));
                Store store = JsonSerializer.Deserialize<Store>(json);

                if (store.name4 == "")
                {
                    tmpbtn4.Visibility = Visibility.Hidden;
                }

                tmpbtn1.ToolTip = store.name1;
                slot = 1;
                LoadIcon();*/
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            NavSettings.Default.slot = 1;
            XSC64TL page = new XSC64TL();
            NavigationService.Navigate(page);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            NavSettings.Default.slot = 3;
            XSC64TL page = new XSC64TL();
            NavigationService.Navigate(page);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            NavSettings.Default.slot = 2;
            XSC64TL page = new XSC64TL();
            NavigationService.Navigate(page);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            NavSettings.Default.slot = 4;
            XSC64TL page = new XSC64TL();
            NavigationService.Navigate(page);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XWareHome page = new XWareHome();
            NavigationService.Navigate(page);
        }
    }
}

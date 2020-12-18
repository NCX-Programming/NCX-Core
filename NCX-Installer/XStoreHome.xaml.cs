using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
using System.IO.Compression;
using Newtonsoft.Json;
using System.Windows.Resources;

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
            public string name1 { get; set; }
            public string auth1 { get; set; }
            public string desc1 { get; set; }
            public string icon1 { get; set; }
            public string down1 { get; set; }
            public string file1 { get; set; }
        }

        public XStoreHome()
        {
            InitializeComponent();
            if (Settings1.Default.lightTheme == true)
            {
                this.Background = Brushes.White;
                label1.Foreground = Brushes.Black; label2.Foreground = Brushes.Black; btn6.Foreground = Brushes.Black;
            }
            if (File.Exists(System.IO.Path.Combine(SavePath, "XStore.json")))
            {
                string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "XStore.json"));
                Store store = JsonConvert.DeserializeObject<Store>(json);

                slot = 1;
                DownloadIcon(store.icon1);
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            XSCSharpCol page = new XSCSharpCol();
            NavigationService.Navigate(page);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            XSDSiD page = new XSDSiD();
            NavigationService.Navigate(page);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            XSC64TL page = new XSC64TL();
            NavigationService.Navigate(page);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XWareHome page = new XWareHome();
            NavigationService.Navigate(page);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            MainMenu page = new MainMenu();
            NavigationService.Navigate(page);
        }

        private void btn3_Click_1(object sender, RoutedEventArgs e)
        {
            Library page = new Library();
            NavigationService.Navigate(page);
        }

        private void btn1_Click_1(object sender, RoutedEventArgs e)
        {
            Settings page = new Settings();
            NavigationService.Navigate(page);
        }

        private void btn2_Click_1(object sender, RoutedEventArgs e)
        {
            About page = new About();
            NavigationService.Navigate(page);
        }

        public void DownloadIcon(string link)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri($"{link}"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, $"NCX-Core/slot{slot}.png")
                );
            }
        }

        public void DownloadCompleted(object sender, EventArgs e)
        {
            // icon = System.IO.Path.Combine(SavePath, $"NCX-Core/slot1.png");
            Uri resourceUri = new Uri(System.IO.Path.Combine(SavePath, $"NCX-Core/slot1.png"), UriKind.Absolute);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = temp;
            switch (slot) {
                case 1:
                    tmpbtn1.Background = brush;
                    break;
                case 2:
                    tmpbtn2.Background = brush;
                    break;
                case 3: 
                    tmpbtn3.Background = brush;
                    break;
            } 
        }
    }
}

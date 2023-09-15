using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Net;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for XSC64TL.xaml
    /// </summary>
    public partial class XSC64TL : Page
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static readonly string SavePath2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public int slot;
        public string downloadloc;
        public string filename;

        public class Store
        {
            public string name1 { get; set; }
            public string auth1 { get; set; }
            public string proj1 { get; set; }
            public string desc1 { get; set; }
            public string icon1 { get; set; }
            public string down1 { get; set; }
            public string beta1 { get; set; }
            public string file1 { get; set; }
            public string name2 { get; set; }
            public string auth2 { get; set; }
            public string proj2 { get; set; }
            public string desc2 { get; set; }
            public string icon2 { get; set; }
            public string down2 { get; set; }
            public string file2 { get; set; }
            public string name3 { get; set; }
            public string auth3 { get; set; }
            public string proj3 { get; set; }
            public string desc3 { get; set; }
            public string icon3 { get; set; }
            public string down3 { get; set; }
            public string file3 { get; set; }
            public string name4 { get; set; }
            public string auth4 { get; set; }
            public string proj4 { get; set; }
            public string desc4 { get; set; }
            public string icon4 { get; set; }
            public string down4 { get; set; }
            public string file4 { get; set; }
        }

        public XSC64TL()
        {
            InitializeComponent();
            try
            {
                string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "NCX-Core/XStore.json"));
                Store store = JsonConvert.DeserializeObject<Store>(json);
                slot = NavSettings.Default.slot;
                if (Settings1.Default.lightTheme == true)
                {
                    this.Background = Brushes.White;
                    label1.Foreground = Brushes.Black; label2.Foreground = Brushes.Black; label3.Foreground = Brushes.Black;
                }
                if (Settings1.Default.betaVer == true)
                {
                    btn8.Visibility = Visibility.Visible;
                    btn10.Visibility = Visibility.Visible;
                    btn11.Visibility = Visibility.Hidden;
                }
                if (slot == 1) label4.Content = store.name1;
                if (slot == 2) label4.Content = store.name2;
                if (slot == 3) label4.Content = store.name3;
                if (slot == 4) label4.Content = store.name4;

                if (slot == 1) label3.Content = store.auth1;
                if (slot == 2) label3.Content = store.auth2;
                if (slot == 3) label3.Content = store.auth3;
                if (slot == 4) label3.Content = store.auth4;

                if (slot == 1) label2.Text = store.desc1;
                if (slot == 2) label2.Text = store.desc2;
                if (slot == 3) label2.Text = store.desc3;
                if (slot == 4) label2.Text = store.desc4;

                var brush = new ImageBrush();
                FileStream f = File.OpenRead(System.IO.Path.Combine(SavePath, $"NCX-Core/slot{slot}.png"));
                var imageSource = new BitmapImage();
                imageSource.BeginInit();
                imageSource.StreamSource = f;
                imageSource.EndInit();

                img1.Source = imageSource;
            }
            catch(Exception)
            {
                NavSettings.Default.errorcode = 2;
                NavSettings.Default.Save();
                Error page = new Error();
                NavigationService.Navigate(page);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "NCX-Core/XStore.json"));
            Store store = JsonConvert.DeserializeObject<Store>(json);
            string url = "";
            switch (slot)
            {
                case 1:
                    url = $"https://github.com/{store.auth1}/{store.proj1}";
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    break;
                case 2:
                    url = $"https://github.com/{store.auth2}/{store.proj2}";
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    break;
                case 3:
                    url = $"https://github.com/{store.auth3}/{store.proj3}";
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "NCX-Core/XStore.json"));
            Store store = JsonConvert.DeserializeObject<Store>(json);
            string url = "";
            switch (slot)
            {
                case 1:
                    url = $"https://github.com/{store.auth1}";
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    break;
                case 2:
                    url = $"https://github.com/{store.auth2}";
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    break;
                case 3:
                    url = $"https://github.com/{store.auth3}";
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    break; 
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            XStoreHome page = new XStoreHome();
            NavigationService.Navigate(page);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "NCX-Core/XStore.json"));
            Store store = JsonConvert.DeserializeObject<Store>(json);
            switch (slot)
            {
                case 1:
                    downloadloc = store.down1;
                    filename = store.file1;
                    break;
                case 2:
                    downloadloc = store.down2;
                    filename = store.file2;
                    break;
                case 3:
                    downloadloc = store.down3;
                    filename = store.file3;
                    break;
            }
            using (WebClient wc = new WebClient())
            {
                btn8.Visibility = Visibility.Hidden;
                btn10.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Visible;
                progressBar1.Visibility = Visibility.Visible;
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri(downloadloc),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath2, filename)
                );
            }
        }

        public void DownloadCompleted(object sender, EventArgs e)
        {
            label1.Content = "Download Complete";
            Directory.SetCurrentDirectory(SavePath);
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            img1.Source = (ImageSource)FindResource("image1");
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            img1.Source = (ImageSource)FindResource("image2");
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            MainMenu page = new MainMenu();
            NavigationService.Navigate(page);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Library page = new Library();
            NavigationService.Navigate(page);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            XStoreHome page = new XStoreHome();
            NavigationService.Navigate(page);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            About page = new About();
            NavigationService.Navigate(page);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            Settings page = new Settings();
            NavigationService.Navigate(page);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                btn11.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Visible;
                progressBar1.Visibility = Visibility.Visible;
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/IanSkinner1982/C64-title-loader/releases/latest/download/loader.d64"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "loader.d64")
                );
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                btn8.Visibility = Visibility.Hidden;
                btn10.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Visible;
                progressBar1.Visibility = Visibility.Visible;
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://ncx-programming.github.io/ncxprogramming.github.io/loader-nightly.d64"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "loader-nightly.d64")
                );
            }
        }

        private void btn13_Click(object sender, RoutedEventArgs e)
        {
            img1.Source = (ImageSource)FindResource("image3");
        }
    }
}

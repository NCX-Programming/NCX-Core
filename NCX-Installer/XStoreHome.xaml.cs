using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Text.Json;

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
            public string beta1 { get; set; }
            public string file1 { get; set; }
            public string name2 { get; set; }
            public string auth2 { get; set; }
            public string desc2 { get; set; }
            public string icon2 { get; set; }
            public string down2 { get; set; }
            public string file2 { get; set; }
            public string name3 { get; set; }
            public string auth3 { get; set; }
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

        public XStoreHome()
        {
            InitializeComponent();
            if (Settings1.Default.lightTheme == true)
            {
                this.Background = Brushes.White;
                label1.Foreground = Brushes.Black; label2.Foreground = Brushes.Black; btn6.Foreground = Brushes.Black;
            }
            try
            {
                if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/XStore.json")))
                {
                    string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "NCX-Core/XStore.json"));
                    Store store = JsonSerializer.Deserialize<Store>(json);

                    if (store.name4 == "")
                    {
                        tmpbtn4.Visibility = Visibility.Hidden;
                    }

                    tmpbtn1.ToolTip = store.name1;
                    slot = 1;
                    LoadIcon();
                }
            }
            catch (Exception)
            {
                NavSettings.Default.errorcode = 1;
                NavSettings.Default.Save();
                Error page = new Error();
                NavigationService.Navigate(page);
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

        public void LoadIcon()
        {
            string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "NCX-Core/XStore.json"));
            Store store = JsonSerializer.Deserialize<Store>(json);

            try
            {
                var brush = new ImageBrush();
                FileStream f = File.OpenRead(System.IO.Path.Combine(SavePath, $"NCX-Core/slot{slot}.png"));
                var imageSource = new BitmapImage();
                imageSource.BeginInit();
                imageSource.StreamSource = f;
                imageSource.EndInit();
                brush.ImageSource = imageSource;
                switch (slot)
                {
                    case 1:
                        tmpbtn1.Background = brush;
                        if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/slot2.png")))
                        {
                            tmpbtn2.ToolTip = store.name2;
                            slot = 2;
                            LoadIcon();
                        }
                        break;
                    case 2:
                        tmpbtn2.Background = brush;
                        if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/slot3.png")))
                        {
                            tmpbtn3.ToolTip = store.name3;
                            slot = 3;
                            LoadIcon();
                        }
                        break;
                    case 3:
                        tmpbtn3.Background = brush;
                        if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/slot4.png")))
                        {
                            tmpbtn4.ToolTip = store.name4;
                            slot = 4;
                            LoadIcon();
                        }
                        break;
                    case 4:
                        tmpbtn4.Background = brush;
                        break;
                }
            }
            catch (Exception)
            {
                NavSettings.Default.errorcode = 1;
                NavSettings.Default.Save();
                Error page = new Error();
                NavigationService.Navigate(page);
            }
        }
    }
}

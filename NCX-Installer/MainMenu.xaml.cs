using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using Newtonsoft.Json;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string newstext;
        public string banner;
        public string navigation;

        public class Menu
        {
            public string Featured { get; set; }
            public string New1 { get; set; }
            public string New2 { get; set; }
            public string New3 { get; set; }
        }

        public MainMenu()
        {
            InitializeComponent();
            if (Settings1.Default.name != "")
            {
                label1.Content = "Welcome back, " + Settings1.Default.name + "!";
            }
            else if (Settings1.Default.name == "")
            {
                label1.Content = "Welcome back!";
            }
            if (Settings1.Default.lightTheme == true)
            {
                this.Background = Brushes.White;
                label1.Foreground = Brushes.Black; label2.Foreground = Brushes.Black; label6.Foreground = Brushes.Black; 
            }
            if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/newsLatest.txt")))
            {
                TextReader tr = new StreamReader(System.IO.Path.Combine(SavePath, "NCX-Core/newsLatest.txt"));
                string newsString = tr.ReadLine();
                newstext = Convert.ToString(newsString);
                tr.Close();
                label2.Text = newsString;
            }
                if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/ncxCoreMainMenu.json")))
                {
                    string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "NCX-Core/ncxCoreMainMenu.json"));
                    Menu menu = JsonConvert.DeserializeObject<Menu>(json);

                    switch (menu.Featured)
                    {
                        case "cscol":
                            banner = "image/csharpcol.png";
                            break;
                        case "ncxnewsplus":
                            banner = "image/banner/ncxnewsplus.png";
                            break;
                        case "c64titleloader":
                            banner = "image/c64titleloader.png";
                            break;
                        case "dsidownloader":
                            banner = "image/dsidownloader.png";
                            break;
                        case "coreupdater":
                            banner = "image/coreupdater.png";
                            break;
                        default:
                            btn4.Content = "An error has occured while loading the featured program.";
                            break;
                    }

                    Uri resourceUri = new Uri(banner, UriKind.Relative);
                    StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                    BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                    var brush = new ImageBrush();
                    brush.ImageSource = temp;

                    btn4.Background = brush;
                }
                if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe")))
                {
                    btn10.Visibility = Visibility.Visible;
                }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "NCX-Core/ncxCoreMainMenu.json"));
            Menu menu = JsonConvert.DeserializeObject<Menu>(json);

            switch (menu.Featured)
            {
                case "ncxnewsplus":
                    XWareNews page2 = new XWareNews();
                    NavigationService.Navigate(page2);
                    break;
                case "c64titleloader":
                    XSC64TL page3 = new XSC64TL();
                    NavigationService.Navigate(page3);
                    break;
                case "coreupdater":
                    XWareUpdater page5 = new XWareUpdater();
                    NavigationService.Navigate(page5);
                    break;
                default:
                    btn4.Content = "An error has occured while loading the featured program.";
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe")))
            {
                Process.Start(System.IO.Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe"));
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (File.Exists(System.IO.Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe")))
            {
                Process.Start(System.IO.Path.Combine(SavePath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe"));
            }
        }
    }
}

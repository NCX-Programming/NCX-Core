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
using System.Windows.Resources;
using System.Windows.Shapes;
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
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/NCX-Installer-News/releases/latest/download/newsLatest.txt"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "newsLatest.txt")
                );
            }
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted2;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/ncx-core-files/releases/latest/download/ncxCoreMainMenu.json"),
                    // Param2 = Path to save
                    System.IO.Path.Combine(SavePath, "ncxCoreMainMenu.json")
                );
            }
        }

        public void DownloadCompleted(object sender, EventArgs e)
        {
            TextReader tr = new StreamReader(System.IO.Path.Combine(SavePath, "newsLatest.txt"));
            string newsString = tr.ReadLine();
            newstext = Convert.ToString(newsString);
            tr.Close();
            label2.Text = newsString;
        }

        public void DownloadCompleted2(object sender, EventArgs e)
        {
            string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "ncxCoreMainMenu.json"));
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

            switch (menu.New1)
            {
                case "cscol":
                    banner = "image/csharpcol.png";
                    label3.Text = "CSharp Collection";
                    break;
                case "ncxnewsplus":
                    banner = "image/ncxnewsplus.png";
                    label3.Text = "NCX-News+";
                    break;
                case "c64titleloader":
                    banner = "image/c64titleloader.png";
                    label3.Text = "C64 Title Loader";
                    break;
                case "dsidownloader":
                    banner = "image/dsidownloader.png";
                    label3.Text = "lazy-dsi-file-downloader";
                    break;
                case "coreupdater":
                    banner = "image/coreupdater.png";
                    label3.Text = "NCX-Core Updater";
                    break;
                default:
                    btn4.Content = "An error has occured while loading the featured program.";
                    break;
            }

            Uri resourceUri2 = new Uri(banner, UriKind.Relative);
            StreamResourceInfo streamInfo2 = Application.GetResourceStream(resourceUri2);

            BitmapFrame temp2 = BitmapFrame.Create(streamInfo2.Stream);
            var brush2 = new ImageBrush();
            brush2.ImageSource = temp2;

            btn5.Background = brush2;

            switch (menu.New2)
            {
                case "cscol":
                    banner = "image/csharpcol.png";
                    label4.Text = "CSharp Collection";
                    break;
                case "ncxnewsplus":
                    banner = "image/ncxnewsplus.png";
                    label4.Text = "NCX-News+";
                    break;
                case "c64titleloader":
                    banner = "image/c64titleloader.png";
                    label4.Text = "C64 Title Loader";
                    break;
                case "dsidownloader":
                    banner = "image/dsidownloader.png";
                    label4.Text = "lazy-dsi-file-downloader";
                    break;
                case "coreupdater":
                    banner = "image/coreupdater.png";
                    label4.Text = "NCX-Core Updater";
                    break;
                default:
                    btn4.Content = "An error has occured while loading the featured program.";
                    break;
            }

            Uri resourceUri3 = new Uri(banner, UriKind.Relative);
            StreamResourceInfo streamInfo3 = Application.GetResourceStream(resourceUri3);

            BitmapFrame temp3 = BitmapFrame.Create(streamInfo3.Stream);
            var brush3 = new ImageBrush();
            brush3.ImageSource = temp3;

            btn6.Background = brush3;

            switch (menu.New3)
            {
                case "cscol":
                    banner = "image/csharpcol.png";
                    label5.Text = "CSharp Collection";
                    break;
                case "ncxnewsplus":
                    banner = "image/ncxnewsplus.png";
                    label5.Text = "NCX-News+";
                    break;
                case "c64titleloader":
                    banner = "image/c64titleloader.png";
                    label5.Text = "C64 Title Loader";
                    break;
                case "dsidownloader":
                    banner = "image/dsidownloader.png";
                    label5.Text = "lazy-dsi-file-downloader";
                    break;
                case "coreupdater":
                    banner = "image/coreupdater.png";
                    label5.Text = "NCX-Core Updater";
                    break;
                default:
                    btn4.Content = "An error has occured while loading the featured program.";
                    break;
            }

            Uri resourceUri4 = new Uri(banner, UriKind.Relative);
            StreamResourceInfo streamInfo4 = Application.GetResourceStream(resourceUri4);

            BitmapFrame temp4 = BitmapFrame.Create(streamInfo4.Stream);
            var brush4 = new ImageBrush();
            brush4.ImageSource = temp4;

            btn7.Background = brush4;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "ncxCoreMainMenu.json"));
            Menu menu = JsonConvert.DeserializeObject<Menu>(json);

            switch (menu.Featured)
            {
                case "cscol":
                    XSCSharpCol page = new XSCSharpCol();
                    NavigationService.Navigate(page);
                    break;
                case "ncxnewsplus":
                    XWareNews page2 = new XWareNews();
                    NavigationService.Navigate(page2);
                    break;
                case "c64titleloader":
                    XSC64TL page3 = new XSC64TL();
                    NavigationService.Navigate(page3);
                    break;
                case "dsidownloader":
                    XSDSiD page4 = new XSDSiD();
                    NavigationService.Navigate(page4);
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

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "ncxCoreMainMenu.json"));
            Menu menu = JsonConvert.DeserializeObject<Menu>(json);

            switch (menu.New1)
            {
                case "cscol":
                    XSCSharpCol page = new XSCSharpCol();
                    NavigationService.Navigate(page);
                    break;
                case "ncxnewsplus":
                    XWareNews page2 = new XWareNews();
                    NavigationService.Navigate(page2);
                    break;
                case "c64titleloader":
                    XSC64TL page3 = new XSC64TL();
                    NavigationService.Navigate(page3);
                    break;
                case "dsidownloader":
                    XSDSiD page4 = new XSDSiD();
                    NavigationService.Navigate(page4);
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

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "ncxCoreMainMenu.json"));
            Menu menu = JsonConvert.DeserializeObject<Menu>(json);

            switch (menu.New2)
            {
                case "cscol":
                    XSCSharpCol page = new XSCSharpCol();
                    NavigationService.Navigate(page);
                    break;
                case "ncxnewsplus":
                    XWareNews page2 = new XWareNews();
                    NavigationService.Navigate(page2);
                    break;
                case "c64titleloader":
                    XSC64TL page3 = new XSC64TL();
                    NavigationService.Navigate(page3);
                    break;
                case "dsidownloader":
                    XSDSiD page4 = new XSDSiD();
                    NavigationService.Navigate(page4);
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

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(System.IO.Path.Combine(SavePath, "ncxCoreMainMenu.json"));
            Menu menu = JsonConvert.DeserializeObject<Menu>(json);

            switch (menu.New3)
            {
                case "cscol":
                    XSCSharpCol page = new XSCSharpCol();
                    NavigationService.Navigate(page);
                    break;
                case "ncxnewsplus":
                    XWareNews page2 = new XWareNews();
                    NavigationService.Navigate(page2);
                    break;
                case "c64titleloader":
                    XSC64TL page3 = new XSC64TL();
                    NavigationService.Navigate(page3);
                    break;
                case "dsidownloader":
                    XSDSiD page4 = new XSDSiD();
                    NavigationService.Navigate(page4);
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
    }
}

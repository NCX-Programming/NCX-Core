using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Text.Json;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        static readonly string docFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static readonly string userName = Environment.UserName;
        public string banner;
        public string navigation;

        public class Menu
        {
            public string Featured { get; set; }
        }

        public MainMenu()
        {
            InitializeComponent();
            // Load saved name, if there is one, if not use the current Windows user's name
            if (Settings1.Default.name != "")
            {
                welcomeLbl.Content = "Welcome back, " + Settings1.Default.name + "!";
            }
            else
            {
                welcomeLbl.Content = "Welcome back, " + userName + "!";
            }
            if (Settings1.Default.lightTheme == true)
            {
                Background = Brushes.White;
                welcomeLbl.Foreground = Brushes.Black; newsText.Foreground = Brushes.Black; label6.Foreground = Brushes.Black; 
            }
            // Read the latest news file, display error message if it can't be found
            if (File.Exists(Path.Combine(docFolderPath, "NCX-Core/newsLatest.txt")))
            {
                TextReader tr = new StreamReader(Path.Combine(docFolderPath, "NCX-Core/newsLatest.txt"));
                string newsString = tr.ReadLine();
                tr.Close();
                newsText.Text = newsString;
            }
            else
            {
                newsText.Text = "NCX-News could not be loaded.";
            }
            // Read the main menu file and load the featured program
            if (File.Exists(Path.Combine(docFolderPath, "NCX-Core/ncxCoreMainMenu.json")))
            {
                string json = File.ReadAllText(Path.Combine(docFolderPath, "NCX-Core/ncxCoreMainMenu.json"));
                Menu menu = JsonSerializer.Deserialize<Menu>(json);
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
                        featuredPgrmBtn.Content = "An error has occured while loading the featured program.";
                        break;
                }
                // Paint the banner on the button for the featured program
                Uri resourceUri = new Uri(banner, UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;
                featuredPgrmBtn.Background = brush;
            }
            // If we can find NCX-News+, offer to launch it
            if (File.Exists(Path.Combine(docFolderPath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe")))
            {
                newsPlusBtn.Visibility = Visibility.Visible;
            }
        }

        private void featuredPgrmBtn_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the page for the featured program
            string json = File.ReadAllText(Path.Combine(docFolderPath, "NCX-Core/ncxCoreMainMenu.json"));
            Menu menu = JsonSerializer.Deserialize<Menu>(json);

            switch (menu.Featured)
            {
                case "ncxnewsplus":
                    XWareNews page2 = new XWareNews();
                    NavigationService.Navigate(page2);
                    break;
                case "coreupdater":
                    XWareUpdater page5 = new XWareUpdater();
                    NavigationService.Navigate(page5);
                    break;
                default:
                    featuredPgrmBtn.Content = "An error has occured while loading the featured program.";
                    break;
            }
        }

        private void newsPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Path.Combine(docFolderPath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe")))
            {
                Process.Start(Path.Combine(docFolderPath, "NCX-Core/NCXNewsPlus/NCXNewsPlus.exe"));
            }
        }
    }
}

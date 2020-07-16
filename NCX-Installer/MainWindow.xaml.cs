using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string newstext;

        public MainWindow()
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
            if (Settings1.Default.arch == true)
            {
                btn9.Visibility = Visibility.Visible;
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
            if (File.Exists("C:/Program Files/NCX/CSharp Collection/CSharpCollectionVol1.exe"))
            {
                btn1.Visibility = Visibility.Visible;
            }
            if (File.Exists("C:/Program Files/NCX/AutoMod/AutoMod.exe"))
            {
                btn2.Visibility = Visibility.Visible;
            }
            if (Settings1.Default.firstTime == true)
            {
                FirstTime1 win = new FirstTime1();
                win.Show();
                win.Topmost = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (File.Exists("C:/Program Files/NCX/CSharp Collection/CSharpCollectionVol1.exe"))
            {
                Process.Start("C:/Program Files/NCX/CSharp Collection/CSharpCollectionVol1.exe");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (File.Exists("C:/Program Files/NCX/AutoMod/AutoMod.exe"))
            {
                Process.Start("C:/Program Files/NCX/AutoMod/AutoMod.exe");
            }
        }

        public void DownloadCompleted(object sender, EventArgs e)
        {
            TextReader tr = new StreamReader(System.IO.Path.Combine(SavePath, "newsLatest.txt"));
            string newsString = tr.ReadLine();
            newstext = Convert.ToString(newsString);
            tr.Close();
            label3.Text = newsString;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
            Hide();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            Updates win = new Updates();
            win.Show();
            Hide();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            Environment.Exit(0);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            About win = new About();
            win.Show();
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            FirstTime2 win = new FirstTime2();
            win.Show();
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            ArchivedProjects win = new ArchivedProjects();
            win.Show();
            Hide();
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            XStore win = new XStore();
            win.Show();
        }
    }
}

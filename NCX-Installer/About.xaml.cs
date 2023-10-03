using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Page
    {
        static readonly string docFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public About()
        {
            InitializeComponent();
            versionLbl.Content = "v" + Settings1.Default.version;
            if (Settings1.Default.lightTheme == true)
            {
                Background = Brushes.White;
                versionLbl.Foreground = Brushes.Black; label2.Foreground = Brushes.Black; label3.Foreground = Brushes.Black;
                label4.Foreground = Brushes.Black; label5.Foreground = Brushes.Black; label6.Foreground = Brushes.Black;
                versionLbl.Foreground = Brushes.Black; updateBtn.Foreground = Brushes.Black;
            }
        }

        private void githubBtn_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/NinjaCheetah/NCX-Core";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(Path.Combine(docFolderPath, "NCX-Core/NCXCoreUpdater/NCX-Core Updater.exe")))
            {
                string message = "As of NCX-Core v3.0, the built-in update menu has been removed. Please install NCX-Core Updater from XStore.\n \nGo to Store > XWare > NCX-Core Updater, then click Install.";
                string caption = "NCX-Core Updater Not Installed";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Exclamation;
                if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.OK)
                {

                }
            }
            else
            {
                if (File.Exists(Path.Combine(docFolderPath, "NCX-Core/NCXCoreUpdater/NCX-Core Updater.exe")))
                {
                    ExecuteAsAdmin(Path.Combine(docFolderPath, "NCX-Core/NCXCoreUpdater/NCX-Core Updater.exe"));
                    string text = Settings1.Default.version;
                    File.WriteAllText(Path.Combine(docFolderPath, "version.txt"), text);
                }
            }
        }

        public void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }
    }
}

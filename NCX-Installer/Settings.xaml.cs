using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            textBox1.Text = Settings1.Default.name;
            checkBox1.IsChecked = Settings1.Default.betaVer;
            checkBox2.IsChecked = Settings1.Default.oldVer;
            if (Settings1.Default.lightTheme == true) radioButton2.IsChecked = true;
            else radioButton1.IsChecked = true;
            if (Settings1.Default.firstTime == false)
            {
                btn7.Visibility = Visibility.Visible;
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            Settings1.Default.firstTime = false;
            Settings1.Default.name = textBox1.Text;
            Settings1.Default.betaVer = (bool)checkBox1.IsChecked;
            Settings1.Default.oldVer = (bool)checkBox2.IsChecked;
            if (radioButton1.IsChecked == true) Settings1.Default.lightTheme = false;
            else if (radioButton2.IsChecked == true) Settings1.Default.lightTheme = true;
            Settings1.Default.Save();

            string message = "Your settings have been saved. Some changes might require a restart to take effect.";
            string caption = "Changes Saved";
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.OK)
            {
                
            }
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            string message = "Are you sure you want to reset your settings? This will change the settings to the default, and then return you to the menu.";
            string caption = "Reset settings?";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Exclamation;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                Settings1.Default.firstTime = true;
                Settings1.Default.name = "";
                Settings1.Default.oldVer = false;
                Settings1.Default.betaVer = false;
                Settings1.Default.arch = false;
                Settings1.Default.Save();

                MainMenu page = new MainMenu();
                NavigationService.Navigate(page);
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Library page = new Library();
            NavigationService.Navigate(page);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            MainMenu page = new MainMenu();
            NavigationService.Navigate(page);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            About page = new About();
            NavigationService.Navigate(page);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            XStoreHome page = new XStoreHome();
            NavigationService.Navigate(page);
        }
    }
}

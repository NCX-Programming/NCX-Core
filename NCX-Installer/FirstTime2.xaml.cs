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
using System.Windows.Shapes;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for FirstTime2.xaml
    /// </summary>
    public partial class FirstTime2 : Window
    {
        public FirstTime2()
        {
            InitializeComponent();
            InitializeComponent();
            textBox1.Text = Settings1.Default.name;
            checkBox1.IsChecked = Settings1.Default.oldVer;
            checkBox2.IsChecked = Settings1.Default.betaVer;
            checkBox3.IsChecked = Settings1.Default.arch;
            if (Settings1.Default.firstTime == false)
            {
                btn2.Visibility = Visibility.Visible;
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Settings1.Default.firstTime = false;
            Settings1.Default.name = textBox1.Text;
            Settings1.Default.oldVer = (bool)checkBox1.IsChecked;
            Settings1.Default.betaVer = (bool)checkBox2.IsChecked;
            Settings1.Default.arch = (bool)checkBox3.IsChecked;
            Settings1.Default.Save();
            btn1.Visibility = Visibility.Hidden;

            string message = "It is recommended that you restart the program after initial setup. Would you like to restart now?";
            string caption = "Restart Recommended";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Information;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            else if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.No)
            {
                string message2 = "Some changes may not take effect until you restart the program.";
                string caption2 = "Restart Recommended";
                MessageBoxButton buttons2 = MessageBoxButton.OK;
                MessageBoxImage icon2 = MessageBoxImage.Exclamation;
                if (MessageBox.Show(message2, caption2, buttons2, icon2) == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            string message = "Are you sure you want to reset your settings? This will restart the program and go through setup again.";
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
                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            else if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.No)
            {
                this.Close();
            }
        }
    }
}

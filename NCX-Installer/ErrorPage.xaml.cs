using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace NCX_Installer
{
    /// <summary>
    /// Interaction logic for ErrorPage.xaml
    /// </summary>
    public partial class ErrorPage : Page
    {

        public ErrorPage(int errCode)
        {
            InitializeComponent();
            switch (errCode)
            {
                default:
                    break;
                case 1:
                    label1.Content = "Error Code: 01 (XStore File Error)";
                    break;
                case 2:
                    label1.Content = "Error Code: 02 (Network Error)";
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
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
    /// Interaction logic for XStore.xaml
    /// </summary>
    public partial class XStore : Window
    {
        public XStore()
        {
            InitializeComponent();
            if (NavSettings.Default.comingFrom == "")
            {
                _NavigationFrame.Navigate(new XStoreHome());
            }
            else if (NavSettings.Default.comingFrom == "cscol")
            {
                NavSettings.Default.comingFrom = "";
                _NavigationFrame.Navigate(new XSCSharpCol());
            }
        }
    }
}

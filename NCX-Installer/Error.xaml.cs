using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Error.xaml
    /// </summary>
    public partial class Error : Page
    {

        public Error()
        {
            InitializeComponent();
            switch (NavSettings.Default.errorcode)
            {
                default:
                    break;
                case 1:
                    label1.Content = "Error Code: 01 (XStore Icon/Title Error)";
                    NavSettings.Default.errorcode = 0;
                    NavSettings.Default.Save();
                    break;
                case 2:
                    label1.Content = "Error Code: 02 (XStore Content Error)";
                    NavSettings.Default.errorcode = 0;
                    NavSettings.Default.Save();
                    break;
            }
        }
    }
}

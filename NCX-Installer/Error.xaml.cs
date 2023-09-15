using System.Windows.Controls;

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

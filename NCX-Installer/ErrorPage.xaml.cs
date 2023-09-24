using System.Windows;
using System.Windows.Controls;
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
        public int errCode;
        public string ErrorData = """"""
        {
          "errorCodesData": {
            "00": {
              "code": "0",
              "errName": "Unhandled Error",
              "errDesc": ""
            },
            "01": {
              "code": "1",
              "errName": "XStore File Error",
              "errDesc": "There may be a problem with your XStore data. If this problem occurs again, try clearing NCX-Core data from Settings."
            },
            "02": {
              "code": "2",
              "errName": "Network Error",
              "errDesc": "You may be offline. Check your internet connection before launching NCX-Core again."
            },
            "03": {
              "code": "3",
              "errName": "Download Error",
              "errDesc": "The download couldn't be completed, and may no longer be available. Please wait a little while and try again."
            }
          }
        }
        """""";

        public class ErrorCodes
        {
            public Dictionary<string, ErrorCodeData> errorCodesData { get; set; }
        }

        public class ErrorCodeData
        {
            public string code { get; set; }
            public string errName { get; set; }
            public string errDesc { get; set; }
        }

        public ErrorPage(int errCodeCtx)
        {
            InitializeComponent();
            errCode = errCodeCtx;
            Loaded += ErrorPage_Loaded;
        }

        private void ErrorPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Create array of dictionaries of store items
            ErrorCodes errCodes = JsonSerializer.Deserialize<ErrorCodes>(ErrorData);
            // Build a list of the available dictionaries
            string[] itemList = errCodes.errorCodesData.Keys.ToArray();
            // Create the string containing the error's code and name, then set it
            string errorCodeLblStr = $"Error Code: {errCodes.errorCodesData[itemList[errCode]].code} ({errCodes.errorCodesData[itemList[errCode]].errName})";
            errCodeLbl.Content = errorCodeLblStr;
            // Load the error's description
            errDesc.Text = errCodes.errorCodesData[itemList[errCode]].errDesc;
        }
    }
}

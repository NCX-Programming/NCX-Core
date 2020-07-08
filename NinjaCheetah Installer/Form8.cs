using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Globalization;

namespace NinjaCheetah_Installer
{
    public partial class Form8 : Form
    {

        public decimal updateNum;

        public Form8()
        {
            InitializeComponent();
        }

        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Visible = true;
            Visible = false;
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Fetching release data...";
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/NCX-Installer/releases/latest/download/NinjaCheetahInstallerSetup.msi"),
                    // Param2 = Path to save
                    Path.Combine(SavePath, "NinjaCheetahInstallerSetup.msi")
                );
            }
        }
        public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start(Path.Combine(SavePath, "NinjaCheetahInstallerSetup.msi"));
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted2;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/NCX-Installer-News/releases/latest/download/updateNotice.txt"),
                    // Param2 = Path to save
                    Path.Combine(SavePath, "updateNotice.txt")
                );
            }
        }

        public void DownloadCompleted2(object sender, AsyncCompletedEventArgs e)
        {
            string text = File.ReadAllText(Path.Combine(SavePath, "updateNotice.txt"));
            updateNum = Decimal.Parse(text);
            label3.Text = "Fetching release data...";
            if (updateNum == Properties.Settings.Default.version)
            {
                label3.Text = "You are using the latest release!";
                button3.Text = "Check again";
            }
            else if (updateNum > Properties.Settings.Default.version)
            {
                label3.Text = "There is an update available: v" + updateNum;
                button1.Visible = true;
                button3.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string message = "Are you sure you would like to uninstall NCX-Installer?";
            string title = "Confirm Uninstallation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Start_Unistall();
            }
            else if (result == DialogResult.No)
            {
                
            }
        }

        public void Start_Unistall()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            label4.Visible = true;
            if (File.Exists(Path.Combine(SavePath, "updateNotice.txt")))
            {
                File.Delete(Path.Combine(SavePath, "updateNotice.txt"));
            }
            if (File.Exists(Path.Combine(SavePath, "newsLatest.txt")))
            {
                File.Delete(Path.Combine(SavePath, "newsLatest.txt"));
            }
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted3;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/NCX-Installer/releases/latest/download/NinjaCheetahInstallerSetup.msi"),
                    // Param2 = Path to save
                    Path.Combine(SavePath, "NinjaCheetahInstallerSetup.msi")
                );
            }
        }

        public void DownloadCompleted3(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start(Path.Combine(SavePath, "NinjaCheetahInstallerSetup.msi"));
            label4.Text = "Uninstallation Started.";
            string message = "Thank you for using NCX-Installer. We will miss you!";
            string title = "Goodbye!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}

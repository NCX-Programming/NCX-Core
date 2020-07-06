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
    }
}

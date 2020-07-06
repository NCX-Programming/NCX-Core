using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace NinjaCheetah_Installer
{
    public partial class Form9 : Form
    {
        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public Form9()
        {
            InitializeComponent();
            if (File.Exists("C:/Program Files/NCX/AutoMod/AutoMod.exe"))
            {
                label4.Visible = true;
                button4.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Visible = true;
            Visible = false;
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/automod-rewrite/releases/latest/download/AutoModSetup.msi"),
                    // Param2 = Path to save
                    Path.Combine(SavePath, "AutoModSetup.msi")
                );
            }
        }
        public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start(Path.Combine(SavePath, "AutoModSetup.msi"));
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("C:/Program Files/NCX/AutoMod/AutoMod.exe");
        }
    }   
}

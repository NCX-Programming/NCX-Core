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
using System.Diagnostics;
using System.Threading;

namespace NinjaCheetah_Installer
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

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

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/CSharp-Collection-Vol1/releases/latest/download/CSharpCollectionVol1Latest.zip"),
                    // Param2 = Path to save
                    Path.Combine(SavePath, "CSharpCollectionVol1Latest.zip")
                );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/CSharp-Collection-Vol1/releases/latest/download/CSharpCollectionSetup.msi"),
                    // Param2 = Path to save
                    Path.Combine(SavePath, "CSharpCollectionSetup.msi")
                );
            }
        }
        public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start(Path.Combine(SavePath, "CSharpCollectionSetup.msi"));
        }
    }
}

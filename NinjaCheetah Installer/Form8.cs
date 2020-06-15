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

namespace NinjaCheetah_Installer
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

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
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/NinjaCheetah-Installer/releases/latest/download/NinjaCheetahInstallerSetup.msi"),
                    // Param2 = Path to save
                    Path.Combine(SavePath, "NinjaCheetahInstallerSetup.msi")
                );
            }

            Thread.Sleep(5000);
            Process.Start(Path.Combine(SavePath, "NinjaCheetahInstallerSetup.msi"));
        }
    }
}

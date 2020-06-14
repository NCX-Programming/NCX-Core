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

namespace NinjaCheetah_Installer
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/AutoMod/releases/latest/download/AutoModLatest.zip"),
                    // Param2 = Path to save
                    Path.Combine(SavePath,"AutoModLatest.zip")
                );
            }
        }
        // Event to track the progress
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Visible = true;
            Visible = false;
        }
    }
}

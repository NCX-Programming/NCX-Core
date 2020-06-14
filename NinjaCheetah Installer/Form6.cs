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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Visible = true;
            Visible = false;
        }

        // Event to track the progress
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/VisualBasic-Collection-Vol.1/releases/latest/download/VBCollectionVol1Latest.zip"),
                    // Param2 = Path to save
                    Path.Combine(SavePath, "VBCollectionVolLatest.zip")
                );
            }
        }
    }
}

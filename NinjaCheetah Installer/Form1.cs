using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NinjaCheetah_Installer
{
    public partial class Form1 : Form
    {

        static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string newstext;

        public Form1()
        {
            InitializeComponent();
            button3.TabStop = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button7.TabStop = false;
            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;
            button8.TabStop = false;
            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 0;
            if (Properties.Settings.Default.firstTime == true)
            {
                Form11 f = new Form11();
                f.Visible = true;
                f.TopMost = true;
            } 
            if (Properties.Settings.Default.name != "")
            {
                label1.Text = "Welcome back, " + Properties.Settings.Default.name + "!";
            }
            else if (Properties.Settings.Default.name == "")
            {
                label1.Text = "Welcome back!";
            }
            if (Properties.Settings.Default.arch == true)
            {
                button2.Visible = true;
            }
            label4.Text = "Fetching news... Please wait.";
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += DownloadCompleted;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/NinjaCheetah/NCX-Installer-News/releases/latest/download/newsLatest.txt"),
                    // Param2 = Path to save
                    Path.Combine(SavePath, "newsLatest.txt")
                );
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Visible = true;
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Visible = true;
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Visible = true;
            Visible = false;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10();
            f.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form13 f = new Form13();
            f.Visible = true;
            Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Visible = true;
            Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.Visible = true;
            Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form12 f = new Form12();
            f.Visible = true;
        }

        public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            TextReader tr = new StreamReader(Path.Combine(SavePath, "newsLatest.txt"));
            string newsString = tr.ReadLine();
            newstext = Convert.ToString(newsString);
            tr.Close();
            label4.Text = newsString;
        }
    }
}

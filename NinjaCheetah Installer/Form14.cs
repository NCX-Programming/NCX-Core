using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NinjaCheetah_Installer
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button3.TabStop = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 1;
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Visible = true;
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("C:/Program Files/NCX/CSharp Collection/CSharpCollectionVol1.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("C:/Program Files/NCX/AutoMod/AutoMod.exe");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Visible = true;
            Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.Visible = true;
            Visible = false;
        }
    }
}

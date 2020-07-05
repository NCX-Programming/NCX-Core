using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NinjaCheetah_Installer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form11 f = new Form11();
            f.Visible = true;
            f.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Visible = true;
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Visible = true;
            Visible = false;
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
    }
}

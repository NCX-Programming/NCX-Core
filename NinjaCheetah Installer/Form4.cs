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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Visible = true;
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Visible = true;
            Visible = false;
        }
    }
}

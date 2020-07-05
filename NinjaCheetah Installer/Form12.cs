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
using System.Threading;

namespace NinjaCheetah_Installer
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.name;
            checkBox1.Checked = Properties.Settings.Default.oldVer;
            checkBox2.Checked = Properties.Settings.Default.betaVer;
            checkBox3.Checked = Properties.Settings.Default.arch;
            if (Properties.Settings.Default.firstTime == false) {
                button2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.firstTime = false;
            Properties.Settings.Default.name = textBox1.Text;
            Properties.Settings.Default.oldVer = checkBox1.Checked;
            Properties.Settings.Default.betaVer = checkBox2.Checked;
            Properties.Settings.Default.arch = checkBox3.Checked;
            Properties.Settings.Default.Save();
            Visible = false;

            string message = "It is reccomended that you restart the program after initial setup. Would you like to restart now?";
            string title = "Restart";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Application.Restart();
            }
            else if (result == DialogResult.No)
            {

                string message2 = "Some changes may not take effect until you restart the program.";
                string title2 = "Notice";
                MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Exclamation);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to reset your settings? This will restart the program and go through setup again.";
            string title = "Reset settings?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.firstTime = true;
                Properties.Settings.Default.name = "";
                Properties.Settings.Default.oldVer = false;
                Properties.Settings.Default.betaVer = false;
                Properties.Settings.Default.arch = false;
                Properties.Settings.Default.Save();
                this.Close();
                Application.Restart();
            }
            else if (result == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myFirstAoo
{
    public partial class MenuExample : Form
    {
        public MenuExample()
        {
            InitializeComponent();
        }

        private void page1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBoxExample pbe = new PictureBoxExample();
            pbe.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openPage2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBoxExample pbe = new PictureBoxExample();
            pbe.Show();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "This is a panel";
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 100; i++)
			{
               
                toolStripProgressBar1.Value = i;
			}
           
        }
    }
}

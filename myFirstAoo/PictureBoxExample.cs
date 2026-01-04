using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myFirstAoo
{
    public partial class PictureBoxExample : Form
    {
        public PictureBoxExample()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                
                textBox1.Text = openFileDialog1.FileName;
                Image i = new Bitmap(textBox1.Text);
                pictureBox1.Image = i;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                File.Copy(textBox1.Text, Application.StartupPath + "\\b.jpg");
                MessageBox.Show("Copied");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myFirstAoo
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            checkBoxExample obj = new checkBoxExample();
            obj.Show();
        }

        private void radioBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            radioExample obj = new radioExample();
            obj.Show();
        }

        private void comboBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            comboExample obj = new comboExample();
            obj.Show();
        }

        private void mainBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow obj = new MainWindow();
            obj.Show();
        }

        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}

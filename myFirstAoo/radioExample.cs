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
    public partial class radioExample : Form
    {
        public radioExample()
        {
            InitializeComponent();
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            if (maleRB.Checked)
            {
                displayLabel.Text = "Your name is " + nameTXt.Text + " and your gender is Male";
            }
            else if(femaleRB.Checked)
            {
                displayLabel.Text = "Your name is " + nameTXt.Text + " and your gender is " + femaleRB.Text;
            }
        }

        private void maleRB_CheckedChanged(object sender, EventArgs e)
        {
            if (maleRB.Checked)
            {
                MessageBox.Show("Hi I am male");
            }
            else
            {
                MessageBox.Show("Female selected");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            home obj = new home();
            obj.Show();
        }

      
       
    }
}

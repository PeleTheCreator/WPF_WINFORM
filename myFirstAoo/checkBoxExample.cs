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
    public partial class checkBoxExample : Form
    {
        public checkBoxExample()
        {
            InitializeComponent();
        }
        float sum = 0;
        private void calc(ListBox lb,CheckBox x,float price,Label result)
        {
            if (x.Checked)
            {
                lb.Items.Add(x.Text);
                sum += price;
                result.Text = sum.ToString();
            }
            else
            {
                lb.Items.Remove(x.Text);
                sum -= price;
                result.Text = sum.ToString();
            }
        }
        private void interCB_CheckedChanged(object sender, EventArgs e)
        {
            calc(servicesLB, interCB, 500, billLabel);
        }

        private void lunchCB_CheckedChanged(object sender, EventArgs e)
        {
            calc(servicesLB, lunchCB, 450, billLabel);
        }

        private void newsCB_CheckedChanged(object sender, EventArgs e)
        {
            calc(servicesLB, newsCB, 30, billLabel);
        }

        private void SwimCB_CheckedChanged(object sender, EventArgs e)
        {
            calc(servicesLB, SwimCB, 1000, billLabel);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            home obj = new home();
            obj.Show();
        }
    }
}

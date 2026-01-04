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
    public partial class myBrowser : Form
    {
        public myBrowser()
        {
            InitializeComponent();
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            if (addressTxt.Text != "")
            {
                string s = "http://www.";
                Uri u = new Uri(s+addressTxt.Text);
                webBrowser1.Url = u;
                addressTxt.Text = s + addressTxt.Text;
            
            }
            else
            {
                MessageBox.Show("Enter Address");
            }
            
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void myBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}

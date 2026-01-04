using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace myFirstAoo
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Regex rg = new Regex("^[0-9]+$");
            if (num1Txt.Text == "")
            {
                num1ErrorLabel.Visible = true;
            }
            else
            {
                num1ErrorLabel.Visible = false;
            }
            if (num2Txt.Text == "")
            {
                num2ErrorLabel.Visible = true;
            }
            else
            {
                num2ErrorLabel.Visible = false;
            }
            if (num1ErrorLabel.Visible || num2ErrorLabel.Visible)
            {
                MessageBox.Show("Fields with * are mandatory.");
            }
            else
            {
                if (rg.Match(num1Txt.Text).Success && rg.Match(num2Txt.Text).Success)
                {
                    int num1 = Convert.ToInt32(num1Txt.Text);
                    int num2 = Convert.ToInt32(num2Txt.Text);
                    int res = num1 + num2;
                    resTxt.Text = res.ToString();
                }
                else
                {

                    MessageBox.Show("Only numerics are accepted.");
                }
               
            }
           
        }

        private void num1Txt_TextChanged(object sender, EventArgs e)
        {
            if (num1Txt.Text == "")
            {
                num1ErrorLabel.Visible = true;
            }
            else
            {
                num1ErrorLabel.Visible = false;
            }
        }

        private void num2Txt_TextChanged(object sender, EventArgs e)
        {
            if (num2Txt.Text == "")
            {
                num2ErrorLabel.Visible = true;
            }
            else
            {
                num2ErrorLabel.Visible = false;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            home obj = new home();
            obj.Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

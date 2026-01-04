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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        public void reset(Panel p)
        {
            foreach (Control c in p.Controls)
            {
                if (c is TextBox)
                {
                    TextBox t = (TextBox)c;
                    t.Text = "";
                }
                if(c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    cb.SelectedIndex = -1;
                }
                if (c is RadioButton)
                {
                    RadioButton cb = (RadioButton)c;
                    cb.Checked = false;
                }
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.Checked = false;
                }
            }
        }
        private void resetBtn_Click(object sender, EventArgs e)
        {
            reset(panel1);
            reset(panel2);
        }
    }
}

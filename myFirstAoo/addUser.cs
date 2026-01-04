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
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen obj = new MainScreen();
            obj.Show();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            imp obj = new imp();
            Int16 gender = maleRb.Checked?Convert.ToInt16(1):Convert.ToInt16(0);
            Int16 status = statusDD.SelectedItem.ToString() == "Active"?Convert.ToInt16(1):Convert.ToInt16(0);
            obj.addUser(nameTxt.Text, phoneTxt.Text, Convert.ToInt16(ageTxt.Text), gender, status);
        }
    }
}

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
    public partial class datePickerExample : Form
    {
        public datePickerExample()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = dateTimePicker1.Value.ToString("MMM-yyyy");
            MessageBox.Show(dateTimePicker1.Value.AddDays(-67).ToString("dd-MMM-yyyy"));
            notifyIcon1.ShowBalloonTip(2000);
        }

        private void datePickerExample_Load(object sender, EventArgs e)
        {
          
        }
    }
}

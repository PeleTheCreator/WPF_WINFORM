using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LearningWinform
{
    public partial class RadionControlForm : Form
    {
        public RadionControlForm()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            var selectedgroup1 = groupBox1.Controls.OfType<RadioButton>()
              .Where(r => r.Checked)
              .Select(r => r.Text);

            if(selectedgroup1 != null)
            {
                foreach (var item in selectedgroup1)
                {
                    MessageBox.Show("group1 "+item);
                }
            }

            var selectedgroup2 = groupBox2.Controls.OfType<RadioButton>()
              .Where(r => r.Checked)
              .Select(r => r.Text);
            if (selectedgroup2 != null)
            {
                foreach (var item in selectedgroup2)
                {
                    MessageBox.Show("group2 " + item);
                }
            }
        }
    }
}

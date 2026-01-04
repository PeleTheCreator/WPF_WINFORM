using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningWinform
{
    public partial class DateTimeControlForm : Form
    {
        public DateTimeControlForm()
        {
            InitializeComponent();
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            label4.Text = dateTimePicker4.Value.ToString("yyyy-MM-dd HH:mm:ss");

            var dt = dateTimePicker4.Value;
            label5.Text = $"{dt.Day} - {dt.Month} - {dt.Year}";
        }

        private void DateTimeControlForm_Load(object sender, EventArgs e)
        {
            label4.Text = dateTimePicker3.Value.ToString();

        }
    }
}

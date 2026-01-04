using System;
using System.Windows.Forms;

namespace LearningWinform
{
    public partial class TextControlForm : Form
    {
        public TextControlForm()
        {
            InitializeComponent();
        }

        private void num1Txt_TextChanged(object sender, EventArgs e)
        {
          if(!int.TryParse(num1Txt.Text, out _))
            num1ErrorLbl.Visible = true;
          else
             num1ErrorLbl.Visible = false;
            
        }

        private void num2Txt_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(num2Txt.Text, out _))
                num2ErrorLbl.Visible = true;
            else
                num2ErrorLbl.Visible = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(num1Txt.Text, out var num1))
                num1ErrorLbl.Visible = true;
            else
                num1ErrorLbl.Visible = false;

            if (!int.TryParse(num2Txt.Text, out var num2))
                num2ErrorLbl.Visible = true;
            else
                num2ErrorLbl.Visible = false;

            if (num1ErrorLbl.Visible || num2ErrorLbl.Visible)
            {
                MessageBox.Show("Fields with * are mandatory.");
            }
            else
            {
                var result = num1 + num2;
                resultTxt.Text = result.ToString(); 

            }

        }
    }
}

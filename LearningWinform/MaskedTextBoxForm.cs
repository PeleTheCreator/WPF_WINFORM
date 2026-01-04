using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningWinform
{
    public partial class MaskedTextBoxForm : Form
    {
        public MaskedTextBoxForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (maskedTextBox1.MaskCompleted)
            {

            }

            if (maskedTextBox1.MaskFull)
            {

            }

            //maskedTextBox1.TextMaskFormat = MaskFormat.IncludeLiterals;
            //maskedTextBox1.TextMaskFormat = MaskFormat.IncludePrompt;


            //maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;



            label1.Text = maskedTextBox1.Text;
        }
    }
}

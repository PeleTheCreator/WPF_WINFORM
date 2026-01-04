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
    public partial class CheckboxControlForm : Form
    {
        public CheckboxControlForm()
        {
            InitializeComponent();
        }

        private void checkBoxSelectAll_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.CheckState == CheckState.Indeterminate)
                return; // Ignore auto state

            bool check = checkBoxSelectAll.CheckState == CheckState.Checked;

            checkBoxFileA.Checked = check;
            checkBoxFileB.Checked = check;
            checkBoxFileC.Checked = check;
        }

        private void Child_CheckedChanged(object sender, EventArgs e)
        {
            int checkedCount = 0;
            CheckBox[] children =
            {
        checkBoxFileA,
        checkBoxFileB,
        checkBoxFileC
    };

            foreach (CheckBox cb in children)
                if (cb.Checked)
                    checkedCount++;

            if (checkedCount == children.Length)
                checkBoxSelectAll.CheckState = CheckState.Checked;
            else if (checkedCount == 0)
                checkBoxSelectAll.CheckState = CheckState.Unchecked;
            else
                checkBoxSelectAll.CheckState = CheckState.Indeterminate;
        }

    }
}

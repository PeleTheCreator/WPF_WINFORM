using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace myFirstAoo
{
    public partial class RichTextBoxExample : Form
    {
        public RichTextBoxExample()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (paraTxt.Text != "" && fileNameTxt.Text!= "")
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (File.Exists(path+"\\"+fileNameTxt.Text))
                {
                   DialogResult dr = MessageBox.Show("File already exists, Do you want to add current data to this file?","Question..",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                   if (dr == DialogResult.Yes)
                   {
                       File.AppendAllText(path +"\\"+ fileNameTxt.Text, paraTxt.Text);
                   }
                   else
                   {

                   }
                }
                else
                {
                    File.WriteAllText(path + "\\" + fileNameTxt.Text, paraTxt.Text);
                    MessageBox.Show("File Created Successfully.");
                }
                
              
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            if (fileNameTxt.Text != "")
            {
                 string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\"+fileNameTxt.Text;
               FileStream fs =  File.Open(path, FileMode.Open, FileAccess.Read);
                byte[] abc =new byte[100];
                fs.Read(abc, 0, Convert.ToInt32(fs.Length));
                foreach (byte  i in abc)
                {
                    paraTxt.AppendText(Convert.ToChar(i).ToString());
                }
            }
        }
    }
}

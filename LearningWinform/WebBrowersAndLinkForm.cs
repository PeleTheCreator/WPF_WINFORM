using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace LearningWinform
{
    public partial class WebBrowersAndLinkForm : Form
    {
        public WebBrowersAndLinkForm()
        {
            InitializeComponent();
        }

      

        private void backBtn_Click(object sender, EventArgs e)
        {

            if(webBrowser1.CanGoBack)
                webBrowser1.GoBack();
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
                webBrowser1.GoForward();    
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            var adrresss = textBox1.Text;
            var url = $"https://www.{adrresss}";
            webBrowser1.Url = new Uri(url);
            //webBrowser1.Navigate(url);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            webBrowser1.Url = new Uri("https://www.baidu.com");
        }
    }
}

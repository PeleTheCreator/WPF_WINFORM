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
    public partial class comboExample : Form
    {
        public comboExample()
        {
            InitializeComponent();
        }

        private void countryDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (countryDD.SelectedIndex != -1)
            {
                citiesDD.Items.Clear();
                if (countryDD.SelectedIndex == 0)
                {
                    citiesDD.Items.Add("Karachi");
                    citiesDD.Items.Add("Lahore");
                }
                else if(countryDD.SelectedIndex == 1)
                {
                    citiesDD.Items.Add("Beijing");
                }
            }
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            if (countryDD.SelectedIndex == -1)
            {
                MessageBox.Show("Please select country");
            }
            else
            {
                ansLabel.Text = countryDD.SelectedItem.ToString();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (countryDD.SelectedIndex == -1)
            {
                MessageBox.Show("Please select country");
            }
            else
            {
                if (myItemsLB.Items.Contains(countryDD.SelectedItem.ToString()))
                {
                    MessageBox.Show(countryDD.SelectedItem.ToString()+" already exist.");
                }
                else
                {
                    myItemsLB.Items.Add(countryDD.SelectedItem.ToString());
                }
               
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            home obj = new home();
            obj.Show();
        }
    }
}

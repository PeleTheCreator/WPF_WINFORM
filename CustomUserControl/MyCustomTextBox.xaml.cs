using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomUserControl
{
    /// <summary>
    /// Interaction logic for MyCustomTextBox.xaml
    /// </summary>
    public partial class MyCustomTextBox : UserControl
    {
        public MyCustomTextBox()
        {
            InitializeComponent();
        }

        public string placeholder;
        public string Placeholder
        {
            get
            {
                return placeholder;
            }
            set
            {
                placeholder = value;
                placeholderTxt.Text = placeholder;
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            inputTxt.Clear();
            inputTxt.Focus();
        }

        private void inputTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            placeholderTxt.Visibility = string.IsNullOrEmpty(inputTxt.Text) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}

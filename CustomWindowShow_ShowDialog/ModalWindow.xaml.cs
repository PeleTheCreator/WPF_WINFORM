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
using System.Windows.Shapes;

namespace CustomWindowShow_ShowDialog
{
    /// <summary>
    /// Interaction logic for ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow : Window
    {
        public bool success = false;
        public string inputTxt = string.Empty;
        public ModalWindow()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            success = true;
            inputTxt = modalInputTxt.Text;
            Close();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            success = false;
            Close();
        }

        private void modalInputTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (modalInputTxt.Text.Length > 0)
            {
                okBtn.IsEnabled = true;
            }
            else
            {
                okBtn.IsEnabled = false;
            }
        }
    }
}

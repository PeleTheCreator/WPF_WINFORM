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

namespace ListViewExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
           displayLV.Items.Add(inputTxt.Text);
           inputTxt.Clear();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            //displayLV.Items.RemoveAt(displayLV.SelectedIndex);
            //displayLV.Items.Remove(displayLV.SelectedItem);

            //---for multiple selection---
            var selectedItems = displayLV.SelectedItems.Cast<object>().ToList();
            foreach (var item in selectedItems)
            {
                displayLV.Items.Remove(item);
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            displayLV.Items.Clear();
        }
    }
}

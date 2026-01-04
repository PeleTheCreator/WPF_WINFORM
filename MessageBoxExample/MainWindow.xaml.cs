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

namespace MessageBoxExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
     
        private void showMsgBoxBtn_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Kindly ", "Error Mesaage", MessageBoxButton.OK, MessageBoxImage.Information);

            MessageBoxResult MessageResult = MessageBox.Show("Do you want to save changes?", "Save Changes", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if(MessageResult == MessageBoxResult.Yes)
            {
                resultTxt.Text = "You clicked Yes";
                MessageBox.Show("You clicked Yes", "Response", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (MessageResult == MessageBoxResult.No)
            {
                resultTxt.Text = "You clicked No";
                MessageBox.Show("You clicked No", "Response", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (MessageResult == MessageBoxResult.Cancel)
            {
                resultTxt.Text = "You clicked Cancel";
                MessageBox.Show("You clicked Cancel", "Response", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}

using System.Windows;
using winform = System.Windows.Forms;
namespace FolderBrowserDialog
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

        private void openFolderBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new winform.FolderBrowserDialog())
            {
                dialog.SelectedPath = @"C:\Users\salam\Desktop\PELE\Yahoo\TEST\TestApp";
                winform.DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    winform.MessageBox.Show(dialog.SelectedPath);
                }
            }
        }
    }
}

using System.Windows;
using Microsoft.Win32;

namespace OpenFileDialogExample
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

        private void fireBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Please pick cs source file....";
            openFileDialog.Filter = "C# Source Files (*.cs)|*.cs";
            openFileDialog.InitialDirectory = @"C:\Users\salam\Desktop";
            openFileDialog.Multiselect = true;
            bool? result = openFileDialog.ShowDialog();

            if(result == true)
            {
                //string filePath = openFileDialog.FileName;
                //string filename = openFileDialog.SafeFileName;
                //fileInfoText.Text = $"Full Path: {filePath}\nFile Name: {filename}";
              
                string[] filePaths = openFileDialog.FileNames;
                string[] filenames = openFileDialog.SafeFileNames;

                fileInfoText.Text = "Selected Files:\n";
                for (int i = 0; i < filePaths.Length; i++)
                {
                    fileInfoText.Text += $"Full Path: {filePaths[i]}\nFile Name: {filenames[i]}\n\n";
                }

            }
            else
            {
                MessageBox.Show("No file selected.");
            }
        }
    }
}

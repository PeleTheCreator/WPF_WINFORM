using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool running = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void runToggleBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    if (running)
        //    {
        //        statusTb.Text = "Stopping...";
        //    }
        //    else
        //    {
        //      statusTb.Text = "Running...";
        //    }
        //     running = !running;
        //}
    }
}

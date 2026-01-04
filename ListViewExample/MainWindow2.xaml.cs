using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ListViewExample
{
    /// <summary>
    /// Interaction logic for MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            DataContext = this;
            entries = new ObservableCollection<string>();
            entries.Add("First Entry");
            InitializeComponent();
        }

        private ObservableCollection<string> entries;

        public ObservableCollection<string> Entries
        {
            get { return entries; }
            set { entries = value; }
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Entries.Add(inputTxt.Text);
            inputTxt.Clear();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            //Entries.Remove((string)displayLV.SelectedItem);

            if (displayLV.SelectedItems == null)
                return;
            var items = displayLV.SelectedItems.Cast<string>().ToList();

            foreach (var i in items)
                Entries.Remove(i);
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Entries.Clear();
        }
    }
}

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
    /// Interaction logic for MyCustomUserControl.xaml
    /// </summary>
    public partial class MyCustomUserControl : UserControl
    {
        public MyCustomUserControl()
        {
            InitializeComponent();
        }


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(MyCustomUserControl), new PropertyMetadata("Default Title"));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button in MyCustomUserControl clicked!");
        }
    }
}

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

namespace WPFFormProject
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

        private void applyBtn_Click(object sender, RoutedEventArgs e)
        {

            var validationErrrors = ValidateForm();
            if (!string.IsNullOrEmpty(validationErrrors))
            {
                MessageBox.Show(validationErrrors,
                                "Validation Failed",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }


            MessageBox.Show("Form submitted successfully!",
                            "Success",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
            //if(finishedCb.SelectedIndex == 2)
            //{
            //    string finishedText = ((ComboBoxItem)finishedCb.SelectedItem).Content.ToString();
            //    MessageBox.Show("Selected Finished: " + finishedText);
            //}
            //else
            //{
            //    MessageBox.Show("No Finished option selected.");
            //}
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
            this.Close();
        }

        private void weildChb_Checked(object sender, RoutedEventArgs e)
        {
            if (weildChb.IsChecked == true)
                MessageBox.Show("checked");
        }

        private void weildChb_Click(object sender, RoutedEventArgs e)
        {
            if (weildChb.IsChecked == true)
                MessageBox.Show("checked");
            if (weildChb.IsChecked == false)
                MessageBox.Show("unchecked");
        }


        private string ValidateForm()
        {
            var errors = new StringBuilder();

            // Required text fields
            ValidateRequired(pulseDescriptionTextBox.Text, "Pulse Description", errors);
            ValidateRequired(statusTextBox.Text, "Status", errors);
            ValidateRequired(revisionTextBox.Text, "Revision", errors);
            ValidateRequired(partNumberTextBox.Text, "Part Number", errors);
            ValidateRequired(supplierNameTextBox.Text, "Supplier Name", errors);
            ValidateRequired(supplierCodeTextBox.Text, "Supplier Code", errors);

            // ComboBox validation
            if (rawMaterialComboBox.SelectedIndex < 0)
                errors.AppendLine("• Raw Material must be selected.");

            if (finishedCb.SelectedIndex < 0)
                errors.AppendLine("• Finished option must be selected.");

            // Numeric validation
            ValidatePositiveNumber(lengthTextBox.Text, "Length", errors);
            ValidatePositiveNumber(massTextBox.Text, "Mass", errors);

            // Manufacturing checkbox validation (at least one selected)
            if (!IsAnyWorkCenterSelected())
                errors.AppendLine("• At least one Work Centre must be selected.");

            return errors.ToString();
        }

        private bool IsAnyWorkCenterSelected()
        {
            return weildChb.IsChecked == true
                   || assemblyChb.IsChecked == true
                   || plasmaChb.IsChecked == true
                   || laserChb.IsChecked == true
                   || purchaseChb.IsChecked == true
                   || latheChb.IsChecked == true
                   || drillChb.IsChecked == true
                   || foldChb.IsChecked == true
                   || rollChb.IsChecked == true
                   || sawChb.IsChecked == true;
        }

        private void ValidateRequired(string value, string fieldName, StringBuilder errors)
        {
            if (string.IsNullOrWhiteSpace(value))
                errors.AppendLine($"• {fieldName} is required.");
        }

        private void ValidatePositiveNumber(string value, string fieldName, StringBuilder errors)
        {
            if (!double.TryParse(value, out double number) || number <= 0)
                errors.AppendLine($"• {fieldName} must be a positive number.");
        }

    }
}

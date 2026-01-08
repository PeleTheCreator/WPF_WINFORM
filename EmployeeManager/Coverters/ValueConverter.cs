using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EmployeeManager.Converters
{
    /// <summary>
    /// Converts Boolean to Visibility
    /// MOST COMMONLY USED converter in WPF
    /// 
    /// USE CASE: Show/hide UI elements based on boolean condition
    /// Example: Show "Edit" panel only when employee is selected
    /// 
    /// WITHOUT THIS:
    /// You'd need properties like "IsEditPanelVisible" in ViewModel (BAD)
    /// 
    /// WITH THIS:
    /// Just bind to boolean and converter handles the rest (GOOD)
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Convert bool to Visibility
        /// true → Visible
        /// false → Collapsed
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        /// <summary>
        /// Convert Visibility back to bool (rarely needed)
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility == Visibility.Visible;
            }
            return false;
        }
    }

    /// <summary>
    /// Inverted BoolToVisibilityConverter
    /// false → Visible
    /// true → Collapsed
    /// 
    /// USE CASE: Show message when condition is NOT met
    /// Example: Show "No employees found" when list is empty
    /// </summary>
    public class InverseBoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility != Visibility.Visible;
            }
            return true;
        }
    }

    /// <summary>
    /// Converts null to Visibility
    /// null → Collapsed
    /// not null → Visible
    /// 
    /// USE CASE: Show UI elements only when object exists
    /// Example: Show employee details panel only when employee is selected
    /// </summary>
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Inverted NullToVisibilityConverter
    /// null → Visible
    /// not null → Collapsed
    /// 
    /// USE CASE: Show placeholder when no data exists
    /// Example: Show "Select an employee" message when nothing is selected
    /// </summary>
    public class InverseNullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converts decimal to currency string
    /// 50000 → "$50,000.00"
    /// 
    /// USE CASE: Display salary in proper format
    /// Better than StringFormat in binding (more flexible)
    /// </summary>
    public class DecimalToCurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal decimalValue)
            {
                return decimalValue.ToString("C2", CultureInfo.CurrentCulture);
            }
            return "$0.00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                // Remove currency symbol and parse
                string cleanValue = stringValue.Replace("$", "").Replace(",", "");
                if (decimal.TryParse(cleanValue, out decimal result))
                {
                    return result;
                }
            }
            return 0m;
        }
    }

    /// <summary>
    /// Converts DateTime to formatted date string
    /// DateTime → "MM/dd/yyyy"
    /// 
    /// USE CASE: Display dates in consistent format
    /// Can customize format per instance
    /// </summary>
    public class DateTimeToStringConverter : IValueConverter
    {
        /// <summary>
        /// Default format, can be overridden by parameter
        /// </summary>
        public string DateFormat { get; set; } = "MM/dd/yyyy";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                // Use parameter as format if provided, otherwise use DateFormat
                string format = parameter as string ?? DateFormat;
                return dateTime.ToString(format, CultureInfo.CurrentCulture);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                if (DateTime.TryParse(stringValue, out DateTime result))
                {
                    return result;
                }
            }
            return DateTime.MinValue;
        }
    }

    /// <summary>
    /// Inverts boolean value
    /// true → false
    /// false → true
    /// 
    /// USE CASE: Disable button when condition is true
    /// Example: Disable "Edit" when already in edit mode
    /// </summary>
    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return !boolValue;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return !boolValue;
            }
            return false;
        }
    }

    /// <summary>
    /// Checks if string is null or empty
    /// Returns bool (true if has value, false if empty)
    /// 
    /// USE CASE: Enable search button only when text is entered
    /// </summary>
    public class StringNotEmptyToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrWhiteSpace(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converts collection count to boolean
    /// 0 → false
    /// >0 → true
    /// 
    /// USE CASE: Show "No results" message when list is empty
    /// Example: Show message when employee search returns nothing
    /// </summary>
    public class CountToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int count)
            {
                return count > 0;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Multi-value converter: Checks if any value is true
    /// USE CASE: Enable button if ANY condition is met
    /// Example: Enable Save if FirstName OR LastName is filled
    /// </summary>
    public class AnyTrueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null) return false;

            foreach (var value in values)
            {
                if (value is bool boolValue && boolValue)
                {
                    return true;
                }
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Multi-value converter: Checks if all values are true
    /// USE CASE: Enable button only if ALL conditions are met
    /// Example: Enable Save only if FirstName AND LastName AND Email are filled
    /// </summary>
    public class AllTrueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0) return false;

            foreach (var value in values)
            {
                if (!(value is bool boolValue) || !boolValue)
                {
                    return false;
                }
            }
            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

/*
 * =============================================================================
 * VALUE CONVERTER BEST PRACTICES:
 * =============================================================================
 * 
 * 1. WHEN TO USE:
 *    - Convert data for display purposes
 *    - Transform data types for binding
 *    - Keep ViewModel clean of UI concerns
 * 
 * 2. WHEN NOT TO USE:
 *    - Business logic (belongs in ViewModel)
 *    - Complex calculations (use computed properties)
 *    - Database operations (belongs in Service)
 * 
 * 3. NAMING CONVENTION:
 *    - [Source]To[Target]Converter
 *    - Example: BoolToVisibilityConverter, DecimalToCurrencyConverter
 * 
 * 4. REGISTRATION:
 *    Register in App.xaml or Window.Resources:
 *    
 *    <Window.Resources>
 *        <converters:BoolToVisibilityConverter x:Key="BoolToVisibility"/>
 *        <converters:NullToVisibilityConverter x:Key="NullToVisibility"/>
 *    </Window.Resources>
 * 
 * 5. USAGE IN XAML:
 *    
 *    <!-- Simple converter -->
 *    <TextBox Visibility="{Binding IsEditing, 
 *                          Converter={StaticResource BoolToVisibility}}"/>
 *    
 *    <!-- With parameter -->
 *    <TextBlock Text="{Binding HireDate, 
 *                      Converter={StaticResource DateTimeToString},
 *                      ConverterParameter='yyyy-MM-dd'}"/>
 *    
 *    <!-- Multi-value converter -->
 *    <Button>
 *        <Button.IsEnabled>
 *            <MultiBinding Converter="{StaticResource AllTrue}">
 *                <Binding Path="HasFirstName"/>
 *                <Binding Path="HasLastName"/>
 *                <Binding Path="HasEmail"/>
 *            </MultiBinding>
 *        </Button.IsEnabled>
 *    </Button>
 * 
 * 6. CONVERTBACK:
 *    - Only implement if using TwoWay binding
 *    - Most converters are OneWay (don't need ConvertBack)
 *    - Throw NotImplementedException if not needed
 * 
 * 7. ERROR HANDLING:
 *    - Always check for null
 *    - Return sensible default if conversion fails
 *    - Don't throw exceptions from Convert method
 * 
 * 
 * REAL-WORLD EXAMPLES:
 * 
 * Example 1: Show Edit Panel only when employee is selected
 * 
 * <StackPanel Visibility="{Binding SelectedEmployee, 
 *                          Converter={StaticResource NullToVisibility}}">
 *     <!-- Edit form controls -->
 * </StackPanel>
 * 
 * 
 * Example 2: Show "No Results" message when list is empty
 * 
 * <TextBlock Text="No employees found" 
 *            Visibility="{Binding Employees.Count, 
 *                         Converter={StaticResource CountToVisibility}}"/>
 * 
 * 
 * Example 3: Display salary as currency
 * 
 * <TextBlock Text="{Binding Salary, 
 *                   Converter={StaticResource DecimalToCurrency}}"/>
 * 
 * 
 * WHY THIS IS IMPORTANT:
 * 
 * WITHOUT CONVERTERS (Bad):
 * public class ViewModel
 * {
 *     public bool IsEmployeeSelected { get; set; }
 *     public Visibility EditPanelVisibility => 
 *         IsEmployeeSelected ? Visibility.Visible : Visibility.Collapsed;
 *     
 *     public string FormattedSalary => 
 *         Salary.ToString("C2");
 * }
 * 
 * Problems:
 * - ViewModel knows about UI concepts (Visibility)
 * - Extra properties just for display
 * - Hard to test
 * - Violates separation of concerns
 * 
 * 
 * WITH CONVERTERS (Good):
 * public class ViewModel
 * {
 *     public Employee SelectedEmployee { get; set; }
 *     public decimal Salary { get; set; }
 * }
 * 
 * Benefits:
 * - ViewModel is clean and focused
 * - Converters are reusable
 * - Easy to test
 * - Proper MVVM separation
 * 
 * =============================================================================
 */

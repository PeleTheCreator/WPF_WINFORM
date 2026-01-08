
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using EmployeeManager.Commands;
using EmployeeManager.Data;
using EmployeeManager.Models;

namespace EmployeeManager.ViewModels
{
    /// <summary>
    /// Main ViewModel for the application
    /// This is the "VM" in MVVM - it acts as the bridge between View and Model
    /// 
    /// RESPONSIBILITIES:
    /// 1. Expose data to the View through properties
    /// 2. Handle user interactions through Commands
    /// 3. Contain business logic and validation
    /// 4. Communicate with the Data Access Layer
    /// 5. Implement INotifyPropertyChanged to update UI automatically
    /// 
    /// NO UI CODE should be in ViewModel - it should be UI-agnostic
    /// This allows for unit testing without UI
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Private Fields
        // Data access layer instance
        private readonly DatabaseHelper _databaseHelper;

        // Private backing fields for bindable properties
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Department> _departments;
        private Employee _selectedEmployee;
        private string _searchText;
        private bool _isEditMode;
        private string _statusMessage;
        #endregion

        #region Public Properties

        /// <summary>
        /// ObservableCollection automatically notifies UI of changes
        /// When items are added/removed, DataGrid updates automatically
        /// Use ObservableCollection instead of List for data binding in WPF
        /// </summary>
        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set
            {
                if (_employees != value)
                {
                    _employees = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Collection of departments for ComboBox binding
        /// </summary>
        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set
            {
                if (_departments != value)
                {
                    _departments = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Currently selected employee in the DataGrid
        /// Bound to SelectedItem property of DataGrid
        /// When user selects a row, this property is automatically updated
        /// </summary>
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                if (_selectedEmployee != value)
                {
                    _selectedEmployee = value;
                    OnPropertyChanged();

                    // When selection changes, update command states
                    // This enables/disables Edit and Delete buttons
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        /// <summary>
        /// Search text bound to TextBox
        /// Uses two-way binding - changes in UI update this property
        /// and changes here update the UI
        /// </summary>
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Indicates if we're in edit mode (editing existing) or add mode (creating new)
        /// Used to change button labels and behavior
        /// </summary>
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                if (_isEditMode != value)
                {
                    _isEditMode = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Status message displayed in StatusBar
        /// Shows feedback to user about operations
        /// </summary>
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                if (_statusMessage != value)
                {
                    _statusMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands
        // ICommand properties that bind to buttons and UI actions
        // Commands are the MVVM way to handle user interactions
        // No event handlers in code-behind needed

        /// <summary>
        /// Command to load all employees from database
        /// Bound to Refresh button
        /// </summary>
        public ICommand LoadEmployeesCommand { get; }

        /// <summary>
        /// Command to add new employee
        /// Opens employee entry form in "Add" mode
        /// </summary>
        public ICommand AddEmployeeCommand { get; }

        /// <summary>
        /// Command to edit selected employee
        /// Opens employee entry form in "Edit" mode
        /// Can only execute when an employee is selected
        /// </summary>
        public ICommand EditEmployeeCommand { get; }

        /// <summary>
        /// Command to delete selected employee
        /// Shows confirmation dialog before deleting
        /// Can only execute when an employee is selected
        /// </summary>
        public ICommand DeleteEmployeeCommand { get; }

        /// <summary>
        /// Command to save employee (either new or edited)
        /// Validates data before saving
        /// </summary>
        public ICommand SaveEmployeeCommand { get; }

        /// <summary>
        /// Command to cancel add/edit operation
        /// Clears the form
        /// </summary>
        public ICommand CancelCommand { get; }

        /// <summary>
        /// Command to search employees
        /// Filters employees based on search text
        /// </summary>
        public ICommand SearchCommand { get; }

        /// <summary>
        /// Command to clear search and show all employees
        /// </summary>
        public ICommand ClearSearchCommand { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor - initializes ViewModel
        /// Called when application starts
        /// </summary>
        public MainViewModel()
        {
            // Initialize data access layer
            _databaseHelper = new DatabaseHelper();

            // Initialize collections
            // ObservableCollection MUST be initialized before use
            Employees = new ObservableCollection<Employee>();
            Departments = new ObservableCollection<Department>();

            // Initialize commands by connecting them to methods
            // First parameter: method to execute
            // Second parameter (optional): method to check if can execute
            LoadEmployeesCommand = new RelayCommand(LoadEmployees);
            AddEmployeeCommand = new RelayCommand(AddEmployee);
            EditEmployeeCommand = new RelayCommand(EditEmployee, CanEditOrDeleteEmployee);
            DeleteEmployeeCommand = new RelayCommand(DeleteEmployee, CanEditOrDeleteEmployee);
            SaveEmployeeCommand = new RelayCommand(SaveEmployee, CanSaveEmployee);
            CancelCommand = new RelayCommand(Cancel);
            SearchCommand = new RelayCommand(SearchEmployees);
            ClearSearchCommand = new RelayCommand(ClearSearch);

            // Load initial data when ViewModel is created
            LoadInitialData();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load initial data on application startup
        /// Loads both employees and departments
        /// </summary>
        private void LoadInitialData()
        {
            try
            {
                // Test database connection first
                if (!_databaseHelper.TestConnection())
                {
                    StatusMessage = "Error: Cannot connect to database. Check connection string.";
                    MessageBox.Show(
                        "Cannot connect to database. Please check your connection string in App.config",
                        "Database Connection Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Load employees and departments
                LoadEmployees();
                LoadDepartments();

                StatusMessage = "Ready";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                MessageBox.Show(
                    $"Error loading initial data: {ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Load all employees from database
        /// Called by LoadEmployeesCommand
        /// </summary>
        private void LoadEmployees()
        {
            try
            {
                // Clear existing items
                Employees.Clear();

                // Get employees from database
                var employeeList = _databaseHelper.GetAllEmployees();

                // Add each employee to ObservableCollection
                // ObservableCollection will notify UI of each addition
                foreach (var employee in employeeList)
                {
                    Employees.Add(employee);
                }

                StatusMessage = $"Loaded {Employees.Count} employees";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error loading employees: {ex.Message}";
                MessageBox.Show(
                    $"Error loading employees: {ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Load all departments from database
        /// Used to populate ComboBox
        /// </summary>
        private void LoadDepartments()
        {
            try
            {
                Departments.Clear();

                var departmentList = _databaseHelper.GetAllDepartments();

                foreach (var department in departmentList)
                {
                    Departments.Add(department);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error loading departments: {ex.Message}";
                MessageBox.Show(
                    $"Error loading departments: {ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Prepare UI for adding new employee
        /// Creates new empty Employee object
        /// </summary>
        private void AddEmployee()
        {
            // Create new employee with default values
            SelectedEmployee = new Employee
            {
                HireDate = DateTime.Today,
                IsActive = true
            };

            IsEditMode = false;
            StatusMessage = "Adding new employee...";
        }

        /// <summary>
        /// Prepare UI for editing selected employee
        /// Creates a copy of selected employee to allow canceling
        /// </summary>
        private void EditEmployee()
        {
            if (SelectedEmployee == null) return;

            // Create a copy of the selected employee
            // This allows canceling without modifying the original
            var employeeCopy = new Employee
            {
                EmployeeId = SelectedEmployee.EmployeeId,
                FirstName = SelectedEmployee.FirstName,
                LastName = SelectedEmployee.LastName,
                Email = SelectedEmployee.Email,
                Phone = SelectedEmployee.Phone,
                HireDate = SelectedEmployee.HireDate,
                Salary = SelectedEmployee.Salary,
                DepartmentId = SelectedEmployee.DepartmentId,
                DepartmentName = SelectedEmployee.DepartmentName,
                IsActive = SelectedEmployee.IsActive
            };

            SelectedEmployee = employeeCopy;
            IsEditMode = true;
            StatusMessage = "Editing employee...";
        }

        /// <summary>
        /// Delete selected employee
        /// Shows confirmation dialog before deleting
        /// </summary>
        private void DeleteEmployee()
        {
            if (SelectedEmployee == null) return;

            // Show confirmation dialog
            // MessageBoxResult captures which button user clicked
            var result = MessageBox.Show(
                $"Are you sure you want to delete {SelectedEmployee.FullName}?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            // Only proceed if user clicked Yes
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Call database helper to delete
                    bool success = _databaseHelper.DeleteEmployee(SelectedEmployee.EmployeeId);

                    if (success)
                    {
                        // Remove from ObservableCollection
                        // This automatically updates the DataGrid
                        Employees.Remove(SelectedEmployee);

                        SelectedEmployee = null;
                        StatusMessage = "Employee deleted successfully";

                        MessageBox.Show(
                            "Employee deleted successfully",
                            "Success",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    else
                    {
                        StatusMessage = "Failed to delete employee";
                        MessageBox.Show(
                            "Failed to delete employee",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    StatusMessage = $"Error: {ex.Message}";
                    MessageBox.Show(
                        $"Error deleting employee: {ex.Message}",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Save employee (insert new or update existing)
        /// Performs validation before saving
        /// </summary>
        private void SaveEmployee()
        {
            if (SelectedEmployee == null) return;

            // Validate employee data
            string validationError = ValidateEmployee(SelectedEmployee);
            if (!string.IsNullOrEmpty(validationError))
            {
                MessageBox.Show(
                    validationError,
                    "Validation Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (IsEditMode)
                {
                    // Update existing employee
                    bool success = _databaseHelper.UpdateEmployee(SelectedEmployee);

                    if (success)
                    {
                        // Find and update the employee in the collection
                        var existingEmployee = Employees.FirstOrDefault(e => e.EmployeeId == SelectedEmployee.EmployeeId);
                        if (existingEmployee != null)
                        {
                            // Update properties
                            existingEmployee.FirstName = SelectedEmployee.FirstName;
                            existingEmployee.LastName = SelectedEmployee.LastName;
                            existingEmployee.Email = SelectedEmployee.Email;
                            existingEmployee.Phone = SelectedEmployee.Phone;
                            existingEmployee.HireDate = SelectedEmployee.HireDate;
                            existingEmployee.Salary = SelectedEmployee.Salary;
                            existingEmployee.DepartmentId = SelectedEmployee.DepartmentId;

                            // Update department name for display
                            var dept = Departments.FirstOrDefault(d => d.DepartmentId == SelectedEmployee.DepartmentId);
                            if (dept != null)
                            {
                                existingEmployee.DepartmentName = dept.DepartmentName;
                            }
                        }

                        StatusMessage = "Employee updated successfully";
                        MessageBox.Show(
                            "Employee updated successfully",
                            "Success",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);

                        Cancel();
                    }
                }
                else
                {
                    // Insert new employee
                    int newId = _databaseHelper.InsertEmployee(SelectedEmployee);

                    if (newId > 0)
                    {
                        // Set the new ID
                        SelectedEmployee.EmployeeId = newId;

                        // Get department name for display
                        var dept = Departments.FirstOrDefault(d => d.DepartmentId == SelectedEmployee.DepartmentId);
                        if (dept != null)
                        {
                            SelectedEmployee.DepartmentName = dept.DepartmentName;
                        }

                        // Add to collection - UI updates automatically
                        Employees.Add(SelectedEmployee);

                        StatusMessage = "Employee added successfully";
                        MessageBox.Show(
                            "Employee added successfully",
                            "Success",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);

                        Cancel();
                    }
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                MessageBox.Show(
                    $"Error saving employee: {ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Cancel add/edit operation
        /// Clears selected employee
        /// </summary>
        private void Cancel()
        {
            SelectedEmployee = null;
            IsEditMode = false;
            StatusMessage = "Operation cancelled";
        }

        /// <summary>
        /// Search employees by name, email, or department
        /// </summary>
        private void SearchEmployees()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadEmployees();
                return;
            }

            try
            {
                Employees.Clear();

                var searchResults = _databaseHelper.SearchEmployees(SearchText);

                foreach (var employee in searchResults)
                {
                    Employees.Add(employee);
                }

                StatusMessage = $"Found {Employees.Count} matching employees";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                MessageBox.Show(
                    $"Error searching employees: {ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Clear search and show all employees
        /// </summary>
        private void ClearSearch()
        {
            SearchText = string.Empty;
            LoadEmployees();
        }

        /// <summary>
        /// Validate employee data before saving
        /// Returns error message if validation fails, empty string if valid
        /// </summary>
        /// <param name="employee">Employee to validate</param>
        /// <returns>Validation error message or empty string</returns>
        private string ValidateEmployee(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.FirstName))
                return "First name is required";

            if (string.IsNullOrWhiteSpace(employee.LastName))
                return "Last name is required";

            if (string.IsNullOrWhiteSpace(employee.Email))
                return "Email is required";

            // Simple email validation
            if (!employee.Email.Contains("@"))
                return "Invalid email format";

            if (employee.HireDate > DateTime.Today)
                return "Hire date cannot be in the future";

            if (employee.Salary < 0)
                return "Salary cannot be negative";

            if (employee.DepartmentId <= 0)
                return "Please select a department";

            return string.Empty;
        }

        /// <summary>
        /// Determines if Edit or Delete commands can execute
        /// Returns true only if an employee is selected
        /// </summary>
        /// <returns>True if command can execute</returns>
        private bool CanEditOrDeleteEmployee()
        {
            return SelectedEmployee != null;
        }

        /// <summary>
        /// Determines if Save command can execute
        /// Returns true only if an employee is selected and has basic data
        /// </summary>
        /// <returns>True if command can execute</returns>
        private bool CanSaveEmployee()
        {
            return SelectedEmployee != null &&
                   !string.IsNullOrWhiteSpace(SelectedEmployee.FirstName) &&
                   !string.IsNullOrWhiteSpace(SelectedEmployee.LastName);
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        /// <summary>
        /// Event required by INotifyPropertyChanged
        /// WPF subscribes to this to know when to update UI
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises PropertyChanged event
        /// CallerMemberName automatically provides property name
        /// </summary>
        /// <param name="propertyName">Name of property that changed</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
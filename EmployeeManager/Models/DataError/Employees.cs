using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EmployeeManager.Models
{
        /// <summary>
        /// Model class representing an Employee entity
        /// NOW IMPLEMENTS: INotifyDataErrorInfo for PROFESSIONAL validation
        /// 
        /// INotifyDataErrorInfo is the MODERN way to do validation in WPF
        /// Benefits:
        /// - Real-time validation as user types
        /// - Multiple errors per property
        /// - Async validation support
        /// - UI automatically shows validation errors
        /// </summary>
        public class Employees : INotifyPropertyChanged, INotifyDataErrorInfo
        {
            #region Private Fields
            private int _employeeId;
            private string _firstName;
            private string _lastName;
            private string _email;
            private string _phone;
            private DateTime _hireDate;
            private decimal _salary;
            private int _departmentId;
            private string _departmentName;
            private bool _isActive;

            // Dictionary to store validation errors
            // Key: Property name, Value: List of error messages for that property
            private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
            #endregion

            #region Public Properties
            public int EmployeeId
            {
                get => _employeeId;
                set
                {
                    if (_employeeId != value)
                    {
                        _employeeId = value;
                        OnPropertyChanged();
                    }
                }
            }

            /// <summary>
            /// First name with validation
            /// Validates immediately when value changes
            /// </summary>
            public string FirstName
            {
                get => _firstName;
                set
                {
                    if (_firstName != value)
                    {
                        _firstName = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(FullName));

                        // VALIDATE immediately when property changes
                        ValidateFirstName();
                    }
                }
            }

            public string LastName
            {
                get => _lastName;
                set
                {
                    if (_lastName != value)
                    {
                        _lastName = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(FullName));

                        // VALIDATE immediately
                        ValidateLastName();
                    }
                }
            }

            public string FullName => $"{FirstName} {LastName}";

            /// <summary>
            /// Email with comprehensive validation
            /// </summary>
            public string Email
            {
                get => _email;
                set
                {
                    if (_email != value)
                    {
                        _email = value;
                        OnPropertyChanged();

                        // VALIDATE email format
                        ValidateEmail();
                    }
                }
            }

            public string Phone
            {
                get => _phone;
                set
                {
                    if (_phone != value)
                    {
                        _phone = value;
                        OnPropertyChanged();

                        // VALIDATE phone format (optional field)
                        ValidatePhone();
                    }
                }
            }

            public DateTime HireDate
            {
                get => _hireDate;
                set
                {
                    if (_hireDate != value)
                    {
                        _hireDate = value;
                        OnPropertyChanged();

                        // VALIDATE hire date
                        ValidateHireDate();
                    }
                }
            }

            public decimal Salary
            {
                get => _salary;
                set
                {
                    if (_salary != value)
                    {
                        _salary = value;
                        OnPropertyChanged();

                        // VALIDATE salary
                        ValidateSalary();
                    }
                }
            }

            public int DepartmentId
            {
                get => _departmentId;
                set
                {
                    if (_departmentId != value)
                    {
                        _departmentId = value;
                        OnPropertyChanged();

                        // VALIDATE department selection
                        ValidateDepartment();
                    }
                }
            }

            public string DepartmentName
            {
                get => _departmentName;
                set
                {
                    if (_departmentName != value)
                    {
                        _departmentName = value;
                        OnPropertyChanged();
                    }
                }
            }

            public bool IsActive
            {
                get => _isActive;
                set
                {
                    if (_isActive != value)
                    {
                        _isActive = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion

            #region Validation Methods
            /// <summary>
            /// Validate first name
            /// Business rules:
            /// - Cannot be empty
            /// - Must be at least 2 characters
            /// - Cannot contain numbers
            /// </summary>
            private void ValidateFirstName()
            {
                // Clear existing errors for this property
                ClearErrors(nameof(FirstName));

                // Check if empty
                if (string.IsNullOrWhiteSpace(FirstName))
                {
                    AddError(nameof(FirstName), "First name is required");
                }
                // Check minimum length
                else if (FirstName.Length < 2)
                {
                    AddError(nameof(FirstName), "First name must be at least 2 characters");
                }
                // Check for numbers
                else if (FirstName.Any(char.IsDigit))
                {
                    AddError(nameof(FirstName), "First name cannot contain numbers");
                }
            }

            /// <summary>
            /// Validate last name
            /// Same rules as first name
            /// </summary>
            private void ValidateLastName()
            {
                ClearErrors(nameof(LastName));

                if (string.IsNullOrWhiteSpace(LastName))
                {
                    AddError(nameof(LastName), "Last name is required");
                }
                else if (LastName.Length < 2)
                {
                    AddError(nameof(LastName), "Last name must be at least 2 characters");
                }
                else if (LastName.Any(char.IsDigit))
                {
                    AddError(nameof(LastName), "Last name cannot contain numbers");
                }
            }

            /// <summary>
            /// Validate email with comprehensive rules
            /// Business rules:
            /// - Cannot be empty
            /// - Must contain @
            /// - Must contain domain (.)
            /// - Must be valid format
            /// </summary>
            private void ValidateEmail()
            {
                ClearErrors(nameof(Email));

                if (string.IsNullOrWhiteSpace(Email))
                {
                    AddError(nameof(Email), "Email is required");
                    return; // Don't check format if empty
                }

                // Basic email validation
                if (!Email.Contains("@"))
                {
                    AddError(nameof(Email), "Email must contain @");
                }
                else
                {
                    // More detailed validation
                    var parts = Email.Split('@');
                    if (parts.Length != 2)
                    {
                        AddError(nameof(Email), "Invalid email format");
                    }
                    else if (string.IsNullOrWhiteSpace(parts[0]))
                    {
                        AddError(nameof(Email), "Email must have a username");
                    }
                    else if (!parts[1].Contains("."))
                    {
                        AddError(nameof(Email), "Email must have a valid domain");
                    }
                }

                // Check length
                if (Email.Length > 100)
                {
                    AddError(nameof(Email), "Email must be less than 100 characters");
                }
            }

            /// <summary>
            /// Validate phone number (optional field)
            /// Only validates if not empty
            /// </summary>
            private void ValidatePhone()
            {
                ClearErrors(nameof(Phone));

                // Phone is optional, so only validate if provided
                if (!string.IsNullOrWhiteSpace(Phone))
                {
                    // Remove common formatting characters
                    var digitsOnly = new string(Phone.Where(char.IsDigit).ToArray());

                    if (digitsOnly.Length < 10)
                    {
                        AddError(nameof(Phone), "Phone must be at least 10 digits");
                    }
                    else if (digitsOnly.Length > 15)
                    {
                        AddError(nameof(Phone), "Phone must be less than 15 digits");
                    }
                }
            }

            /// <summary>
            /// Validate hire date
            /// Business rules:
            /// - Cannot be in the future
            /// - Cannot be before company founding (example: 1990)
            /// </summary>
            private void ValidateHireDate()
            {
                ClearErrors(nameof(HireDate));

                if (HireDate > DateTime.Today)
                {
                    AddError(nameof(HireDate), "Hire date cannot be in the future");
                }
                else if (HireDate.Year < 1990)
                {
                    AddError(nameof(HireDate), "Hire date cannot be before 1990");
                }
            }

            /// <summary>
            /// Validate salary
            /// Business rules:
            /// - Cannot be negative
            /// - Must be reasonable (between minimum wage and maximum)
            /// </summary>
            private void ValidateSalary()
            {
                ClearErrors(nameof(Salary));

                if (Salary < 0)
                {
                    AddError(nameof(Salary), "Salary cannot be negative");
                }
                else if (Salary < 20000)
                {
                    AddError(nameof(Salary), "Salary seems too low (minimum $20,000)");
                }
                else if (Salary > 1000000)
                {
                    AddError(nameof(Salary), "Salary seems too high (maximum $1,000,000)");
                }
            }

            /// <summary>
            /// Validate department selection
            /// </summary>
            private void ValidateDepartment()
            {
                ClearErrors(nameof(DepartmentId));

                if (DepartmentId <= 0)
                {
                    AddError(nameof(DepartmentId), "Please select a department");
                }
            }

            /// <summary>
            /// Validate ALL properties at once
            /// Call this before saving to ensure entire object is valid
            /// </summary>
            public void ValidateAll()
            {
                ValidateFirstName();
                ValidateLastName();
                ValidateEmail();
                ValidatePhone();
                ValidateHireDate();
                ValidateSalary();
                ValidateDepartment();
            }
            #endregion

            #region INotifyDataErrorInfo Implementation
            /// <summary>
            /// Event fired when validation errors change
            /// WPF subscribes to this to show/hide error messages
            /// </summary>
            public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

            /// <summary>
            /// Check if entire object has any errors
            /// Used to enable/disable Save button
            /// </summary>
            public bool HasErrors => _errors.Any();

            /// <summary>
            /// Get errors for a specific property
            /// Called by WPF to display error messages in UI
            /// </summary>
            /// <param name="propertyName">Property to get errors for</param>
            /// <returns>Collection of error messages</returns>
            public IEnumerable GetErrors(string propertyName)
            {
                if (string.IsNullOrEmpty(propertyName))
                {
                    // Return all errors for entire object
                    return _errors.Values.SelectMany(e => e);
                }

                // Return errors for specific property
                if (_errors.ContainsKey(propertyName))
                {
                    return _errors[propertyName];
                }

                return null;
            }

            /// <summary>
            /// Add an error for a property
            /// </summary>
            /// <param name="propertyName">Property that has error</param>
            /// <param name="error">Error message</param>
            private void AddError(string propertyName, string error)
            {
                // Create list if it doesn't exist
                if (!_errors.ContainsKey(propertyName))
                {
                    _errors[propertyName] = new List<string>();
                }

                // Add error if not already present
                if (!_errors[propertyName].Contains(error))
                {
                    _errors[propertyName].Add(error);

                    // Notify UI that errors changed for this property
                    OnErrorsChanged(propertyName);
                }
            }

            /// <summary>
            /// Clear all errors for a property
            /// Called before re-validating
            /// </summary>
            /// <param name="propertyName">Property to clear errors for</param>
            private void ClearErrors(string propertyName)
            {
                if (_errors.ContainsKey(propertyName))
                {
                    _errors.Remove(propertyName);

                    // Notify UI that errors changed
                    OnErrorsChanged(propertyName);
                }
            }

            /// <summary>
            /// Raise ErrorsChanged event
            /// Tells WPF to re-query errors for this property
            /// </summary>
            /// <param name="propertyName">Property whose errors changed</param>
            private void OnErrorsChanged(string propertyName)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

                // Also notify that HasErrors might have changed
                OnPropertyChanged(nameof(HasErrors));
            }
            #endregion

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion

            #region Constructor
            public Employees()
            {
                HireDate = DateTime.Today;
                IsActive = true;

                // Don't validate in constructor - object is being built
                // Validation happens when properties are set
            }
            #endregion
        }
    }

    /*
     * =============================================================================
     * VALIDATION BEST PRACTICES DEMONSTRATED:
     * =============================================================================
     * 
     * 1. REAL-TIME VALIDATION:
     *    - Validates as user types
     *    - Immediate feedback
     *    - Better UX than validating only on save
     * 
     * 2. MULTIPLE ERRORS PER PROPERTY:
     *    - Can show multiple validation messages
     *    - More informative than single error
     * 
     * 3. CLEAR ERROR MESSAGES:
     *    - Tell user exactly what's wrong
     *    - Tell user how to fix it
     * 
     * 4. BUSINESS RULES:
     *    - Encapsulated in model
     *    - Reusable across application
     *    - Single source of truth
     * 
     * 5. UI INTEGRATION:
     *    - WPF automatically shows errors
     *    - Red border on invalid controls
     *    - Tooltip shows error message
     * 
     * 6. SAVE PREVENTION:
     *    - HasErrors property prevents saving invalid data
     *    - Save button disabled when errors exist
     * 
     * IN XAML, ENABLE VALIDATION LIKE THIS:
     * 
     * <TextBox Text="{Binding FirstName, 
     *                         UpdateSourceTrigger=PropertyChanged, 
     *                         ValidatesOnNotifyDataErrors=True}"/>
     * 
     * WPF will automatically:
     * - Show red border when invalid
     * - Show error message in tooltip
     * - Update when errors change
     * 
     * =============================================================================
     */


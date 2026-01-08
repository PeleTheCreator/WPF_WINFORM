using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    /// <summary>
    /// Model class representing an Employee entity
    /// Implements INotifyPropertyChanged for data binding in WPF
    /// This is the "M" in MVVM - it represents the data structure
    /// </summary>
    public class Employee : INotifyPropertyChanged
    {
        #region Private Fields
        // Private backing fields for properties
        // Using private fields allows us to raise PropertyChanged events
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
        #endregion

        #region Public Properties
        /// <summary>
        /// Unique identifier for the employee (Primary Key)
        /// </summary>
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
        /// Employee's first name
        /// When this changes, UI automatically updates due to INotifyPropertyChanged
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
                    // FullName depends on FirstName, so notify it too
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        /// <summary>
        /// Employee's last name
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                    // FullName depends on LastName, so notify it too
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        /// <summary>
        /// Computed property combining first and last name
        /// No setter needed - it's calculated from other properties
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Employee's email address (must be unique in database)
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
                }
            }
        }

        /// <summary>
        /// Employee's phone number (optional)
        /// </summary>
        public string Phone
        {
            get => _phone;
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Date when employee was hired
        /// </summary>
        public DateTime HireDate
        {
            get => _hireDate;
            set
            {
                if (_hireDate != value)
                {
                    _hireDate = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Employee's annual salary
        /// </summary>
        public decimal Salary
        {
            get => _salary;
            set
            {
                if (_salary != value)
                {
                    _salary = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Foreign key to Department table
        /// </summary>
        public int DepartmentId
        {
            get => _departmentId;
            set
            {
                if (_departmentId != value)
                {
                    _departmentId = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Department name for display purposes (not stored in Employee table)
        /// This comes from a JOIN with Departments table
        /// </summary>
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

        /// <summary>
        /// Soft delete flag - if false, employee is considered deleted
        /// Better than hard delete for audit trails
        /// </summary>
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

        #region INotifyPropertyChanged Implementation
        /// <summary>
        /// Event that fires when a property value changes
        /// This is essential for WPF data binding to work
        /// The UI subscribes to this event and updates automatically
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Helper method to raise PropertyChanged event
        /// CallerMemberName automatically gets the calling property's name
        /// This eliminates the need to pass property name as a string
        /// </summary>
        /// <param name="propertyName">Name of the property that changed</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Invoke the event only if there are subscribers
            // The ?. operator is null-conditional - prevents NullReferenceException
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor initializing default values
        /// </summary>
        public Employee()
        {
            // Set sensible defaults
            HireDate = DateTime.Today;
            IsActive = true;
        }
        #endregion
    }
}

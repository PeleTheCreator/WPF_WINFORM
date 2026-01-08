
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmployeeManager.Models
{
    /// <summary>
    /// Model class representing a Department entity
    /// Departments are used to categorize employees
    /// </summary>
    public class Department : INotifyPropertyChanged
    {
        #region Private Fields
        private int _departmentId;
        private string _departmentName;
        private string _description;
        private bool _isActive;
        #endregion

        #region Public Properties
        /// <summary>
        /// Unique identifier for the department
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
        /// Name of the department (e.g., "IT", "HR", "Finance")
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
        /// Optional description of the department
        /// </summary>
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Indicates if the department is active
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Constructor
        public Department()
        {
            IsActive = true;
        }
        #endregion
    }
}


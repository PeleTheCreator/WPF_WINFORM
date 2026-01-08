

using System;
using System.ComponentModel;
using EmployeeManagementPro.MVVM;

namespace EmployeeManagementPro.Model
{
    public class Employee : INotifyBaseModel
    {
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

        public int EmployeeId 
        {
            get
            {
                return _employeeId;
            }
            set
            {
                _employeeId = value;
                OnPropertyChanged();
            }
        }

        public string FullName => $"{FirstName} {LastName}";
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
    }
}



using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using EmployeeManager.Data;

namespace EmployeeManagementPro.ViewModels

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
    public class MainViewModel 
    {
        public int MyProperty { get; set; }

    }
}
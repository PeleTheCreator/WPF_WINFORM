
using System;
using System.Windows.Input;

namespace EmployeeManager.Commands
{
    /// <summary>
    /// Implementation of ICommand interface for MVVM pattern
    /// RelayCommand allows us to bind button clicks and other UI actions to ViewModel methods
    /// This eliminates code-behind and maintains separation of concerns
    /// Generic version allows passing parameters to commands
    /// </summary>
    /// <typeparam name="T">Type of parameter passed to the command</typeparam>
    public class RelayCommand<T> : ICommand
    {
        #region Private Fields
        // Action to execute when command is invoked
        private readonly Action<T> _execute;

        // Function to determine if command can execute
        // If null, command can always execute
        private readonly Func<T, bool> _canExecute;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="execute">The action to execute - REQUIRED</param>
        /// <param name="canExecute">Function determining if command can execute - OPTIONAL</param>
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            // Execute method is required
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        #endregion

        #region ICommand Implementation
        /// <summary>
        /// Event that fires when CanExecute value changes
        /// CommandManager.RequerySuggested is WPF's built-in event that fires
        /// when UI state changes (like focus changes, text input, etc.)
        /// This automatically re-evaluates if buttons should be enabled/disabled
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Determines whether the command can execute
        /// This controls if buttons are enabled or disabled
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        /// <returns>True if command can execute, false otherwise</returns>
        public bool CanExecute(object parameter)
        {
            // If no canExecute function was provided, always return true
            // Otherwise, call the canExecute function with the parameter
            return _canExecute == null || _canExecute((T)parameter);
        }

        /// <summary>
        /// Executes the command
        /// This is called when the button is clicked or command is triggered
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
        #endregion
    }

    /// <summary>
    /// Non-generic version of RelayCommand for commands without parameters
    /// Most commonly used version
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Fields
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new RelayCommand without parameters
        /// </summary>
        /// <param name="execute">The action to execute - REQUIRED</param>
        /// <param name="canExecute">Function determining if command can execute - OPTIONAL</param>
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        #endregion

        #region ICommand Implementation
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
        #endregion
    }
}


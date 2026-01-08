#region oldApp

//using System;
//using System.Windows;

//namespace EmployeeManager
//{
//    /// <summary>
//    /// Code-behind for App.xaml
//    /// This is the application entry point
//    /// 
//    /// Application lifecycle events you can handle here:
//    /// - Startup: When application starts (before main window)
//    /// - Exit: When application closes
//    /// - Activated: When application gains focus
//    /// - Deactivated: When application loses focus
//    /// - DispatcherUnhandledException: Global exception handler
//    /// </summary>
//    public partial class App : Application
//    {
//        /// <summary>
//        /// Constructor - called before any windows are created
//        /// Good place for application-wide initialization
//        /// </summary>
//        public App()
//        {
//            // You can register global exception handlers here
//            // this.DispatcherUnhandledException += App_DispatcherUnhandledException;
//        }

//        /// <summary>
//        /// Called when application starts
//        /// Use this for initialization that needs to happen before main window shows
//        /// </summary>
//        /// <param name="e">Startup event arguments</param>
//        protected override void OnStartup(StartupEventArgs e)
//        {
//            base.OnStartup(e);

//            // Example: You could initialize logging here
//            // Example: You could check for updates
//            // Example: You could validate database connection
//            // Example: You could set up dependency injection container

//            // Access command line arguments if needed
//            // string[] args = e.Args;
//        }

//        /// <summary>
//        /// Called when application exits
//        /// Clean up resources here
//        /// </summary>
//        /// <param name="e">Exit event arguments</param>
//        protected override void OnExit(ExitEventArgs e)
//        {
//            // Clean up resources
//            // Save application state
//            // Close database connections if any are open
//            // Flush logs

//            base.OnExit(e);
//        }

//        /// <summary>
//        /// Global exception handler
//        /// Catches unhandled exceptions from any thread
//        /// IMPORTANT: This is your last line of defense against crashes
//        /// </summary>
//        /// <param name="sender">Event sender</param>
//        /// <param name="e">Exception event arguments</param>
//        private void App_DispatcherUnhandledException(object sender,
//            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
//        {
//            // Log the exception
//            // In production, use proper logging framework (Serilog, NLog, etc.)
//            string errorMessage = $"An unexpected error occurred: {e.Exception.Message}";

//            // Show user-friendly error dialog
//            MessageBox.Show(
//                errorMessage,
//                "Error",
//                MessageBoxButton.OK,
//                MessageBoxImage.Error);

//            // Mark exception as handled to prevent application crash
//            // Only do this if you're sure the application can continue safely
//            e.Handled = true;

//            // In production, you might want to:
//            // 1. Log to file
//            // 2. Send error report to server
//            // 3. Show detailed error in debug mode only
//            // 4. Restart application if critical error
//        }
//    }
//}

#endregion


using System;
using System.Windows;
using EmployeeManager.Data;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace EmployeeManager
{
    /// <summary>
    /// Application entry point - UPDATED with Serilog configuration
    /// 
    /// LOGGING SETUP:
    /// Serilog is configured here before anything else runs
    /// This ensures all application events are logged
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Constructor - Set up logging first
        /// </summary>
        public App()
        {
            // =============================================
            // SERILOG CONFIGURATION
            // This is the FIRST thing that should happen
            // =============================================

            Log.Logger = new LoggerConfiguration()
                // Minimum log level - Debug shows everything, Information shows less
                .MinimumLevel.Debug()

                // Write to FILE with rolling interval
                // Creates new log file each day: logs/app-20250107.txt
                //// Keeps logs organized and prevents huge single files
                //.WriteTo.File(
                //    path: "logs/app-.txt",
                //    rollingInterval: RollingInterval.Day,
                //    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")

                // OPTIONAL: Also write to Console (useful during development)
               // .WriteTo.Console()

                // Create the logger
                .CreateLogger();

            // Log application start
            Log.Information("========================================");
            Log.Information("Application Starting");
            Log.Information("========================================");

            // Register global exception handler
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            // Log when application domain unloads (crashes)
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        public IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        /// Called when application starts
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Log.Information("OnStartup called");

            // Log command line arguments if any
            if (e.Args.Length > 0)
            {
                Log.Information("Command line arguments: {Args}", string.Join(" ", e.Args));
            }

            var service = new ServiceCollection();

            ConfigureService(service);

            ServiceProvider = service.BuildServiceProvider();
            // You could perform other startup tasks here:
            // - Check for updates
            // - Validate database connection
            // - Load user settings
            // - Initialize dependency injection container
        }

        private void ConfigureService(ServiceCollection service)
        {
            service.AddSingleton<IDatabaseService, DatabaseService>();
        }

        /// <summary>
        /// Called when application exits normally
        /// </summary>
        protected override void OnExit(ExitEventArgs e)
        {
            Log.Information("Application exiting with code: {ExitCode}", e.ApplicationExitCode);
            Log.Information("========================================");

            // Flush and close log
            // IMPORTANT: Always call this to ensure all logs are written
            Log.CloseAndFlush();

            base.OnExit(e);
        }

        /// <summary>
        /// Global exception handler for UI thread
        /// Catches unhandled exceptions that would crash the application
        /// This is your SAFETY NET
        /// </summary>
        private void App_DispatcherUnhandledException(object sender,
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            // LOG THE ERROR - This is critical for debugging production issues
            Log.Fatal(e.Exception, "Unhandled exception in UI thread");

            // Show user-friendly error message
            string errorMessage = $"An unexpected error occurred:\n\n{e.Exception.Message}\n\n" +
                                 $"The error has been logged. Please contact support if the problem persists.";

            MessageBox.Show(
                errorMessage,
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            // Mark as handled to prevent crash
            // CAUTION: Only do this if you're sure the app can continue
            // For critical errors, let it crash and restart
            e.Handled = true;

            // In production, you might want to:
            // 1. Send error report to server
            // 2. Offer to restart application
            // 3. Save user's work before closing
        }

        /// <summary>
        /// Handles exceptions from non-UI threads
        /// These cannot be handled and will crash the application
        /// At least we can log them before crashing
        /// </summary>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;

            if (exception != null)
            {
                Log.Fatal(exception, "Unhandled exception in non-UI thread. Application will terminate.");
            }
            else
            {
                Log.Fatal("Unhandled exception (non-Exception type): {Exception}", e.ExceptionObject);
            }

            // Ensure log is written before app terminates
            Log.CloseAndFlush();

            // Show error before crashing
            MessageBox.Show(
                "A fatal error occurred. The application will now close.",
                "Fatal Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}

/*
 * =============================================================================
 * LOGGING BEST PRACTICES WITH SERILOG:
 * =============================================================================
 * 
 * 1. LOG LEVELS (Use appropriately):
 *    
 *    Verbose  - Very detailed, usually not needed
 *    Debug    - Detailed info for debugging (development only)
 *    Information - General informational messages
 *    Warning  - Something unexpected but application continues
 *    Error    - Error occurred but application can recover
 *    Fatal    - Critical error, application will crash
 * 
 *    Examples:
 *    Log.Debug("Processing item {ItemId}", itemId);
 *    Log.Information("User logged in: {Username}", username);
 *    Log.Warning("API rate limit approaching: {Remaining}", remaining);
 *    Log.Error(ex, "Failed to save data");
 *    Log.Fatal(ex, "Database connection failed, cannot continue");
 * 
 * 
 * 2. STRUCTURED LOGGING:
 *    
 *    ❌ BAD (String interpolation):
 *    Log.Information($"User {username} logged in");
 *    
 *    ✅ GOOD (Structured parameters):
 *    Log.Information("User {Username} logged in", username);
 *    
 *    Why? Serilog can index and search by Username later
 * 
 * 
 * 3. EXCEPTION LOGGING:
 *    
 *    ❌ BAD:
 *    Log.Error("Error occurred: " + ex.Message);
 *    
 *    ✅ GOOD:
 *    Log.Error(ex, "Error loading employees");
 *    
 *    Why? Captures full stack trace, inner exceptions, etc.
 * 
 * 
 * 4. CONTEXT ENRICHMENT:
 *    
 *    Add context to all logs:
 *    Log.Information("Operation completed in {Duration}ms by {User}", 
 *                    duration, currentUser);
 * 
 * 
 * 5. PERFORMANCE CONSIDERATIONS:
 *    
 *    - Use appropriate log levels (don't log everything in production)
 *    - Async logging for high-volume scenarios
 *    - Rolling files to prevent disk space issues
 *    - Consider log aggregation services (Seq, Splunk, ELK)
 * 
 * 
 * 6. WHAT TO LOG:
 *    
 *    ✅ DO LOG:
 *    - Application start/stop
 *    - User actions (login, important operations)
 *    - Database operations
 *    - API calls
 *    - Errors and exceptions
 *    - Performance metrics
 *    - Security events
 *    
 *    ❌ DON'T LOG:
 *    - Passwords or sensitive data
 *    - Personal information (unless required and secured)
 *    - Excessive debug info in production
 *    - Every single property change
 * 
 * 
 * 7. PRODUCTION CONFIGURATION:
 *    
 *    For production, consider:
 *    
 *    Log.Logger = new LoggerConfiguration()
 *        .MinimumLevel.Information()  // Less verbose
 *        .WriteTo.File("logs/app-.txt", 
 *                      rollingInterval: RollingInterval.Day,
 *                      retainedFileCountLimit: 30)  // Keep 30 days
 *        .WriteTo.Seq("http://seq-server:5341")  // Centralized logging
 *        .Enrich.WithMachineName()  // Add machine name
 *        .Enrich.WithEnvironmentUserName()  // Add user
 *        .CreateLogger();
 * 
 * 
 * 8. NUGET PACKAGES NEEDED:
 *    
 *    Install-Package Serilog
 *    Install-Package Serilog.Sinks.File
 *    Install-Package Serilog.Sinks.Console
 *    
 *    Optional:
 *    Install-Package Serilog.Sinks.Seq  (for centralized logging)
 *    Install-Package Serilog.Enrichers.Environment
 * 
 * 
 * 9. REAL-WORLD USAGE IN YOUR CODE:
 *    
 *    // In DatabaseService:
 *    try
 *    {
 *        Log.Information("Getting all employees");
 *        var employees = await GetAllEmployeesAsync();
 *        Log.Information("Loaded {Count} employees", employees.Count);
 *    }
 *    catch (SqlException ex)
 *    {
 *        Log.Error(ex, "SQL error loading employees");
 *        throw;
 *    }
 *    
 *    // In ViewModel:
 *    Log.Information("User {User} started editing employee {EmployeeId}", 
 *                    currentUser, employee.EmployeeId);
 * 
 * 
 * 10. READING LOGS:
 *    
 *     Logs are in: [ProjectFolder]/bin/Debug/logs/app-20250107.txt
 *     
 *     Example log entry:
 *     2025-01-07 14:30:45.123 [INF] User john.doe started editing employee 5
 *     2025-01-07 14:30:46.234 [ERR] SQL error loading employees
 *     System.Data.SqlClient.SqlException: Connection timeout
 *        at System.Data.SqlClient.SqlConnection.Open()
 *        ...
 * 
 * 
 * WHY LOGGING IS CRITICAL:
 * 
 * - Production issues are IMPOSSIBLE to debug without logs
 * - Users report "it's broken" - logs tell you exactly what happened
 * - Performance issues can be tracked over time
 * - Security incidents need audit trail
 * - Compliance requirements often mandate logging
 * - Your boss will ask "what went wrong?" - logs have the answer
 * 
 * REMEMBER: If it's not logged, it didn't happen (from debugging perspective)
 * 
 * =============================================================================
 */
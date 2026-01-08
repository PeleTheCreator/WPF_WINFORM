using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserProfile.Application.BL.Implementation;
using UserProfile.Application.BL.Interface;
using UserProfile.Application.Logging;
using UserProfile.Application.Reprositories;
using UserProfile.Application.Utilities;
using UserProfile.BL.Application.Interfaces;
using UserProfile.Data.DbContext;
using UserProfile.Data.Repositories.SqlServerDB;
using UserProfile.Data.Utilities;

namespace UserProfileManager.WinFormsUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Logging setup
            var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.log");
            ILogger logger = new FileLogger(logPath);
            ExceptionShield.Configure(logger);

            //GLOBAL EXCEPTION HANDLERS
            Application.ThreadException += (s, e) =>
            {
                logger.Error("UI thread exception", e.Exception);
                ShowFriendlyError();
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                logger.Error("Non-UI thread exception", e.ExceptionObject as Exception);
                ShowFriendlyError();
            };

            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                logger.Error("Task exception", e.Exception);
                e.SetObserved(); // keep process alive
                ShowFriendlyError();
            };

            string connString = ConfigurationManager
                                    .ConnectionStrings["DbConnection"]
                                    .ConnectionString;

            //dbcontext
            //var dbContext = new AccessDbContext(connString);
            var dbContext = new SqlServerDbContext(connString);
            ICurrentUserContext currentUser = new CurrentUserContext();

            //reprository
            IUnitOfWork unitOfWork = new UnitOfWork(dbContext);
           

            //service          
            IUserProfileService userService = new UserProfileService(unitOfWork);
            IAuthorizationService authorizationService = new AuthorizationService(currentUser);

            using (var login = new SelectUserForm(userService, currentUser))
            {
                if (login.ShowDialog() != DialogResult.OK)
                    return; // exit if cancelled
            }

            Application.Run(new MainForm(userService, authorizationService, currentUser));
        }

        private static void ShowFriendlyError()
        {
            MessageBox.Show(
                "An unexpected error occurred. The issue has been logged.",
                "Application Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}

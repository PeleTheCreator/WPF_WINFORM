

using System;
using UserProfile.Application.Logging;

namespace UserProfile.Application.Utilities
{
    public static class ExceptionShield
    {
        private static ILogger _logger;

        public static void Configure(ILogger logger)
        {
            _logger = logger;
        }

        public static T Execute<T>(Func<T> func, string contextMessage = null)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                _logger?.Error($"Unhandled exception in: {contextMessage ?? "Unknown"}", ex);
                throw new ApplicationException("An unexpected error occurred. Please contact support.");
            }
        }

        public static void Execute(Action action, string contextMessage = null)
        {
            Execute<object>(() =>
            {
                action();
                return null;
            }, contextMessage);
        }
    }
}

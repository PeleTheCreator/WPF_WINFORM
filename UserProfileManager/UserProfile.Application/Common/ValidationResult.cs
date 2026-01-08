

using System.Collections.Generic;

namespace UserProfile.Application.Common
{
    public class ValidationResult
    {
        public bool IsValid => Errors.Count == 0;
        public List<string> Errors { get; } = new List<string>();

        public void AddError(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                Errors.Add(message);
        }

        public override string ToString() => string.Join("; ", Errors);
    }
}

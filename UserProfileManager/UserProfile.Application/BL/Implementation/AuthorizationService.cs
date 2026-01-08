using UserProfile.Application.BL.Interface;

namespace UserProfile.Application.BL.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ICurrentUserContext _context;

        public AuthorizationService(ICurrentUserContext context)
        {
            _context = context;
        }

        public bool IsAdmin()
            => _context.Current != null && _context.Current.IsAdmin;
    }
}

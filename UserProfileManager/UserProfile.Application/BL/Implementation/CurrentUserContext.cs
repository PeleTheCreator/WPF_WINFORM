
using UserProfile.Application.BL.Interface;
using UserProfile.Domain.Entities;

namespace UserProfile.Application.BL.Implementation
{
    public class CurrentUserContext : ICurrentUserContext
    {
        public UserProfileEntity Current { get; set; }
    }
}

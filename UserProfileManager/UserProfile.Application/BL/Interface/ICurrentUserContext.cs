
using UserProfile.Domain.Entities;

namespace UserProfile.Application.BL.Interface
{
    public interface ICurrentUserContext
    {
        UserProfileEntity Current { get; set; }
    }
}

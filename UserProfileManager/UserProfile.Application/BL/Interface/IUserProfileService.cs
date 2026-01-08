using System.Collections.Generic;
using System.Threading.Tasks;
using UserProfile.Application.Common;
using UserProfile.Domain.Entities;

namespace UserProfile.BL.Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<IList<UserProfileEntity>> GetAllActiveAsync();
        Task<UserProfileEntity> GetByIdAsync(int id);
        Task<UserProfileEntity> GetByDomainAndAccountAsync(string domain, string account);
        Task<(ValidationResult, int?)> CreateAsync(UserProfileEntity user);
        Task<ValidationResult> UpdateAsync(UserProfileEntity user);
        Task<ValidationResult> SoftDeleteAsync(int id);
        Task<IList<UserProfileEntity>> SearchAsync(string term);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using UserProfile.Domain.Entities;

namespace UserProfile.Application.Reprositories
{
    public interface IUserProfileRepository
    {
        Task<IList<UserProfileEntity>> GetAllActiveAsync();
        Task<UserProfileEntity> GetByIdAsync(int id);
        Task<UserProfileEntity> GetByDomainAndAccountAsync(string domain, string account);
        Task<int> InsertAsync(UserProfileEntity user);
        Task UpdateAsync(UserProfileEntity user);
        Task SoftDeleteAsync(int id);
        Task<IList<UserProfileEntity>> SearchAsync(string term);
    }
}

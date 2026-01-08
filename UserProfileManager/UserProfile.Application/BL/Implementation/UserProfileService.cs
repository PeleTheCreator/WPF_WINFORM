using System.Collections.Generic;
using System.Threading.Tasks;
using UserProfile.Application.Common;
using UserProfile.Application.Reprositories;
using UserProfile.BL.Application.Interfaces;
using UserProfile.Domain.Entities;

namespace UserProfile.Application.BL.Implementation
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userprofilerepo;
        private readonly IUnitOfWork _repo;

        public UserProfileService(IUnitOfWork repo)
        {
            _userprofilerepo = repo.UserProfiles;
            _repo = repo;
        }

        public async Task<IList<UserProfileEntity>> GetAllActiveAsync()
            => await _userprofilerepo.GetAllActiveAsync();

        public async Task<(ValidationResult, int?)> CreateAsync(UserProfileEntity user)
        {
            var vr = Validate(user);
            if (!vr.IsValid) return (vr, null);

            // enforce rule: Name = Domain\Account
            user.DisplayName = $"{user.DomainName}\\{user.Account}";
            user.Status = RecordStatus.Active;

            var id = await _userprofilerepo.InsertAsync(user);
            return (vr, id);
        }

        public async Task<ValidationResult> UpdateAsync(UserProfileEntity user)
        {
            var vr = Validate(user);
            if (!vr.IsValid) return vr;

            user.DisplayName = $"{user.DomainName}\\{user.Account}";
            await _userprofilerepo.UpdateAsync(user);
            return vr;
        }

        public async Task<ValidationResult> SoftDeleteAsync(int id)
        {
            var vr = new ValidationResult();
            if (id <= 0)
                vr.AddError("Invalid user id.");

            if (!vr.IsValid) return vr;

            await _userprofilerepo.SoftDeleteAsync(id);
            return vr;
        }

        private ValidationResult Validate(UserProfileEntity user)
        {
            var vr = new ValidationResult();

            if (string.IsNullOrWhiteSpace(user.Account))
                vr.AddError("Account is required.");

            if (string.IsNullOrWhiteSpace(user.DomainName))
                vr.AddError("Domain is required.");

            if (string.IsNullOrWhiteSpace(user.Email))
                vr.AddError("Email is required.");

            // Could also validate email format, length, etc.

            return vr;
        }

        public async Task<UserProfileEntity> GetByIdAsync(int id)
        {
             return  await _userprofilerepo.GetByIdAsync(id);
        }

        public async Task<UserProfileEntity> GetByDomainAndAccountAsync(string domain, string account)
        {
            return await _userprofilerepo.GetByDomainAndAccountAsync(domain, account);
        }

        public async Task<IList<UserProfileEntity>> SearchAsync(string term)
        {
            return await _userprofilerepo.SearchAsync(term);
        }
    }
}

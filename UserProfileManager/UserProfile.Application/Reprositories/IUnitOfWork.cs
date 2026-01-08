
using UserProfile.Application.Reprositories.UserProfile.Domain.Interfaces;

namespace UserProfile.Application.Reprositories
{
    public interface IUnitOfWork
    {
        IUserProfileRepository UserProfiles { get; }
        IBranchRepository Branches { get; }
        ILocalSystemRepository LocalSystems { get; }
    }
}

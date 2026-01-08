using System.Collections.Generic;
using System.Threading.Tasks;
using UserProfile.Domain.Entities;

namespace UserProfile.Application.Reprositories
{
    public interface ILocalSystemRepository
    {
        Task<IList<LocalSystemEntity>> GetAllAsync();

    }
}

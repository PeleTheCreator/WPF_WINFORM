using System.Collections.Generic;
using UserProfile.Domain.Entities;
using System.Threading.Tasks;

namespace UserProfile.Application.Reprositories
{
    namespace UserProfile.Domain.Interfaces
    {
        public interface IBranchRepository
        {
            Task<IList<BranchEntity>> GetAllAsync();
        }
    }

}

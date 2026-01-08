using System;
using System.Data;
using System.Threading.Tasks;
using UserProfile.Application.Reprositories;
using UserProfile.Application.Reprositories.UserProfile.Domain.Interfaces;
using UserProfile.Data.DbContext;
using UserProfile.Infrastructure.SqlServerDB.Repositories;

namespace UserProfile.Data.Repositories.SqlServerDB
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerDbContext _context;

        public IUserProfileRepository UserProfiles { get; }
        public IBranchRepository Branches { get; }
        public ILocalSystemRepository LocalSystems { get; }

        public UnitOfWork(SqlServerDbContext context)
        {
            _context = context;

            UserProfiles = new UserProfileRepository(_context);
            Branches = new BranchRepository(_context);
            LocalSystems = new LocalSystemRepository(_context);
        }

        public void Dispose()
        {
            (_context as IDisposable)?.Dispose();
        }
    }
}

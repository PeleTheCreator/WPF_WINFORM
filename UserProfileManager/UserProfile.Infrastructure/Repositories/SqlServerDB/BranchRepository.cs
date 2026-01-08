using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UserProfile.Application.Reprositories.UserProfile.Domain.Interfaces;
using UserProfile.Data.DbContext;
using UserProfile.Domain.Entities;

namespace UserProfile.Infrastructure.SqlServerDB.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly SqlServerDbContext _context;

        public BranchRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<BranchEntity>> GetAllAsync()
        {
            var list = new List<BranchEntity>();

            using (var conn = _context.CreateConnection())
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText =
                    "SELECT BranchCode, BranchName FROM Branch WHERE BranchCode IS NOT NULL";

                conn.Open();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new BranchEntity
                        {
                            Code = reader["BranchCode"]?.ToString(),
                            Name = reader["BranchName"]?.ToString()
                        });
                    }
                }
            }

            return list;
        }
    }
}

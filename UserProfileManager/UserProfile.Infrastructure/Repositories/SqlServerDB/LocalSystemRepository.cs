using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UserProfile.Application.Reprositories;
using UserProfile.Data.DbContext;
using UserProfile.Domain.Entities;
using UserProfile.Infrastructure.DbContext;

namespace UserProfile.Infrastructure.SqlServerDB.Repositories
{
    public class LocalSystemRepository : ILocalSystemRepository
    {
        private readonly SqlServerDbContext _context;

        public LocalSystemRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<LocalSystemEntity>> GetAllAsync()
        {
            var list = new List<LocalSystemEntity>();

            using (var conn = _context.CreateConnection())
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText =
                    "SELECT LocalSystemId, LocalSystemName FROM LocalSystem WHERE LocalSystemId <> 0";

                conn.Open();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new LocalSystemEntity
                        {
                            Id = reader["LocalSystemId"] != DBNull.Value
                                ? Convert.ToInt32(reader["LocalSystemId"])
                                : 0,
                            Name = reader["LocalSystemName"]?.ToString()
                        });
                    }
                }
            }

            return list;
        }
    }
}

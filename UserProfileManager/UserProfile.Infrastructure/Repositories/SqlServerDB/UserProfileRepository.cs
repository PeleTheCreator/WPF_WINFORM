using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using UserProfile.Application.Reprositories;
using UserProfile.Data.DataMappers;
using UserProfile.Data.DbContext;
using UserProfile.Domain.Entities;

namespace UserProfile.Infrastructure.SqlServerDB.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly SqlServerDbContext _context;

        public UserProfileRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<UserProfileEntity>> GetAllActiveAsync()
        {
            var list = new List<UserProfileEntity>();
            var query = @"
                SELECT UserProfileId,
                       UserProfileStatus,
                       UserProfileAccount,
                       UserProfileDomainName,
                       UserProfileName,
                       UserProfileMailAddress,
                       UserProfileUserLevelToUserAdmin
                FROM UserProfile
                WHERE UserProfileStatus <> -1 OR UserProfileStatus IS NULL
            ";
            using (var conn = _context.CreateConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                        list.Add(UserProfileMapper.Map(reader));
                }
            }

            return list;

        }

        public async Task<UserProfileEntity> GetByDomainAndAccountAsync(string domain, string account)
        {
            using (var conn = _context.CreateConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT * FROM UserProfile
                    WHERE UserProfileDomainName = @domain
                      AND UserProfileAccount = @account
                      AND UserProfileStatus <> -1";

                cmd.Parameters.AddWithValue("@domain", domain);
                cmd.Parameters.AddWithValue("@account", account);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                        return UserProfileMapper.Map(reader);
                }
                    
            }
            return null;
        }

        public async Task<UserProfileEntity> GetByIdAsync(int id)
        {
            var query = $@"
                SELECT UserProfileId,
                       UserProfileStatus,
                       UserProfileAccount,
                       UserProfileDomainName,
                       UserProfileName,
                       UserProfileMailAddress,
                       UserProfileUserLevelToUserAdmin
                FROM UserProfile
                WHERE UserProfileId = {id}";
            using (var conn = _context.CreateConnection())

            using (var cmd = new SqlCommand(
            query, conn))
            {
                await conn.OpenAsync();

                using (var reader =  cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return UserProfileMapper.Map(reader);
                }
            }

            return null;
        }

        public async Task<int> InsertAsync(UserProfileEntity user)
        {
            using (var conn = _context.CreateConnection())
            using (var cmd = new SqlCommand(@"
                INSERT INTO UserProfile
                (UserProfileStatus,
                 UserProfileAccount,
                 UserProfileDomainName,
                 UserProfileName,
                 UserProfileMailAddress,
                 UserProfileUserLevelToUserAdmin,
                 UserProfileOperatorId,
                 UserProfileTimeStamp)
                VALUES
                (@Status, @Account, @Domain, @Name, @Mail,
                 @IsAdmin, @OperatorId, @Timestamp);

                SELECT SCOPE_IDENTITY();
            ", conn))
            {
                cmd.Parameters.AddWithValue("@Status", user.Status);
                cmd.Parameters.AddWithValue("@Account", user.Account);
                cmd.Parameters.AddWithValue("@Domain", user.DomainName);
                cmd.Parameters.AddWithValue("@Name", user.DisplayName);
                cmd.Parameters.AddWithValue("@Mail", user.Email);
                cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin ? "Y" : "N");
                cmd.Parameters.AddWithValue("@OperatorId", 1);
                cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);

                await conn.OpenAsync();
                var result = await cmd.ExecuteScalarAsync();

                return Convert.ToInt32(result);
            }
        }

        public async Task UpdateAsync(UserProfileEntity user)
        {
            using (var conn = _context.CreateConnection())
            using (var cmd = new SqlCommand(@"
                UPDATE UserProfile
                SET UserProfileStatus = @Status,
                    UserProfileAccount = @Account,
                    UserProfileDomainName = @Domain,
                    UserProfileName = @Name,
                    UserProfileMailAddress = @Mail,
                    UserProfileUserLevelToUserAdmin = @IsAdmin,
                    UserProfileOperatorId = @OperatorId,
                    UserProfileTimeStamp = @Timestamp
                WHERE UserProfileId = @Id
            ", conn))
            {
                cmd.Parameters.AddWithValue("@Status", user.Status);
                cmd.Parameters.AddWithValue("@Account", user.Account);
                cmd.Parameters.AddWithValue("@Domain", user.DomainName);
                cmd.Parameters.AddWithValue("@Name", user.DisplayName);
                cmd.Parameters.AddWithValue("@Mail", user.Email);
                cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin ? "Y" : "N");
                cmd.Parameters.AddWithValue("@OperatorId", 1);
                cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                cmd.Parameters.AddWithValue("@Id", user.Id);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task SoftDeleteAsync(int id)
        {
            using (var conn = _context.CreateConnection())
            using (var cmd = new SqlCommand(@"
                UPDATE UserProfile
                SET UserProfileStatus = -1
                WHERE UserProfileId = @Id
            ", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }


        public async Task<IList<UserProfileEntity>> SearchAsync(string term)
        {
            var list = new List<UserProfileEntity>();
            var query = @"
        SELECT UserProfileId,
               UserProfileStatus,
               UserProfileAccount,
               UserProfileDomainName,
               UserProfileName,
               UserProfileMailAddress,
               UserProfileUserLevelToUserAdmin
        FROM UserProfile
        WHERE (UserProfileStatus <> -1 OR UserProfileStatus IS NULL)
          AND (
              UserProfileAccount LIKE @Term OR
              UserProfileName LIKE @Term OR
              UserProfileMailAddress LIKE @Term
          )
    ";

            using (var conn = _context.CreateConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@Term", SqlDbType.NVarChar).Value = $"%{term}%";

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                        list.Add(UserProfileMapper.Map(reader));
                }
            }

            return list;
        }
    }
}

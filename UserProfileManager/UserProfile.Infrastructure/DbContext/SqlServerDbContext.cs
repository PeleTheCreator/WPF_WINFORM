

using System.Data.SqlClient;

namespace UserProfile.Data.DbContext
{
    public class SqlServerDbContext
    {
        private readonly string _connectionString;

        public SqlServerDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

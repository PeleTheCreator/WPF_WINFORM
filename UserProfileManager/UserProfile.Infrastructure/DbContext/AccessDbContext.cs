
using System.Data.OleDb;


namespace UserProfile.Infrastructure.DbContext
{
    public class AccessDbContext
    {
        private readonly string _connectionString;

        public AccessDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public OleDbConnection CreateConnection()
        {
            return new OleDbConnection(_connectionString);
        }
    }
}

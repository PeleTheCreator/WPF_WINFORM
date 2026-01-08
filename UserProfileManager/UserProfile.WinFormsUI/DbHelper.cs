using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace UserProfileManager.WinFormsUI
{
    public static class DbHelper
    {
        private static string ConStr
        {
            get { return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString; }
        }

        public static DataTable GetTable(string sql, params SqlParameter[] p)
        {
            using (var con = new SqlConnection(ConStr))
            using (var da = new SqlDataAdapter(sql, con))
            {
                if (p != null && p.Length > 0)
                    da.SelectCommand.Parameters.AddRange(p);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] p)
        {
            using (var con = new SqlConnection(ConStr))
            using (var cmd = new SqlCommand(sql, con))
            {
                if (p != null && p.Length > 0)
                    cmd.Parameters.AddRange(p);

                con.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static void Execute(string sql, params SqlParameter[] p)
        {
            using (var con = new SqlConnection(ConStr))
            using (var cmd = new SqlCommand(sql, con))
            {
                if (p != null && p.Length > 0)
                    cmd.Parameters.AddRange(p);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace myFirstAoo
{
    class imp
    {
       private static string s = "Data Source=LAB4-118;Initial Catalog=dadDB;User ID=sa;Password=aptech";
       public static SqlConnection con = new SqlConnection(s);
       public void addUser(string name,string phone,Int16 age,Int16 gender,Int16 status)
       {
           try
           {
               SqlCommand cmd = new SqlCommand("st_insertUser", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@name", name);
               cmd.Parameters.AddWithValue("@phone", phone);
               cmd.Parameters.AddWithValue("@gender", gender);
               cmd.Parameters.AddWithValue("@age", age);
               cmd.Parameters.AddWithValue("@status", status);
               con.Open();
               int x = cmd.ExecuteNonQuery();
               if (x>0)
               {
                   MessageBox.Show(name+" added successfully into system.");
               }
               con.Close();
           }
           catch (Exception ex)
           {
              MessageBox.Show(ex.Message);
           }
       }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using sharedClasses;
using System.IO;
using sharedClasses.Exceptions;

namespace DAL
{
     class sqlConnector  
    {

        private static string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("cybrusToolKit")) +@"cybrusToolKit\DAL\verificationInfo.mdf;Integrated Security=True";
        
       // private static string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\c#\Project\cybrusToolKit\DAL\verificationInfo.mdf;Integrated Security=True";
        internal static string getpassword(string username)
        {
            SqlConnection con = new SqlConnection(CS);

            try {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT UserName,Password FROM [verification] WHERE  UserName= '" + username + "'";
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string password1 = reader.GetString(1); // Password string
                con.Close();
                return password1;
            }
            catch (System.InvalidOperationException)
            {
                throw new nonExistentUser();
            }
           catch (System.Data.SqlClient.SqlException)
            {
                throw new nonExistentUser();
            }
        }

        internal static void setpassword(User u1, String Password)
        {
            SqlConnection con = new SqlConnection(CS);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE [verification] SET Password='" + Password + "' WHERE UserName= '" + u1.getUserName() + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

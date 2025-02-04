using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsIntLicenseData
    {


        public static DataTable ListLicenses(int personid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select internationallicenses.* from internationallicenses join Drivers" +
                "\r\non internationalLicenses.DriverID=Drivers.DriverID\r\n" +
                "where Drivers.PersonID=@id";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@id", personid);

            DataTable dtlicenses = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    dtlicenses.Load(reader);
                }

            }
            finally { connection.Close(); }

            return dtlicenses;

        }


        public static int AddLicense(int appid, int driverid, int ldlid, DateTime issudate, DateTime expdate, bool isactive, int userid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into internationallicenses values " +
                "(@appid,@driverid,@ldlid,@issuedate,@expdate,@active,@userid);select Scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@appid", appid);
            command.Parameters.AddWithValue("@driverid", driverid);
            command.Parameters.AddWithValue("@ldlid", ldlid);
            command.Parameters.AddWithValue("@issuedate",issudate);
            command.Parameters.AddWithValue("@expdate", expdate);
            command.Parameters.AddWithValue("@active", isactive);
            command.Parameters.AddWithValue("@userid", userid);


            int id = -1;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    id = int.Parse(result.ToString());
                }
            }
            finally { connection.Close(); }

            return id;
        }

        public static bool Find(int id,ref int appid,ref int driverid,ref int  ldlid,ref DateTime issudate,ref DateTime expdate,ref bool isactive,ref int userid)
        {
            SqlConnection connection =new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from internationallicenses where internationallicenseid=" + id;

            SqlCommand Command = new SqlCommand( query, connection);

            bool found= false;

            try
            {
                connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if(reader.Read())
                {
                    found = true;
                    driverid = int.Parse(reader["driverid"].ToString());
                    ldlid = int.Parse(reader["issuedusinglocallicenseid"].ToString());
                    issudate = DateTime.Parse(reader["issuedate"].ToString());
                    expdate = DateTime.Parse(reader["expirationdate"].ToString());
                    isactive = bool.Parse(reader["isactive"].ToString());
                    userid = int.Parse(reader["createdbyuserid"].ToString());
                    appid = int.Parse(reader["applicationid"].ToString());
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return found;
        }

        public static bool Find(ref int id, ref int appid, ref int driverid, int ldlid, ref DateTime issudate, ref DateTime expdate, ref bool isactive, ref int userid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from internationallicenses where issuedusinglocallicenseid=" + ldlid;

            SqlCommand Command = new SqlCommand(query, connection);

            bool found = false;

            try
            {
                connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    found = true;
                    driverid = int.Parse(reader["driverid"].ToString());
                    id = int.Parse(reader["internationallicenseid"].ToString());
                    issudate = DateTime.Parse(reader["issuedate"].ToString());
                    expdate = DateTime.Parse(reader["expirationdate"].ToString());
                    isactive = bool.Parse(reader["isactive"].ToString());
                    userid = int.Parse(reader["createdbyuserid"].ToString());
                    appid = int.Parse(reader["applicationid"].ToString());
                }
                reader.Close();
            }
            finally { connection.Close(); }
            return found;
        }

        public static List<string> ListColumns()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select top 1 * from  internationallicenses";


            SqlCommand sqlCommand = new SqlCommand(query, connection);



            List<string> list = new List<string>();

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    list.Add(reader.GetName(i));
                }

            }
            finally { connection.Close(); }

            return list;
        }


        public static DataTable ListLicenses(string where, string order)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from internationallicenses";
            if (where != "")
            {
                query += " where " + order + " like '" + where + "%'";
            }
            query += " order by " + order;

            SqlCommand sqlCommand = new SqlCommand(query, connection);



            DataTable dtlicenses = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    dtlicenses.Load(reader);
                }

            }
            finally { connection.Close(); }

            return dtlicenses;

        }

    }
}
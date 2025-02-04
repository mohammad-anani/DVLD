using DVLD_data;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public static class clsUserData
    {
        public static DataTable ListUsers(string where,string order)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from listusers";

            if(where!="")
            {
                query += " where " + order + " like '" + where + "%'";
            }
            query += " order by " + order;

            SqlCommand cmd = new SqlCommand(query, connection);

           DataTable dtusers=new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dtusers.Load(reader);
                }
                reader.Close();
            }
            finally
            {
                connection.Close();
            }
            return dtusers;
        }

        public static bool UpdateUser(int id,string username, string password, bool isactive)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update users set username=@username,password=@password,isactive=@isactive where userid=@userid";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@userid", id);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@isactive", isactive);

            bool isupdated = false;

            try
            {
                connection.Open();

                int rowsaffected = command.ExecuteNonQuery();

                if(rowsaffected>0)
                {
                    isupdated = true;
                }
            }finally
            {
                connection.Close();
            }
            return isupdated;
        }


        public static bool DeleteUser(int id)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from users where userid=" + id;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isdeleted = false;

            try
            {
                connection.Open();

                int rowsaffected = cmd.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    isdeleted = true;
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return isdeleted;
        }

        public static int Adduser(int personid,string username,string password,bool isactive)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into users values(@personid,@username,@password,@isactive);select scope_identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personid", personid);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue ("@password", password);
            command.Parameters.AddWithValue("@isactive", isactive);

            int id = -1;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    id = int.Parse(result.ToString());
                }
            }finally
            {
                connection.Close() ;
            }
            return id;
        }

        public static DataTable GetUserColumns()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select top 1 * from listusers";


            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtcolumns = new DataTable();

            dtcolumns.Columns.Add("columns");

            try
            {
                connection.Open();

                IDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dtcolumns.Rows.Add(reader.GetName(i));
                    }
                }

                reader.Close();
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return dtcolumns;
        }

        public static bool UserExists(string username,string password)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select found=1 from users where username ='" + username + "' and password='" +
                password + "'";

            SqlCommand cmd = new SqlCommand(query, connection);

            bool exists = false;

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    exists = true;
                }
                reader.Close();
            }finally
            {
                connection.Close();
            }
            return exists;
        }

        public static bool UserExists(int personid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select found=1 from users where personid='" + personid + "'";
                

            SqlCommand cmd = new SqlCommand(query, connection);

            bool exists = false;

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    exists = true;
                }
                reader.Close();
            }
            finally
            {
                connection.Close();
            }
            return exists;
        }

        public static bool UserExists(string nationalno)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select found=1 from users join people on users.PersonID=people.PersonID where People.NationalNo='" + nationalno + "'";


            SqlCommand cmd = new SqlCommand(query, connection);

            bool exists = false;

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    exists = true;
                }
                reader.Close();
            }
            finally
            {
                connection.Close();
            }
            return exists;
        }
        public static bool Find(ref int id,ref int personid,string username, string password,ref bool isactive)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from users where username ='" + username + "' and password='" +
                password + "'";

            SqlCommand cmd = new SqlCommand(query, connection);

            bool exists = false;

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    exists = true;
                    id = int.Parse(reader["userid"].ToString());
                    personid = int.Parse(reader["personid"].ToString());
                    isactive = bool.Parse(reader["isactive"].ToString());
                }
                reader.Close();
            }
            finally
            {
                connection.Close();
            }
            return exists;
        }

        public static bool Find(int id, ref int personid,ref string username,ref string password, ref bool isactive)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from users where userid ='" + id+ "'";

            SqlCommand cmd = new SqlCommand(query, connection);

            bool exists = false;

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    exists = true;
                    username = reader["username"].ToString();
                    password = reader["password"].ToString();
                    personid = int.Parse(reader["personid"].ToString());
                    isactive = bool.Parse(reader["isactive"].ToString());
                }
                reader.Close();
            }
            finally
            {
                connection.Close();
            }
            return exists;
        }


        public static bool HasData(int id)
        {
            SqlConnection connection= new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select found=1 where \r\nexists(select found=1 from Applications where Applications.CreatedByUserID=@id) or\r\nexists(select found=1 from DetainedLicenses where DetainedLicenses.CreatedByUserID=@id) or\r\nexists(select found=1 from Licenses where Licenses.CreatedByUserID=@id) or\r\nexists(select found=1 from Drivers where Drivers.CreatedByUserID=@id) or\r\nexists(select found=1 from InternationalLicenses where InternationalLicenses.CreatedByUserID=@id) or\r\nexists(select found=1 from TestAppointments where TestAppointments.CreatedByUserID=@id) or\r\nexists(select found=1 from Tests where Tests.CreatedByUserID=@id)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);

            bool hasdata=false;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result!=null)
                {
                    hasdata = true;
                }

            }finally
            {
                connection.Close();
            }
            return hasdata;
        }
    }
}

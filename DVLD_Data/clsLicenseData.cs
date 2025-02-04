using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsLicenseData
    {


        public static int Addlicense(int appid, int driverid, int licenseclass, DateTime issuedate,
            DateTime expirationdate, string notes, double fees, bool isactive, int issuereason, int userid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into licenses values " +
                "(@appid,@driverid,@classid,@issuedate,@expirationdate,@notes,@fees,@isactive,@issuereason,@userid);" +
                "select Scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@appid", appid);
            command.Parameters.AddWithValue("@driverid", driverid);
            command.Parameters.AddWithValue("@classid", licenseclass);
            command.Parameters.AddWithValue("@issuedate", issuedate);
            command.Parameters.AddWithValue("@expirationdate", expirationdate);
            if (notes != "")
            { command.Parameters.AddWithValue("@notes", notes); }
            else
                command.Parameters.AddWithValue("@notes", DBNull.Value);
            command.Parameters.AddWithValue("@fees", fees);
            command.Parameters.AddWithValue("@isactive", isactive);
            command.Parameters.AddWithValue("@issuereason", issuereason);
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

        public static bool Find(int id, ref int appid, ref int driverid, ref int licenseclass, ref DateTime issuedate,
         ref DateTime expirationdate, ref string notes, ref double fees, ref bool isactive, ref int issuereason, ref int userid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from licenses where licenseid=" + id;

            SqlCommand command = new SqlCommand(query, connection);

            bool found = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    found = true;
                    appid = int.Parse(reader["applicationid"].ToString());
                    driverid = int.Parse(reader["driverid"].ToString());
                    licenseclass = int.Parse(reader["licenseclass"].ToString());
                    issuedate = DateTime.Parse(reader["issuedate"].ToString());
                    expirationdate = DateTime.Parse(reader["expirationdate"].ToString());
                    notes = reader["notes"].ToString();
                    fees = double.Parse(reader["paidfees"].ToString());
                    isactive = bool.Parse(reader["isactive"].ToString());
                    issuereason = int.Parse(reader["issuereason"].ToString());
                    userid = int.Parse(reader["createdbyuserid"].ToString());
                }
                reader.Close();

            }
            finally { connection.Close(); }

            return found;
        }


        public static bool Find(ref int id, int appid, ref int driverid, ref int licenseclass, ref DateTime issuedate,
     ref DateTime expirationdate, ref string notes, ref double fees, ref bool isactive, ref int issuereason, ref int userid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from licenses where applicationid=" + appid;

            SqlCommand command = new SqlCommand(query, connection);

            bool found = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    found = true;
                    id = int.Parse(reader["licenseid"].ToString());
                    driverid = int.Parse(reader["driverid"].ToString());
                    licenseclass = int.Parse(reader["licenseclass"].ToString());
                    issuedate = DateTime.Parse(reader["issuedate"].ToString());
                    expirationdate = DateTime.Parse(reader["expirationdate"].ToString());
                    if (reader["Notes"] != DBNull.Value)
                    { notes = reader["notes"].ToString(); }
                    fees = double.Parse(reader["paidfees"].ToString());
                    isactive = bool.Parse(reader["isactive"].ToString());
                    issuereason = int.Parse(reader["issuereason"].ToString());
                    userid = int.Parse(reader["createdbyuserid"].ToString());
                }
                reader.Close();

            }
            finally { connection.Close(); }

            return found;
        }


        public static bool IsDetained(int id)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select found=1 from detainedlicenses where isreleased=0 and licenseid=" + id;

            SqlCommand command = new SqlCommand(query, connection);

            bool found = false;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    found = true;
                }
            }
            finally { connection.Close(); }
            return found;
        }


        public static DataTable ListLicenses(int personid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select licenses.* from licenses join Drivers" +
                "\r\non Licenses.DriverID=Drivers.DriverID\r\n" +
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

        public static bool DeactivateLicense(int lid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query="update licenses set isactive=0 where licenseid="+lid;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool done=false;

            try
            {
                connection.Open();

                int rows = cmd.ExecuteNonQuery(); ;

                if(rows>0)
                {
                    done = true;
                }
            }finally { connection.Close(); }
            return done;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsApplicationData
    {
        public static int AddApplication(int personid, DateTime appdate, int apptypeid, int appstatus,
            DateTime laststatusdate, double paidfees, int userid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into applications values" +
                "(@personid,@appdate,@apptypeid,@appstatus,@laststatusdate,@paidfees,@userid);" +
                "select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personid", personid);
            command.Parameters.AddWithValue("@appdate", appdate);
            command.Parameters.AddWithValue("@apptypeid", apptypeid);
            command.Parameters.AddWithValue("@appstatus", appstatus);
            command.Parameters.AddWithValue("@laststatusdate", laststatusdate);
            command.Parameters.AddWithValue("@paidfees", paidfees);
            command.Parameters.AddWithValue("@userid", userid);

            int id = -1;


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int newid))
                {
                    id = int.Parse(result.ToString());
                }

            }
            finally
            {
                connection.Close();
            }
            return id;
        }

        public static bool Find(int id, ref int personid, ref DateTime appdate, ref int apptypeid,
            ref int appstatus, ref DateTime statusdate, ref double paidfees, ref int userid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from applications where applicationid=" + id;

            SqlCommand command = new SqlCommand(query, connection);

            bool found = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    found = true;
                    personid = int.Parse(reader["applicantpersonid"].ToString());
                    appdate = DateTime.Parse(reader["applicationdate"].ToString());
                    apptypeid = int.Parse(reader["applicationtypeid"].ToString());
                    appstatus = int.Parse(reader["applicationstatus"].ToString());
                    statusdate = DateTime.Parse(reader["laststatusdate"].ToString());
                    paidfees = double.Parse(reader["paidfees"].ToString());
                    userid = int.Parse(reader["createdbyuserid"].ToString());
                }
                reader.Close();
            }
            finally
            { connection.Close(); }
            return found;
        }

        public static bool UpdateApplication(int id, double fees)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "Update Applications" +
                " set paidfees=" + fees + " where applicationid=" + id;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool updated = false;

            try
            {
                connection.Open();

                int rowsaffected = cmd.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    updated = true;
                }

            }
            finally
            {
                connection.Close();
            }
            return updated;
        }


        public static bool DeleteApplication(int id)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from applications where applicationid=" + id;

            SqlCommand command = new SqlCommand(query, connection);

            bool deleted = false;

            try
            {
                connection.Open();

                int rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    deleted = true;

                }
            }
            finally { connection.Close(); }
            return deleted;
        }
    }
}

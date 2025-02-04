using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsDetainData
    {

        public static int Add(int licenseid,DateTime detaindate,double fees,int userid)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into detainedlicenses values" +
                "(@licenseid,@detaindate,@fees,@userid,0,null,null,null);" +
                "select scope_identity()";

            SqlCommand cmd=new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@licenseid", licenseid);
            cmd.Parameters.AddWithValue("@detaindate", detaindate);
            cmd.Parameters.AddWithValue("@fees",fees);
            cmd.Parameters.AddWithValue("@userid", userid);

            int newid = -1;

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    newid = int.Parse(result.ToString());
                }

            }finally
            {
                connection.Close();
            }
            return newid;
        }


        public static bool Release(int id, DateTime releasedate,int releaseuserid,int releaseapp)
        {
            SqlConnection connection=new SqlConnection (clsDataSettings.ConnectionString);

            string query = "update detainedlicenses" +
                " set isreleased=1,releasedate=@date,releasedbyuserid=@userid,releaseapplicationid=@app" +
                " where detainid=@id";

            SqlCommand command=new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@date", releasedate);
            command.Parameters.AddWithValue("@userid", releaseuserid);
            command.Parameters.AddWithValue("@app", releaseapp);
            command.Parameters.AddWithValue("@id", id);

            bool release = false;   

            try
            {
                connection.Open();
                int rowsaffected = command.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    release = true;
                }
            }
            finally { connection.Close(); }
            return release;


        }

        public static bool FindByLicense(int licenseid,ref int id,ref double fees)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select top 1 * from detainedlicenses where licenseid=" + licenseid;

            SqlCommand command=new SqlCommand(query, connection);

            bool found= false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    found = true;
                    id = int.Parse(reader["detainid"].ToString());
                    fees = double.Parse(reader["finefees"].ToString());
                }

                reader.Close();
            }
            finally { connection.Close(); }
            return found;
        }

    }
}

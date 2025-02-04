using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clstestappointmentsData
    {

        public static DataTable ListAppointments(int id,int testtypeid)
        {
            SqlConnection connection =new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select TestAppointmentsview.* from TestAppointmentsView\r\n" +
                "join TestAppointments\r\non " +
                "TestAppointmentsView.testappointmentid=TestAppointments.TestAppointmentID\r\n" +
                "join LocalDrivingLicenseApplications\r\non" +
                " LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=" +
                "TestAppointments.LocalDrivingLicenseApplicationID\r\n" +
                "where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@id" +
                " and testappointments.testtypeid=@testtypeid";

            SqlCommand cmd=new SqlCommand(query, connection);

            DataTable dttests=new DataTable();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@testtypeid", testtypeid);
            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    dttests.Load(reader);
                
                }
                reader.Close();
            }
            finally
            {
                connection.Close();
            }
            return dttests;
        }


        public static bool AddAppointment(int testtypeid,int ldlappid,DateTime appdate,double fees,int userid)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into testappointments values" +
                "(@typeid,@appid,@appdate,@fees,@userid,@islocked)";

            SqlCommand command=new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@typeid", testtypeid);
            command.Parameters.AddWithValue("@appid", ldlappid);
            command.Parameters.AddWithValue("@appdate", appdate);
            command.Parameters.AddWithValue("@fees", fees);
            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@islocked", false);

            bool isadded = false;

            try
            {
                connection.Open();

                int rowsaffected = command.ExecuteNonQuery();

                if(rowsaffected>0)
                {
                    isadded = true;
                }

            }finally
            {
                connection.Close();
            }
            return isadded;
        }

        public static bool Update(int id,DateTime appdate,bool islocked=false)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "";
            if (!islocked)
          {
                query= "update testappointments " +
                "set appointmentdate=@date where testappointmentid=" + id;
            }
            else
            {
                query = "update testappointments " +
               "set appointmentdate=@date,islocked=1 where testappointmentid=" + id;
            }

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@date", appdate);

            bool isupdated= false;

            try
            {
                connection.Open();

                int rowsaffected = sqlCommand.ExecuteNonQuery();

                if (rowsaffected > 0)
                    isupdated = true;


            }
            finally
            {
                connection.Close();
            }
            return isupdated;
        }

        public static bool Find(int id,ref DateTime appdate,ref int testtypeid)
        {
            
                SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

                string query = "select * from testappointments " +
                    " where testappointmentid=" + id;

                SqlCommand sqlCommand = new SqlCommand(query, connection);

               

                bool isupdated = false;

                try
                {
                    connection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    
                    if(reader.Read())
                    {
                        isupdated = true;
                        appdate = DateTime.Parse(reader["appointmentdate"].ToString());
                    testtypeid = int.Parse(reader["testtypeid"].ToString());
                    }

                }
                finally
                {
                    connection.Close();
                }
                return isupdated;
            

            
        }

        public static bool islocked(int id)
        {
            SqlConnection connection= new SqlConnection(clsDataSettings.ConnectionString);

            string query= "select found=1 from TestAppointments\r\n" +
                "where  TestAppointmentID=@id and IsLocked=1";

            SqlCommand sqlCommand = new SqlCommand(query,connection);

            bool islocked = false;

            sqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();

                object result = sqlCommand.ExecuteScalar();

                if (result != null)
                {
                    islocked = true;
                }
            }
            finally
            {
                connection.Close();
            }
            return islocked;
        }

    }
}

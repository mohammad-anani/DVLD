using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsLDLApplicationData
    {
        public static int AddApplication(int appid, int licenseclassid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into LocalDrivingLicenseApplications values" +
                "(@appid,@licenseclassid);select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            int id = -1;

            command.Parameters.AddWithValue("@appid", appid);
            command.Parameters.AddWithValue("@licenseclassid", licenseclassid);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
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

        public static DataTable GetAppsList(string where, string order)
        {
            {
                SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

                string query = "select * from LocalDrivingLicenseApplications_View";

                if (where != "")
                {
                    query += " where " + order + " like '" + where + "%'";
                }

                query += " order by " + order;

                SqlCommand command = new SqlCommand(query, connection);

                DataTable dtpersons = new DataTable();

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();


                    dtpersons.Load(reader);


                    reader.Close();
                }
                catch
                {
                }
                finally
                {
                    connection.Close();
                }

                return dtpersons;
            }
        }

        public static DataTable GetAppsColumns()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select top 1 * from LocalDrivingLicenseApplications_View";


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


        public static bool CancelApplication(int ldlid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update Applications set ApplicationStatus=2,laststatusdate=@date \r\n" +
                "where ApplicationID=(select Applications.ApplicationID \r\n" +
                "from LocalDrivingLicenseApplications join Applications\r\n" +
                "on LocalDrivingLicenseApplications.ApplicationID=Applications.ApplicationID\r\n" +
                "where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@id)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@id", ldlid);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);

            bool isupdated = false;

            try
            {
                connection.Open();

                int rowsaffected = cmd.ExecuteNonQuery();

                if (rowsaffected > 0)
                    isupdated = true;
            } finally
            {
                connection.Close();
            }
            return isupdated;
        }

        public static bool CompleteApplication(int ldlid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "update Applications set ApplicationStatus=3,laststatusdate=@date \r\n" +
                "where ApplicationID=(select Applications.ApplicationID \r\n" +
                "from LocalDrivingLicenseApplications join Applications\r\n" +
                "on LocalDrivingLicenseApplications.ApplicationID=Applications.ApplicationID\r\n" +
                "where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@id)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@id", ldlid);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);

            bool isupdated = false;

            try
            {
                connection.Open();

                int rowsaffected = cmd.ExecuteNonQuery();

                if (rowsaffected > 0)
                    isupdated = true;
            }
            finally
            {
                connection.Close();
            }
            return isupdated;
        }

        public static bool Find(int id, ref int appid, ref string lclass, ref int tests)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "\r\nselect LocalDrivingLicenseApplications_View.*,LocalDrivingLicenseApplications.ApplicationID\r\n" +
                "from LocalDrivingLicenseApplications_View " +
                "join LocalDrivingLicenseApplications\r\n" +
                "on LocalDrivingLicenseApplications_View.LocalDrivingLicenseApplicationID\r\n" +
                "=\r\nLocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID\r\n" +
                "where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID= @ldlappid ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ldlappid", id);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    appid = int.Parse(reader["applicationid"].ToString());
                    lclass = reader["classname"].ToString();
                    tests = int.Parse(reader["PassedTestCount"].ToString());
                }
                reader.Close();
            } finally
            {
                connection.Close();
            }
            return isfound;
        }

        public static bool HasPendingTest(int id, int typeid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select found=1 from LocalDrivingLicenseApplications\r\n" +
                "join TestAppointments\r\non" +
                " LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=" +
                "TestAppointments.LocalDrivingLicenseApplicationID\r\nwhere " +
                "LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@ldlid\r\nand " +
                "TestAppointments.TestTypeID=@type and TestAppointments.IsLocked=0;";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ldlid", id);
            cmd.Parameters.AddWithValue("@type", typeid);

            bool isfound = false;

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    isfound = true;
                }

            }
            finally {
                connection.Close();

            }

            return isfound;
        }


        public static int CountTests(int id, int testtypeid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select count(*) from TestAppointments\r\n" +
            "where LocalDrivingLicenseApplicationID=@id\r\nand TestTypeID=@type and islocked=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@type", testtypeid);

            int count = -1;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    count = int.Parse(result.ToString());
                }

            } finally
            {
                connection.Close();
            }
            return count;
        }

    


    public static bool HasPassedTest(int ldlid, int testtypeid)
    {
        SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

        string query = "select found=1 from TestAppointments join Tests" +
            "\r\non TestAppointments.TestAppointmentID=Tests.TestAppointmentID\r\nwhere" +
            " TestAppointments.LocalDrivingLicenseApplicationID=@id" +
            "\r\nand TestAppointments.TestTypeID=@type\r\nand Tests.TestResult=1";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@id", ldlid);
        command.Parameters.AddWithValue("@type", testtypeid);

        bool has = false;

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null)
            {
                has = true;
            }


        } finally
        {
            connection.Close();
        }
        return has;
    }

        public static bool DeleteApplication(int id)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from localdrivinglicenseapplications where localdrivinglicenseapplicationid=" + id;

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
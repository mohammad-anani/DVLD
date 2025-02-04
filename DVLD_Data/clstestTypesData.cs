using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clstestTypesData
    {

            public static DataTable GetTestTypesList()
            {
                SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

                string query = "select ID=testTypeID,Title=testTypeTitle,Fees=testtypeFees from testTypes";

                SqlCommand cmd = new SqlCommand(query, connection);

                DataTable dttypes = new DataTable();

                try
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        dttypes.Load(reader);
                    }
                    reader.Close();
                }
                finally
                {
                    connection.Close();
                }
                return dttypes;
            }

            public static bool Find(int id, ref string title,ref string description, ref double fees)
            {
                SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

                string query = "select * from testtypes where testtypeid=" + id;

                SqlCommand cmd = new SqlCommand(query, connection);

                bool isfound = false;

                try
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        title = reader["testtypeTitle"].ToString();
                    description = reader["testtypedescription"].ToString();
                    fees = double.Parse(reader["testtypefees"].ToString());
                    
                    isfound = true;
                    }
                    reader.Close();
                }
                finally
                {
                    connection.Close();
                }
                return isfound;
            }

            public static bool UpdateType(int id, string title,string description, double fees)
            {
                SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

                string query = "Update testtypes set testtypetitle =@title,testtypefees=@fees,testtypedescription=@description where testtypeid=" + id; ;

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@fees", fees);
            command.Parameters.AddWithValue("@description", description);

                bool isupdated = false;
                try
                {
                    connection.Open();

                    int rowsaffected = command.ExecuteNonQuery();

                    if (rowsaffected > 0)
                    {
                        isupdated = true;
                    }

                }
                finally
                {
                    connection.Close();
                }
                return isupdated;
            }
        }
    }


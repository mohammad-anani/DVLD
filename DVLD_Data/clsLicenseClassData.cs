using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsLicenseClassData
    {
        public static DataTable GetClassesList()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select classname from licenseclasses";

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

       public static bool Find(string title,ref int id,ref int length,ref double fees)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from licenseclasses where classname=@title";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@title", title);

            bool found=false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    found=true;
                    id = int.Parse(reader["licenseclassid"].ToString());
                        length = int.Parse(reader["defaultvaliditylength"].ToString());
                    fees = double.Parse(reader["classfees"].ToString());

                }
            }finally
            {
                connection.Close();
            }
            return found;
        }
    }
}

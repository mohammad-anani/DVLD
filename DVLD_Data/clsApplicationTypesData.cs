using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsApplicationTypesData
    {
        public static DataTable GetAppTypesList()
        {
            SqlConnection connection =new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select ID=ApplicationTypeID,Title=ApplicationTypeTitle,Fees=ApplicationFees from ApplicationTypes";

            SqlCommand cmd=new SqlCommand(query, connection);

            DataTable dttypes=new DataTable();

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

		public static bool Find(int id,ref string title,ref double fees)
		{
			SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from applicationtypes where applicationtypeid=" + id;

			SqlCommand cmd = new SqlCommand(query, connection);

			bool isfound=false;

			try
			{
				connection.Open();

				SqlDataReader reader = cmd.ExecuteReader();

				if (reader.Read())
				{
                    title= reader["ApplicationtypeTitle"].ToString();
                    fees = double.Parse(reader["applicationfees"].ToString()) ;
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


        public static bool Find(ref int id,string title, ref double fees)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from applicationtypes where applicationtypetitle=@title";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@title", title);

            bool isfound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    id = int.Parse(reader["Applicationtypeid"].ToString());
                    fees = double.Parse(reader["applicationfees"].ToString());
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


        public static bool UpdateType(int id,string title,double fees)
        {
            SqlConnection connection = new SqlConnection( clsDataSettings.ConnectionString);

            string query = "Update Applicationtypes set applicationtypetitle =@title,applicationfees=@fees where applicationtypeid=" + id; ;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@fees", fees);

            bool isupdated=false;
            try
            {
                connection.Open();

                int rowsaffected = command.ExecuteNonQuery();

                if (rowsaffected > 0)
                { 
                    isupdated = true;
                }

            }finally
            {
                connection.Close();
            }
            return isupdated;
        }
	}
}

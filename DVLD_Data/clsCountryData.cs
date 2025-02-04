using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data;

namespace DVLD_data
{
    public static class clsCountryData
    {
        public static DataTable GetCountryList()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select countryname from Countries";


            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtcountries = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    dtcountries.Load(reader);
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

            return dtcountries;
        }

        public static int FindIDByName(string name)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select countryid from countries where countryname='" + name+"'";

            SqlCommand cmd = new SqlCommand(query, connection);

            int countryid = -1;

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(),out int id))
                {
                    countryid = int.Parse(result.ToString());
                }
            }catch
            {

            }finally
            {
                connection.Close();
            }
            return countryid;
        }

        public static string FindNameByID(int id)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select countryname from countries where countryid=" + id;

            SqlCommand cmd = new SqlCommand(query, connection);

            string name = "";

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    name = result.ToString();
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return name;
        }
    }
}

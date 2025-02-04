using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsDriverData
    {
        public static int AddDriver(int personid,int userid,DateTime creationdate)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "Insert into drivers values " +
                "(@person,@userid,@creationdate);select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@person", personid);
            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@creationdate", creationdate);

            int id = -1;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    id = int.Parse(result.ToString());
                }

            }finally
            {
                connection.Close();
            }
            return id;
        }

        public static bool Find(int personid,ref int id)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select driverid from drivers where personid=" + personid;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool found= false;

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    found = true;
                    id= int.Parse(result.ToString());
                }


            }
            finally
            {
                connection.Close();
            }
            return found;
        }

        public static bool Find(ref int personid, int id)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select personid from drivers where driverid=" + id;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool found = false;

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    found = true;
                    personid = int.Parse(result.ToString());
                }


            }
            finally
            {
                connection.Close();
            }
            return found;
        }

         public static DataTable ListDrivers(string where,string order)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from drivers_view";
            if(where != "")
            {
                query += " where " + order + " like '" + where + "%'"; 
            }
            query += " order by " + order;

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            

            DataTable dtdrivers = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    dtdrivers.Load(reader);
                }

            }
            finally { connection.Close(); }

            return dtdrivers;

        }

        public static List<string> ListColumns()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select top 1 * from  drivers_view";
           

            SqlCommand sqlCommand = new SqlCommand(query, connection);



            List<string> list = new List<string>();

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                for(int i=0;i<reader.FieldCount;i++)
                {
                    list.Add(reader.GetName(i));
                }

            }
            finally { connection.Close(); }

            return list;
        }
        }
}

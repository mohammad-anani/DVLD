using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsTestData
    {

        public static int AddTest(int testappid,bool result,string notes,int userid)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "insert into tests values " +
                "(@testappid,@result,@notes,@userid);select scope_identity()";

            SqlCommand command=new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@testappid", testappid);
            command.Parameters.AddWithValue("@result", result);
            command.Parameters.AddWithValue("@notes", notes);
            command.Parameters.AddWithValue("@userid", userid);

            int newid = -1;

            try
            {
                connection.Open();

                object id = command.ExecuteScalar();

                if(id!=null)
                {
                    newid = int.Parse(id.ToString());
                }

            }finally
            {
                connection.Close();
            }
            return newid;

        }



    }
}

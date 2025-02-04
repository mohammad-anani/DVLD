using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DVLD_Data;
using System.Net;
using System.Security.Policy;
using Microsoft.SqlServer.Server;
using System.IO;


namespace DVLD_data
{
    public static class clsPersonData
    {
        public static DataTable GetPersonList(string where, string order)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from listpersons";

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



        public static DataTable GetPersonColumns()
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select top 1 * from listpersons";


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

        public static bool PersonExistbyNationalNO(string NationalNO)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select found=1 from listpersons where nationalno=" + NationalNO;

            SqlCommand command = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    isfound = true;
                }

            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return isfound;
        }

      
        public static bool IsUser(int id)
        {
            return clsUserData.UserExists(id);
        }

        public static bool IsUser(string nationalno)
        {
            return clsUserData.UserExists(nationalno);
        }
        public static bool IsPersonWithData(int id)
        {
            SqlConnection connection= new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select found=1 where exists(select top 1 y=1 from Drivers where Drivers.PersonID="+id+" ) or\r\nexists(select top 2 x=1 from Users where Users.PersonID="+id+")";

            SqlCommand cmd = new SqlCommand(query, connection);

            bool IsConnected = false;

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    IsConnected = true;
                }
                reader.Close();
            }catch
            {

            }finally
            {
                connection.Close() ;
            }
            return IsConnected;
        }

        public static int AddPerson(string first, string second, string third, string last, string nationalno,
            string phone, string email, string address, int countryid, string imagepath, DateTime dateofbirth, int gender)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "USE [dvld]\r\n\r\n\r\nINSERT INTO people VALUES\r\n (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gender,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath);\r\n\nselect scope_identity()";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@firstname",first);
            cmd.Parameters.AddWithValue("@secondname", second);
            cmd.Parameters.AddWithValue("@thirdname", third);
            cmd.Parameters.AddWithValue("@lastname", last);
            cmd.Parameters.AddWithValue("@nationalno",nationalno );
            cmd.Parameters.AddWithValue("@dateofbirth", dateofbirth);
            cmd.Parameters.AddWithValue("@gender", gender);
            if(email!="")
           { cmd.Parameters.AddWithValue("@email", email); }
            else
            { cmd.Parameters.AddWithValue("@email", DBNull.Value); }
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@NationalityCountryID", countryid);
            cmd.Parameters.AddWithValue("@address", address);
            if (imagepath != "")
            { cmd.Parameters.AddWithValue("@Imagepath", imagepath);
                
                File.Copy(imagepath, "C:\\DVLD_Pictures\\"+Guid.NewGuid()+".jpeg");
            }
            else
                cmd.Parameters.AddWithValue("@Imagepath", DBNull.Value);

            int newID = -1;

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                    newID = int.Parse(result.ToString());


            }
            finally
            {
                connection.Close() ;
            }

            return newID;


        }

        public static bool UpdatePerson(int id, string first, string second, string third, string last, string nationalno,
            string phone, string email, string address, int countryid, string imagepath, DateTime dateofbirth, int gender)
        {
            SqlConnection connection =new SqlConnection(clsDataSettings.ConnectionString);

            string query = "UPDATE [dbo].[People]\r\n   SET [NationalNo] =@nationalno\r\n      ,[FirstName] = @first\r\n      ,[SecondName] = @second\r\n      ,[ThirdName] =@third\r\n      ,[LastName] = @last\r\n      ,[DateOfBirth] = @dateofbirth\r\n      ,[Gender] = @gender\r\n      ,[Address] = @address\r\n      ,[Phone] = @phone\r\n      ,[Email] = @email\r\n      ,[NationalityCountryID] = @countryid\r\n      ,[ImagePath] =@imagepath\r\n\t  \r\n\t  where personid=" + id;
            
            SqlCommand cmd=new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@first", first);
            cmd.Parameters.AddWithValue("@second", second);
            cmd.Parameters.AddWithValue("@third", third);
            cmd.Parameters.AddWithValue("@last", last);
            cmd.Parameters.AddWithValue("@nationalno", nationalno);
            cmd.Parameters.AddWithValue("@dateofbirth", dateofbirth);
            cmd.Parameters.AddWithValue("@gender", gender);
            if (email != "")
            { cmd.Parameters.AddWithValue("@email", email); }
            else
            { cmd.Parameters.AddWithValue("@email", DBNull.Value); }
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@countryid", countryid);
            cmd.Parameters.AddWithValue("@address", address);
            if (imagepath != "")
            { cmd.Parameters.AddWithValue("@Imagepath", imagepath); }
            else
                cmd.Parameters.AddWithValue("@Imagepath", DBNull.Value);
            

            bool isupdated = false;
            try
            {
                connection.Open();
                int rowsaffected = cmd.ExecuteNonQuery();
                if(rowsaffected>0)
                {
                    isupdated = true;
                }

            }
            catch
            {

            }
            finally { connection.Close(); }
            return isupdated;
        }

        public static bool Find(int id,ref string first, ref string second,ref string third,ref string last,ref string nationalno,
           ref string phone,ref string email,ref string address,ref int countryid,ref string imagepath,ref DateTime dateofbirth,ref int gender)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from people where personid=" + id;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                IDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    isfound = true;
                    first = reader["firstname"].ToString();
                    nationalno = reader["nationalno"].ToString() ;
                    second = reader["secondname"].ToString();
                    third = reader["thirdname"].ToString();
                    last = reader["lastname"].ToString();
                    if (reader["email"] != DBNull.Value)
                    { email = reader["email"].ToString(); }
                    else
                        email = "";
                    countryid = int.Parse(reader["nationalitycountryid"].ToString());
                    address=reader["address"].ToString() ;
                    if (reader["imagepath"] != DBNull.Value)
                    { imagepath = reader["imagepath"].ToString(); }
                    else
                        imagepath = "";
                    phone = reader["phone"].ToString();
                    dateofbirth = Convert.ToDateTime(reader["dateofbirth"]);
                    gender = int.Parse(reader["gender"].ToString());

                }


            }
            finally
            {
                connection.Close();
            }

            
            return isfound;

        }

            public static bool Find(ref int id,ref string first, ref string second,ref string third,ref string last, string nationalno,
           ref string phone,ref string email,ref string address,ref int countryid,ref string imagepath,ref DateTime dateofbirth,ref int gender)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from people where nationalno='" + nationalno+"'";

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isfound = false;

            try
            {
                connection.Open();

                IDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    isfound = true;
                    first = reader["firstname"].ToString();
                    id = int.Parse(reader["Personid"].ToString()) ;
                    second = reader["secondname"].ToString();
                    third = reader["thirdname"].ToString();
                    last = reader["lastname"].ToString();
                    if (reader["email"] != DBNull.Value)
                    { email = reader["email"].ToString(); }
                    else
                        email = "";
                    countryid = int.Parse(reader["nationalitycountryid"].ToString());
                    address=reader["address"].ToString() ;
                    if (reader["imagepath"] != DBNull.Value)
                    { imagepath = reader["imagepath"].ToString(); }
                    else
                        imagepath = "";
                    phone = reader["phone"].ToString();
                    dateofbirth = Convert.ToDateTime(reader["dateofbirth"]);
                    gender = int.Parse(reader["gender"].ToString());

                }


            }
            finally
            {
                connection.Close();
            }

            
            return isfound;

        }

        public static bool DeletePerson(int id)
        {
            SqlConnection connection=new SqlConnection(clsDataSettings.ConnectionString);

            string query = "delete from people where personid=" + id;

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isdeleted = false;

            try
            {
                connection.Open();

                int rowsaffected = cmd.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    isdeleted = true;
                }

            }
            catch
            {

            }finally
            {
                connection.Close();
            }
            return isdeleted;
        }

      public static bool HasLicense(int personid, int licenseid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select found=1 where exists(select * from licenses join Drivers on Licenses.DriverID=Drivers.DriverID\r\n" +
                "join people on Drivers.PersonID=People.PersonID where People.PersonID=@person and Licenses.LicenseClass=@class)";

            SqlCommand command = new SqlCommand(query, connection);

            bool isfound = false;

            command.Parameters.AddWithValue("@person", personid);
            command.Parameters.AddWithValue("@class", licenseid);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if(result != null)
                {
                    isfound = true;
                }
            }finally
            {
                connection.Close();
            }
            return isfound;
        }

        public static int HasSameApplication(int personid, int licenseid)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select Applications.ApplicationID from LocalDrivingLicenseApplications join Applications\r\n" +
                "on LocalDrivingLicenseApplications.ApplicationID=Applications.ApplicationID join\r\npeople on Applications.ApplicantPersonID=People.PersonID \r\n" +
                "where personid=@person and LocalDrivingLicenseApplications.LicenseClassID=@class\r\nand (Applications.ApplicationStatus=1 or Applications.ApplicationStatus=3)";

            SqlCommand command = new SqlCommand(query, connection);

            int appid = -1;

            command.Parameters.AddWithValue("@person", personid);
            command.Parameters.AddWithValue("@class", licenseid);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    appid = int.Parse(result.ToString());
                }
            }
            finally
            {
                connection.Close();
            }
            return appid;
        }
    }
}

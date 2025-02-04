using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsUser
    {
        public enum enMode { Add,Update};
        public int id { get;set;}

        public int Personid { get;set;}
        public string username {  get; set; }

        public string password { get; set; }

        public bool isactive { get; set; }

        public enMode UMode { get; set; }

        public clsUser()
        {
            this.id = -1;
            this.Personid = -1;
            this.username = "";
            this.password = "";
            this.isactive = false;
            this.UMode = enMode.Add;
        }

        public static DataTable GetUserColumns()
        {
            return clsUserData.GetUserColumns();
        }
        private clsUser(int id,int personid,string username,string password,bool isactive)
        {
            this.id=id;
            this.Personid = personid;
            this.username = username;
            this.password = password;
            this.isactive = isactive;
        }

        public static  clsUser Find(string username,string password)
        {
            int id = -1;
            int personid = -1;
            bool isactive = false;
            if(clsUserData.Find(ref id,ref personid,username,password,ref isactive))
            {
                return new clsUser(id,personid,username,password,isactive);
            }
            return null;
        }

        public static clsUser FindUser(int id)
        {
            string username = "";
            string password = "";
            int personid = -1;
            bool isactive = false;
            if (clsUserData.Find( id, ref personid,ref username,ref password, ref isactive))
            {
                return new clsUser(id, personid, username, password, isactive);
            }
            return null;
        }


        public static bool Deleteuser(int id)
        {
            return clsUserData.DeleteUser(id);
        }

        public static bool Exists(string username, string password)
        {
            return clsUserData.UserExists(username,password);
        }

       public static DataTable ListUsers(string where,string order)
        {
            return clsUserData.ListUsers(where,order);
        }

        private bool _Adduser()
        {
            this.id=clsUserData.Adduser(this.Personid,this.username,this.password,this.isactive);
            return (this.id != 1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.id,this.username, this.password,this.isactive);
        }

        public bool SaveUser()
        {
            if (this.UMode == enMode.Add)
            {
                if (_Adduser())
                {
                    this.UMode = enMode.Update;
                    return true;
                }
            }
            else if(this.UMode == enMode.Update)
            {
                if(_UpdateUser())
                {
                    return true;
                }
            }
            return false;
                
        }

        public static bool HasData(int id)
        {
            return clsUserData.HasData(id);
        }
    }
}

using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsDriver
    {
        public int id {  get; set; }

        public int personid { get; set; }

        public int userid { get; set; }

        public DateTime creationdate { get; set; }

        public clsDriver()
        {
            id = -1;
        }

        public clsDriver(int id,int person)
        {
            this.id = id;
            this.personid = person;
        }

        public bool AddDriver()
        {
            this.id=clsDriverData.AddDriver(this.personid,this.userid,this.creationdate);
            return this.id != -1;
        }

        public static clsDriver Find(int personid)
        {
            int id = -1;
             if(clsDriverData.Find(personid,ref id))
                return new clsDriver(id,personid);
            return new clsDriver();
            
        }

        public static clsDriver FindByID(int id)
        {
            int personid = -1;
            if (clsDriverData.Find(ref personid, id))
                return new clsDriver(id, personid);
            return new clsDriver();

        }

        public static DataTable ListDrivers(string where,string order)
        {
            return clsDriverData.ListDrivers(where,order);
        }

        public static List<string> Listcolumns()
        {
            return clsDriverData.ListColumns();
        }
    }
}

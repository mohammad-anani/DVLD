using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsLicenseClass
    {
        public int id {  get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public double fees { get; set; }

        public int length { get; set; }

        public clsLicenseClass(int id,string title,int length,double fees)
        {
            this.id = id;
            this.title = title;
            this.length = length;
            this.fees = fees;

        }

        public clsLicenseClass()
        {
        }
        public static DataTable GetClassList()
        {
            return clsLicenseClassData.GetClassesList();
        }

        public static clsLicenseClass Find(string title)
        {
            int id = -1;
            double fees = -1;
            int length = -1;
            if(clsLicenseClassData.Find(title,ref id,ref length,ref fees))
            return new clsLicenseClass(id,title,length,fees);
            return new clsLicenseClass();
        }
    }
}

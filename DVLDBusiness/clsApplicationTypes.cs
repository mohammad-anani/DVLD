using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsApplicationTypes
    {
        public int id {  get; set; }

        public string title { get; set; }

        public double fees { get; set; }

        private clsApplicationTypes(int id,string title,double fees)
        {
            this.id = id;
            this.title = title;
            this.fees = fees;
        }

        public clsApplicationTypes()
        {

        }
        public static DataTable GetTypesList()
        {
            return clsApplicationTypesData.GetAppTypesList();
        }

        public static clsApplicationTypes Find(int id)
        {
            string title = "";
            double fees = 0;

            clsApplicationTypesData.Find(id, ref title, ref fees);
            return new clsApplicationTypes(id, title, fees);
        }

        public static clsApplicationTypes Find(string title)
        {
            int id = -1;
            double fees = 0;

            clsApplicationTypesData.Find(ref id, title, ref fees);
            return new clsApplicationTypes(id, title, fees);
        }


        public bool UpdateType()
        {
            if(clsApplicationTypesData.UpdateType(this.id,this.title,this.fees))
            {
                return true;
            }
            return false;
        }
    }
}

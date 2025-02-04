using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsTestType
    {
   
            public int id { get; set; }

            public string title { get; set; }

        public string description { get; set; }

            public double fees { get; set; }

            private clsTestType(int id, string title,string description, double fees)
            {
                this.id = id;
                this.title = title;
                this.fees = fees;
            this.description = description;
            }

        public clsTestType()
        {

        }

            public static DataTable GetTypesList()
            {
                return clstestTypesData.GetTestTypesList();
            }

            public static clsTestType Find(int id)
            {
                string title = "";
                double fees = 0;
            string description = "";
                if(clstestTypesData.Find(id, ref title,ref description, ref fees))
                return new clsTestType(id, title,description, fees);
            return new clsTestType();
            }

            public bool UpdateType()
            {
                if (clstestTypesData.UpdateType(this.id, this.title,this.description, this.fees))
                {
                    return true;
                }
                return false;
            }
        }
    }


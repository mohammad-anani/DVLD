using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsLDLApplication
    {
        public int id { get; set; }
        public int appid { get; set; }
        public string classname { get; set; }

        public int passedtests { get; set; }

        private clsLDLApplication(int id, int appid, string classname,int passedtests)
        {
            this.classname = classname;
            this.id = id;
            this.appid = appid;
            this.passedtests = passedtests;
        }

        public clsLDLApplication()
        {

        }


        public  bool AddApplication()
        {
            this.id=clsLDLApplicationData.AddApplication(this.appid,clsLicenseClass.Find(this.classname).id);
            return (this.id != -1);
        }

        public static DataTable GetList(string where,string order)
        {
            return clsLDLApplicationData.GetAppsList(where,order);
        }

        public static DataTable GetColumns()
        {
            return clsLDLApplicationData.GetAppsColumns();
        }

        public static bool CancelApplication(int id)
        {
            return clsLDLApplicationData.CancelApplication(id);
        }

        public static bool CompleteApplication(int id)
        {
            return clsLDLApplicationData.CompleteApplication(id);
        }

        public static clsLDLApplication Find(int id)
        {
            int appid = -1;
            string classname = "";
            int passedtests = 0;
            if(clsLDLApplicationData.Find(id,ref appid,ref classname,ref passedtests))
                {
                return new clsLDLApplication(id,appid,classname,passedtests);
            }
            return new clsLDLApplication();

        }

        public static bool HasPendingTest(int id,int typeid)
        {
            return clsLDLApplicationData.HasPendingTest(id,typeid);
        }

        public static int CountTests(int id,int testtypeid)
        {
            return clsLDLApplicationData.CountTests(id,testtypeid);
        }

        public static bool HasPassedTest(int id,int testtypeid)
        {
            return clsLDLApplicationData.HasPassedTest(id,testtypeid);
        }

        public static bool DeleteApplication(int id)
        {
            return clsLDLApplicationData.DeleteApplication(id);
        }
    }
}

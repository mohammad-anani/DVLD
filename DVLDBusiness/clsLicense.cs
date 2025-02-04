using DVLD_Data;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsLicense
    {
       public int id {  get; set; }

        public int appid { get; set; }
        public int driverid { get; set; }
        public int classid { get; set; }

        public DateTime issuedate  { get; set; }

        public DateTime expirationdate { get; set; }

        public int issuereason { get; set; }
        public string notes { get; set; }

        public double fees { get; set; }

        public bool isactive { get; set; }
        public int userid {  get; set; }

      
        public clsLicense(int id, int appid, int driverid, int classid, DateTime issuedate, DateTime expirationdate, int issuereason, string notes, double fees, bool isactive, int userid)
        {
            this.id = id;
            this.appid = appid;
            this.driverid = driverid;
            this.classid = classid;
            this.issuedate = issuedate;
            this.expirationdate = expirationdate;
            this.issuereason = issuereason;
            this.notes = notes;
            this.fees = fees;
            this.isactive = isactive;
            this.userid = userid;
        }

        public clsLicense()
        {
            this.id = -1;
        }

        public bool AddLicense()
        {
            this.id = clsLicenseData.Addlicense(this.appid, this.driverid, this.classid, this.issuedate,
                this.expirationdate, this.notes, this.fees, this.isactive, this.issuereason,
                this.userid);
            return this.id != -1;
        }

        public static clsLicense Find(int id)
        {
             
               int appid = -1;
            int driverid = -1;
            int classid = -1;
            DateTime issuedate = DateTime.MinValue; 
              DateTime expirationdate = DateTime.MinValue;
            int issuereason = -1;
             string  notes = "";
               double fees = -1;
            bool isactive = false;
            int userid = -1;


            if(clsLicenseData.Find(id,ref appid,ref driverid,ref classid,ref issuedate,
                ref expirationdate,ref notes,ref fees,ref isactive,ref issuereason,ref userid))
                return new clsLicense(id,appid,driverid,classid,issuedate,expirationdate,issuereason,notes,fees,isactive,userid);

            return new clsLicense();
        }


        public static clsLicense FindByAppID(int appid)
        {

            int id = -1;
            int driverid = -1;
            int classid = -1;
            DateTime issuedate = DateTime.MinValue;
            DateTime expirationdate = DateTime.MinValue;
            int issuereason = -1;
            string notes = "";
            double fees = -1;
            bool isactive = false;
            int userid = -1;


            if (clsLicenseData.Find(ref id, appid, ref driverid, ref classid, ref issuedate,
                ref expirationdate, ref notes, ref fees, ref isactive, ref issuereason, ref userid))
                return new clsLicense(id, appid, driverid, classid, issuedate, expirationdate, issuereason, notes, fees, isactive, userid);

            return new clsLicense();
        }

        public static bool IsDetained(int id)
        {
            return clsLicenseData.IsDetained(id);
        }

        public static DataTable Listlicenses(int personid)
        {
            return clsLicenseData.ListLicenses(personid);
        }

        public static bool deactivate(int lid)
        {
            return clsLicenseData.DeactivateLicense(lid);
        }

    }
}

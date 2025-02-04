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
    public class clsIntLIcense
    {

        public int id { get; set; }
        public int driverid { get; set; }
        public int issuedlicenseid { get; set; }
        public int appid { get; set; }
        public DateTime issuedate { get; set; }
        public DateTime expirationdate { get; set; }
        public bool isactive { get; set; }
        public int userid { get; set; }

        public clsIntLIcense(int id, int appid, int driverid, int issuedlicenseid, DateTime issuedate, DateTime expirationdate, bool isactive, int userid)
        {
            this.id = id;
            this.driverid = driverid;
            this.issuedlicenseid = issuedlicenseid;
            this.appid = appid;
            this.issuedate = issuedate;
            this.expirationdate = expirationdate;
            this.isactive = isactive;
            this.userid = userid;
        }

        public clsIntLIcense()
        {

        }

        public static DataTable Listlicenses(int personid)
        {
            return clsIntLicenseData.ListLicenses(personid);
        }

        public bool Add()
        {
            this.id = clsIntLicenseData.AddLicense(this.appid, this.driverid, this.issuedlicenseid, this.issuedate, this.expirationdate, this.isactive, this.userid);
            return this.id != -1;
        }

        public static clsIntLIcense Find(int id)
        {

            int driverid = -1;
            int issuedlicenseid = -1;
            int appid = -1;
            DateTime issuedate = DateTime.MinValue;
            DateTime expirationdate = DateTime.MinValue;
            bool isactive = false;
            int userid = -1;
            if (clsIntLicenseData.Find(id, ref appid, ref driverid, ref issuedlicenseid, ref issuedate, ref expirationdate, ref isactive, ref userid))
            {
                return new clsIntLIcense(id, appid, driverid, issuedlicenseid, issuedate, expirationdate, isactive, userid);
            }
            return new clsIntLIcense();
        }


        public static clsIntLIcense FindByLDL(int ldlid)
        {

            int driverid = -1;
            int id = -1;
            int appid = -1;
            DateTime issuedate = DateTime.MinValue;
            DateTime expirationdate = DateTime.MinValue;
            bool isactive = false;
            int userid = -1;
            if (clsIntLicenseData.Find(ref id, ref appid, ref driverid, ldlid, ref issuedate, ref expirationdate, ref isactive, ref userid))
            {
                return new clsIntLIcense(id, appid, driverid, ldlid, issuedate, expirationdate, isactive, userid);
            }
            return new clsIntLIcense();
        }


        public static List<string> ListColumns()
        {
            return clsIntLicenseData.ListColumns();

        }

        public static DataTable ListLicenses(string where,string order)
        {
            return clsIntLicenseData.ListLicenses(where,order);
        }
    }


}

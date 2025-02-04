using DVLD_Data;
using DVLDBusiness;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplication
    {
        public int id { get; set; }
        public int personid { get; set; }
        public DateTime appdate { get; set; }
        public string apptype { get; set; }
        public string appstatus { get; set; }
        public DateTime laststatusdate { get; set; }

        public double paidfees { get; set; }

        public int userid { get; set; }

private clsApplication(int id, int personid, DateTime appdate, string apptype, string appstatus, DateTime laststatusdate, double paidfees, int userid)
        {
            this.id       = id;
            this.personid = personid;
            this.appdate  = appdate;
            this.apptype = apptype;
            this.appstatus = appstatus;
            this.laststatusdate = laststatusdate;
            this.paidfees = paidfees;
            this.userid = userid;
        }

        public clsApplication()
        {
          
        }

        public bool AddApplication()
        {
            this.id = clsApplicationData.AddApplication(this.personid, this.appdate,clsApplicationTypes.Find(this.apptype).id,
               1,this.laststatusdate,this.paidfees,this.userid);
            return (this.id != -1);
        }

        public static string FindStatus(int id)
        {
            switch (id)
            {
                case 1:
                    return "New";
                    case 2:
                    return "Cancelled";
                    case 3:
                    return "Completed";
                default:
                    return "";
            
            }
        }

        public static int FindStatusid(string status)
        {
            switch (status)
            {
                case "New":
                    return 1;
                case "Cancelled":
                    return 2;
                case "Completed":
                    return 3;
                default:
                    return -1;

            }
        }

        public static clsApplication Find(int id)
        {
          int  personid = -1;
            DateTime appdate = DateTime.MinValue;
            int apptypeid = -1;
            int appstatus = 1;
           DateTime laststatusdate = DateTime.MinValue;
            double paidfees = 0;
            int userid = -1;

            if(clsApplicationData.Find(id,ref personid,ref appdate,ref apptypeid,ref appstatus,ref laststatusdate,ref paidfees,ref userid))
            {
                return new clsApplication(id,personid,appdate,clsApplicationTypes.Find(apptypeid).title,FindStatus(appstatus),laststatusdate,paidfees,userid);
            }
            return new clsApplication();
        }

      
        public bool Update()
        {
            return clsApplicationData.UpdateApplication(this.id,this.paidfees);
        }

        public static bool DeleteApplication(int id)
        {
            return clsApplicationData.DeleteApplication(id);
        }
    }
}

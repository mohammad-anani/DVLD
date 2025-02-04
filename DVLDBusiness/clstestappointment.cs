using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clstestappointment
    {
        public int id {  get; set; }

        public int testtype { get; set; }
        public int ldlappid { get; set; }

        public DateTime appdate { get; set; }

        public double fees { get; set; }

       public bool islocked { get; set; }

        public int userid { get; set; }

        public clstestappointment(int id,int typeid,int ldlappid, DateTime appdate, double fees,bool islocked,int userid)
        {
            this.id = id;
            this.appdate = appdate;
            this.fees = fees;
            this.islocked = islocked;
            this.userid = userid;
            this.ldlappid = ldlappid;
            this.testtype = typeid;
        }

        public clstestappointment()
        {

        }

        public clstestappointment(int id,DateTime date,int testtypeid)
        {
            this.id=id;
            this.appdate=date;
            this.testtype=testtypeid;
        }


        public static DataTable GetList(int id,int testtypeid)
        {
            return clstestappointmentsData.ListAppointments(id,testtypeid);
        }

        public bool AddAppointment()
        {
            return clstestappointmentsData.AddAppointment(this.testtype, this.ldlappid, this.appdate, this.fees, this.userid);
        }

        public bool Update()
        {
            return clstestappointmentsData.Update(this.id, this.appdate,this.islocked);
        }

        public static clstestappointment Find(int id)
        {
            DateTime date = DateTime.Now;
            int testtypeid = -1;
            if (clstestappointmentsData.Find(id, ref date, ref testtypeid))
                return new clstestappointment(id, date, testtypeid);
            return new clstestappointment();
        }




        public static bool IsLocked(int id)
        {
            return clstestappointmentsData.islocked(id);
        }
    }
}

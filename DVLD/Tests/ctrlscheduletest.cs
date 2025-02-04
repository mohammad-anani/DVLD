using DVLD.Properties;
using DVLD_Business;
using DVLDBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class ctrlscheduletest : UserControl
    {

        public bool retake = false;
        public clsLDLApplication app = new clsLDLApplication();
        clsApplication appl = new clsApplication();
        clsPerson person = new clsPerson();
        public static int testtypeid = -1;
        double fees = -1;

        public int apptid = -1;

        public ctrlscheduletest()
        {
            InitializeComponent();


        }

        public void FillFees()
        {
            lbltrial.Text = clsLDLApplication.CountTests(app.id, testtypeid).ToString();
            fees = clsTestType.Find(testtypeid).fees;
          
        }
        void fillinfo()
        {

            lblid.Text = app.id.ToString();
            lblclass.Text = app.classname;
            lblfees.Text = fees.ToString();
          appl=clsApplication.Find(app.appid);
           
            person = clsPerson.Find(appl.personid);
            if (person != null)
            { lblname.Text = person.FullName(); }
            if(1!=5)
            { dtpdate.MinDate = DateTime.Now; }
            if (apptid!=-1)
            {
                DateTime date = clstestappointment.Find(apptid).appdate;
                if (dtpdate.Value>date)
                {
                    MessageBox.Show("Appointment Date Has Passed!");
                    dtpdate.Value=DateTime.Now;
                }
                else
                {
                    dtpdate.Value = date;
                }
               
            }
           
        }


        public clstestappointment newapp = new clstestappointment();
        private void ctrlscheduletest_Load(object sender, EventArgs e)
        {
           
                fillinfo();
            newapp.id = apptid;
            newapp.ldlappid = app.id;
            if (clsGlobalcs.CurrentUser != null)
           { newapp.userid = clsGlobalcs.CurrentUser.id; }
            newapp.fees = fees;
            newapp.testtype = testtypeid;
            if(retake)
            {
                label8.Enabled = true;
                lblretake.Enabled = true;
                lblretake.Text = clsApplicationTypes.Find(8).fees.ToString();
            }
        }

        public event Action<clstestappointment> OnSaveEvent;
        protected virtual void  OnSave(clstestappointment app)
        {
            Action<clstestappointment> handler = OnSaveEvent;
            if (handler != null)
            {

                OnSaveEvent(app);
            }


        }



        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {
              

            
            newapp.appdate = dtpdate.Value;
              




        }
    }
}

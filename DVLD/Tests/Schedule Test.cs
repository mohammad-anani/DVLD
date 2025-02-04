using DVLD.Properties;
using DVLD_Business;
using DVLDBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Schedule_Test : Form
    {

        public clsLDLApplication app = new clsLDLApplication();
        public clstestappointment appointment = new clstestappointment();
        public int apptid = -1;
        public int typeid;
        public Schedule_Test(clsLDLApplication ldlapp, int testtypeid, bool editmode, int appid,bool retake=false)
        {
            InitializeComponent();
            app = ldlapp ;
            ctrlscheduletest2.app = app;
            typeid = testtypeid;
            ctrlscheduletest.testtypeid = testtypeid;
            ctrlscheduletest2.FillFees();
            if (editmode)
            {
                apptid = appid;
                ctrlscheduletest2.apptid = apptid;
                ctrlscheduletest.testtypeid=testtypeid;
            }
            if(retake)
            {
                ctrlscheduletest2.retake = true;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public delegate void OnSaveEvent(object sender);
        public event OnSaveEvent OnSave;


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ctrlscheduletest2_OnSaveEvent(clstestappointment obj)
        {

         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            appointment = ctrlscheduletest2.newapp;
            if (apptid != -1)
            {
                if (appointment.Update())
                {
                    MessageBox.Show("Test Updated");
                    OnSave?.Invoke(this);
                }
                return;
            }

            if (appointment.AddAppointment())
            {
                MessageBox.Show("Test Added");
                clsApplication application = clsApplication.Find(app.appid);
                if (ctrlscheduletest2.retake)
                {
                    application.paidfees += clsApplicationTypes.Find(8).fees;
                   }
                application.paidfees += clsTestType.Find(typeid).fees;

                application.Update();
                OnSave?.Invoke(this);
            }
        }

        private void Schedule_Test_Load(object sender, EventArgs e)
        {
            switch (typeid)
            {
                case 1:
                    pictureBox1.Image = Resources.eyetest;
                    lbltitle.Text = "Schedule Vision Test";
                    break;
                case 2:
                    pictureBox1.Image = Resources.test2;
                    lbltitle.Text = "Schedule Written Test";
                    break;
                case 3:
                    pictureBox1.Image = Resources.cars1;
                    lbltitle.Text = "Schedule Street Test";
                    break;
            }
            if(ctrlscheduletest2.retake)
            {
                lbltitle.Text=lbltitle.Text.Insert(0, "Re");
            }
        }
    }
}

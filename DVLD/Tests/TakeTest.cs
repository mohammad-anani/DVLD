using DVLD.Properties;
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
    public partial class TakeTest : Form
    {
        public int ldlappid {  get; set; }

        public int apptid { get; set; }


        clstestappointment testappt=new clstestappointment();
        public TakeTest(int ldlid,int testappid)
        {
            InitializeComponent();
            ldlappid = ldlid;
       
            
            apptid = testappid;
            testappt = clstestappointment.Find(apptid);
            filltitle();
            fillinfo();

        }

        void fillinfo()
        {
         
          ctrlTakeTest1.ldlappid=ldlappid;
            ctrlTakeTest1.apptid = apptid;
            ctrlTakeTest1.testtypeid = clsLDLApplication.Find(ldlappid).passedtests+1;
            ctrlTakeTest1.FillInfo();
            
        }

        void filltitle()
        {
          

            switch (testappt.testtype)
            {
                case 1:
                    pbpic.Image = Resources.eyetest;
                    lbltitle.Text = "View Test";
                    break;
                case 2:
                    pbpic.Image = Resources.test2;
                    lbltitle.Text = "Written Test";
                    break;
                case 3:
                    pbpic.Image = Resources.cars1;
                    lbltitle.Text = "Street Test";
                    break;

            }

        }

        private void TakeTest_Load(object sender, EventArgs e)
        {

        }

        public delegate void OnSave(object sender);
        public event OnSave Save;

        private void button1_Click(object sender, EventArgs e)
        {
            clsTest newtest= new clsTest();
            newtest.testappid = apptid;
            newtest.result = (rbpass.Checked ? true : false);
            newtest.userid = clsGlobalcs.CurrentUser.id;
            newtest.notes = textBox1.Text;

            if(newtest.AddTest())
            {
                clstestappointment appointment = new clstestappointment();
                appointment.id = apptid;
                appointment.appdate = clstestappointment.Find(apptid).appdate;
                appointment.islocked= true;
                appointment.Update();
                MessageBox.Show("Test Taken Successfully!");
                this.Close();
                Save?.Invoke(this);
            }
        }
    }
}

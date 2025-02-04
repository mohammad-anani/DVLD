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
    public partial class ctrlTakeTest : UserControl
    {
        public int ldlappid {  get; set; }

        public int apptid { get; set; }

        public int testtypeid { get; set; }

        public ctrlTakeTest()
        {
            InitializeComponent();
         
        }

        public void FillInfo()
        {
            clsLDLApplication application = new clsLDLApplication();
            application = clsLDLApplication.Find(ldlappid);
            lblid.Text = application.id.ToString();
            lblclass.Text = application.classname;
            clsApplication app = new clsApplication();
            app = clsApplication.Find(application.appid);
            clsPerson person = new clsPerson();
            person = clsPerson.Find(app.personid);
            lblname.Text = person.FullName();
            lbldate.Text = clstestappointment.Find(apptid).appdate.ToShortDateString();
            lbltrial.Text = clsLDLApplication.CountTests(application.id, testtypeid).ToString();

        }
        private void ctrlTakeTest_Load(object sender, EventArgs e)
        {
          
        }
    }
}

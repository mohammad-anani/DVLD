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
    public partial class IssueFirstTime : Form
    {
        public int ldlappid { get; set; }
        clsLDLApplication LDLApplication = new clsLDLApplication();
        clsLicenseClass lclass = new clsLicenseClass();
        public IssueFirstTime(int ldlid)
        {
            InitializeComponent();
            ctrlFullApplicationInfo1.id = ldlid;
            ctrlFullApplicationInfo1.fillinfo();
            ldlappid = ldlid;

            LDLApplication = clsLDLApplication.Find(ldlappid);

            lclass = clsLicenseClass.Find(LDLApplication.classname);
            lblfees.Text = lclass.fees.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        clsDriver driver = new clsDriver();
        bool AddLicense()
        {

            clsApplication application = new clsApplication();
            application = clsApplication.Find(LDLApplication.appid);
            int personid = application.personid;
            if (clsDriver.Find(personid).id == -1)
            {
                driver.personid = personid;
                driver.userid = clsGlobalcs.CurrentUser.id;
                driver.creationdate = DateTime.Now;
                driver.AddDriver();
            }
            else
            {
                driver = clsDriver.Find(personid);
            }
            clsLicense license = new clsLicense();
            license.appid = application.id;
            license.driverid = driver.id;
            license.classid = lclass.id;
            license.issuedate = DateTime.Now;
            license.expirationdate = license.issuedate.AddYears(lclass.length);
            license.issuereason = 1;
            license.notes = textBox1.Text;
            license.fees = lclass.fees;
            license.isactive = true;
            license.userid = clsGlobalcs.CurrentUser.id;
            if (license.AddLicense())
            {
                application.paidfees += lclass.fees;
                application.Update();
                MessageBox.Show("License Added Successfully With ID=" + license.id);
                return true;
            }
            return false;



        }


        public delegate void OnIssue(object sender);
        public event OnIssue Issue;
            

            

        private void button2_Click(object sender, EventArgs e)
        {
            if(AddLicense())
            {
                button2.Enabled = false;
                clsLDLApplication.CompleteApplication(LDLApplication.id);
                Issue?.Invoke(this);
            }
        }
    }
}

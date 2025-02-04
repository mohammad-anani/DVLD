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
    public partial class Renew_Driving_License : Form
    {
        public Renew_Driving_License()
        {
            InitializeComponent();
        }

        private void Renew_Driving_License_Load(object sender, EventArgs e)
        {

        }


        clsLicense license = new clsLicense();

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button3.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
                return;

            license = clsLicense.Find(int.Parse(textBox2.Text.ToString()));

            if (license.id != -1)
            {
                ctrlDrivingLicense2.appid = license.appid;
                ctrlDrivingLicense2.FillInfo();
                ctrlRenewApplication1.oldlicenseid = license.id;
                ctrlRenewApplication1.FillOldLicenseInfo();
                ctrlRenewApplication1.AppType = 2;
                ctrlRenewApplication1.FillAppType();
                linkLabel4.Enabled = true;
            }
            else
                MessageBox.Show("License Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        clsLicense newlicense = new clsLicense();

        private void button4_Click(object sender, EventArgs e)
        {
            if(license.id==-1)
            {

                MessageBox.Show("Please Select a License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(license.expirationdate>DateTime.Now)
            {
                MessageBox.Show("License Not Expired Yet","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsApplication app=new clsApplication();
            if(clsGlobalcs.CurrentUser!=null)
            {
                app.userid = clsGlobalcs.CurrentUser.id;
            }
            app.appdate = DateTime.Now;
            app.laststatusdate = DateTime.Now;
            app.appstatus = "Completed";
            clsApplicationTypes apptype = clsApplicationTypes.Find(2);
            app.apptype = apptype.title;
            clsLicenseClass lclass = clsLicenseClass.Find(clsLicenseClass.GetClassList().Rows[license.classid - 1][0].ToString());
            app.paidfees = apptype.fees +lclass.fees;
            app.personid = clsDriver.FindByID(license.driverid).personid;
            if(app.AddApplication())
            {
             
                newlicense.notes=license.notes;
                if (clsGlobalcs.CurrentUser != null)
                {
                    newlicense.userid = clsGlobalcs.CurrentUser.id;
                }
                newlicense.driverid=license.driverid;
                newlicense.isactive = true;
                newlicense.issuedate = DateTime.Now;
                newlicense.expirationdate = DateTime.Now.AddYears(lclass.length);
                newlicense.appid = app.id;
                newlicense.classid=license.classid;
                newlicense.fees=lclass.fees;
                newlicense.issuereason = 2;

                if(newlicense.AddLicense())
                {
                   if(clsLicense.deactivate(license.id))
                    {
                        MessageBox.Show("License Renewed Successfully With ID=" + newlicense.id);
                        ctrlRenewApplication1.newlicenseid = newlicense.id;
                        ctrlRenewApplication1.FillNewLicenseInfo();
                        linkLabel3.Enabled = true;
                    }
                }
                
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form=new Show_Driving_License(newlicense.appid);
            form.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new License_History(clsDriver.FindByID(license.driverid).personid);
            form.ShowDialog();
        }
    }
}

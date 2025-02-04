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
    public partial class New_International_License_Application : Form
    {
        public New_International_License_Application()
        {
            InitializeComponent();
        }

        clsLicense license=new clsLicense();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length==0)
                return;

            license = clsLicense.Find(int.Parse(textBox2.Text.ToString()));

            if(license.id!=-1)
           { ctrlDrivingLicense2.appid = license.appid;
                ctrlDrivingLicense2.FillInfo();
                linkLabel4.Enabled = true;
            }
            else
                MessageBox.Show("License Not Found!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                button3.PerformClick();
        }

        clsIntLIcense intLicense = new clsIntLIcense();
        private void button2_Click(object sender, EventArgs e)
        {
            if (license.id==-1)
            {
                MessageBox.Show("Please Select A License");
                return;
            }

            if(license.classid!=3)
            {
                MessageBox.Show("License Should Be An Ordinary Driving License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(license.expirationdate<DateTime.Now)
            {

                MessageBox.Show("License Has Expired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ilid = clsIntLIcense.FindByLDL(int.Parse(textBox2.Text.ToString())).id;
            if(ilid!=-1)
            {
                MessageBox.Show("License Already Got International License With ID="+ilid, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsApplication app = new clsApplication();
            app.appdate = DateTime.Now;
            app.laststatusdate = DateTime.Now;
            app.appstatus = "Completed";
            app.personid = clsDriver.FindByID(license.driverid).personid;
            if (clsGlobalcs.CurrentUser != null)
            {
                app.userid = clsGlobalcs.CurrentUser.id;
            }
            app.apptype = clsApplicationTypes.Find(6).title;
            app.paidfees = clsApplicationTypes.Find(6).fees;
            if(app.AddApplication())
            {
                
                intLicense.userid = app.userid;
                intLicense.issuedate = app.appdate;
                intLicense.isactive = true;
                intLicense.appid = app.id;
                intLicense.driverid=license.driverid;
                intLicense.expirationdate = app.appdate.AddYears(1);
                intLicense.issuedlicenseid=license.id;
                if(intLicense.Add())
                {
                    ctrlIntApplication2.license=intLicense;
                    ctrlIntApplication2.FillInfo();
                    linkLabel3.Enabled = true;
                    MessageBox.Show("License Issued Successfully With ID=" + intLicense.id);
                    button4.Enabled = false;
                }
            }
                
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new License_History(clsDriver.FindByID(license.driverid).personid);
            form.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new International_License_Details(intLicense.id);
            form.ShowDialog();
        }

        private void New_International_License_Application_Load(object sender, EventArgs e)
        {

        }
    }
}

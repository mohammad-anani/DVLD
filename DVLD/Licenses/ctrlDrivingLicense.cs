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
    public partial class ctrlDrivingLicense : UserControl
    {

        public int appid {  get; set; }

        clsLicense license=new clsLicense();

        public ctrlDrivingLicense()
        {
            InitializeComponent();
        }


       

        public void FillInfo()
        {
            license = clsLicense.FindByAppID(appid);
            clsPerson person= new clsPerson();
            person = clsPerson.Find(clsDriver.FindByID(license.driverid).personid);
            lblclass.Text = clsLicenseClass.GetClassList().Rows[license.classid-1][0].ToString();
            lblname.Text = person.FullName();
            lblnationalno.Text = person.NationalNO;
            lblid.Text=license.id.ToString();
            lblissuedate.Text= license.issuedate.ToShortDateString();
            lblexpirationdate.Text=license.expirationdate.ToShortDateString();
            lbldriverid.Text=license.driverid.ToString();
            lbldateofbirth.Text = person.DateOfBirth.ToShortDateString();
            if(license.notes!="")
            {
                lblnotes.Text = license.notes;
            }
            lblgender.Text = person.Gender;

            if (license.isactive)
            {
                lblisactive.Text = "Yes";
            }
            else
                lblisactive.Text = "No";

            switch (license.issuereason)
            {
                case 1:
                    lblissuereason.Text = "First Time";
                    break;
                case 2:
                    lblissuereason.Text = "Renew";
                    break;
                case 3:
                    lblissuereason.Text = "Replace For Damaged";
                   
                    break;
                case 4:
                    lblissuereason.Text = "Replace For Lost";
                    break;

            }

            if (clsLicense.IsDetained(license.id))
            {
                lblisdetained.Text = "Yes";
            }
            else
                lblisdetained.Text = "No";
            if (person.ImagePath != "")
                pbimage.Image = Image.FromFile(person.ImagePath);
            else
                pbimage.Image = Resources.male;
        }

        private void ctrlDrivingLicense_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

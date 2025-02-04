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
    public partial class ctrlIntLicense : UserControl
    {

        public int id {  get; set; }
        public ctrlIntLicense()
        {
            InitializeComponent();
        }

        private void pbimage_Click(object sender, EventArgs e)
        {

        }

       public void fillinfo()
        {
           clsIntLIcense license =new clsIntLIcense();
            license=clsIntLIcense.Find(id);
            if(license == new clsIntLIcense())
            {
                return;
            }
            clsPerson person = new clsPerson();
            person = clsPerson.Find(clsDriver.FindByID(license.driverid).personid);
            
            lblname.Text = person.FullName();
            lblnationalno.Text = person.NationalNO;
            lblid.Text = license.issuedlicenseid.ToString();
            lblintid.Text = license.id.ToString();
            lblissuedate.Text = license.issuedate.ToShortDateString();
            lblexpirationdate.Text = license.expirationdate.ToShortDateString();
            lbldriverid.Text = license.driverid.ToString();
            lbldateofbirth.Text = person.DateOfBirth.ToShortDateString();
            lblappid.Text = license.appid.ToString();
            lblgender.Text = person.Gender;

            if (license.isactive)
            {
                lblisactive.Text = "Yes";
            }
            else
                lblisactive.Text = "No";

            if(person.ImagePath!="")
            {
                pbimage.Image=Image.FromFile(person.ImagePath);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

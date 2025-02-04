using DVLDBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlRenewApplication : UserControl
    {
        public int newlicenseid {  get; set; }

        public int oldlicenseid { get; set; }

        public int AppType { get; set; }

        clsLicense oldlicense=new clsLicense();
        clsLicenseClass lclass=new clsLicenseClass();

        public ctrlRenewApplication()
        {
            InitializeComponent();
            lblappdate.Text=DateTime.Now.ToShortDateString();
            lblissuedate.Text=DateTime.Now.ToShortDateString();
            if (clsGlobalcs.CurrentUser != null)
                lbluser.Text=clsGlobalcs.CurrentUser.username;
            

        }

       public void FillAppType()
        {
            lblrenewfees.Text = clsApplicationTypes.Find(AppType).fees.ToString();
        }
        public void FillOldLicenseInfo()
        {
            oldlicense = clsLicense.Find(oldlicenseid);
            lclass = clsLicenseClass.Find(clsLicenseClass.GetClassList().Rows[oldlicense.classid - 1][0].ToString());
            if(oldlicense != null)
            {
                lblexpirationdate.Text = DateTime.Now.AddYears(lclass.length).ToShortDateString();
                lblfees.Text=lclass.fees.ToString();
                lblldlid.Text = oldlicense.id.ToString();
            }
        }

        public void FillNewLicenseInfo()
        {
            clsLicense newlicense=clsLicense.Find(newlicenseid);
            lblappid.Text=newlicense.appid.ToString();
            lbllicenseid.Text=newlicense.id.ToString();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class ctrlIntApplication : UserControl
    {
        public clsIntLIcense license =new clsIntLIcense();
        public ctrlIntApplication()
        {
            InitializeComponent();
            lblappdate.Text = DateTime.Now.ToShortDateString();
            lblissuedate.Text = DateTime.Now.ToShortDateString();
            lblexpirationdate.Text=DateTime.Now.AddYears(1).ToShortDateString();
            if (clsGlobalcs.CurrentUser != null){ lbluser.Text = clsGlobalcs.CurrentUser.username; }
            lblfees.Text = clsApplicationTypes.Find(6).fees.ToString();

        }

        public void FillInfo()
        {
            lblilid.Text = license.appid.ToString();
            lbllicenseid.Text=license.id.ToString();
            lblldlid.Text=license.issuedlicenseid.ToString();
        }

        private void ctrlIntApplication_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

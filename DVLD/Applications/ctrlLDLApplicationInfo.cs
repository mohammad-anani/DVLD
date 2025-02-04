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
    public partial class ctrlLDLApplicationInfo : UserControl
    {
        public int ldlid {  get; set; }

        public clsLDLApplication ldlapp=new clsLDLApplication();
        clsApplication application = new clsApplication();

        public ctrlLDLApplicationInfo()
        {
            InitializeComponent();
        }

       public void fillctrl()
        {
            ldlapp = clsLDLApplication.Find(ldlid);
            lblid.Text = ldlapp.id.ToString();
            lblclass.Text = ldlapp.classname;
            lbltests.Text=ldlapp.passedtests.ToString()+"/3";
            application=clsApplication.Find(ldlapp.appid);
            if (application.appstatus == "Completed")
            {
                linkLabel1.Enabled = true;
            }
            else
            {
                linkLabel1.Enabled = false;
            }

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlLDLApplicationInfo_Load(object sender, EventArgs e)
        {
            fillctrl();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form=new Show_Driving_License(application.id);
            form.ShowDialog();
        }
    }
}

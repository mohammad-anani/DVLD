using DVLD_Business;
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
    public partial class ctrlApplicationInfo : UserControl
    {
        public int appid {  get; set; }

        clsApplication application=new clsApplication();

        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

       public void FillControl()
        {
            application=clsApplication.Find(appid);
            lblid.Text=application.id.ToString();
            lblstatus.Text = application.appstatus;
            lblfees.Text = application.paidfees.ToString() ;
            lbltype.Text = application.apptype;
            lblpersonid.Text=application.personid.ToString();
            lbldate.Text=application.appdate.ToShortDateString();
            lblstatusdate.Text = application.laststatusdate.ToShortDateString();
            lbluserid.Text = application.userid.ToString();

        }

        private void ctrlApplicationInfo_Load(object sender, EventArgs e)
        {
            FillControl();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new ShowPersonCard(application.personid);
            form.ShowDialog();

        }
    }
}

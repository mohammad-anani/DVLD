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
    public partial class Release_Detained_License : Form
    {

        clsApplicationTypes apptype = new clsApplicationTypes();
        clsDetain detain=new clsDetain();
        public Release_Detained_License()
        {
            InitializeComponent();
            apptype = clsApplicationTypes.Find(5);
            lblappfees.Text = apptype.fees.ToString();

        }

        private void Release_Detained_License_Load(object sender, EventArgs e)
        {

        }


        clsLicense license = new clsLicense();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
                return;

            if (!clsLicense.IsDetained(int.Parse(textBox2.Text.ToString())))
            {
                MessageBox.Show("License Not Detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            license = clsLicense.Find(int.Parse(textBox2.Text.ToString()));


            if (license.id != -1)
            {
                ctrlDrivingLicense2.appid = license.appid;
                ctrlDrivingLicense2.FillInfo();
                detain = clsDetain.FindID(license.id);
                lblreleasefees.Text = detain.fees.ToString();
                linkLabel4.Enabled = true;
            }
            else
                MessageBox.Show("License Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button3.PerformClick();
        }


        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form form = new License_History(clsDriver.FindByID(license.driverid).personid);
            form.ShowDialog();

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new Show_Driving_License(license.appid);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (license.id == -1)
            {

                MessageBox.Show("Please Select a License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsApplication app = new clsApplication();
            app.personid = clsDriver.FindByID(license.driverid).personid;
            app.userid=(clsGlobalcs.CurrentUser!=null?clsGlobalcs.CurrentUser.id:0);
        
            
            
            app.apptype = apptype.title;
           
            app.paidfees= apptype.fees+detain.fees;
            app.appdate = DateTime.Now;
            app.laststatusdate = DateTime.Now;
            if(app.AddApplication())
            {
                detain.releaseappid = app.id;
                detain.releasedbyuserid = app.userid;
                detain.releasedate = DateTime.Now;
                if(detain.Release())
                {
                    MessageBox.Show("License Successfully Released.");
                    linkLabel3.Enabled = true;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

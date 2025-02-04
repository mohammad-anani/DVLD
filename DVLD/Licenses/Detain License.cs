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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD
{
    public partial class Detain_License : Form
    {
        public Detain_License()
        {
            InitializeComponent();
        }

        private void Detain_License_Load(object sender, EventArgs e)
        {
        }

        clsLicense license = new clsLicense();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
                return;

            if (clsLicense.IsDetained(int.Parse(textBox2.Text.ToString())))
            {
                MessageBox.Show("License Already Detained","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                license = clsLicense.Find(int.Parse(textBox2.Text.ToString()));

        
            if (license.id != -1)
            {
                ctrlDrivingLicense2.appid = license.appid;
                ctrlDrivingLicense2.FillInfo();
              ctrlDetainInfo1.licenseid = license.id;
                ctrlDetainInfo1.FillLicense();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (license.id == -1)
            {

                MessageBox.Show("Please Select a License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!license.isactive)
            {
                MessageBox.Show("License Not Active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(ctrlDetainInfo1.fees==-1)
            {
                MessageBox.Show("Please Insert a Fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsDetain detain=new clsDetain();

            detain.licenseid = license.id;
            detain.detaindate=DateTime.Now;
            detain.fees = ctrlDetainInfo1.fees;
            detain.userid = (clsGlobalcs.CurrentUser != null ? clsGlobalcs.CurrentUser.id : -1);
            if(detain.AddDetain())
            {
                MessageBox.Show("License Successfully Detained With Detain ID=" + detain.id);
                ctrlDetainInfo1.detainid=detain.id;
                ctrlDetainInfo1.FillDetain();
                ctrlDrivingLicense2.FillInfo();
                linkLabel3.Enabled = true;
            }
        }

        private void ctrlDetainInfo1_Load(object sender, EventArgs e)
        {

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
    }
}

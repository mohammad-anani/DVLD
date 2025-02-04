using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusiness;

namespace DVLD
{
    public partial class Main_Menu : Form
    {
        public clsUser user {  get; set; }

        public Main_Menu(clsUser user)
        {
            InitializeComponent();
            this.user = user;
        }


        

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form form = new ListPersons();
            form.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form frm=new ListUserscs();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Show_Details(clsGlobalcs.CurrentUser.id);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Change_Password(clsGlobalcs.CurrentUser.id);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm=new Manage_Application_Types();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm=new List_Test_Types();
            frm.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Form form=new New_Local_License(-1);
            form.ShowDialog();
        }

        private void manageApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Manage_Application form=new Manage_Application();
            form.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form form=new List_Drivers();
            form.ShowDialog();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Form form=new New_International_License_Application();
            form.ShowDialog();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Form form = new List_International_Licenses();
            form.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form form=new Renew_Driving_License();
            form.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            
        }

        private void lostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Replace_License(3);
            form.ShowDialog();
        }

        private void damagedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Replace_License(4);
            form.ShowDialog();
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form=new Detain_License();
            form.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form =new Release_Detained_License();
            form.ShowDialog();
        }
    }
}

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
    public partial class Manage_Application : Form
    {
        public Manage_Application()
        {
            InitializeComponent();
        }

        string order = "NationalNo";
        string where = "";

        void RefreshList()
        {
            dataGridView1.DataSource = clsLDLApplication.GetList(where, order);
            lbltotal.Text=dataGridView1.Rows.Count.ToString();
        }

        void FillCB()

        {
            foreach(DataRow row in clsLDLApplication.GetColumns().Rows)
            {
                comboBox1.Items.Add(row[0].ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            order = comboBox1.Text;
            RefreshList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            where=textBox1.Text;
            RefreshList();
        }

        private void Manage_Application_Load(object sender, EventArgs e)
        {
            RefreshList();
            FillCB();
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            New_Local_License form = new New_Local_License(-1);
            form.Onsave += Form_Onsave;
            form.ShowDialog();
        }

        private void Form_Onsave(object sender)
        {
            RefreshList();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure You Want To Cancel This Application?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                if (clsLDLApplication.CancelApplication(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())))
                {
                    MessageBox.Show("Application Cancelled Successfully.");
                    RefreshList();
                }
            }
        }

        private void scheduleTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Schedule_View_Test form =new Schedule_View_Test(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            clsLDLApplication ldlapplication = clsLDLApplication.Find(id);
            clsApplication application = clsApplication.Find(ldlapplication.appid);
            if(application.appstatus=="Cancelled")
            {
                scheduleTestsToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                issue.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;

                return;

            }

            if (application.appstatus=="Completed")
            {
                showLicenseToolStripMenuItem.Enabled = true;
                issue.Enabled=false;
                editApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                scheduleTestsToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
            }
            else
               {
                scheduleTestsToolStripMenuItem.Enabled = true;
                showLicenseToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = true;
                issue.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                
                    }

           switch(ldlapplication.passedtests)
            {
                case 0:
                    scheduleTestsToolStripMenuItem.Enabled = true;
                    eye.Enabled = true;
                    witten.Enabled = false;
                    street.Enabled = false;

                    break;

                case 1:
                    scheduleTestsToolStripMenuItem.Enabled = true;
                    eye.Enabled = false;
                    witten.Enabled = true;
                    street.Enabled = false;
                    break;
                case 2:
                    scheduleTestsToolStripMenuItem.Enabled = true;
                    eye.Enabled = false;
                    witten.Enabled = false;
                    street.Enabled = true;
                    break;
                case 3:
                    scheduleTestsToolStripMenuItem.Enabled = false;
         if (!clsPerson.HasLicense(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), application.personid))
                        {
                        issue.Enabled = true;
                        }
         else
                        { issue.Enabled = false; }

                    break;


            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ShowAppDetails(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.ShowDialog();
        }

        private void witten_Click(object sender, EventArgs e)
        {
            Schedule_View_Test form = new Schedule_View_Test(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.ShowDialog();
        }

        private void street_Click(object sender, EventArgs e)
        {
            Schedule_View_Test form = new Schedule_View_Test(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.ShowDialog();
        }

        private void issue_Click(object sender, EventArgs e)
        {
            IssueFirstTime form = new IssueFirstTime(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.Issue += Form_Issue;
            form.ShowDialog();
        }

        private void Form_Issue(object sender)
        {
            RefreshList();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplication application = new clsApplication();
            application = clsApplication.Find(clsLDLApplication.Find(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())).appid);
            Form form = new Show_Driving_License(application.id);
            form.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personid = clsApplication.Find(clsLDLApplication.Find(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())).appid).personid;
            Form form = new License_History(personid);
            form.ShowDialog();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure You Want To Delete?","Attention",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
             
                
                    if(clsLDLApplication.DeleteApplication(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())))
                    {
                        RefreshList();
                        MessageBox.Show("Deleted Successfully.");
                    }
                

            }
        }
    }
}

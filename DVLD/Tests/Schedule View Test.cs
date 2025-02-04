using DVLD.Properties;
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
    public partial class Schedule_View_Test : Form
    {

      public int id {  get; set; }

        clsLDLApplication app=new clsLDLApplication();
        public Schedule_View_Test(int ldlid)
        {
            InitializeComponent();
            id=ldlid;
            app = clsLDLApplication.Find(id);
            fillcard();
            FillTitle();
        }


        public delegate void OnSave(object sender);
        public event OnSave Save;

        void fillcard()
        {
           
            ctrlFullApplicationInfo1.id = id;
            ctrlFullApplicationInfo1.fillinfo();

          
        }

        void FillTitle()
        {
            switch (app.passedtests)
            {
                case 0:
                    lbltitle.Text = "View Test Appointments";
                    pbtitle.Image = Resources.eyetest;
                    break;
                case 1:
                    lbltitle.Text = "Written Test Appointments";
                    pbtitle.Image = Resources.test2;
                    break;
                case 2:
                    lbltitle.Text = "Street Test Appointments";
                    pbtitle.Image = Resources.cars1;
                    break;

            }
        }

        private void ctrlFullApplicationInfo1_Load(object sender, EventArgs e)
        {

        }

        void FillInfo()
        {
            dataGridView1.DataSource = clstestappointment.GetList(id,app.passedtests+1);
            lbltotal.Text=dataGridView1.Rows.Count.ToString();
        }
        private void Schedule_View_Test_Load(object sender, EventArgs e)
        {
            FillInfo();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ctrlFullApplicationInfo1_Load_1(object sender, EventArgs e)
        {

        }

        bool Hastests()
        {
            return dataGridView1.Rows.Count > 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(clsLDLApplication.HasPassedTest(id,app.passedtests+1))
            {
                MessageBox.Show("Applicant Passed This Test","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

                        
            if(clsLDLApplication.HasPendingTest(id,app.passedtests+1))
            {
                MessageBox.Show("Application Already Has a Pending Test","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

       
            

            Schedule_Test form = new Schedule_Test(clsLDLApplication.Find(id),app.passedtests+1,false,-1,Hastests());
            form.OnSave += Form_OnSave;
            form.ShowDialog();
        }

        private void Form_OnSave(object sender)
        {
            FillInfo();
            Save?.Invoke(this);
            fillcard();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Schedule_Test form = new Schedule_Test(clsLDLApplication.Find(id), app.passedtests+1, true, int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.OnSave += Form_OnSave1;
            form.ShowDialog();
        }

        private void Form_OnSave1(object sender)
        {
            FillInfo();
            Save?.Invoke(this);
            fillcard();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (clstestappointment.IsLocked(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()))) 
            {
                editToolStripMenuItem.Enabled = false;
                takeTestToolStripMenuItem.Enabled = false;
            }
            else
            { editToolStripMenuItem.Enabled = true; 
                takeTestToolStripMenuItem.Enabled = true; }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeTest form = new TakeTest(id, int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.Save += Form_Save;
            form.ShowDialog();
        }

        private void Form_Save(object sender)
        {
            FillInfo();
            Save?.Invoke(this);
            fillcard();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

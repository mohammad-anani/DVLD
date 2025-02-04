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
    public partial class New_Local_License : Form
    {
        clsApplication application = new clsApplication();

        int personid = -1;
        public New_Local_License(int id)
        {
            InitializeComponent();
            if(id!=-1)
            {
                
            }
        }


        bool isfound=false;
        private void ctrlFindPerson1_OnFindPerson(int obj)
        {
            personid = obj;
            isfound = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(isfound)
           { tabControl1.SelectedIndex = 1; }

        }

        void fillcombobox()
        {
            foreach (DataRow row in clsLicenseClass.GetClassList().Rows)
            {
                comboBox1.Items.Add(row[0].ToString());
            }
            comboBox1.SelectedIndex = 2;
        }


        void LoadInfo()
        {
            lbldate.Text = DateTime.Now.ToShortDateString();
            lbluser.Text = clsGlobalcs.CurrentUser.username;
            lblfees.Text = clsApplicationTypes.Find(1).fees.ToString();
        }
        private void New_Local_License_Load(object sender, EventArgs e)
        {
       fillcombobox();
            LoadInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        clsLDLApplication ldlapp = new clsLDLApplication();
        bool AddNewApp()
        {
           
            application.personid = personid;
            application.appdate = DateTime.Now;
            application.userid = clsGlobalcs.CurrentUser.id;
            application.laststatusdate = DateTime.Now;
            application.paidfees = clsApplicationTypes.Find(1).fees;
            application.apptype = clsApplicationTypes.Find(1).title;

         

            if (application.AddApplication())
            {
               
                ldlapp.appid = application.id;
                ldlapp.classname = comboBox1.Text;
                if (ldlapp.AddApplication())
                {
                    lblid.Text = ldlapp.id.ToString();
                    return true;
                }

            }
            return false;

        }

        public delegate void OnsaveEvent(object sender);
        public event OnsaveEvent Onsave;
        
        private void button2_Click(object sender, EventArgs e)
        {
            if(personid==-1)
            {
                MessageBox.Show("Person Not Selected");
                return;
            }
            if(clsPerson.HasLicense(comboBox1.Text,personid))
            {
                MessageBox.Show("Person Already Has This License","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int appid = clsPerson.HasSameApplication(comboBox1.Text, personid);
            if(appid!=-1)
            {
                MessageBox.Show("Person Has Same Application With ID=" + appid,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

           if(AddNewApp())
            {
                MessageBox.Show("LDL Application Added Successfully.New Application ID=" + ldlapp.id, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Onsave?.Invoke(this);
            }
        
        }
    }
}
